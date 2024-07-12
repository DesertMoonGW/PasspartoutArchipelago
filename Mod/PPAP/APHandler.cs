using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using PPAP.Patches;
using System;
using UnityEngine;

namespace PPAP
{
    public class APHandler
    {
        public static ArchipelagoSession session;

        public static void APConnect(string Address, string Slot, string Password, GameObject Menu)
        {
            Debug.Log($"Attempting AP Connection to {Address}.");
            string[] addressport = Address.Split(':');
            try
            {
                Debug.Log("Trying to convert port to numbers.");
                Int32.Parse(addressport[1]);
            }
            catch
            {
                Debug.Log("Non-integer port, try again.");
            }
            session = ArchipelagoSessionFactory.CreateSession(addressport[0], Int32.Parse(addressport[1]));

            LoginResult result;
            try
            {
                Debug.Log("Trying to connect...");
                result = session.TryConnectAndLogin("Passpartout", Slot, ItemsHandlingFlags.AllItems, null, null, null, Password, true);
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
                foreach (string error in fail.Errors)
                {
                    errorMessage += $"\n    {error}";
                }
                foreach (ConnectionRefusedError error in fail.ErrorCodes)
                {
                    errorMessage += $"\n    {error}";
                }

                return;
            }

            var loginSuccess = (LoginSuccessful)result;
            Debug.Log("Connect success.");

            //This just replicates the StartGame function from MainMenuUI because it's private.
            Menu.SetActive(false);

            MonoSingleton<Player>.Instance.ShouldInitializeFromSave = false;
            MonoSingleton<Player>.Instance.IsEndlessMode = false;
            if (!MonoSingleton<Player>.Instance.ShouldInitializeFromSave)
            {
                MonoSingleton<Player>.Instance.Clear();
                MonoSingleton<ProgressionTutorials>.Instance.Clear();
            }
            SceneTransitioner.LoadScene("Act1.1", 0.35f);
            UISystem.instance.GetPanel<CanvasPainterUI>(UISystem.Panel.EASEL, false).painter.DisableExtraBrushes();
            MusicManager.instance.StopMusic();
        }
    }
}