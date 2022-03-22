using HarmonyLib;
using FractalSpace;
using UnityEngine;
using System.Collections;
using System;

namespace BetterFSDemo
{
    [HarmonyPatch(typeof(Controls), nameof(Controls.DamageCharacter), new Type[] {typeof(int)})]
    class NoDamage
    {
        static bool Prefix()
        {
            return false;
        }
    }
}