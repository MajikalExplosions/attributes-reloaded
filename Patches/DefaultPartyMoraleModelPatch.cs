using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace AttributesReloaded
{
    [HarmonyPatch(typeof(DefaultPartyMoraleModel))]
    class DefaultPartyMoraleModelPatch
    {
        private static float decreaseMoralLoss(float __result, MobileParty party)
        {
            if (party.Leader == null) return __result;
            var bonuses = new CharacterAttributeBonuses(party.Leader);
            var bonus = __result * bonuses.NegativeMoraleMultiplier;
            Logger.Log("Decrased morale loss by " + bonus + " for CON", party.Leader);
            return __result - bonus;
        }
        private static float increaseMoralGain(float __result, MobileParty party)
        {
            if (party.Leader == null) return __result;
            var bonuses = new CharacterAttributeBonuses(party.Leader);
            var bonus = __result * bonuses.PositiveMoraleMultiplier;
            Logger.Log("Increase morale gain by " + bonus + " for VIG", party.Leader);
            return __result + bonus;
        }

        [HarmonyPostfix]
        [HarmonyPatch("GetDailyNoWageMoralePenalty")]
        public static int GetDailyNoWageMoralePenalty(int __result, MobileParty party) => (int)decreaseMoralLoss(__result, party);

        [HarmonyPostfix]
        [HarmonyPatch("GetDailyStarvationMoralePenalty")]
        public static int GetDailyStarvationMoralePenalty(int __result, PartyBase party) => (int)decreaseMoralLoss(__result, party.MobileParty);

        [HarmonyPostfix]
        [HarmonyPatch("GetDefeatMoraleChange")]
        public static float GetDefeatMoraleChange(int __result, PartyBase party) => decreaseMoralLoss(__result, party.MobileParty);

        //[HarmonyPostfix]
        //[HarmonyPatch("GetEffectivePartyMorale")]
        //public static float GetEffectivePartyMorale(int __result, MobileParty mobileParty, StatExplainer explanation = null)
        //{
        //    return __result;
        //}

        //[HarmonyPostfix]
        //[HarmonyPatch("GetStandardBaseMorale")]
        //public static float GetStandardBaseMorale(float __result, PartyBase party)
        //{
        //    return __result;
        //}

        [HarmonyPostfix]
        [HarmonyPatch("GetVictoryMoraleChange")]
        public static float GetVictoryMoraleChange(float __result, PartyBase party) => increaseMoralGain(__result, party.MobileParty);
    }
}
