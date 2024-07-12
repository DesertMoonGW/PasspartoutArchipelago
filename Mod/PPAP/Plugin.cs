using BepInEx;
using HarmonyLib;

namespace PPAP
{
    [BepInPlugin("com.desertmoongw.archipelago.passpartout", "Passpartout Archipelago", "0.1.0")]
    [BepInProcess("Passpartout.exe")]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("com.desertmoongw.archipelago.passpartout");

        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo("Plugin Passpartout Archipelago is loaded!");

            harmony.PatchAll();
        }
    }
}

