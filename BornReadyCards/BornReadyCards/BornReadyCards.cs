using BepInEx;
using UnboundLib.Cards;
using BornReadyCards.Cards;
using HarmonyLib;

namespace BornReadyCards
{
    [BepInPlugin(ModId, ModName, Version)]
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInProcess("Rounds.exe")]
    public class BornReadyCards : BaseUnityPlugin
    {
        private const string ModId = "com.popodil.rounds.BornReadyCards";
        private const string ModName = "BornReadyCards";
        public const string Version = "0.0.1";
        public const string ModInitials = "BRC";

        public static BornReadyCards instance { get; private set; }

        void Awake()
        {
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }

        void Start()
        {
            instance = this;
            CustomCard.BuildCard<CrazyBurst>();
            CustomCard.BuildCard<CrazyDamage>();
            CustomCard.BuildCard<Flight>();
            CustomCard.BuildCard<LMG>();
            CustomCard.BuildCard<Uzi>();
            CustomCard.BuildCard<Drunk>();
        }
    }
}
