using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AttributesReloaded
{
    [HarmonyPatch(typeof(CharacterObject))]
    class CharacterObjectPatch
    {
        [HarmonyPatch("GetAttributeValue")]
        [HarmonyPostfix]
        public static int GetAttributeValue(int __result, CharacterObject __instance, CharacterAttributesEnum charAttribute)
        {
            var attribute = __result;
            // if following is true, then this attribute is already set by developers/other mods
            if (attribute >= 2) return attribute;
            // we use maximum skill level to determine how big attribute should be
            var maxSkill = CharacterAttributes.GetCharacterAttribute(charAttribute).Skills.Select(skill => __instance.GetSkillValue(skill)).Max();
            // 0 - is minimal for any skill and we consider this amount as 2 for repsective attribute
            // 240 is a soft cap for skill leveling in Mount & Blade, so we consider this amount as 10 for  repsective attribute
            // between them we assume linear growth of attributes
            attribute = 2 + maxSkill / (240 / (10 - 2));

            return (attribute < 10)
                ? attribute
                : 10;
        }

        [HarmonyPatch("MaxHitPoints")]
        [HarmonyPostfix]
        public static int MaxHitPoints(int __result, CharacterObject __instance)
        {
            var bonuses = new CharacterAttributeBonuses(__instance);
            var bonusHP = (int)(__result * bonuses.HPMultiplier);
            if (__instance.IsPlayerCharacter && Config.Instance.enable_messages)
            {
                InformationManager.DisplayMessage(new InformationMessage("Bonus " + bonusHP + " HP from END", Colors.Red));
            }

            return __result + bonusHP;
        }

        [HarmonyPatch("MaxHitpointsExplanation", MethodType.Getter)]
        [HarmonyPostfix]
        public static StatExplainer MaxHitpointsExplanation(StatExplainer __result, CharacterObject __instance)
        {
            var bonuses = new CharacterAttributeBonuses(__instance);
            var bonusHP = (int)(__instance.MaxHitPoints() * bonuses.HPMultiplier / (1 + bonuses.HPMultiplier));
            __result.AddLine("Endurance modifier", bonusHP);
            return __result;
        }
    }
}
