global using GameSettings = MonoBehaviourPublicObjomaOblogaTMObseprUnique;
global using SteamManager = MonoBehaviourPublicObInUIgaStCSBoStcuCSUnique;
global using GameManager = MonoBehaviourPublicDi2UIObacspDi2UIObUnique;
global using GameUI = MonoBehaviourPublicGaroloGaObInCacachGaUnique;
global using ChatBox = MonoBehaviourPublicRaovTMinTemeColoonCoUnique;
global using DamageVignette = MonoBehaviourPublicRadaSiSiSiUnique;
global using PlayerMovement = MonoBehaviourPublicGaplfoGaTrorplTrRiBoUnique;
global using ServerSend = MonoBehaviourPublicInInUnique;
global using MapManager = MonoBehaviourPublicObInMamaLi1plMadeMaUnique;
global using GameModeManager = MonoBehaviourPublicGadealGaLi1pralObInUnique;
global using MapSize = Map.EnumNPublicSealedvasmmelaan5vUnique;
global using BouncePlayer = MonoBehaviourPublicSicofoSimuupInSiboVeUnique;
global using JumpPad = MonoBehaviourPublicSiBopuSiUnique;
global using SharedObjectManager = MonoBehaviourPublicDi2InObInObInUnique;
global using SnowballPile = MonoBehaviour1PublicBoInSiUnique;
global using LobbyReadyInteract = MonoBehaviour1PublicTrbuObreunObBoVeVeVeUnique;
global using GameModeTag = GameModePublicLi1UIUnique;
global using Packet = ObjectPublicIDisposableLi1ByInByBoUnique;
global using GameServer = MonoBehaviourPublicObInCoIE85SiAwVoFoCoUnique;
global using TimerUI = MonoBehaviourPublicTetifrTeStBoStfoSiTiUnique;
global using Crosshair = MonoBehaviourPublicRedoleReritoboReBoenUnique;
global using LobbyManager = MonoBehaviourPublicCSDi2UIInstObUIloDiUnique;
global using ThrownSnowball = MonoBehaviour1PublicTrtrGahiRiCoBoItVeBoUnique;
global using PlayerInventory = MonoBehaviourPublicItDi2ObIninInTrweGaUnique;
global using ItemGun = MonoBehaviour2PublicGathObauTrgumuGaSiBoUnique;
global using NetStatus = MonoBehaviourPublicStLi1InInUnique;
global using GameLoop = MonoBehaviourPublicObInLi1GagasmLi1GaUnique;
global using LocalSfx = MonoBehaviourPublicAuhibuAusoObInAuUnique;
global using VoiceChat = MonoBehaviourPublicAusoMeInObInInInInUnique;
global using PersistentPlayerData = MonoBehaviourPublicBofrhnBoObInUnique;
global using ServerClock = MonoBehaviourPublicSiObSiInSiUnique;
global using EffectManager = MonoBehaviourPublicGataInefObInUnique;
global using MakeDissonance = MonoBehaviourPublicGadiUnique;
global using MusicController = MonoBehaviourPublicAuInMeAufuscwiAuObSiUnique;
global using SongType = MonoBehaviourPublicAuInMeAufuscwiAuObSiUnique.EnumNPublicSealedvaNoInMeFuScWi7vUnique;
global using Cosmetics = MonoBehaviourPublicLi1CoalDi2InitCoUIUnique;
global using Quests = MonoBehaviourPublicLi1QudaDi2InquQuacUnique;
global using SteamInventory = MonoBehaviourPublicStCaSt1ObSthaUIStmaUnique;
global using InputManager = MonoBehaviourPublicInfobaInlerijuIncrspUnique;
global using PPController = MonoBehaviourPublicMoBlAmChPoObInUnique;
global using SteamPacketManager = MonoBehaviourPublicInStInpabyDiInpaby2Unique;
global using WorkshopUtility = MonoBehaviourPublicStwodeStUnique;
global using ChatFilter = MonoBehaviourPublicTeprLi1StUnique;
global using LoadingScreen = MonoBehaviourPublicTeprUIObUIBotiRabamaUnique;
global using RedLightSafeZone = MonoBehaviourPublicLi1ObsaInObUnique;// rlgl safe zonees are also used in race and king of the hill because of course they are
global using Ladder = MonoBehaviourPublicLi1CoonUnique;
global using MovingObject = MonoBehaviourPublicVeofSispRiVeSiofUnique;
global using WaterSplash = MonoBehaviourPublicGaspLi1ObUnique;
global using MoveLava = MonoBehaviourPublicVeSioflaSiAulasiBoSiUnique;
global using KillPlayerOutOfBounds = MonoBehaviourPublicSikiUnique;
global using GameModeTimer = MonoBehaviourPublicTetifrTeStBoStfoSiTiUnique;
global using PlayerManager = MonoBehaviourPublicCSstReshTrheObplBojuUnique;
global using PlayerServerCommunication = MonoBehaviourPublicTrrocaTrInSiVeSipoObUnique;
global using DetectItems = MonoBehaviourPublicLawhTrcaGacuMaouUnique;
global using PlayerStatus = MonoBehaviourPublicObcumaObInplInObUnique;
global using PunchPlayers = MonoBehaviourPublicObsfBoLawhSiUnique;
global using RevealPlayerNames = MonoBehaviourPublicLi1ObplLawhRaUnique;
global using MoveCamera = MonoBehaviourPublicTrplVeofdeVevaCaRiVeUnique;

