using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace NPCiville.Furniture
{
    internal class YingYangLantern : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FireflyinaBottle);
            Item.createTile = ModContent.TileType<YingYangLanternAnimation>();
        }


    }
}
