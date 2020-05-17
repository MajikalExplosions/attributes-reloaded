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
			if (agent.IsHuman && agent.IsHero)
			{
				var characterObject = CharacterObject.Find(agent.Character.StringId);
				var heroBonuses = new CharacterAttributeBonuses(characterObject);
				float bonusHP = agent.HealthLimit * heroBonuses.HPMultiplier;
				if (characterObject.HeroObject == Hero.MainHero && Config.Instance.enable_messages)
				{
					InformationManager.DisplayMessage(new InformationMessage("Bonus " + bonusHP + " HP from END", Colors.Red));
					InformationManager.DisplayMessage(new InformationMessage("Bonus " + (100 * heroBonuses.MoveSpeedMultiplier) + "% movement speed from END", Colors.Red));
				}

				var helthRatio = agent.Health / agent.HealthLimit;
				agent.HealthLimit += bonusHP;
				agent.Health += bonusHP * helthRatio;

				agentDrivenProperties.CombatMaxSpeedMultiplier *= heroBonuses.MoveSpeedMultiplier + 1;
			}
			// DefaultCharacterStatsModel;
		}

		[HarmonyPostfix]
		[HarmonyPatch("UpdateAgentStats")]
		public static void UpdateAgentStats(Agent agent, AgentDrivenProperties agentDrivenProperties)
		{
			if (agent.IsHuman && agent.IsHero)
			{
				var characterObject = CharacterObject.Find(agent.Character.StringId);
				var heroBonuses = new CharacterAttributeBonuses(characterObject);
				WeaponComponentData weapon;
				var isRanged = agent.WieldedWeapon.IsAnyRanged(out weapon);
				float speedMultiplier = isRanged
					? heroBonuses.RangeSpeedMultiplier
					: heroBonuses.MeleeSpeedMultiplier;
				if (characterObject.HeroObject == Hero.MainHero && Config.Instance.enable_messages)
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
