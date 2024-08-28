using HarmonyLib;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;

namespace PPAP.Patches
{
    [HarmonyPatch(typeof(MainMenuUI))]
    class MainMenuUIPatch : MonoBehaviour
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void ChangeMenu()
        {
            if (!GameObject.Find("APHandlerObj"))
            {
                Debug.Log("No APHandlerObj found, creating one...");
                GameObject APHO = new GameObject("APHandlerObj");
                APHO.AddComponent<APHandler>();
                DontDestroyOnLoad(APHO);
                GameObject APHandlerObj = GameObject.Instantiate<GameObject>(APHO);
            }
            else
            {
                Debug.Log("APHandlerObj found, no need to make a new one!");
            }

            APConnectMenu();
        }

        static void APConnectMenu()
        {
            Debug.Log("Creating AP Connect Menu.");
            GameObject ContButtonText = GameObject.Find("ContinueButton").transform.GetChild(0).gameObject;
            GameObject APButtonBase = new GameObject("APButton", typeof(UnityEngine.UI.Button), typeof(RectTransform), typeof(CanvasRenderer));
            GameObject APButton = GameObject.Instantiate<GameObject>(APButtonBase, GameObject.Find("ButtonsGameObject").transform);
            GameObject APButtonText = GameObject.Instantiate<GameObject>(ContButtonText, APButton.transform);
            APButton.transform.localPosition = new Vector3(APButton.transform.localPosition.x, 180.49f, APButton.transform.localPosition.z);
            APButtonText.GetComponent<Text>().text = "Archipelago";
            APButtonText.GetComponent<Text>().horizontalOverflow = HorizontalWrapMode.Overflow;
            APButton.GetComponent<UnityEngine.UI.Button>().targetGraphic = APButtonText.GetComponent<Text>();




            GameObject APmenu = GameObject.Instantiate(GameObject.Find("Confirm Restart"), GameObject.Find("MainMenu UI").transform);
            APmenu.name = "APMenu";

            APButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { APmenu.SetActive(true); });

            GameObject THEBOX = APmenu.transform.Find("Box").gameObject;
            THEBOX.transform.localScale = new Vector3(1, 1.5f, 1);
            foreach (Transform item in THEBOX.GetComponentInChildren<Transform>())
            {
                if (item.gameObject.name == "Image")
                {
                    item.localScale = new Vector3(0.29f, 0.29f, 0.29f);
                }
                else
                {
                    item.localScale = new Vector3(1, 0.65f, 1);
                }
            }

            THEBOX.transform.localPosition = new Vector3(THEBOX.transform.localPosition.x, THEBOX.transform.localPosition.y + 100, THEBOX.transform.localPosition.z);

            THEBOX.transform.Find("Title").GetComponent<Text>().text = "Archipelago Connect";
            THEBOX.transform.Find("Title").transform.localPosition = new Vector3(THEBOX.transform.Find("Title").transform.position.x + 100, THEBOX.transform.Find("Title").transform.position.y - 30, THEBOX.transform.Find("Title").transform.position.z);

            THEBOX.transform.Find("Text").GetComponent<Text>().text = "Address";
            THEBOX.transform.Find("Text").transform.localPosition = new Vector3(THEBOX.transform.Find("Text").transform.position.x + 100, THEBOX.transform.Find("Text").transform.position.y - 50, THEBOX.transform.Find("Text").transform.position.z);

            GameObject APSlotText = GameObject.Instantiate(THEBOX.transform.Find("Text").gameObject, THEBOX.transform);
            APSlotText.GetComponent<Text>().text = "Slot";
            APSlotText.transform.localPosition = new Vector3(APSlotText.transform.position.x + 100, APSlotText.transform.position.y - 90, APSlotText.transform.position.z);

            GameObject APPassText = GameObject.Instantiate(THEBOX.transform.Find("Text").gameObject, THEBOX.transform);
            APPassText.GetComponent<Text>().text = "Password";
            APPassText.transform.localPosition = new Vector3(APPassText.transform.position.x + 100, APPassText.transform.position.y - 130, APPassText.transform.position.z);

            Transform.Destroy(THEBOX.transform.Find("Portrait").gameObject);

            GameObject InputBase = GameObject.Instantiate(new GameObject("AddressInput", typeof(InputField)), THEBOX.transform);
            GameObject InputText = GameObject.Instantiate(THEBOX.transform.Find("Text").gameObject, InputBase.transform);
            InputBase.transform.localPosition = new Vector3(111, -62, 0);
            InputText.transform.localPosition = new Vector3(0, 0, 0);
            InputText.GetComponent<Text>().horizontalOverflow = HorizontalWrapMode.Wrap;
            InputText.GetComponent<Text>().verticalOverflow = VerticalWrapMode.Overflow;
            InputBase.GetComponent<InputField>().textComponent = InputText.GetComponent<Text>();
            InputBase.GetComponent<InputField>().text = "archipelago.gg:XXXXXX";
            InputText.GetComponent<Text>().text = "archipelago.gg:XXXXXX";

