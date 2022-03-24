using HarmonyLib;
using FractalSpace;
using UnityEngine;
namespace BetterFSDemo
{

    [HarmonyPatch(typeof(Gun), nameof(Gun.Pickup))]
    class enableAllGunModules
    {
        static AccessTools.FieldRef<Gun, GameObject> aimStabilizerModule = AccessTools.FieldRefAccess<Gun, GameObject>("aimStabilizerModule");
        static AccessTools.FieldRef<Gun, GameObject> powerRail1Module = AccessTools.FieldRefAccess<Gun, GameObject>("powerRail1Module");
        static AccessTools.FieldRef<Gun, GameObject> powerRail2Module = AccessTools.FieldRefAccess<Gun, GameObject>("powerRail2Module");
        static AccessTools.FieldRef<Gun, GameObject> battery1 = AccessTools.FieldRefAccess<Gun, GameObject>("battery1");
        static AccessTools.FieldRef<Gun, GameObject> battery2 = AccessTools.FieldRefAccess<Gun, GameObject>("battery2");
        static AccessTools.FieldRef<Gun, GameObject> battery3 = AccessTools.FieldRefAccess<Gun, GameObject>("battery3");
        static AccessTools.FieldRef<Gun, GameObject> scopeModule = AccessTools.FieldRefAccess<Gun, GameObject>("scopeModule");
        static AccessTools.FieldRef<Gun, GameObject> hoverModule = AccessTools.FieldRefAccess<Gun, GameObject>("hoverModule");
        static void Postfix(Gun __instance)
        {
            aimStabilizerModule(__instance).SetActive(false);
            powerRail1Module(__instance).SetActive(false);
            powerRail2Module(__instance).SetActive(false);
            battery1(__instance).SetActive(true);
            battery2(__instance).SetActive(false);
            battery3(__instance).SetActive(false);
            scopeModule(__instance).SetActive(false);
            hoverModule(__instance).SetActive(false);
        }
    }
}