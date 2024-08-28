using HarmonyLib;
using System;
using UnityEngine;

namespace PPAP.Patches
{
    [HarmonyPatch(typeof(AICustomerController))]
    class AICustomerControllerPatch
    {
        //public int percentageToLoc = 0;


        [HarmonyPatch("AICustomerController+TakePaintingState, Assembly-CSharp", "OnEnter")]
        [HarmonyPrefix]
        static void PercentageOnSale(AICustomerController __instance)
        {
            if (GameObject.Find("APHandlerObj").GetComponent<APHandler>().IsAP())
            {
                Debug.Log("START 111111111111111111111111111111111");
                Painting painting = Traverse.Create(__instance).Field<Transform>("target").Value.GetComponent<InteractablePainting>().container.GetPainting();
                Debug.Log("2222222222222222222222222222222222");
                MonoSingleton<Player>.Instance.economy.AddTransaction(-Traverse.Create(__instance).Field<Func<int>>("price").Value.Invoke(), MonoSingleton<Player>.Instance.economy.PaintingsSalesCategoryName, painting.score.name);
                Debug.Log("333333333333333333333333333333");
                //AddPercentage(Traverse.Create(__instance).Field<Func<int>>("price").Value.Invoke());
                GameObject.Find("APHandlerObj").GetComponent<APHandler>().ChangePercent(Traverse.Create(__instance).Field<Func<int>>("price").Value.Invoke());
                Debug.Log("END 0000000000000000000000000");
            }
            else
            {
                Debug.Log("Oop! Not connected to AP");
            }
        }
    }
}