            GameObject InputSlot = GameObject.Instantiate(InputBase, THEBOX.transform);
            InputSlot.transform.localPosition = new Vector3(111, -102, 0);
            InputSlot.GetComponent<InputField>().text = "Player";

            GameObject InputPass = GameObject.Instantiate(InputBase, THEBOX.transform);
            InputPass.transform.localPosition = new Vector3(111, -142, 0);
            InputPass.GetComponent<InputField>().text = "";

            THEBOX.transform.Find("Reject Button").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate {
                APmenu.SetActive(false); 
            });



            RectTransform OldAcceptRect = THEBOX.transform.Find("Accept Button").GetComponent<RectTransform>();
            UnityEngine.UI.Button OldAcceptButt = THEBOX.transform.Find("Accept Button").GetComponent<UnityEngine.UI.Button>();
            GameObject OldAcceptImage = THEBOX.transform.Find("Accept Button").GetChild(0).gameObject;
            GameObject NewAcceptButtonOrig = new GameObject("NewAcceptButton", typeof(RectTransform), typeof(CanvasRenderer), typeof(UnityEngine.UI.Button));
            
            NewAcceptButtonOrig.GetComponent<RectTransform>().anchoredPosition = OldAcceptRect.anchoredPosition;
            NewAcceptButtonOrig.GetComponent<RectTransform>().anchoredPosition3D = OldAcceptRect.anchoredPosition3D;
            NewAcceptButtonOrig.GetComponent<RectTransform>().anchorMax = OldAcceptRect.anchorMax;
            NewAcceptButtonOrig.GetComponent<RectTransform>().anchorMin = OldAcceptRect.anchorMin;
            NewAcceptButtonOrig.GetComponent<RectTransform>().offsetMax = OldAcceptRect.offsetMax;
            NewAcceptButtonOrig.GetComponent<RectTransform>().offsetMin = OldAcceptRect.offsetMin;
            NewAcceptButtonOrig.GetComponent<RectTransform>().pivot = OldAcceptRect.pivot;
            NewAcceptButtonOrig.GetComponent<RectTransform>().sizeDelta = OldAcceptRect.sizeDelta;
            NewAcceptButtonOrig.GetComponent<RectTransform>().eulerAngles = OldAcceptRect.eulerAngles;
            NewAcceptButtonOrig.GetComponent<RectTransform>().hasChanged = OldAcceptRect.hasChanged;
            NewAcceptButtonOrig.GetComponent<RectTransform>().hierarchyCapacity = OldAcceptRect.hierarchyCapacity;
            NewAcceptButtonOrig.GetComponent<RectTransform>().localEulerAngles = OldAcceptRect.localEulerAngles;
            NewAcceptButtonOrig.GetComponent<RectTransform>().localPosition = OldAcceptRect.localPosition;
            NewAcceptButtonOrig.GetComponent<RectTransform>().localRotation = OldAcceptRect.localRotation;
            NewAcceptButtonOrig.GetComponent<RectTransform>().localScale = OldAcceptRect.localScale;
            NewAcceptButtonOrig.GetComponent<RectTransform>().position = OldAcceptRect.position;
            NewAcceptButtonOrig.GetComponent<RectTransform>().right = OldAcceptRect.right;
            NewAcceptButtonOrig.GetComponent<RectTransform>().rotation = OldAcceptRect.rotation;
            NewAcceptButtonOrig.GetComponent<RectTransform>().up = OldAcceptRect.up;
            NewAcceptButtonOrig.GetComponent<UnityEngine.UI.Button>().image = OldAcceptButt.image;
            NewAcceptButtonOrig.GetComponent<UnityEngine.UI.Button>().targetGraphic = OldAcceptButt.targetGraphic;
            NewAcceptButtonOrig.GetComponent<UnityEngine.UI.Button>().colors = OldAcceptButt.colors;

            GameObject NABO = GameObject.Instantiate(NewAcceptButtonOrig, THEBOX.transform);
            GameObject.Instantiate(OldAcceptImage, NABO.transform);
            THEBOX.transform.Find("Accept Button").gameObject.SetActive(false);
            Transform.Destroy(THEBOX.transform.Find("Accept Button"));

            NABO.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate {
                GameObject.Find("APHandlerObj").GetComponent<APHandler>().APConnect(InputBase.GetComponent<InputField>().text, InputSlot.GetComponent<InputField>().text, InputPass.GetComponent<InputField>().text, APmenu);
            });
            APmenu.SetActive(false);
        }

        
        [HarmonyPatch("OnConfirmStartButtonPressed")]
        [HarmonyPrefix]
        static void MakeSureAP()
        {
            bool IsAP = false;
            if (IsAP == true) return;
        }

        
    }
}
