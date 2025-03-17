using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;


namespace NPCiville.Furniture
{
    internal class RainLampAnimation : ModTile
    {

        public override void SetStaticDefaults()
        {

            Main.tileLighted[Type] = true;

            Main.tileFrameImportant[Type] = true;

            Main.tileLavaDeath[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);

            TileObjectData.addTile(Type);


            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(238, 145, 105), name);


        }

        private readonly int animationFrameWidth = 18;


        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 2f;
            g = 0.8f;
            b = 0.5f;
        }


        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {

            if (i % 2 == 1)
                spriteEffects = SpriteEffects.FlipHorizontally;
        }

        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
        {

            int uniqueAnimationFrame = Main.tileFrame[Type] + i;
            if (i % 2 == 0)
                uniqueAnimationFrame += 3;
            if (i % 3 == 0)
                uniqueAnimationFrame += 3;
            if (i % 4 == 0)
                uniqueAnimationFrame += 3;
            uniqueAnimationFrame %= 6;


            frameXOffset = uniqueAnimationFrame * animationFrameWidth;
        }


        public override bool KillSound(int i, int j, bool fail)
        {

            if (!fail)
            {
                SoundEngine.PlaySound(SoundID.Shatter, new Vector2(i, j).ToWorldCoordinates());
                return false;
            }
            return base.KillSound(i, j, fail);
        }



        public override void AnimateTile(ref int frame, ref int frameCounter)
        {

            frame = Main.tileFrame[TileID.FireflyinaBottle];
        }
    }


}