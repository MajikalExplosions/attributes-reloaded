using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation.Persuasion;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AttributesReloaded
{
	[HarmonyPatch(typeof(DefaultPersuasionModel))]
	[HarmonyPatch("GetChances")]
	class DefaultPersuasionModelPatch
	{
		public static void Postfix(PersuasionOptionArgs optionArgs, ref float successChance, ref float critSuccessChance, ref float critFailChance, ref float failChance, float difficultyMultiplier)
		{
			var bonuses = new CharacterAttributeBonuses(Hero.MainHero.CharacterObject);
			float attrBonus = bonuses.PersuadeAddition;
			if (Config.Instance.enable_messages)
			{
				InformationManager.DisplayMessage(new InformationMessage(("Bonus " + attrBonus + "% persuation chance from SOC"), Colors.Red));
			}
			successChance += attrBonus;
			if (successChance > 1)
			{
				attrBonus -= successChance - 1;
				successChance = 1;
			}
			critSuccessChance = 0;
			if (optionArgs.GivesCriticalSuccess)
			{
				critSuccessChance = successChance;
				successChance = 0;
			}
			critFailChance = (critFailChance > attrBonus / 2)
				? critFailChance - (attrBonus / 2)
				: 0;
			failChance = 1 - critSuccessChance - successChance - critFailChance;
		}
	}
}
