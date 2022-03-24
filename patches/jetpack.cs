using HarmonyLib;
using FractalSpace;
using UnityEngine;

namespace BetterFSDemo
{

    [HarmonyPatch(typeof(Controls), nameof(Controls.ProcessJetpackMovement))]
    class jetpackInfinity
    {
        static AccessTools.FieldRef<Controls, float> currentJetpackRemainingDurationRef = AccessTools.FieldRefAccess<Controls, float>("currentJetpackRemainingDuration");
        static void Postfix(Controls __instance)
        {
            currentJetpackRemainingDurationRef(__instance) = 100f;
        }
    }
}