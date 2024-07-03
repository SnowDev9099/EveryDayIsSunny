using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace EveryDayIsSunny
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class EasyInputsMod : BaseUnityPlugin
    {
        private Harmony harmony;

        void Awake()
        {
            harmony = new Harmony(PluginInfo.GUID);
            harmony.PatchAll();
        }

        void OnDestroy()
        {
            harmony.UnpatchSelf();
        }
    }

    [HarmonyPatch(typeof(BetterDayNightManager))] 
    [HarmonyPatch("ChangeToDay")] 
    public static class GameManager_Start_Patch
    {
        static void Postfix()
        {
            ChangeToDay();
        }

        public static void ChangeToDay()
        {
            foreach (BetterDayNightManager t in GameObject.FindObjectsOfType<BetterDayNightManager>())
            {
                t.currentWeatherIndex = 3;
                t.SetTimeOfDay(4);
            }
        }
    }
}
