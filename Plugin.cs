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
        public static System.Collections.Generic.Dictionary<string,System.Func<string>> DebugDataCallbacks;

        public static void registerDataCallback(string s, System.Func<string> f){
            DebugDataCallbacks.Add(s,f);
        }
        public static void registerDataCallbacks(System.Collections.Generic.Dictionary<string,System.Func<string>> dict){
            foreach (System.Collections.Generic.KeyValuePair<string,System.Func<string>> pair in dict){
                DebugDataCallbacks.Add(pair.Key,pair.Value);
            }
        }
        public static void checkFileExists(){
            if (!System.IO.File.Exists(path)){
                System.IO.File.WriteAllText(path,"Speed: [SPEED] u/s\nPosition: [POSITION]",System.Text.Encoding.UTF8);
            }
        }
        public static void loadLayout(){
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
            checkFileExists();
            loadLayout();
            registerDefaultCallbacks();
        }
        public static void registerDefaultCallbacks(){
            registerDataCallbacks(new System.Collections.Generic.Dictionary<string,System.Func<string>>(){
                {"SPEED",getPlayerSpeed},
                {"POSITION",getPlayerPos}
            });
        }
        public static Rigidbody getPlayerBody(){
            GameObject obj = GameObject.Find("/Player");
            return obj==null?null:obj.GetComponent<Rigidbody>();
        }
        public static Rigidbody getPlayerBodySafe(){
            if (playerBody==null){
                playerBody=getPlayerBody();
            }
            return playerBody;
        }
        public static string getPlayerSpeed()
        {
            Rigidbody rb = getPlayerBodySafe();
            return rb == null ? "" : rb.velocity.magnitude.ToString("0.00");
        }
        public static string getPlayerPos(){
            Rigidbody rb = getPlayerBodySafe();
            return rb==null?"":rb.transform.position.ToString();
        }

        public static Camera getCamera()
        {
            return UnityEngine.Object.FindObjectOfType<Camera>();
        }
        public static Camera getCameraSafe()
        {
            if (camera == null)
            {
                camera = getCamera();
            }
            return camera;
        }
        public static string getPlayerRotation(){
                   Camera cam = getCameraSafe();
                   return cam == null?"" : cam.transform.rotation.ToString();
               }
        
        static void createFileSafe(string path)
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
        
        static async Task writeOnFile(string path, string line)
        {
            using StreamWriter file = new(path, append: true);
            await file.WriteLineAsync(line);
        }
        
        static async Task writeOnFileSafe(string path, string line)
        {
            createFileSafe(path);
            await writeOnFile(path, line);
        }
        static string stringsToCSV(string[] array)
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

        static void logSpeedOther(string path)
        {
            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;
            float speed = activePlayers.entries.ToList()[1].value.GetComponent<Rigidbody>().velocity.magnitude;

            writeOnFile(path, speed.ToString("0.0000"));

        }

        static void logPos(string path)
        {
            List<string> list = new List<string>();

        
            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;
            foreach (Il2CppSystem.Collections.Generic.KeyValuePair<ulong, PlayerManager> pair in activePlayers)
            {
                //if (pair.Value.dead)  
                    //a normaliser!?
                  //  list.Add("0;-1000000;0");
                //else { 
                list.Add(pair.Value.transform.position.ToString("0.0000").Replace(",",";").Replace("(","").Replace(")","").Replace(" ",""));
                //}
            }

            String[] pos = list.ToArray();
            writeOnFile(path, stringsToCSV(pos));
        }

        static void logDistFromOther(string path)
        {
            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;
            UnityEngine.Vector3 pos1 = activePlayers.entries.ToList()[0].value.transform.position;
            UnityEngine.Vector3 pos2 = activePlayers.entries.ToList()[1].value.transform.position;

            Double distance = Math.Sqrt(Math.Pow(pos1.x - pos2.x, 2) + Math.Pow(pos1.y - pos2.y, 2) + Math.Pow(pos1.z - pos2.z, 2));
            writeOnFile(path, distance.ToString("0.0000"));
        }

        static void logDirFromOther(string path)
        {
            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;
            UnityEngine.Vector3 pos1 = activePlayers.entries.ToList()[0].value.transform.position;
            UnityEngine.Vector3 pos2 = activePlayers.entries.ToList()[1].value.transform.position;

            UnityEngine.Vector3 dir = new UnityEngine.Vector3((pos2.x - pos1.x ), (pos2.y - pos1.y),(pos2.z - pos1.z));
            writeOnFile(path, dir.ToString("0.0000").Replace(",", ";").Replace("(", "").Replace(")", "").Replace(" ", ""));
        }



        static void logHealth(string path)
        {
            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;

            PlayerStatus playerStatus = activePlayers.entries.ToList()[0].value.GetComponent<PlayerStatus>();

            string health = playerStatus.currentHp.ToString();

            writeOnFile(path, health);
        }


        static void amITagged()
        {
            Il2CppSystem.Collections.Generic.Dictionary<ulong, PlayerManager> activePlayers = gameManager.activePlayers;

            PlayerInventory playerInventory = activePlayers.entries.ToList()[0].value.GetComponent<PlayerInventory>();


            if (playerInventory.currentItem != null)
                ChatBox.Instance.ForceMessage("You are tagged");
        }

        static void logInput(string path)
        {
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

            writeOnFile(path,stringsToCSV(keys));
        }


        public static string formatLayout(){
            string formatted = layout;
            foreach (System.Collections.Generic.KeyValuePair<string,System.Func<string>> pair in DebugDataCallbacks){
                formatted = formatted.Replace("["+pair.Key+"]",pair.Value());
            }
            return formatted;
        }
        public class DebugMenu : MonoBehaviour {
            public Text text;
            bool MenuEnabled = false;

            void Update(){

                text.text = MenuEnabled ? formatLayout() : ""; 
                if(Input.GetKeyDown("f3")){
                    
                    if (gameManager == null)
                        gameManager = GameObject.Find("/GameManager (1)").GetComponent<GameManager>();
                    //ChatBox.Instance.ForceMessage("Data Registered");
                    MenuEnabled = !MenuEnabled;
                    amITagged();
                    logPos("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Crab Game\\test\\pos.txt");
                    logDistFromOther("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Crab Game\\test\\distance.txt");
                    logDirFromOther("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Crab Game\\test\\direction.txt");
                    logSpeedOther("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Crab Game\\test\\speedOpponent.txt");
                    logHealth("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Crab Game\\test\\health.txt");
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
            menuObject.transform.SetParent(__instance.transform);
            menuObject.transform.localPosition = new UnityEngine.Vector3(menuObject.transform.localPosition.x,-menuObject.transform.localPosition.y,menuObject.transform.localPosition.z);
            RectTransform rt = menuObject.GetComponent<RectTransform>();
            rt.pivot = new UnityEngine.Vector2(0,1);
            rt.sizeDelta = new UnityEngine.Vector2(1000,1000);
        }
    }
}
