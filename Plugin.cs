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
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;



using UnityEngine.Rendering;
using Cpp2IL.Core.Analysis.PostProcessActions;
using System.Numerics;
using System.Linq;
using Cpp2IL.Core.Analysis.Actions.x86;

namespace DebugMenu
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        public static Camera camera;
        static GameManager gameManager;
        static string layout;
        static string path;
        public static Rigidbody playerBody;
        public static Rigidbody otherPlayerBody;
        public static string otherPlayerUsername;
        public static float otherPlayerSpeed;

        public static UnityEngine.Vector3 playerOtherPosition;
        public static UnityEngine.Vector3 oldOtherPlayerPosition;
        public static System.Collections.Generic.Dictionary<string,System.Func<string>> DebugDataCallbacks;
        public static int i = 0;
        public static int trigger = 0;
        private static float smoothedSpeed = 0;
        private static float smoothingFactor = 0.7f;

        private static string testPath = Environment.UserName.StartsWith("Pey") ? "D:\\SteamLibrary\\steamapps\\common\\Crab Game\\test\\" : "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Crab Game\\test\\";
        
        public static void RegisterDataCallback(string s, System.Func<string> f){
            DebugDataCallbacks.Add(s,f);
        }
        public static void RegisterDataCallbacks(System.Collections.Generic.Dictionary<string,System.Func<string>> dict){
            foreach (System.Collections.Generic.KeyValuePair<string,System.Func<string>> pair in dict){
                DebugDataCallbacks.Add(pair.Key,pair.Value);
            }
        }
        public static void CheckFileExists(){
            if (!System.IO.File.Exists(path)){
                System.IO.File.WriteAllText(path,"Speed: [SPEED] u/s\nPosition: [POSITION]",System.Text.Encoding.UTF8);
            }
        }
        public static void LoadLayout(){
            layout = System.IO.File.ReadAllText(path,System.Text.Encoding.UTF8);
        }
        public override void Load()
        {
            ClassInjector.RegisterTypeInIl2Cpp<DebugMenu>();
            DebugDataCallbacks = new System.Collections.Generic.Dictionary<string, System.Func<string>>();
            // Plugin startup logic
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            path = System.IO.Directory.GetParent(Application.dataPath)+"\\DebugLayout.txt";
            Harmony.CreateAndPatchAll(typeof(Plugin));
            CheckFileExists();
            LoadLayout();
            RegisterDefaultCallbacks();
        }
        public static void RegisterDefaultCallbacks(){
            RegisterDataCallbacks(new System.Collections.Generic.Dictionary<string,System.Func<string>>(){
                {"SPEED", GetPlayerSpeed},
                {"ROTATION", GetPlayerRotation},
                {"POSITION", GetPlayerPosition},
                {"OTHERPLAYER", GetOtherPlayerUsername},
                {"OTHERSPEED", GetOtherPlayerSpeed},
                {"OTHERPOSITION", GetOtherPlayerPositionStr},
                {"i", GetI},
                {"STATUS", GetStatus}

            });
        }
        public static string GetOtherPlayerUsername()
        {
            string name = gameManager.activePlayers.entries.ToList()[i].value.username.ToString();
            return name == null ? "You" : name;
        }

        public static string GetI()
        {
            string value = i.ToString();    

            return value;
        }
        public static Rigidbody GetOtherPlayerBody()
        {
            Rigidbody rb = gameManager.activePlayers.entries.ToList()[i].value.GetComponent<Rigidbody>();
            return rb == null ? GetPlayerBody() : rb;
        }
      
        public static UnityEngine.Vector3 GetOtherPlayerPosition()
        {

            Rigidbody rb = GetOtherPlayerBody();
            UnityEngine.Vector3 position = new UnityEngine.Vector3(rb.position.x, rb.position.y, rb.position.z);
            return rb == null ? new UnityEngine.Vector3(0,0,0): position;
        }
        public static string GetOtherPlayerPositionStr()
        {
            Rigidbody rb = GetOtherPlayerBody();
            UnityEngine.Vector3 position = new UnityEngine.Vector3(rb.position.x, rb.position.y, rb.position.z);
            return rb == null ? new UnityEngine.Vector3(0, 0, 0).ToString() : position.ToString();
        }
        public static string GetStatus()
        {
            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;

            if (smoothedSpeed > 60)
            {
                trigger += 1;
                if (trigger >= 5)
                    return "CHEAT (or Sussy Slope)";
                if (trigger >= 50)
                    ChatBox.Instance.SendMessage(activePlayers.entries.ToList()[0].value.username.ToString() + " is cheating. Speed for more 10 sec = " + smoothedSpeed.ToString() );
                return "";
            }
            else if (smoothedSpeed > 30)
            {
                trigger += 1;
                if (trigger >= 5)
                    return "FAST";
                if (trigger >= 50)
                    ChatBox.Instance.SendMessage(activePlayers.entries.ToList()[0].value.username.ToString() + " is sus. Speed for more 10 sec = " + smoothedSpeed.ToString());
                return "";
            }
            else if(smoothedSpeed > 21)
            {
                trigger += 1;
                if (trigger >= 5)
                    return "MOONWALK";
                return "";
            }
            else if (smoothedSpeed > 5)
            {
                trigger += 1;
                if (trigger >= 5)
                    return "MOVING";
                return "";
            }
            else if (smoothedSpeed <= 5)
            {
                trigger += 1;
                if (trigger >= 5)
                    return "IDLE";
                return "";
            }

            if (trigger > 0)
                trigger -= 1;
            return "";
        }

        public static string GetOtherPlayerSpeed()
        {
            UnityEngine.Vector3 posxyz = GetOtherPlayerPosition();
            UnityEngine.Vector3 oldposxyz = oldOtherPlayerPosition;

            UnityEngine.Vector3 pos = new UnityEngine.Vector3(posxyz.x, 0f, posxyz.z);
            UnityEngine.Vector3 oldpos = new UnityEngine.Vector3(oldposxyz.x, 0f, oldposxyz.z);
            double distance = Math.Sqrt(Math.Pow(pos.x - oldpos.x, 2) + Math.Pow(pos.y - oldpos.y, 2) + Math.Pow(pos.z - oldpos.z, 2));

            double speedDouble = distance / 0.2;

            smoothedSpeed = (float)((smoothedSpeed * smoothingFactor + (1 - smoothingFactor) * speedDouble) * 0.99);
            string speed = smoothedSpeed.ToString("0.0");

            return speed;
        }

        public static Camera GetCamera()
        {
            return UnityEngine.Object.FindObjectOfType<Camera>();
        }
        public static Camera GetCameraSafe()
        {
            if (camera == null)
            {
                camera = GetCamera();
            }
            return camera;
        }
        public static string GetPlayerRotation(){
                   Camera cam = GetCameraSafe();
                   return cam == null?"" : cam.transform.rotation.eulerAngles.ToString();
        }
        public static Rigidbody GetPlayerBody()
        {
            GameObject obj = GameObject.Find("/Player");
            return obj == null ? null : obj.GetComponent<Rigidbody>();
        }
        public static Rigidbody GetPlayerBodySafe()
        {
            if (playerBody == null)
            {
                playerBody = GetPlayerBody();
            }
            return playerBody;
        }
        public static string GetPlayerPosition()
        {
            Rigidbody rb = GetPlayerBodySafe();
            return rb == null ? "" : rb.transform.position.ToString();
        }
        public static string GetPlayerSpeed()
        {
            Rigidbody rb = GetPlayerBodySafe();

            UnityEngine.Vector3 velocity = new UnityEngine.Vector3(rb.velocity.x, 0f, rb.velocity.z);

            return rb == null ? "" : velocity.magnitude.ToString("0.00");
        }

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
        
        static async Task WriteOnFile(string path, string line)
        {
            using StreamWriter file = new(path, append: true);
            await file.WriteLineAsync(line);
        }
        
        static async Task writeOnFileSafe(string path, string line)
        {
            CreateFileSafe(path);
            await WriteOnFile(path, line);
        }
        static string StringsToCSV(string[] array)
        {
            string result = "";

            if (array.Length > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (string s in array)
                {
                    sb.Append(s).Append(",");
                }

                result = sb.Remove(sb.Length - 1, 1).ToString();
            }

            return result;
        }

        static void LogSpeedOther(bool logToChatNotFile = false)
        {
            string path = testPath + "speedOpponent.txt";
            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;
            float speed = activePlayers.entries.ToList()[1].value.GetComponent<Rigidbody>().velocity.magnitude;

            if (logToChatNotFile)
            {
                ChatBox.Instance.ForceMessage(speed.ToString("0.0000"));
            }
            else
            {
                WriteOnFile(path, speed.ToString("0.0000"));
            }


        }

        static void LogPos(bool logToChatNotFile = false)
        {

            string path = testPath + "pos.txt";

            List<string> list = new List<string>();


            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;
            foreach (Il2CppSystem.Collections.Generic.KeyValuePair<ulong, PlayerManager> pair in activePlayers)
            {
                //if (pair.Value.dead)  
                //a normaliser!?
                //  list.Add("0;-1000000;0");
                //else { 
                list.Add(pair.Value.transform.position.ToString("0.0000").Replace(",", ";").Replace("(", "").Replace(")", "").Replace(" ", ""));
                //}
            }

            String[] pos = list.ToArray();

            if (logToChatNotFile)
            {
                ChatBox.Instance.ForceMessage(StringsToCSV(pos));
            }
            else
            {
                WriteOnFile(path, StringsToCSV(pos));
            }
        }

        static void LogDistFromOther(bool logToChatNotFile = false)
        {
            string path = testPath + "distance.txt";
            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;
            UnityEngine.Vector3 pos1 = activePlayers.entries.ToList()[0].value.transform.position;
            UnityEngine.Vector3 pos2 = activePlayers.entries.ToList()[1].value.transform.position;

            Double distance = Math.Sqrt(Math.Pow(pos1.x - pos2.x, 2) + Math.Pow(pos1.y - pos2.y, 2) + Math.Pow(pos1.z - pos2.z, 2));

            if (logToChatNotFile)
            {
                ChatBox.Instance.ForceMessage(distance.ToString("0.0000"));
            }
            else
            {
                WriteOnFile(path, distance.ToString("0.0000"));
            }
        }

        static void LogDirFromOther(bool logToChatNotFile = false)
        {
            string path = testPath + "direction.txt";

            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;
            UnityEngine.Vector3 pos1 = activePlayers.entries.ToList()[0].value.transform.position;
            UnityEngine.Vector3 pos2 = activePlayers.entries.ToList()[1].value.transform.position;

            UnityEngine.Vector3 dir = new UnityEngine.Vector3((pos2.x - pos1.x), (pos2.y - pos1.y), (pos2.z - pos1.z));

            if (logToChatNotFile)
            {
                ChatBox.Instance.ForceMessage(dir.ToString("0.0000").Replace(",", ";").Replace("(", "").Replace(")", "").Replace(" ", ""));
            }
            else
            {
                WriteOnFile(path, dir.ToString("0.0000").Replace(",", ";").Replace("(", "").Replace(")", "").Replace(" ", ""));
            }
        }



        static void LogHealth(bool logToChatNotFile = false)
        {
            string path = testPath + "health.txt";
            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;

            PlayerStatus playerStatus = activePlayers.entries.ToList()[0].value.GetComponent<PlayerStatus>();

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


        static void AmITagged(bool logToChatNotFile = false)
        {
            path = testPath + "tagged.txt";
            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;

            PlayerInventory playerInventory = activePlayers.entries.ToList()[0].value.GetComponent<PlayerInventory>();


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


            //UnityEngine.Object.FindObjectOfType<MusicController>().PlaySong(SongType.WinMusic);
        }



        static void LogInput(bool logToChatNotFile = false)
        {
            string path = testPath + "input.txt";

            List<string> list = new List<string>();

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


        public static string FormatLayout(){
            string formatted = layout;
            foreach (System.Collections.Generic.KeyValuePair<string,System.Func<string>> pair in DebugDataCallbacks){
                formatted = formatted.Replace("["+pair.Key+"]",pair.Value());
            }
            return formatted;
        }
        public class DebugMenu : MonoBehaviour {
            public Text text;
            bool MenuEnabled = false;

            DateTime start = DateTime.Now;

            void Update(){



                DateTime end = DateTime.Now;

                TimeSpan ts = (end - start);
                if (ts.TotalMilliseconds >= 200)
                {
                    start = DateTime.Now;
                    text.text = MenuEnabled ? FormatLayout() : "";
                    oldOtherPlayerPosition = GetOtherPlayerPosition();
                    AmITagged(false);
                }
                if(Input.GetKeyDown("f3")){
                    gameManager = GameObject.Find("/GameManager (1)").GetComponent<GameManager>();
                    //ChatBox.Instance.ForceMessage("Data Registered");
                    MenuEnabled = !MenuEnabled;
                    LogPos(false);
                    LogDistFromOther(false);
                    LogDirFromOther(false);
                    LogHealth(false);
                    AmITagged(false);
                    LogSpeedOther(false);
                    LogInput(false);
                }
                if (Input.GetKeyDown("left") && i > 0)
                {
                    Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;
                    i -= 1;
                    smoothedSpeed = 0;

                    oldOtherPlayerPosition = activePlayers.entries.ToList()[i].value.transform.position;
                }
                if (Input.GetKeyDown("right") && i < 40)
                {
                    Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;
                    i += 1;
                    smoothedSpeed = 0;

                    oldOtherPlayerPosition = activePlayers.entries.ToList()[i].value.transform.position;
                }
            }
        }
        [HarmonyPatch(typeof(MonoBehaviourPublicGaroloGaObInCacachGaUnique),"Awake")]
        [HarmonyPostfix]
        public static void UIAwakePatch(MonoBehaviourPublicGaroloGaObInCacachGaUnique __instance){
            GameObject menuObject = new GameObject();
            Text text = menuObject.AddComponent<Text>();
            text.font = (Font)Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.raycastTarget = false;
            DebugMenu menu = menuObject.AddComponent<DebugMenu>();
            menu.text = text;
            Plugin.playerBody = null;
            Plugin.otherPlayerBody = null;
            Plugin.otherPlayerUsername = null;
            menuObject.transform.SetParent(__instance.transform);
            menuObject.transform.localPosition = new UnityEngine.Vector3(menuObject.transform.localPosition.x,-menuObject.transform.localPosition.y,menuObject.transform.localPosition.z);
            RectTransform rt = menuObject.GetComponent<RectTransform>();
            rt.pivot = new UnityEngine.Vector2(0,1);
            rt.sizeDelta = new UnityEngine.Vector2(1000,1000);
        }
    }
}
