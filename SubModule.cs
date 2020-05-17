using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using HarmonyLib;

namespace AttributesReloaded
{
	public static class MyPatcher
	{
		public static void DoPatching()
		{
			var harmony = new Harmony("com.igmat.attributesreloaded");
			harmony.PatchAll();
		}
	}
	public class SubModule : MBSubModuleBase
	{
		protected override void OnSubModuleLoad()
		{
			MyPatcher.DoPatching();
		}
	}
}