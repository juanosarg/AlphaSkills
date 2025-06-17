
using HarmonyLib;
using JetBrains.Annotations;
using RimWorld;
using System.Linq;
using UnityEngine;
using Verse;
using System;
using AlphaSkills;

namespace AlphaSkills
{
    [HarmonyPatch(typeof(GenRecipe), "PostProcessProduct")]
    public class AlphaSkills_GenRecipe_PostProcessProduct_Patch
    {
        [HarmonyPostfix]
        private static void PostFix(Thing product, RecipeDef recipeDef, ref Thing __result, Pawn worker)
        {
            

            if (recipeDef.workSkill == SkillDefOf.Crafting && __result.stackCount>1)
            {
                int resultingStack = __result.stackCount;
                resultingStack = (int)(resultingStack * worker.GetStatValue(InternalDefOf.AS_CraftingYield));
                __result.stackCount = resultingStack;
            }
           
        }
    }
}