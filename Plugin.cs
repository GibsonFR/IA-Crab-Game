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

namespace DebugMenu
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {

        private static Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = null;
        private static string layout;
        private static string path;
        
        /*
        private static Rigidbody otherPlayerBody;
        private static string otherPlayerUsername;
        private static float otherPlayerSpeed;
        */

        private static Vector3? oldOtherPlayerPosition;

        private static System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<object>> DebugDataCallbacks;

        private static int trigger = 0;
        private static float smoothedSpeed = 0;
        private static readonly float smoothingFactor = 0.7f;

        private static readonly string customPrecisionFormat = "F4";

        // je met 0 dedans à priori,
        // mais in fine on fera une recherche dans la liste des activePlayers en début de partie pour trouver celui qui a le bon identifiant,
        // et on prendra son index dans la liste à chaque partie 1 fois
        private static int localPlayerIndexInList = 0;
        // pareil qu'au dessus mais avec index à 1 à priori
        private static int otherPlayerIndexInList = 1;

        private static readonly int selectedIndex = 1;

        private static bool menuEnabled = false;

        private static readonly string testPath = Environment.UserName.StartsWith("Pey") ? "D:\\SteamLibrary\\steamapps\\common\\Crab Game\\test\\" : "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Crab Game\\test\\";


        public static void CheckFileExists()
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "Speed: [SPEED] u/s\tRotation: [ROTATION]\tPosition: [POSITION]\n" +
                    "________________________________________________________________________________\n" +
                    "Speed: [OTHERSPEED] u/s\tRotation: [OTHERROTATION]\tPosition: [OTHERPOSITION]\n" +
                    "[OTHERPLAYERNAME]\t [SELECTEDINDEX]\n" +
                    "Status: [STATUS]", Encoding.UTF8);
            }
        }

        public static void LoadLayout()
        {
            layout = File.ReadAllText(path, Encoding.UTF8);
        }

        public override void Load()
        {
            ClassInjector.RegisterTypeInIl2Cpp<DebugMenu>();
            DebugDataCallbacks = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<object>>();
            // Plugin startup logic
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            path = Directory.GetParent(Application.dataPath) + "\\DebugLayout.txt";
            Harmony.CreateAndPatchAll(typeof(Plugin));
            CheckFileExists();
            LoadLayout();
            RegisterDefaultCallbacks();
        }

        public static void RegisterDataCallback(string s, System.Collections.Generic.List<object> f)
        {
            DebugDataCallbacks.Add(s, f);
        }

        public static void RegisterDataCallbacks(System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<object>> dict)
        {
            foreach (System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.List<object>> pair in dict)
            {
                DebugDataCallbacks.Add(pair.Key, pair.Value);
            }
        }

        public static void RegisterDefaultCallbacks()
        {
            System.Collections.Generic.List<System.Collections.Generic.List<object>> listOfFuncsAndArgs = new()
            {
                new() { (object)GetPlayerSpeedAsString,          (object)localPlayerIndexInList },
                new() { (object)GetPlayerRotationAsString,       (object)localPlayerIndexInList },
                new() { (object)GetPlayerPositionAsString,       (object)localPlayerIndexInList },
                new() { (object)GetPlayerUsernameAsString,       (object)otherPlayerIndexInList },
                new() { (object)GetPlayerSpeedAsString,          (object)otherPlayerIndexInList },
                new() { (object)GetPlayerPositionAsString,  (object)otherPlayerIndexInList },
                new() { (object)GetPlayerRotationAsString,  (object)otherPlayerIndexInList },
/*
                new() { (object)GetSelectedIndexAsString,        (object)null },
                new(){ (object)GetStatusAsString,                (object)null }
*/
            };

            RegisterDataCallbacks(new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<object>>(){
                {"SPEED",           listOfFuncsAndArgs[0]},
                {"POSITION",        listOfFuncsAndArgs[1]},
                {"ROTATION",        listOfFuncsAndArgs[2]},
                {"OTHERPLAYERNAME", listOfFuncsAndArgs[3]},
                {"OTHERSPEED",      listOfFuncsAndArgs[4]},
                {"OTHERPOSITION",   listOfFuncsAndArgs[5]},
                {"OTHERROTATION",   listOfFuncsAndArgs[6]},
/*
                {"SELECTEDINDEX",   listOfFuncsAndArgs[7]},
                {"STATUS",          listOfFuncsAndArgs[8]},
*/
            });
        }

        public static string FormatLayout()
        {
            string formatted = layout;
            foreach (System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.List<object>> pair in DebugDataCallbacks)
            {
                int? functionArgument = (int?)pair.Value[1];
                
                if (functionArgument.HasValue)
                {
                    formatted = formatted.Replace("[" + pair.Key + "]", (pair.Value[0] as Func<int, string>)((int)pair.Value[1]));
                }
                else
                {
                    formatted = formatted.Replace("[" + pair.Key + "]", (pair.Value[0] as Func<string>)());
                }
            }
            return formatted;
        }

        public static string GetGameModeId()
        {
            return UnityEngine.Object.FindObjectOfType<LobbyManager>().gameMode.id.ToString();
        }
        public static string GetMapId()
        {
            return UnityEngine.Object.FindObjectOfType<LobbyManager>().map.id.ToString();
        }
        public static string GetCurrentGameTimer()
        {
            int seconds = UnityEngine.Object.FindObjectOfType<TimerUI>().field_Private_TimeSpan_0.Seconds;
            int minutes = UnityEngine.Object.FindObjectOfType<TimerUI>().field_Private_TimeSpan_0.Minutes;

            return (seconds + 1 + minutes * 60).ToString();
        }


        public static string GetPlayerUsernameAsString(int playerIndexInList)
        {
            string name = "";
            PlayerManager activePlayer = activePlayers.entries.ToList()[playerIndexInList].value;

            if (activePlayer != null)
                name = activePlayer.username.ToString();

            return activePlayer == null ? "Them" : name;
        }

        public static string GetSelectedIndexAsString()
        {
            string value = selectedIndex.ToString();

            return value;
        }
        /*

        public static Rigidbody GetOtherPlayerBody()
        {
            return activePlayers.entries.ToList()[1]?.value.GetComponent<Rigidbody>();
        }

        public static Vector3? GetOtherPlayerPosition(int otherPlayerIndexInList = 1)
        {
            return activePlayers.entries.ToList()[otherPlayerIndexInList]?.value.gameObject.transform.position;
        }

        public static string GetOtherPlayerPositionAsString()
        {
            Vector3? otherPlayerPosition = GetOtherPlayerPosition();
            return otherPlayerPosition.HasValue ? "" : "(" + otherPlayerPosition.Value.x.ToString(customPrecisionFormat) + ";" + otherPlayerPosition.Value.y.ToString(customPrecisionFormat) + ";" + otherPlayerPosition.Value.z.ToString(customPrecisionFormat) + ")";
        }

        public static string GetOtherPlayerRotationAsString(int otherPlayerIndexInList)
        {
            Vector3? otherPlayerRotation = GetPlayerRotation(otherPlayerIndexInList);
            return otherPlayerRotation.HasValue ? "" : "(" + otherPlayerRotation.Value.x.ToString(customPrecisionFormat) + ";" + otherPlayerRotation.Value.y.ToString(customPrecisionFormat) + ";" + otherPlayerRotation.Value.z.ToString(customPrecisionFormat) + ")";

        }*/


        public static string GetStatusAsString()
        {
            string mode = GetGameModeId();

            if (smoothedSpeed > 45 && mode != "10")
            {
                trigger += 1;
                if (trigger >= 5 && trigger < 40)
                    return "CHEAT (or Sussy Slope)";
                if (trigger >= 40)
                    ChatBox.Instance.SendMessage(activePlayers.entries.ToList()[1].value.username.ToString() + " is cheating. Speed for more 8 sec = " + smoothedSpeed.ToString(customPrecisionFormat));
                trigger = 0;
                return "";
            }
            else if (smoothedSpeed > 30 && mode != "10")
            {
                trigger += 1;
                if (trigger >= 5 && trigger < 40)
                    return "FAST";
                if (trigger >= 40)
                    ChatBox.Instance.SendMessage(activePlayers.entries.ToList()[1].value.username.ToString() + " is sus. Speed for more 8 sec = " + smoothedSpeed.ToString(customPrecisionFormat));
                trigger = 0;
                return "";
            }
            else if (smoothedSpeed > 21)
            {
                if (trigger < 5)
                    trigger += 1;
                if (trigger > 5)
                    trigger -= 1;
                if (trigger >= 5)
                    return "MOONWALK";
                return "";
            }
            else if (smoothedSpeed > 5)
            {
                if (trigger < 5)
                    trigger += 1;
                if (trigger > 5)
                    trigger -= 1;
                if (trigger >= 5)
                    return "MOVING";
                return "";
            }
            else if (smoothedSpeed <= 5)
            {
                if (trigger < 5)
                    trigger += 1;
                if (trigger > 5)
                    trigger -= 1;
                if (trigger >= 5)
                    return "IDLE";
                return "";
            }

            if (trigger > 0)
                trigger += -1;
            return "";
        }


        public static double? DEBUG_BOBI_GetPlayerSpeed(int playerIndexInList)
        {
            //Rigidbody rb = GetOtherPlayerBody();


            //Vector3 velocity = new(); GetOtherPlayerBody()?.get_velocity_Injected(out velocity); return velocity.magnitude;
            return GetPlayerBody(playerIndexInList)?.velocity.magnitude;
        }

        public static string DEBUG_BOBI_GetPlayerSpeedAsString(int playerIndexInList)
        {
            double? speed = DEBUG_BOBI_GetPlayerSpeed(playerIndexInList);
            return speed.HasValue ? "" : speed.Value.ToString(customPrecisionFormat);
        }

        /*
        public static string GetOtherPlayerSpeedAsString()
        {
            double speedDouble, distance;
            Vector3 pos, oldpos;
            Vector3? posxyz = GetOtherPlayerPosition();
            Vector3? oldposxyz = oldOtherPlayerPosition;

            if (posxyz.HasValue && oldposxyz.HasValue)
            {
                pos = new Vector3(posxyz.Value.x, 0f, posxyz.Value.z);
                oldpos = new Vector3(oldposxyz.Value.x, 0f, oldposxyz.Value.z);
                distance = Math.Sqrt(Math.Pow(pos.x - oldpos.x, 2) + Math.Pow(pos.y - oldpos.y, 2) + Math.Pow(pos.z - oldpos.z, 2));
                speedDouble = distance / 0.2;
                smoothedSpeed = (float)((smoothedSpeed * smoothingFactor + (1 - smoothingFactor) * speedDouble) * 0.99);
                string speed = smoothedSpeed.ToString("0.0");
                return speed;
            }

            return "";
        }
        */

        public static Camera GetCamera()
        {
            return UnityEngine.Object.FindObjectOfType<Camera>();
        }

        public static Vector3? GetPlayerRotation(int playerIndexInList)
        {
            if (playerIndexInList == localPlayerIndexInList)
            {
                return GetCamera()?.transform.rotation.eulerAngles;
            }

            return activePlayers.entries.ToList()[playerIndexInList]?.value.head.gameObject.transform.eulerAngles;

        }

        public static string GetPlayerRotationAsString(int playerIndexInList)
        {
            if (playerIndexInList == localPlayerIndexInList)
            {
                Camera cam = GetCamera();
                return cam == null ? "" : cam.transform.rotation.eulerAngles.ToString(customPrecisionFormat);
            }

            return activePlayers.entries.ToList()[playerIndexInList]?.value.head.gameObject.transform.eulerAngles.ToString(customPrecisionFormat);

        }

        public static Rigidbody GetPlayerBody(int playerIndexInList)
        {
            if (playerIndexInList == localPlayerIndexInList)
            {
                return GameObject.Find("/Player")?.GetComponent<Rigidbody>();
            }
            return activePlayers.entries.ToList()[playerIndexInList]?.value.GetComponent<Rigidbody>();
        }

        public static Vector3? GetPlayerPosition(int playerIndexInList)
        {
            return GetPlayerBody(playerIndexInList)?.transform.position;
        }

        public static string GetPlayerPositionAsString(int playerIndexInList)
        {
            Vector3? playerPos = GetPlayerPosition(playerIndexInList);

            return playerPos.HasValue ? "" : playerPos.Value.ToString(customPrecisionFormat);

        }
        public static double? GetPlayerSpeed(int playerIndexInList)
        {
            return GetPlayerBody(playerIndexInList)?.velocity.magnitude;
        }

        public static string GetPlayerSpeedAsString(int playerIndexInList)
        {
            double? speed = GetPlayerSpeed(playerIndexInList);

            return speed.HasValue ? "" : speed.Value.ToString(customPrecisionFormat);
        }


        static string FormatVectorString(string originalString)
        {
            return originalString.Replace(",", ";").Replace("(", "").Replace(")", "").Replace(" ", "");
        }

        /*
        static void CreateFileSafe(string path)
        {
            if (File.Exists(path))
            {


                FileStream fileStream = File.Open(path, FileMode.Open);

                fileStream.SetLength(0);
                fileStream.Close();

            }
            else
            {
                File.Create(path);
            }
        }
        */

        static void WriteOnFile(string path, string line)
        {
            using StreamWriter file = new(path, append: true);
            file.WriteLine(line);
        }

        /*        static void WriteOnFileSafe(string path, string line)
                {
                    CreateFileSafe(path);
                    WriteOnFile(path, line);
                }
        */
        static string StringsToCSV(string[] array)
        {
            string result = "";

            if (array.Length > 0)
            {
                StringBuilder sb = new();

                foreach (string s in array)
                {
                    sb.Append(s).Append(",");
                }

                result = sb.Remove(sb.Length - 1, 1).ToString();
            }

            return result;
        }

        static void LogSpeed(int playerIndexInList, bool logToChatNotFile = false)
        {
            string path = testPath + "speedOpponent.txt";

            string speedString = GetPlayerSpeedAsString(playerIndexInList);

            if (logToChatNotFile)
            {
                ChatBox.Instance.ForceMessage(speedString);
            }
            else
            {
                WriteOnFile(path, speedString);
            }
        }

        static void LogPos(int playerIndexInList, bool logToChatNotFile = false)
        {
            string path = testPath + "pos.txt";

            string posString = GetPlayerPositionAsString(playerIndexInList);

            if (logToChatNotFile)
            {
                ChatBox.Instance.ForceMessage(posString);
            }
            else
            {
                WriteOnFile(path, posString);
            }
        }

        static void LogRotation(int playerIndexInList, bool logToChatNotFile = false)
        {
            string path = testPath + "rotation.txt";

            string rot = GetPlayerRotationAsString(playerIndexInList);

            if (logToChatNotFile)
            {
                ChatBox.Instance.ForceMessage(rot);
            }
            else
            {
                WriteOnFile(path, rot);
            }
        }

        static void LogDistFromOther(int playerIndexInList, int otherPlayerIndexInList, bool logToChatNotFile = false)
        {
            string path = testPath + "distance.txt";

            Vector3? pos1 = GetPlayerPosition(playerIndexInList);

            Vector3? pos2 = GetPlayerPosition(otherPlayerIndexInList);

            if (pos1.HasValue && pos2.HasValue)
            {
                Double distance = Math.Sqrt(Math.Pow(pos1.Value.x - pos2.Value.x, 2) + Math.Pow(pos1.Value.y - pos2.Value.y, 2) + Math.Pow(pos1.Value.z - pos2.Value.z, 2));
                if (logToChatNotFile)
                {
                    ChatBox.Instance.ForceMessage(distance.ToString(customPrecisionFormat));
                }
                else
                {
                    WriteOnFile(path, distance.ToString(customPrecisionFormat));
                }
            }

        }

        static void LogDirFromOther(int playerIndexInList, int otherPlayerIndexInList, bool logToChatNotFile = false)
        {
            string path = testPath + "direction.txt";

            Vector3? pos1 = GetPlayerPosition(playerIndexInList);

            Vector3? pos2 = GetPlayerPosition(otherPlayerIndexInList);

            Vector3? dir;

            String logString = "";

            if (pos1.HasValue && pos2.HasValue)
            {
                dir = new((pos2.Value.x - pos2.Value.x), (pos2.Value.y - pos1.Value.y), (pos2.Value.z - pos1.Value.z));
                
                dir.Value.Normalize();

                logString = dir.Value.ToString(customPrecisionFormat);
            }


            if (logToChatNotFile)
            {
                ChatBox.Instance.ForceMessage(logString);
            }
            else
            {
                WriteOnFile(path, logString);
            }


        }

        static void LogHealth(int playerIndexInList, bool logToChatNotFile = false)
        {
            string path = testPath + "health.txt";

            PlayerStatus playerStatus = activePlayers.entries.ToList()[playerIndexInList].value.GetComponent<PlayerStatus>();

            string health = playerStatus.currentHp.ToString();

            if (logToChatNotFile)
            {
                ChatBox.Instance.ForceMessage(health);
            }
            else
            {
                WriteOnFile(path, health);
            }
        }


        static void LogIsTagged(int playerIndexInList, bool logToChatNotFile = false)
        {
            path = testPath + "tagged.txt";

            PlayerInventory playerInventory = activePlayers.entries.ToList()[playerIndexInList].value.GetComponent<PlayerInventory>();


            if (playerInventory.currentItem != null)
            {
                if (logToChatNotFile)
                {
                    ChatBox.Instance.ForceMessage("You are tagged");
                }
                else
                {
                    WriteOnFile(path, "You are tagged");
                }
            }
        }


        static void LogInputLocalPlayer(bool logToChatNotFile = false)
        {
            string path = testPath + "input.txt";

            System.Collections.Generic.List<string> list = new();

            if (Input.GetKey("z"))
                list.Add("1");
            else
                list.Add("0");
            if (Input.GetKey("q"))
                list.Add("1");
            else
                list.Add("0");
            if (Input.GetKey("s"))
                list.Add("1");
            else
                list.Add("0");
            if (Input.GetKey("d"))
                list.Add("1");
            else
                list.Add("0");
            if (Input.GetKeyDown("space"))
                list.Add("1");
            else
                list.Add("0");
            if (Input.GetKey("left shift"))
                list.Add("1");
            else
                list.Add("0");
            if (Input.GetKey("left ctrl"))
                list.Add("1");
            else
                list.Add("0");
            if (Input.GetMouseButtonDown(0))
                list.Add("1");
            else
                list.Add("0");

            String[] keys = list.ToArray();

            if (logToChatNotFile)
            {
                ChatBox.Instance.ForceMessage(StringsToCSV(keys));
            }
            else
            {
                WriteOnFile(path, StringsToCSV(keys));
            }

        }

        public class DebugMenu : MonoBehaviour
        {
            public Text text;

            DateTime start = DateTime.Now;

            void Update()
            {
                DateTime end = DateTime.Now;

                TimeSpan ts = (end - start);

                text.text = menuEnabled ? FormatLayout() : "";

                if (ts.TotalMilliseconds >= 200)
                {
                    start = DateTime.Now;
                    //oldOtherPlayerPosition = GetOtherPlayerPosition();
                }

                if (GameManager.Instance.isActiveAndEnabled)
                {
                    if (Input.GetKeyDown("f3"))
                    {
                        menuEnabled = !menuEnabled;
                        activePlayers = GameManager.Instance.activePlayers;
                    }

                    // DANS LE CHAT
                    if (Input.GetKeyDown("f4"))
                    {
                        LogPos(localPlayerIndexInList, true);
                        LogDistFromOther(localPlayerIndexInList, otherPlayerIndexInList, true);
                        LogDirFromOther(localPlayerIndexInList, otherPlayerIndexInList, true);
                        LogHealth(localPlayerIndexInList, true);
                        LogIsTagged(localPlayerIndexInList, true);
                        LogSpeed(localPlayerIndexInList, true);
                        LogRotation(localPlayerIndexInList, true);

                        LogInputLocalPlayer(true);
                    }

                    // DANS LE FILE
                    if (Input.GetKeyDown("f5"))
                    {
                        LogPos(localPlayerIndexInList, false);
                        LogDistFromOther(localPlayerIndexInList, otherPlayerIndexInList, false);
                        LogDirFromOther(localPlayerIndexInList, otherPlayerIndexInList, false);
                        LogHealth(localPlayerIndexInList, false);
                        LogIsTagged(localPlayerIndexInList, false);
                        LogSpeed(localPlayerIndexInList, false);
                        LogRotation(localPlayerIndexInList, false);

                        LogInputLocalPlayer(false);
                    }

                    /*
                    if (Input.GetKeyDown("left") && selectedIndex > 1)
                    {
                        selectedIndex -= 1;
                        smoothedSpeed = 0;

                        oldOtherPlayerPosition = activePlayers.entries.ToList()[selectedIndex].value.transform.position;
                    }
                    if (Input.GetKeyDown("right") && selectedIndex < 40)
                    {
                        selectedIndex += 1;
                        smoothedSpeed = 0;

                        oldOtherPlayerPosition = activePlayers.entries.ToList()[selectedIndex].value.transform.position;
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
            /*
            Plugin.playerBody = null;
            Plugin.otherPlayerBody = null;
            Plugin.otherPlayerUsername = null;
            */
            menuObject.transform.SetParent(__instance.transform);
            menuObject.transform.localPosition = new Vector3(menuObject.transform.localPosition.x, -menuObject.transform.localPosition.y, menuObject.transform.localPosition.z);
            RectTransform rt = menuObject.GetComponent<RectTransform>();
            rt.pivot = new Vector2(0, 1);
            rt.sizeDelta = new Vector2(1000, 1000);
        }
    }
}