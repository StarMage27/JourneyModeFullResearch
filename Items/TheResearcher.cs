using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;

namespace JourneyModeFullResearch.Items
{
    public class TheResearcher : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Left click to research all items" +
                "\nRight click to reset research count of all items");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.value = Item.buyPrice(999, 999, 999, 999);
            Item.rare = ItemRarityID.Master;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[this.Type] = 0;
        }

        public override bool? UseItem(Player player)
        {
            if (!player.altFunctionUse.Equals(2))
            {
                Research();
            }
            else
            {
                Unresearch();
            }
            return true;
        }

        public override bool CanUseItem(Player player) => base.CanUseItem(player);

        public override bool AltFunctionUse(Player player) => true;

        public static void Research()
        {
            foreach (var v in CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId)
                Main.LocalPlayerCreativeTracker.ItemSacrifices.SetSacrificeCountDirectly(ContentSamples.ItemPersistentIdsByNetIds[v.Key], v.Value);
            SoundEngine.PlaySound(SoundID.Research); SoundEngine.PlaySound(SoundID.ResearchComplete);
        }

        public static void Unresearch()
        {
            foreach (var v in CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId)
                Main.LocalPlayerCreativeTracker.ItemSacrifices.SetSacrificeCountDirectly(ContentSamples.ItemPersistentIdsByNetIds[v.Key], 0);
            SoundEngine.PlaySound(SoundID.Item8);
        }
    }
}