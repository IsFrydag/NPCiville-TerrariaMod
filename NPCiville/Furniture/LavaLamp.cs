using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace NPCiville.Furniture
{
    internal class LavaLamp : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FireflyinaBottle);
            Item.createTile = ModContent.TileType<LavaLampAnimation>();
        }


    }
}
