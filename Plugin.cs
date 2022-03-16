using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using FractalSpace;
using UnityEngine;
using System.Collections;
using UniverseLib;
using UniverseLib.Input;
using System;
using System.Text;
using System.Linq;

namespace BetterFSDemo
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);     
        public void Awake()
        {
            // Plugin startup logic
            harmony.PatchAll();
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

        }
        static bool cheats = false;

        public static void Update()
        {
            if(InputManager.GetKeyDown(KeyCode.K))
            {
                cheats = !cheats;
            }
        }

        [HarmonyPatch(typeof(Controls), nameof(Controls.ToggleDevMode))]
        class Patch
        {
            static AccessTools.FieldRef<Controls, bool> debugRef = AccessTools.FieldRefAccess<Controls, bool>("debug");
            static bool Prefix(Controls __instance)
            {

                debugRef(__instance) = !debugRef(__instance);
                return false;
            }
        }

        [HarmonyPatch(typeof(Controls), nameof(Controls.DamageCharacter), new Type[] {typeof(int)})]
        class NoDamage
        {
            static bool Prefix()
            {
                if(cheats)
                {
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(Controls), nameof(Controls.CanKillPlayer))]
        class NoKill
        {
            static bool Prefix(ref bool __result)
            {
                if(cheats)
                {
                    __result = false;
                    return false;
                }
                
                return true;
            }
        }

               
    }
}
