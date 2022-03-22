using HarmonyLib;
using FractalSpace;
using UnityEngine;

namespace BetterFSDemo
{

    [HarmonyPatch(typeof(Controls), nameof(Controls.CanKillPlayer))]
    class NoKill
    {
        static bool Prefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }

}