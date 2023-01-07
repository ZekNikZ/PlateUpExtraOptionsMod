using HarmonyLib;
using Kitchen;
using System.Collections.Generic;
using System.Reflection;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using System.Linq;
using KitchenData;
using System;

namespace KitchenExtraOptionsMod.Patches
{
	[HarmonyPatch(typeof(CreateDishOptions), "Initialise")]
	class CreateDishOptionsInitializePatch
    {
		internal static EntityQuery ExistingDishChoices;
		internal static EntityQuery AllDishChoices;

		static void Postfix(CreateDishOptions __instance)
        {
			ExistingDishChoices = __instance.EntityManager.CreateEntityQuery(new QueryHelper()
				.All(typeof(CDishChoice)));
			AllDishChoices = __instance.EntityManager.CreateEntityQuery(new QueryHelper()
				.All(typeof(CDishUpgrade)));
		}
    }

    [HarmonyPatch(typeof(CreateDishOptions), "OnUpdate")]
    class CreateDishOptionsOnUpdatePatch
    {
		static void Postfix(CreateDishOptions __instance)
		{
			Mod.LogInfo("yo yo yo");
			MethodInfo mInfo = typeof(CreateDishOptions).GetMethod("CreateFoodSource", BindingFlags.NonPublic | BindingFlags.Instance);
			Mod.LogInfo(mInfo);

			using var existingDishes = CreateDishOptionsInitializePatch.ExistingDishChoices.ToComponentDataArray<CDishChoice>(Allocator.Temp);
			using var allDishOptions = CreateDishOptionsInitializePatch.AllDishChoices.ToComponentDataArray<CDishUpgrade>(Allocator.Temp);

			var dishes = Kitchen.RandomExtensions.Shuffle(
				allDishOptions.Select(d => d.DishID)
				.Except(existingDishes.Select(c => c.Dish)).ToList()
			);
			
			List<Vector3> positions = new()
			{
				new Vector3(1f, 0f, -7f),
				new Vector3(4f, 0f, -5f)
			};
			for (int i = 0; i < positions.Count; i++)
			{
				mInfo.Invoke(__instance, new object[] { positions[i], GameData.Main.Get<Dish>(dishes[i]), false });
			}
		}
    }
}
