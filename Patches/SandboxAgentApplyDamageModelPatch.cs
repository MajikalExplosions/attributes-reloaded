using SandBox;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using HarmonyLib;

namespace AttributesReloaded
{
	[HarmonyPatch(typeof(SandboxAgentApplyDamageModel))]
	[HarmonyPatch("CalculateDamage")]
	class SandboxAgentApplyDamageModelPatch
	{
		public static int Postfix(int __result, ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon)
		{
			CharacterObject atacker = attackInformation.AttackerAgentCharacter as CharacterObject;
			CharacterObject victim = attackInformation.VictimAgentCharacter as CharacterObject;
			if (attackInformation.IsVictimAgentNull || attackInformation.IsAttackerAgentNull || !attackInformation.IsAttackerAgentHuman || !attackInformation.IsVictimAgentHuman)
			{
				return __result;
			}
			if (!collisionData.IsFallDamage && atacker != null && victim != null && !collisionData.IsAlternativeAttack)
			{
				var bonuses = new CharacterAttributeBonuses(atacker);
				var isMelee = weapon != null && !weapon.IsRangedWeapon;
				float damageMultiplier = isMelee
					? bonuses.MeleeDamageMultiplier
					: bonuses.RangeDamageMultiplier;
				var bonusDamage = (int)(__result * damageMultiplier);
                Logger.Log("Bonus " + bonusDamage + " damage from " + (isMelee ? "VIG" : "CON"), atacker);
				__result += bonusDamage;
			}
			return __result;
		}
	}
}
