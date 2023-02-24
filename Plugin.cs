global using GameSettings = MonoBehaviourPublicObjomaOblogaTMObseprUnique;
global using GameManager = MonoBehaviourPublicDi2UIObacspDi2UIObUnique;
global using ChatBox = MonoBehaviourPublicRaovTMinTemeColoonCoUnique;
global using TimerUI = MonoBehaviourPublicTetifrTeStBoStfoSiTiUnique;
global using LobbyManager = MonoBehaviourPublicCSDi2UIInstObUIloDiUnique;
global using PlayerInventory = MonoBehaviourPublicItDi2ObIninInTrweGaUnique;
global using InputManager = MonoBehaviourPublicInfobaInlerijuIncrspUnique;
global using PlayerManager = MonoBehaviourPublicCSstReshTrheObplBojuUnique;
global using PlayerStatus = MonoBehaviourPublicObcumaObInplInObUnique;


using BepInEx;
using BepInEx.IL2CPP;
using UnityEngine;
using UnityEngine.UI;
using UnhollowerRuntimeLib;
using HarmonyLib;
using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using CodeStage.AntiCheat.ObscuredTypes;
using Il2CppSystem.IO;
using File = System.IO.File;
using FileStream = System.IO.FileStream;
using System.Xml.Linq;
using TMPro;

