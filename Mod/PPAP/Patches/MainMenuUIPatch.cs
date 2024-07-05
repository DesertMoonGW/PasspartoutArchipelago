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
    class MainMenuUIPatch
    {

        static void APConnectMenu()
        {
            Debug.Log("Creating AP Connect Menu.");

            GameObject APmenu = GameObject.Instantiate(GameObject.Find("Confirm Restart"), GameObject.Find("MainMenu UI").transform);
            APmenu.name = "APMenu";

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


            Debug.Log("About to add functionality to buttons...");
            THEBOX.transform.Find("Reject Button").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate {
                APmenu.SetActive(false); 
            });
            THEBOX.transform.Find("Accept Button").GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            THEBOX.transform.Find("Accept Button").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate {
                Debug.Log("Adding Accept Button functionality.");
                APConnect(InputBase.GetComponent<InputField>().text, InputSlot.GetComponent<InputField>().text, InputPass.GetComponent<InputField>().text); 
            });
        }

        private static void APConnect(string Address, string Slot, string Password)
        {
            string[] addressport = Address.Split(':');
            Debug.Log(addressport[0] + " " + Int32.Parse(addressport[1]));

            Debug.Log("Attempting AP Connection...");
            var APsession = ArchipelagoSessionFactory.CreateSession(addressport[0], Int32.Parse(addressport[1]));
            Debug.Log("Part 1");
            LoginResult result;
            Debug.Log("Part 2");
            try
            {
                Debug.Log("Trying to connect...");
                result = APsession.TryConnectAndLogin("Passpartout", Slot, ItemsHandlingFlags.AllItems, null, null, null, Password, true);
            }
            catch (Exception e)
            {
                Debug.Log("Connect failed.");
                result = new LoginFailure(e.GetBaseException().Message);
            }
            
            if (!result.Successful)
            {
                LoginFailure fail = (LoginFailure)result;
                string errorMessage = $"Failed to connect to {Address} as {Slot}:";
                foreach(string error in fail.Errors)
                {
                    errorMessage += $"\n    {error}";
                }
                foreach(ConnectionRefusedError error in fail.ErrorCodes)
                {
                    errorMessage += $"\n    {error}";
                }

                return;
            }

            var loginSuccess = (LoginSuccessful)result;
            Debug.Log("Connect success.");
        }

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
		static void ChangeMenu()
        {
            APConnectMenu();
        }

    }
}
