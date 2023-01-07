using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Kitchen;
using UnityEngine;

namespace KitchenExtraOptionsMod.Patches
{
    [HarmonyPatch(typeof(CreateLayoutSlots), "OnUpdate")]
    class CreateLayoutSlotsPatch
    {
		static void Postfix(CreateLayoutSlots __instance)
		{
			if (Mod.IsSeedExplorerInstalled)
            {
				return;
            }

			MethodInfo mInfo = typeof(CreateLayoutSlots).GetMethod("CreateMapSource", BindingFlags.NonPublic | BindingFlags.Instance);

			List<Vector3> positions = new()
			{
				new Vector3(0f, 0f, -7f),
				new Vector3(-1f, 0f, -7f)
			};
			for (int i = 0; i < positions.Count; i++)
			{
				mInfo.Invoke(__instance, new object[] { positions[i] });
			}
		}
    }
}
