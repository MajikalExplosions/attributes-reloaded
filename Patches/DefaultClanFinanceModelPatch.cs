using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using HarmonyLib;
using System.Linq;

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
            goldChange.AddFactor(bonuses.IncomeMultiplier, new TextObject("Additional income for Leader's INT"));

            if (Config.Instance.bonus_finance_from_all_heroes)
            {
                var companionBonus = clan.Companions
                    .Select(companion =>
                        new CharacterAttributeBonuses(companion.CharacterObject).IncomeMultiplier)
                    .Sum();
                goldChange.AddFactor(companionBonus, new TextObject("Additional income for Companions' INT"));
            }
        }
        [HarmonyPostfix]
        [HarmonyPatch("CalculateClanExpenses")]
        public static void CalculateClanExpenses(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals = false)
        {
            var bonuses = new CharacterAttributeBonuses(clan.Leader.CharacterObject);
            goldChange.AddFactor(bonuses.ExpensesMultiplier, new TextObject("Decreasing expenses for Leader's INT"));

            if (Config.Instance.bonus_finance_from_all_heroes)
            {
                var maxDecreas = Config.Instance.max_bonus_decreas;
                var companionBonus = clan.Companions
                    .Select(companion =>
                        new CharacterAttributeBonuses(companion.CharacterObject).ExpensesMultiplier)
                    .Sum();
                companionBonus = companionBonus < maxDecreas
                    ? companionBonus
                    : maxDecreas;
                goldChange.AddFactor(companionBonus, new TextObject("Decreasing expenses for Companions' INT"));
            }
        }
    }
}