//Using
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
        private static string path2;
        private static string filename;
        static GameManager gameManager;

        private static System.Collections.Generic.Dictionary<string, System.Func<string>> DebugDataCallbacks;

        private static readonly string customPrecisionFormat = "F2";

        private static bool menuEnabled = false;
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
            path2 = System.IO.Directory.GetParent(Application.dataPath) + "\\DebugLayout.txt";
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
            if (!File.Exists(path2))
            {
                File.WriteAllText(path2,
                    "Player: [PLAYERNAME]\tSpeed: [SPEED] u/s\tRotation: [ROTATION]\tPosition: [POSITION]\n", Encoding.UTF8);
            }
        }

        private static void LoadLayout()
        {
            layout = File.ReadAllText(path2, Encoding.UTF8);
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
            return originalString.Replace(",", ";").Replace("(", "").Replace(")", "").Replace(" ", "");
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

        //A voir avec bobi
        public static string GetGameNameAsString()
        {
            //UnityEngine.Object.FindObjectOfType<GameSettings>().UpdateServerName();
            //UnityEngine.Object.FindObjectOfType<GameSettings>().name.ToString();
            return UnityEngine.Object.FindObjectOfType<GameSettings>().serverNameField.ToString();
        }
        // A TESTER FORTEMENT
        private static LobbyManager GetLobbyManager()
        {
            return LobbyManager.Instance;
        }

        private static GameObject GetPlayerObject()
        {
            GameObject playerObject = GameObject.Find("/Player");
            return playerObject;
        }

        // A TESTER FORTEMENT
        private static PlayerStatus GetPlayerStatus()
        {
            return PlayerStatus.Instance;
        }

        // A TESTER FORTEMENT
        private static PlayerInventory GetPlayerInventory()
        {
            return PlayerInventory.Instance;
        }

        // A TESTER FORTEMENT
        private static PlayerManager GetPlayerManager()
        {
            return GetPlayerObject().GetComponent<PlayerManager>();
        }

        // A TESTER FORTEMENT
        private static Rigidbody GetPlayerRigidbody()
        {
            return GetPlayerObject()?.GetComponent<Rigidbody>();
        }

        // A TESTER FORTEMENT
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
    




        // GetGameModeId est utile pour savoir si on est dans le lobby ?
        private static int GetGameModeId()
        {
            return GetLobbyManager().gameMode.id;
        }


        // GetGameModeId est utile pour savoir si on est dans le lobby ?
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

        public static Rigidbody GetOtherPlayerBody()
        {
            Rigidbody rb = null;
            gameManager = GameObject.Find("/GameManager (1)").GetComponent<GameManager>();
            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager>.Entry activePlayer = gameManager.activePlayers.entries.ToList()[1]; 
            if (activePlayer != null)
                rb = activePlayer.value.GetComponent<Rigidbody>();
            return rb;
        }
        public static Vector3? GetOtherPlayerPosition()
        {
            UnityEngine.Vector3? position = null;
            Rigidbody rb = GetOtherPlayerBody();

            if (rb != null)
                position = rb.transform.position;
            return rb == null? null : position;
        }
        public static string GetOtherPlayerPositionAsString()
        {
            Vector3? otherPlayerPosition = GetOtherPlayerPosition();
            return otherPlayerPosition == null? "" : otherPlayerPosition.ToString();
        }
        public static string GetOtherPlayerSpeedAsString()
        {
            Rigidbody rb = GetOtherPlayerBody();
            return rb == null ? "" : rb.velocity.magnitude.ToString();
        }
        public static string GetOtherPlayerRotationAsString()
        {
            Rigidbody rb = GetOtherPlayerBody();
            return rb == null ? "" : rb.gameObject.transform.rotation.eulerAngles.ToString();
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

        // A TESTER FORTEMENT
        private static void LogPlayerHealth()
        {
            string path = testPath + "health.csv";

            WriteOnFile(path, GetPlayerHealthAsString());
        }

        // A TESTER FORTEMENT
        private static void LogPlayerIsTagged()
        {
            string path = testPath + "tagged.csv";
            PlayerInventory playerInventory = GetPlayerInventory();
            bool isTagged = playerInventory.currentItem != null;

            WriteOnFile(path, isTagged ? "1" : "0");
        }

        // A TESTER FORTEMENT
        private static void LogCurrentGameTimer()
        {
            string path = testPath + "timer.csv";
            PlayerInventory playerInventory = GetPlayerInventory();
            bool isTagged = playerInventory.currentItem != null;

            WriteOnFile(path, GetCurrentGameTimerAsString());
        }

        // A TESTER FORTEMENT
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
            private DateTime start = DateTime.Now;
            bool inGame = false;
        private void Update()
            {

                DateTime end = DateTime.Now;

                TimeSpan ts = (end - start);

                text.text = menuEnabled ? FormatLayout() : "";

                if (ts.TotalMilliseconds >= 200)
                {
                    start = DateTime.Now;

                }

                if (GameManager.Instance.isActiveAndEnabled)
                {
                    if (Input.GetKeyDown("f3"))
                    {
                        menuEnabled = !menuEnabled;
                    }

                    if (GetGameModeId() != 0 && GetPlayerObject() != null && GetGameStateAsString() == "Playing")
                    {
                        if (!inGame)
                        {
                            GameManager gameManager = GameObject.Find("/GameManager (1)").GetComponent<GameManager>();
                            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;
                            string username0 = activePlayers.entries.ToList()[0].value.username.ToString();
                            string username1 = activePlayers.entries.ToList()[1].value.username.ToString();
                            startGame = DateTime.Now;
                            long startGameTimeMilliseconds = new DateTimeOffset(startGame).ToUnixTimeMilliseconds();
                            // il faut mettre ce if tout en haut dans le 1er if
                            // le code dans ce if est éxécuté une seule fois
                            string[] filenameArray =
                            {
                                username0,
                                username1,
                                startGameTimeMilliseconds.ToString(),
                                GetMapIdAsString()
                            };

                            filename = StringsArrayToCsvLine(filenameArray);
                            logData = "";

                            // If directory does not exist, create it
                            if (!System.IO.Directory.Exists("Crabi"))
                            {
                                System.IO.Directory.CreateDirectory("Crabi");
                            }
                            inGame = true;

                        }
                        LogAllData(filename, startGame);

                    }
                    else
                    {
                        inGame = false;
                    }


                    /*
                    // DANS LE FILE
                    // CLICKE F4 INSTANT
                    if (Input.GetKeyDown("f4"))
                    {
                        LogAllData();
                    }


                    // DANS LE FILE
                    // PRESSE F5 CONSTANT
                    else if (Input.GetKey("f5"))
                    {
                        LogAllData();
                    }
                    */
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