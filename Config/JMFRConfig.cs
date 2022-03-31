using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace JourneyModeFullResearch.Config
{
	public class JMFRConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		//[Header("$Mods.ExampleMod.Config.ItemHeader")]
		//[Label("$Mods.ExampleMod.Config.AutoResearchToggle.Label")]
		//[Tooltip("$Mods.ExampleMod.Config.AutoResearchToggle.Tooltip")]

		[Header("JMFR config")]
		[Label("Auto research")]
		[Tooltip("Automatically research all items on entering world")]
		[DefaultValue(false)]
		//[ReloadRequired]

		public bool AutoResearchToggle;
	}
}