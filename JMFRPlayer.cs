using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using JourneyModeFullResearch.Items;
using JourneyModeFullResearch.Config;
using Terraria.GameInput;
using Terraria.Audio;

namespace JourneyModeFullResearch
{
    public class JMFRP : ModPlayer
    {
        public override void OnEnterWorld(Player player)
        {
            if (ModContent.GetInstance<JMFRConfig>().AutoResearchToggle.Equals(true))
            {
                TheResearcher.Research();
            }
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ModContent.ItemType<TheResearcher>()] = 0;
            Main.LocalPlayerCreativeTracker.ItemSacrifices.SetSacrificeCountDirectly(ContentSamples.ItemPersistentIdsByNetIds[ModContent.ItemType<TheResearcher>()], 0);
        }
    }
}
