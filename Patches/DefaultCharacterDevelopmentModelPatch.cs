
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using HarmonyLib;
using TaleWorlds.Library;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace AttributesReloaded
{
	[HarmonyPatch(typeof(DefaultCharacterDevelopmentModel))]
	[HarmonyPatch("CalculateLearningRate", typeof(Hero), typeof(SkillObject), typeof(StatExplainer))]
	public class DefaultCharacterDevelopmentModelPatch
	{
		public static float Postfix(float __result, Hero hero, SkillObject skill, StatExplainer explainer = null)
		{
			var bonuses = new CharacterAttributeBonuses(hero.CharacterObject);
			var bonus = __result * bonuses.XPMultiplier;
            if (explainer != null)
            {
                explainer.AddLine("INT bonus", bonus); // TODO: Why this stuff doesn't work?
            }
			if (hero.CharacterObject.IsPlayerCharacter && Config.Instance.enable_messages)
			{
				InformationManager.DisplayMessage(new InformationMessage("Bonus " + bonus.ToString("P") + " XP from INT", Colors.Red));
			}
			return __result + bonus;
		}
	}
}
