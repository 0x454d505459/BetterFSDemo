using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using FractalSpace;
using UnityEngine;

namespace BetterFSDemo
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
		private ConfigEntry<bool> testcfg;
        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
    
        private void Awake()
        {
            // Plugin startup logic
            harmony.PatchAll();
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            testcfg = Config.Bind("General", "Lot of ammos", true, "Makes you start with 999 ammos");

        }

        // [HarmonyPatch(typeof(GunController), "RefreshTaserModules")]
        // class gun_fixes {
        //     [HarmonyPostfix]
        //     static void get_modules(ref GameObject scopeModule) {
        //         scopeModule.SetActive(value: true);
        //     }

        // }
    }
}
