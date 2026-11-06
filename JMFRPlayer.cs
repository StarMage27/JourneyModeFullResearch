using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using JourneyModeFullResearch.Items;
using JourneyModeFullResearch.Config;

namespace JourneyModeFullResearch
{
    public class JMFRP : ModPlayer
    {
        public override void OnEnterWorld()
        {
            if (ModContent.GetInstance<JMFRConfig>().AutoResearchToggle.Equals(true))
            {
                TheResearcher.Research();
            }

            int theResearcherID = ModContent.ItemType<TheResearcher>();

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[theResearcherID] = 0;
            Main.LocalPlayerCreativeTracker.ItemSacrifices.SetSacrificeCountDirectly(ContentSamples.ItemPersistentIdsByNetIds[theResearcherID], 0);
        }
    }
}
