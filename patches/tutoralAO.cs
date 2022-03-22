using HarmonyLib;
using FractalSpace;
using UnityEngine;

namespace BetterFSDemo
{

    [HarmonyPatch(typeof(Controls), nameof(Controls.FirstSwitchTazed))]
    class tutModeOn
    {
        static bool Prefix()
        {
            return false;
        }
    }
}