using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using HarmonyLib;

namespace AttributesReloaded
{
    [HarmonyPatch(typeof(DefaultClanFinanceModel))]
    class DefaultClanFinanceModelPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("CalculateClanIncome")]
        public static void CalculateClanIncome(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals = false)
        {
            var bonuses = new CharacterAttributeBonuses(clan.Leader.CharacterObject);
            goldChange.AddFactor(bonuses.IncomeMultiplier, new TextObject("Additional income for INT"));
        }
        [HarmonyPostfix]
        [HarmonyPatch("CalculateClanExpenses")]
        public static void CalculateClanExpenses(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals = false)
        {
            var bonuses = new CharacterAttributeBonuses(clan.Leader.CharacterObject);
            goldChange.AddFactor(bonuses.ExpensesMultiplier, new TextObject("Decreasing expenses for INT"));
        }
    }
}
