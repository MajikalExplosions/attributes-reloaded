using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Core;
using HarmonyLib;
using TaleWorlds.Library;

namespace AttributesReloaded
{
	[HarmonyPatch(typeof(DefaultPartySizeLimitModel))]
	[HarmonyPatch("GetPartyMemberSizeLimit")]
	class DefaultPartySizeLimitModelPatch
	{
		public static int Postfix(int __result, PartyBase party, StatExplainer explanation = null)
		{
			int bonus = 0;
			var showMessages = party.LeaderHero == Hero.MainHero && Config.Instance.enable_messages;
			if (party.LeaderHero == null) return __result;
			// if we take all party members into account to calculate bonus, then we don't need to take leader additionally
			if (!Config.Instance.party_size_from_all_heroes)
			{
				var leaderBonuses = new CharacterAttributeBonuses(party.LeaderHero.CharacterObject);
				bonus += (int)(__result * leaderBonuses.PartySizeMultiplier);
				if (showMessages)
				{
					InformationManager.DisplayMessage(new InformationMessage("Bonus " + bonus + " party size limit from SOC", Colors.Red));
				}
			}
			else
			{
				foreach (var troop in party.MemberRoster.Troops)
				{
					if (troop.HeroObject != null)
					{
						var companionBonuses = new CharacterAttributeBonuses(troop);
						var companionBonus = (int)(__result * companionBonuses.PartySizeMultiplier); ;
						bonus += companionBonus;
						if (showMessages)
						{
							InformationManager.DisplayMessage(new InformationMessage("Bonus " + companionBonus + " party size limit from " + troop.Name + "'s SOC", Colors.Red));
						}
					}
				}
			}
			return __result + bonus;
		}
		
	}
}
