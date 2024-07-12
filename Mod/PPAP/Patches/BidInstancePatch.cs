using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace PPAP.Patches
{
    [HarmonyPatch(typeof(BidInstance))]
    class BidInstancePatch
    {
        public static void GetLocations(bool isPainting)
        {
            string[] locs;
            switch (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
            {
                case "Act1.1":
                    long[] id = { 6455000, 6455001, 6455002, 6455003, 6455004, 6455005, 6455006, 6455007, 6455008, 6455009 };
                    Debug.Log(APHandler.session.Locations.ScoutLocationsAsync(id));
                    break;
                //I don't know how to do "or" cases in a switch case.
                case "Act2.1":

                case "Act2.2":

                case "Act3.1":

                case "Act3.2":

                case "Act3.3":

                case "Act3.4":

                default:

                break;
            }
        }

        [HarmonyPatch(typeof(BidInstance), "PlaySequence")]
        [HarmonyPostfix]
        public static void PatchBid(BidInstance __instance/*, ref int __bidAmount*/)
        {
            //__bidAmount = 0;
            //___bidAmount = 0;
            //__instance.bidAmount
            Debug.Log("PENIS AAAAA ");
            //foreach (string item in Traverse.Create<BidInstance>().Methods())
            //{
            //    Debug.Log("PENIS AAAAA " + item);
            //}
        }
        /*static MethodInfo NewBidMethod = SymbolExtensions.GetMethodInfo(() => PatchBid());
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var found = false;
            foreach (var instruction in instructions)
            {
                if (instruction.StoresField(AccessTools.Field(typeof(BidInstance), nameof(BidInstance.bidAmount))))
                {
                    yield return new CodeInstruction(OpCodes.Call, NewBidMethod);
                    found = true;
                }
                yield return instruction;
            }
            if (found is false)
                Debug.Log("Transpiler Failed!");
        }*/
    }
}
