using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PPAP.Patches
{
    [HarmonyPatch(typeof(BidInstance))]
    public static class BidInstancePatch
    {
   //     public static void GetLocations(bool isPainting)
   //     {
   //         string[] locs;
   //         switch (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
   //         {
   //             case "Act1.1":
   //                 long[] id = { 6455000, 6455001, 6455002, 6455003, 6455004, 6455005, 6455006, 6455007, 6455008, 6455009 };
   //                 Debug.Log(APHandler.session.Locations.ScoutLocationsAsync(id));
   //                 break;
   //             //I don't know how to do "or" cases in a switch case.
   //             case "Act2.1":

   //             case "Act2.2":

   //             case "Act3.1":

   //             case "Act3.2":

   //             case "Act3.3":

   //             case "Act3.4":

   //             default:

   //             break;
   //         }
   //     }

   //     [HarmonyPatch(typeof(BidInstance), "PlaySequence")]
   //     [HarmonyPrefix]
   //     public static bool DisableOldBid(BidInstance __instance)
   //     {
   //         return false;
   //     }
   //     [HarmonyPatch(typeof(BidInstance), "PlaySequence")]
   //     [HarmonyPostfix]
   //     public static IEnumerator PatchBid(IEnumerator __result, BidInstance __instance)
   //     {
   //         float startTime = Time.time;
			//Traverse.Create(__instance).Field<UISoundScript>("soundSystem").Value = GameObject.Find("Canvas(Clone)").GetComponent<UISoundScript>();
			//Traverse.Create(__instance).Field<UISoundScript>("soundSystem").Value.bidBubbles.AddLast(__instance);
			//Traverse.Create(__instance).Field<bool>("interrupted").Value = false;
			//Traverse.Create(__instance).Field<int>("bidAmount").Value = 0;
			//Traverse.Create(__instance).Field<Text>("bid").Value.text = "AP Check";
			//Debug.Log("GAY LORD GAY LORD GAY LORD" + Traverse.Create(__instance).Field<Text>("bid").Value.text);
			//Traverse.Create(__instance).Field<Button>("acceptButton").Value.onClick.AddListener(delegate()
   //         {
   //             Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAA ");
   //             Traverse.Create(__instance).Field<bool>("accepted").Value = true;
   //             Traverse.Create(__instance).Field<bool>("interrupted").Value = true;
   //             Analytics.CustomEvent("bidInteractions", new Dictionary<string, object>
   //             {
   //                 {
   //                     "bid",
   //                     "accepted"
   //                 }
   //             });
   //             Debug.Log("BBBBBBBBBBBBBBBBBBBBBBBBBBB ");
   //         });
   //         Debug.Log("CCCCCCCCCCCCCCCCCCCCCC ");
   //         //this.haggleButton.onClick.AddListener(delegate()
   //         //{
   //         //	if (Random.Range(0f, 1f) < this.initalSuccessRate)
   //         //	{
   //         //		this.initalSuccessRate *= this.successFalloffFactor;
   //         //		this.bidAmount = (int)((float)this.bidAmount * Random.Range(1.01f, 1.2f)) + 1;
   //         //		this.bid.text = string.Format(this.formatString, this.bidAmount);
   //         //		this.OnHaggleSuccess.Invoke();
   //         //		base.GetComponent<Animator>().SetTrigger("Bid_Raised");
   //         //		return;
   //         //	}
   //         //	int nHaggles = this.nHaggles;
   //         //	this.nHaggles = nHaggles + 1;
   //         //	this.bidAmount = (int)((float)this.bidAmount * Random.Range(0.7f, 1f));
   //         //	this.bid.text = string.Format(this.formatString, this.bidAmount);
   //         //	this.OnHaggleFail.Invoke();
   //         //	base.GetComponent<Animator>().SetTrigger("Bid_Lowered");
   //         //	if (this.nHaggles >= 2)
   //         //	{
   //         //		this.haggleButton.interactable = false;
   //         //	}
   //         //});

   //         //this.denyButton.onClick.AddListener(delegate()
   //         //{
   //         //	this.accepted = false;
   //         //	this.interrupted = true;
   //         //	Analytics.CustomEvent("bidInteractions", new Dictionary<string, object>
   //         //	{
   //         //		{
   //         //			"bid",
   //         //			"denied"
   //         //		}
   //         //	});
   //         //});

   //         EventTrigger.TriggerEvent triggerEvent = new EventTrigger.TriggerEvent();
   //         Debug.Log("DDDDDDDDDDDDDDDDDDDDDD ");
   //         triggerEvent.AddListener(delegate(BaseEventData d)
   //         {
   //         	Debug.Log("ET");
   //             Debug.Log(Traverse.Create(__instance).GetType().BaseType.GetField("IsBeingHeld"));
   //             typeof(NotificationInstance).GetProperty("IsBeingHeld").GetSetMethod(true);
   //             //Traverse.Create(__instance).GetType().BaseType.GetField("IsBeingHeld").SetValue(__instance,true);
   //             Debug.Log("ET2");
   //             //base.IsBeingHeld = true;
   //         });
   //         //EventTrigger.TriggerEvent triggerEvent2 = new EventTrigger.TriggerEvent();
   //         //triggerEvent2.AddListener(delegate (BaseEventData d)
   //         //{
   //         //    Debug.Log("LV");
   //         //    base.IsBeingHeld = false;
   //         //});
   //         EventTrigger.TriggerEvent triggerEvent2 = new EventTrigger.TriggerEvent();
   //         Debug.Log("EEEEEEEEEEEEEEEEEEEEEEEEEEE ");
   //         triggerEvent2.AddListener(delegate (BaseEventData d)
   //         {
   //             Debug.Log("LV");
   //             Debug.Log((__instance as NotificationInstance).IsBeingHeld);
   //             //(__instance as NotificationInstance).IsBeingHeld
   //             typeof(NotificationInstance).GetProperty("IsBeingHeld").GetSetMethod(true);
                
   //             Debug.Log("LV2");
   //             //base.IsBeingHeld = true;
   //         });
   //         Debug.Log("FFFFFFFFFFFFFFFFFFFFFFFFFFFF ");
   //         EventTrigger eventTrigger = Traverse.Create(__instance).Field<RectTransform>("popupBubble").Value.gameObject.AddComponent<EventTrigger>();
   //         Debug.Log("GGGGGGGGGGGGGGGGGGGGGGGGG ");
   //         eventTrigger.triggers.Add(new EventTrigger.Entry
   //         {
   //             eventID = EventTriggerType.PointerEnter,
   //         	callback = triggerEvent
   //         });
   //         Debug.Log("HHHHHHHHHHHHHHHHHHHHHHHHHHHH ");
   //         eventTrigger.triggers.Add(new EventTrigger.Entry
   //         {
   //         	eventID = EventTriggerType.PointerExit,
   //         	callback = triggerEvent2
   //         });
   //         Debug.Log("IIIIIIIIIIIIIIIIIIIIII ");
   //         while (!Traverse.Create(__instance).Field<bool>("interrupted").Value && Time.time - startTime < Traverse.Create(__instance).Field<float>("duration").Value)
   //         {
   //             Debug.Log("JJJJJJJJJJJJJJJJ ");
   //             //float num = Traverse.Create(__instance).Field<NotificationInstance>("popupCurve").Value.ev
   //             //.Evaluate(Mathf.Clamp01((Time.time - startTime) / this.popupTime) * (1f - Mathf.Clamp01((Time.time - startTime - this.duration + this.popupTime) / this.popupTime)));
   //             Traverse.Create(__instance).Field<ProgressBar>("progressBar").Value.delta = 1f - (Time.time - startTime) / (Traverse.Create(__instance).Field<float>("duration").Value - Traverse.Create(__instance).Field<float>("popupTime").Value * 2f);

   //             Debug.Log("KKKKKKKKKKKKKKKKKKKK ");
   //             //Traverse.Create(__instance).Field<NotificationInstance>("popupBubble").Value.gameObject.transform.localScale = new Vector3(num, num, 1f);
   //             Traverse.Create(__instance).Field<RectTransform>("popupBubble").Value.GetComponent<RectTransform>().anchoredPosition = new Vector2(Traverse.Create(__instance).Field<RectTransform>("popupBubble").Value.GetComponent<RectTransform>().anchoredPosition.x, Mathf.Lerp(Traverse.Create(__instance).Field<RectTransform>("popupBubble").Value.GetComponent<RectTransform>().anchoredPosition.y, Traverse.Create(__instance).Field<float>("feedDisplayTargetY").Value, (Mathf.Abs(Traverse.Create(__instance).Field<float>("feedDisplayTargetY").Value - Traverse.Create(__instance).Field<RectTransform>("popupBubble").Value.GetComponent<RectTransform>().anchoredPosition.y) * 0.03f + 5f) * Time.deltaTime));

   //             Debug.Log("LLLLLLLLLLLLLLLLLLLLLLLLLLL ");
   //             yield return null;
   //         }
   //         Debug.Log("MMMMMMMMMMMMM ");
   //         //this.onFinish(this);
   //         Traverse.Create(__instance).Field<BidInstance.OnFinish>("onFinish").Value.DynamicInvoke(__instance);
   //         Debug.Log("?????????????? ");
   //         if (Traverse.Create(__instance).Field<bool>("interrupted").Value)
   //         {
   //             //////////////////////base.StartCoroutine(this.InterruptFadeout());

   //             Debug.Log("NNNNNNNNNNNNNNNN ");
   //             //typeof(NotificationInstance).GetProperty("IsBeingHeld").GetSetMethod(true);
   //             //Traverse.Create(__instance).GetType().BaseType.GetMethod("StartCoroutine");
   //             //Traverse.Create(__instance).GetType().BaseType.GetMethod("StartCoroutine", Coroutine).method;
   //             Debug.Log("OOOOOOOOOOOOOO ");



   //             //Traverse.Create(__instance).Method("InterruptFadeout");
   //             Debug.Log("PPPPPPPPPPPPPPPPPPPPPPPPPPPP ");
   //         }
   //         else
   //         {
   //             Debug.Log("QQQQQQQQQQQQQQQQQQQQQQQQ ");
   //             Analytics.CustomEvent("bidInteractions", new Dictionary<string, object>
   //             {
   //                 {
   //                     "bid",
   //                     "missed"
   //                 }
   //             });
   //             Debug.Log("RRRRRRRRRRRRRRRRRRRRRRRRR ");
   //             Traverse.Create(__instance).GetType().BaseType.GetMethod("SendMessageUpward");
   //             //base.SendMessageUpwards("OnBubbleLifeTimeEnd", Traverse.Create(__instance));
   //             Debug.Log("SSSSSSSSSSSSSSSSSSSSSSSSS ");
   //         }
   //         //return PatchBid();
   //         Debug.Log("TTTTTTTTTTTTTTTTTTTTTTTTT ");
   //         yield break;
   //     }

   //     /*static MethodInfo NewBidMethod = SymbolExtensions.GetMethodInfo(() => PatchBid());
   //     [HarmonyTranspiler]
   //     static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
   //     {
   //         var found = false;
   //         foreach (var instruction in instructions)
   //         {
   //             if (instruction.StoresField(AccessTools.Field(typeof(BidInstance), nameof(BidInstance.PlaySequence))))
   //             {
   //                 yield return new CodeInstruction(OpCodes.Call, NewBidMethod);
   //                 found = true;
   //             }
   //             yield return instruction;
   //         }
   //         if (found is false)
   //             Debug.Log("Transpiler Failed!");
   //     }*/
    }
}
