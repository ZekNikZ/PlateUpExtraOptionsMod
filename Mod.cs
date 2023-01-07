using Kitchen;
using KitchenLib;
using KitchenLib.Event;
using KitchenLib.Registry;
using KitchenMods;
using System.Reflection;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using System.Linq;

// Namespace should have "Kitchen" in the beginning
namespace KitchenExtraOptionsMod
{
    public class Mod : BaseMod, IModSystem
    {
        // guid must be unique and is recommended to be in reverse domain name notation
        // mod name that is displayed to the player and listed in the mods menu
        // mod version must follow semver e.g. "1.2.3"
        public const string MOD_GUID = "ZekNikZ.PlateUp.ExtraOptionsMod";
        public const string MOD_NAME = "ExtraOptionsMod";
        public const string MOD_VERSION = "0.2.0";
        public const string MOD_AUTHOR = "ZekNikZ";
        public const string MOD_GAMEVERSION = ">=1.1.1";
        // Game version this mod is designed for in semver
        // e.g. ">=1.1.1" current and all future
        // e.g. ">=1.1.1 <=1.2.3" for all from/until

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        public static bool IsSeedExplorerInstalled => ModRegistery.Registered.Any(kv => kv.Value.ModID == "beaudenon.PlateUp.SeedExplorer");

        protected override void Initialise()
        {
            base.Initialise();
        }

        protected override void OnUpdate()
        {

        }

        #region Logging
        // You can remove this, I just prefer a more standardized logging
        public static void LogInfo(string _log) { Debug.Log($"{MOD_NAME} " + _log); }
        public static void LogWarning(string _log) { Debug.LogWarning($"{MOD_NAME} " + _log); }
        public static void LogError(string _log) { Debug.LogError($"{MOD_NAME} " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        public static void LogError(object _log) { LogError(_log.ToString()); }
        #endregion
    }
}