namespace DebugMenu
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        private static Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = null;
        public static TMP_InputField name;
        private static string logData;
        private static string layout;
        private static string pathMenu;
        private static string filename;
        static GameManager gameManager;
        static PlayerManager otherPlayerManager;

        private static System.Collections.Generic.Dictionary<string, System.Func<string>> DebugDataCallbacks;

        private static readonly string customPrecisionFormat = "F2";

        private static bool menuEnabled = false;
        private static bool gameEnded = true;
        private static DateTime startGame;


        private static KeyCode keyForward = (KeyCode)InputManager.forward;
        private static KeyCode keyLeft = (KeyCode)InputManager.left;
        private static KeyCode keyRight = (KeyCode)InputManager.right;
        private static KeyCode keyBackwards = (KeyCode)InputManager.backwards;

        private static KeyCode keyJump = (KeyCode)InputManager.jump;
        private static KeyCode keyRun = (KeyCode)InputManager.sprint;
        private static KeyCode keyCrouch = (KeyCode)InputManager.crouch;

        private static readonly string testPath = "Crabi\\";

        public override void Load()
        {
            ClassInjector.RegisterTypeInIl2Cpp<DebugMenu>();
            DebugDataCallbacks = new System.Collections.Generic.Dictionary<string, System.Func<string>>();
            // Plugin startup logic
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            pathMenu = System.IO.Directory.GetParent(Application.dataPath) + "\\DebugLayout.txt";
            Harmony.CreateAndPatchAll(typeof(Plugin));
            CheckFileExists();
            LoadLayout();
            RegisterDefaultCallbacks();
            // If directory does not exist, create it
            if (!System.IO.Directory.Exists("Crabi"))
            {
                System.IO.Directory.CreateDirectory("Crabi");
            }
        }

        private static void CheckFileExists()
        {
            if (!File.Exists(pathMenu))
            {
                File.WriteAllText(pathMenu,
                    "Player: [PLAYERNAME]\tSpeed: [SPEED] u/s\tRotation: [ROTATION]\tPosition: [POSITION]\n", Encoding.UTF8);
            }
        }

        private static void LoadLayout()
        {
            layout = File.ReadAllText(pathMenu, Encoding.UTF8);
        }

        private static void RegisterDataCallback(string s, System.Func<string> f)
        {
            DebugDataCallbacks.Add(s, f);
        }

        private static void RegisterDataCallbacks(System.Collections.Generic.Dictionary<string, System.Func<string>> dict)
        {
            foreach (System.Collections.Generic.KeyValuePair<string, System.Func<string>> pair in dict)
            {
                DebugDataCallbacks.Add(pair.Key, pair.Value);
            }
        }

        private static void RegisterDefaultCallbacks()
        {
            RegisterDataCallbacks(new System.Collections.Generic.Dictionary<string, System.Func<string>>(){
                {"SPEED",      GetPlayerSpeedAsString},
                {"POSITION",   GetPlayerRotationAsString},
                {"ROTATION",   GetPlayerPositionAsString},
                {"PLAYERNAME", GetPlayerUsernameAsString}
            });
        }

        private static string FormatLayout()
        {
            string formatted = layout;

            foreach (System.Collections.Generic.KeyValuePair<string, System.Func<string>> pair in DebugDataCallbacks)
            {
                formatted = formatted.Replace("[" + pair.Key + "]", pair.Value());
            }

            return formatted;
        }

        private static string DefaultFormatCsv(string originalString)
        {
            return originalString.Replace("(", "").Replace(")", "").Replace(" ", "");
        }

        private static void ClearFileContent(string path)
        {
            if (File.Exists(path))
                return;

            FileStream fileStream = File.Open(path, System.IO.FileMode.Open);

            fileStream.SetLength(0);
            fileStream.Close();
        }

        private static void WriteOnFile(string path, string line)
        {
            using System.IO.StreamWriter file = new(path, append: true);
            file.WriteLine(line);
        }

        private static string StringsArrayToCsvLine(string[] array)
        {
            string result = "";

            if (array.Length > 0)
            {
                StringBuilder sb = new();

                string formattedString;

                foreach (string s in array)
                {
                    formattedString = DefaultFormatCsv(s);
                    sb.Append(formattedString).Append(",");
                }

                result = sb.Remove(sb.Length - 1, 1).ToString();
            }

            return result;
        }


        public static string GetGameStateAsString()
        {
            return UnityEngine.Object.FindObjectOfType<GameManager>().gameMode.modeState.ToString();
        }
        public static string GetGameNameAsString()
        {
            return UnityEngine.Object.FindObjectOfType<GameSettings>().serverNameField.ToString();
        }
        private static LobbyManager GetLobbyManager()
        {
            return LobbyManager.Instance;
        }

        private static GameObject GetPlayerObject()
        {
            GameObject playerObject = GameObject.Find("/Player");
            return playerObject;
        }


        private static PlayerStatus GetPlayerStatus()
        {
            return PlayerStatus.Instance;
        }

        private static PlayerInventory GetPlayerInventory()
        {
            return PlayerInventory.Instance;
        }


        private static PlayerManager GetPlayerManager()
        {
            return GetPlayerObject().GetComponent<PlayerManager>();
        }


        private static Rigidbody GetPlayerRigidbody()
        {
            return GetPlayerObject()?.GetComponent<Rigidbody>();
        }

        private static Camera GetCamera()
        {
            return UnityEngine.Object.FindObjectOfType<Camera>();
        }

        static string GetSHA256(string input)
        {
            // Convertir la chaîne de caractères en tableau de bytes
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Calculer l'empreinte SHA-256 du tableau de bytes
            byte[] hashBytes = SHA256.Create().ComputeHash(inputBytes);

            // Convertir l'empreinte SHA-256 en chaîne de caractères hexadécimale
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        private static int GetGameModeId()
        {
            return GetLobbyManager().gameMode.id;
        }

        private static string GetGameModeIdAsString()
        {
            return GetGameModeId().ToString();
        }

        private static int GetMapId()
        {
            return GetLobbyManager().map.id;
        }

        private static string GetMapIdAsString()
        {
            return GetMapId().ToString();
        }
        private static int GetPlayersAlive()
        {
            if (GameManager.Instance != null)
            {
                return GameManager.Instance.GetPlayersAlive();
            }
            else
            {
                return 0;
            }
        }


        private static string GetPlayerUsernameAsString()
        {
            PlayerManager localPlayer = GetPlayerManager();

            return localPlayer == null ? "Player's name is unknown" : localPlayer.username.ToString();
        }



        private static int GetCurrentGameTimer()
        {
            int seconds = UnityEngine.Object.FindObjectOfType<TimerUI>().field_Private_TimeSpan_0.Seconds;
            int minutes = UnityEngine.Object.FindObjectOfType<TimerUI>().field_Private_TimeSpan_0.Minutes;
            int hours = UnityEngine.Object.FindObjectOfType<TimerUI>().field_Private_TimeSpan_0.Hours;
            int days = UnityEngine.Object.FindObjectOfType<TimerUI>().field_Private_TimeSpan_0.Days;

            return (seconds + 1 + minutes * 60 + hours * 60 + days * 60);
        }

        private static string GetTimeStamp()
        {

            int totalTime = UnityEngine.Object.FindObjectOfType<LobbyManager>().gameMode.modeTime;
            int milliseconds = UnityEngine.Object.FindObjectOfType<TimerUI>().field_Private_TimeSpan_0.Milliseconds;
            int seconds = UnityEngine.Object.FindObjectOfType<TimerUI>().field_Private_TimeSpan_0.Seconds;
            int minutes = UnityEngine.Object.FindObjectOfType<TimerUI>().field_Private_TimeSpan_0.Minutes;


            return ((-1 * (seconds + milliseconds + minutes * 60)) + totalTime).ToString();
        }



        private static string GetCurrentGameTimerAsString()
        {
            return GetCurrentGameTimer().ToString();
        }

        private static Vector3? GetPlayerRotation()
        {
            return GetCamera()?.transform.rotation.eulerAngles;
        }

        private static string GetPlayerRotationAsString()
        {
            Vector3? rotation = GetPlayerRotation();

            return !rotation.HasValue ? "ERROR" : rotation.Value.ToString(customPrecisionFormat);
        }

        private static Vector3? GetPlayerPosition()
        {
            return GetPlayerRigidbody()?.transform.position;
        }

        private static string GetPlayerPositionAsString()
        {
            Vector3? playerPos = GetPlayerPosition();

            return !playerPos.HasValue ? "ERROR" : playerPos.Value.ToString(customPrecisionFormat);
        }

        private static float? GetPlayerSpeed()
        {
            return GetPlayerRigidbody()?.velocity.magnitude;
        }

        private static string GetPlayerSpeedAsString()
        {
            float? speed = GetPlayerSpeed();

            return !speed.HasValue ? "ERROR" : speed.Value.ToString(customPrecisionFormat).Replace(",", ".");
        }

        private static ObscuredInt GetPlayerHealth()
        {
            return GetPlayerStatus().currentHp;
        }

        private static string GetPlayerHealthAsString()
        {
            return GetPlayerHealth().ToString();
        }

        private static bool GetPlayerIsTagged()
        {
            return GetPlayerInventory().currentItem != null;
        }

        private static string GetIsTaggedAsString()
        {
            return GetPlayerIsTagged() ? "1" : "0";
        }


        public static PlayerManager GetOtherPlayerManager()
        {
            foreach (Il2CppSystem.Collections.Generic.KeyValuePair<ulong, PlayerManager> activePlayer in activePlayers)
            {
                if (!GetPlayerUsernameAsString().Equals(activePlayer.Value.username.ToString()))
                    return activePlayer.Value;
            }
            return null;
        }
        public static Rigidbody GetOtherPlayerBody()
        {
            Rigidbody rb = null;
            gameManager = GameObject.Find("/GameManager (1)").GetComponent<GameManager>();
            PlayerManager otherPlayer = otherPlayerManager;
            
            if (otherPlayer != null)
                rb = otherPlayer.GetComponent<Rigidbody>();
            return rb;
        }
        public static Vector3? GetOtherPlayerPosition()
        {
            UnityEngine.Vector3? position = null;
            Rigidbody rb = GetOtherPlayerBody();

            if (rb != null)
                position = rb.transform.position;
            return rb == null ? null : position;
        }
        public static string GetOtherPlayerPositionAsString()
        {
            Vector3? otherPlayerPosition = GetOtherPlayerPosition();
            return otherPlayerPosition == null ? "" : otherPlayerPosition.ToString();
        }
        public static string GetOtherPlayerSpeedAsString()
        {
            Rigidbody rb = GetOtherPlayerBody();
            return rb == null ? "" : rb.velocity.magnitude.ToString(customPrecisionFormat).Replace(",", ".");
        }
        public static string GetOtherPlayerRotationAsString()
        {
            return otherPlayerManager.head.gameObject.transform.eulerAngles.ToString(customPrecisionFormat);
        }


        private static bool[] GetInputArray()
        {

            bool[] keys = {
                    Input.GetKey(keyForward),
                    Input.GetKey(keyLeft),
                    Input.GetKey(keyRight),
                    Input.GetKey(keyBackwards),

                    Input.GetKey(keyJump),
                    Input.GetKey(keyRun),
                    Input.GetKey(keyCrouch),

                    Input.GetMouseButtonDown(0)
                };

            return keys;
        }

        private static string GetInputArrayAsString()
        {
            bool[] keys = GetInputArray();

            String[] keysString =
            {
                keys[0] ? "1" : "0",
                keys[1] ? "1" : "0",
                keys[2] ? "1" : "0",
                keys[3] ? "1" : "0",

                keys[4] ? "1" : "0",
                keys[5] ? "1" : "0",
                keys[6] ? "1" : "0",

                keys[7] ? "1" : "0"
            };

            return StringsArrayToCsvLine(keysString);
        }

        private static void LogPlayerSpeed()
        {
            string path = testPath + "speed.csv";

            string speedString = GetPlayerSpeedAsString();

            WriteOnFile(path, speedString);
        }

        private static void LogPlayerPosition()
        {
            string path = testPath + "pos.csv";

            string posString = GetPlayerPositionAsString();

            WriteOnFile(path, posString);
        }

        private static void LogPlayerRotation()
        {
            string path = testPath + "rotation.csv";

            string playerRotation = GetPlayerRotationAsString();

            WriteOnFile(path, playerRotation);
        }

        private static void LogPlayerHealth()
        {
            string path = testPath + "health.csv";

            WriteOnFile(path, GetPlayerHealthAsString());
        }

        private static void LogPlayerIsTagged()
        {
            string path = testPath + "tagged.csv";
            PlayerInventory playerInventory = GetPlayerInventory();
            bool isTagged = playerInventory.currentItem != null;

            WriteOnFile(path, isTagged ? "1" : "0");
        }

        private static void LogCurrentGameTimer()
        {
            string path = testPath + "timer.csv";
            PlayerInventory playerInventory = GetPlayerInventory();
            bool isTagged = playerInventory.currentItem != null;

            WriteOnFile(path, GetCurrentGameTimerAsString());
        }

        private static void LogInputArray()
        {
            string path = testPath + "input.csv";

            WriteOnFile(path, GetInputArrayAsString());
        }

        private static void LogAllData(string filename, DateTime start)
        {
            string path = testPath + filename + ".csv";

            DateTime end = DateTime.Now;

            TimeSpan ts = (end - start);

            int timestamp = ts.Milliseconds + ts.Seconds * 1000 + ts.Minutes * 1000 * 60;

            string[] stringArray =
            {
                timestamp.ToString(),
                GetPlayerPositionAsString(),
                GetPlayerSpeedAsString(),
                GetPlayerRotationAsString(),
                GetPlayerHealthAsString(),
                GetIsTaggedAsString(),
                GetInputArrayAsString(),
                GetCurrentGameTimerAsString(),
                GetOtherPlayerPositionAsString(),
                GetOtherPlayerSpeedAsString(),
                GetOtherPlayerRotationAsString()
            };

            WriteOnFile(path, StringsArrayToCsvLine(stringArray));
            string logDataOld = logData;
            logData = logDataOld + "\n" + StringsArrayToCsvLine(stringArray);
        }

        public class DebugMenu : MonoBehaviour
        {
            public Text text;
            private DateTime startTimer = DateTime.Now;
            bool inTwoPlayersGame = false;
            private DateTime tournamentEnding = new DateTime(2023, 2, 28);

            private void Update()
            {

                text.text = menuEnabled ? FormatLayout() : "";

                if (GameManager.Instance.isActiveAndEnabled)
                {
                    activePlayers = GameManager.Instance.activePlayers;

                    // activePlayers.Count represente le nombre de vivants au début de la manche MOINS les déconnectés
                    // GetPlayerAlive() représente le nombre de vivants

                    if (GetGameModeId() != 0 &&
                        GetPlayerObject() != null &&
                        GetGameStateAsString() == "Playing" &&
                        tournamentEnding.CompareTo(DateTime.Now) > 0 &&
                        (activePlayers.Count == 2 && GetPlayersAlive() == 2))
                    {
                        if (!inTwoPlayersGame)
                        {
                            otherPlayerManager = GetOtherPlayerManager();
                            string username0 = GetPlayerManager().username.ToString();
                            string username1 = otherPlayerManager.username.ToString();
                            startGame = DateTime.Now;
                            long startGameTimeMilliseconds = new DateTimeOffset(startGame).ToUnixTimeMilliseconds();
                            string[] filenameArray =
                            {
                                username0,
                                username1,
                                startGameTimeMilliseconds.ToString(),
                                GetMapIdAsString()
                            };
                            filename = StringsArrayToCsvLine(filenameArray);
                            logData = "";

                            // Si le dossier n'existe pas, créer un dossier 'Crabi'
                            if (!System.IO.Directory.Exists("Crabi"))
                            {
                                System.IO.Directory.CreateDirectory("Crabi");
                            }

                            //permet d'executer uniquement une fois par partie le code dans le if (!inTwoPlayersGame)
                            inTwoPlayersGame = true;
                        }

                        LogAllData(filename, startGame);
                        gameEnded = false;
                    }
                    else
                    {
                        string winner = "NoWinner";

                        if (activePlayers.Count == 1 && inTwoPlayersGame && !gameEnded)
                            winner = "Disconnected";
                    


                        if (GetPlayersAlive() == 1 && activePlayers.Count == 2 && inTwoPlayersGame && !gameEnded)
                        {
                            if (!otherPlayerManager.dead && otherPlayerManager.isActiveAndEnabled)
                                winner = otherPlayerManager.username.ToString();
                            else
                                winner = GetPlayerManager().username.ToString();
                        }
                        // Source file to be renamed
                        string sourceFile = "Crabi\\" + filename + ".csv";
                        // Create a FileInfo
                        System.IO.FileInfo fi = new System.IO.FileInfo(sourceFile);
                        // Check if file is there
                        if (fi.Exists)
                        {
                            // Move file with a new name. Hence renamed.
                            fi.MoveTo("Crabi\\" + filename + "," + winner + ".csv");
                        }
                        inTwoPlayersGame = false;
                        gameEnded= true;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(MonoBehaviourPublicGaroloGaObInCacachGaUnique), "Awake")]
        [HarmonyPostfix]
        public static void UIAwakePatch(MonoBehaviourPublicGaroloGaObInCacachGaUnique __instance)
        {
            GameObject menuObject = new();
            Text text = menuObject.AddComponent<Text>();
            text.font = (Font)Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.raycastTarget = false;
            DebugMenu menu = menuObject.AddComponent<DebugMenu>();
            menu.text = text;

            menuObject.transform.SetParent(__instance.transform);
            menuObject.transform.localPosition = new Vector3(menuObject.transform.localPosition.x, -menuObject.transform.localPosition.y, menuObject.transform.localPosition.z);
            RectTransform rt = menuObject.GetComponent<RectTransform>();
            rt.pivot = new Vector2(0, 1);
            rt.sizeDelta = new Vector2(1000, 1000);
        }
    }
}