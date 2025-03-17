using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NPCiville.Furniture;




namespace NPCiville.NPCs
{
    [AutoloadHead]
    public class FurnitureGuy : ModNPC
    {


        public const string ShopName = "Shop";


        public override void SetStaticDefaults()
        {
            

        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.defense = 40;
            NPC.lifeMax = 400;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.9f;
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 450;
            NPCID.Sets.AttackType[NPC.type] = 2;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 3;
            AnimationType = 22;




        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                if (player.active)
                {
                    return true;
                }
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
              "Jason",
              "Pieter",
              "Dricus"
              

            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";


        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {

                shop = ShopName;

            }
        }



        public override void AddShops()
        {

            var npcShop = new NPCShop(Type, ShopName);


            npcShop.Add(new Item(ModContent.ItemType<YingYangLantern>()) { shopCustomPrice = Item.buyPrice(silver: 25) });

            npcShop.Add(new Item(ModContent.ItemType<LavaLamp>()) { shopCustomPrice = Item.buyPrice(silver: 25) });

            npcShop.Add(new Item(ModContent.ItemType<RainLamp>()) { shopCustomPrice = Item.buyPrice(silver: 25) });

            // 1 = 1 copper coin, 100 = 1 silver coin, 10000 = 1 gold coin, and 1000000 = 1 platinum coin.     


            npcShop.Register();
        }


        public override string GetChat()
        {
            NPC.FindFirstNPC(ModContent.NPCType<FurnitureGuy>());
            switch (Main.rand.Next(3))
            {
                case 1:
                    return "Dzień dobry!";
                case 2:
                    return "Nazywam się?";
                case 3:
                    return "Dziękuję?";
                default:
                    return "Dzień dobry";
            }

        }




        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 2;
            randExtraCooldown = 9;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.BoneArrow;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
        }

        public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.GoldCoin, 1, false, 0, false, false);
        }


    }

}
