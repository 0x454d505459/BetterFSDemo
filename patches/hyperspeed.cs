using System;
using HarmonyLib;
using UnityEngine;

namespace BetterFSDemo
{
    [HarmonyPatch(typeof(TimeManipulator), nameof(TimeManipulator.IsCurrentlyActive))]
    class HyperSpeedFix
    {
        static AccessTools.FieldRef<TimeManipulator, float> healthconsRef = AccessTools.FieldRefAccess<TimeManipulator, float>("healthConsumption");
        static bool Prefix(TimeManipulator __instance, ref bool ___m_isActive)
        {
            healthconsRef(__instance) = 0.0f;
            return ___m_isActive;

        }
    }
}
