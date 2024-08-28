using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Models;
using Archipelago.MultiClient.Net.Packets;
using PPAP.Patches;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PPAP
{
    public class APHandler : MonoBehaviour
    {
        public static ArchipelagoSession session;

        public int percentNeededForLoc = 250;
        public int percentToLoc = 0;
        private int currentPaintingCount = 0;

        public void APConnect(string Address, string Slot, string Password, GameObject Menu)
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
        
        public bool IsAP()
        {
            if (session != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ChangePercent(int change)
        {
            Debug.Log("Changing percentage from " + percentToLoc + " to " + (percentToLoc + change));
            percentToLoc += change;
            while (percentToLoc >= percentNeededForLoc) //bug: always activates
            {
                Debug.Log("Enough for a Location!");
                if (SceneManager.GetActiveScene().name == "Act1.1")
                {
                    Debug.Log("In Act 1");
                    switch (currentPaintingCount) //bug: locations don't send
                    {
                        case 0:
                            Debug.Log("Lookie here!");
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act I - Painting Sale #1"));
                            session.Say("test");
                            break;

                        case 1:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act I - Painting Sale #2"));
                            break;

                        case 2:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act I - Painting Sale #3"));
                            break;

                        case 3:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act I - Painting Sale #4"));
                            break;

                        case 4:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act I - Painting Sale #5"));
                            break;

                        case 5:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act I - Painting Sale #6"));
                            break;

                        case 6:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act I - Painting Sale #7"));
                            break;

                        case 7:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act I - Painting Sale #8"));
                            break;

                        case 8:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act I - Painting Sale #9"));
                            break;

                        case 9:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act I - Painting Sale #10"));
                            break;

                        default:
                            break;
                    }
                }
                else if(SceneManager.GetActiveScene().name == "Act2.1" || SceneManager.GetActiveScene().name == "Act2.2")
                {
                    Debug.Log("In Act 2");
                    switch (currentPaintingCount) //bug: locations don't send
                    {
                        case 0:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act II - Painting Sale #1"));
                            break;

                        case 1:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act II - Painting Sale #2"));
                            break;

                        case 2:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act II - Painting Sale #3"));
                            break;

                        case 3:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act II - Painting Sale #4"));
                            break;

                        case 4:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act II - Painting Sale #5"));
                            break;

                        case 5:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act II - Painting Sale #6"));
                            break;

                        case 6:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act II - Painting Sale #7"));
                            break;

                        case 7:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act II - Painting Sale #8"));
                            break;

                        case 8:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act II - Painting Sale #9"));
                            break;

                        case 9:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act II - Painting Sale #10"));
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    Debug.Log("In Act 3");
                    switch (currentPaintingCount) //bug: locations don't send
                    {
                        case 0:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act III - Painting Sale #1"));
                            break;

                        case 1:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act III - Painting Sale #2"));
                            break;

                        case 2:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act III - Painting Sale #3"));
                            break;

                        case 3:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act III - Painting Sale #4"));
                            break;

                        case 4:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act III - Painting Sale #5"));
                            break;

                        case 5:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act III - Painting Sale #6"));
                            break;

                        case 6:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act III - Painting Sale #7"));
                            break;

                        case 7:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act III - Painting Sale #8"));
                            break;

                        case 8:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act III - Painting Sale #9"));
                            break;

                        case 9:
                            session.Locations.CompleteLocationChecks(session.Locations.GetLocationIdFromName("Passpartout", "Act III - Painting Sale #10"));
                            break;

                        default:
                            break;
                    }
                }
                Debug.Log("Changing percentage from " + percentToLoc + " to " + (percentToLoc - percentNeededForLoc));
                percentToLoc -= percentNeededForLoc;
                currentPaintingCount++;
                Debug.Log("Ending ChangePercent");
            }
        }
    }
}