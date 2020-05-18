using SandBox;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using HarmonyLib;
using System;

namespace AttributesReloaded
{
	[HarmonyPatch(typeof(SandboxAgentStatCalculateModel))]
	class SandboxAgentStatCalculateModelPatch
	{
		[HarmonyPostfix]
		[HarmonyPatch("InitializeAgentStats")]
		public static void InitializeAgentStats(Agent agent, Equipment spawnEquipment, AgentDrivenProperties agentDrivenProperties, AgentBuildData agentBuildData)
		{
			if (agent.IsHuman)
			{
				var characterObject = CharacterObject.Find(agent.Character.StringId);
				var characterBonuses = new CharacterAttributeBonuses(characterObject);
				if (characterObject.IsPlayerCharacter && Config.Instance.enable_messages)
				{
					InformationManager.DisplayMessage(new InformationMessage("Bonus " + characterBonuses.MoveSpeedMultiplier.ToString("P") + " movement speed from END", Colors.Red));
				}

               agentDrivenProperties.CombatMaxSpeedMultiplier *= characterBonuses.MoveSpeedMultiplier + 1;
			}
		}

        [HarmonyPostfix]
		[HarmonyPatch("UpdateAgentStats")]
		public static void UpdateAgentStats(Agent agent, AgentDrivenProperties agentDrivenProperties)
		{
			if (agent.IsHuman)
			{
				var characterObject = CharacterObject.Find(agent.Character.StringId);
				var characterBonuses = new CharacterAttributeBonuses(characterObject);
				WeaponComponentData weapon;
				var isRanged = agent.WieldedWeapon.IsAnyRanged(out weapon);
				float speedMultiplier = isRanged
					? characterBonuses.RangeSpeedMultiplier
					: characterBonuses.MeleeSpeedMultiplier;
				if (characterObject.IsPlayerCharacter && Config.Instance.enable_messages)
				{
					InformationManager.DisplayMessage(new InformationMessage("Bonus " + (100 * speedMultiplier) + "% Attack Speed from " + (isRanged ? "CON" : "VIG"), Colors.Red));
				}
				agentDrivenProperties.ThrustOrRangedReadySpeedMultiplier *= (1 + speedMultiplier);
				agentDrivenProperties.ReloadSpeed *= (1 + speedMultiplier);
				agentDrivenProperties.SwingSpeedMultiplier *= (1 + speedMultiplier);
			}
		}
	}
}
