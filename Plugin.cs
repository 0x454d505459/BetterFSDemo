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
        private ConfigEntry<bool> testcfg;  
        public void Awake()
        {
            // Plugin startup logic
            harmony.PatchAll();
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            testcfg = Config.Bind("General", "Lot of ammos", true, "Makes you start with 999 ammos");
        }

               
    }
}
