using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace BornReadyCards.Cards
{
    class CrazyBurst : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            UnityEngine.Debug.Log($"[{BornReadyCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            gunAmmo.maxAmmo += 1;
            gun.bursts = gunAmmo.maxAmmo;
            gun.spread = 0.5f;
            gun.numberOfProjectiles = gunAmmo.maxAmmo * 5;
            gun.damage /= gunAmmo.maxAmmo;

            foreach (CardInfo card in player.data.currentCards)
            {
                if (card.cardName == "Crazy Damage")
                {
                    gun.damage *= 100f;
                    gunAmmo.maxAmmo = 1;
                    gunAmmo.ammoReg = 1;
                }
            }
            UnityEngine.Debug.Log($"[{BornReadyCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Debug.Log($"[{BornReadyCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }
        protected override string GetTitle()
        {
            return "Crazy Burst";
        }
        protected override string GetDescription()
        {
            return "More max ammo means more projectiles, but less damage. Unless...";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Burst",
                    amount = "No",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Projectiles",
                    amount = "+20",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return BornReadyCards.ModInitials;
        }
    }
}



