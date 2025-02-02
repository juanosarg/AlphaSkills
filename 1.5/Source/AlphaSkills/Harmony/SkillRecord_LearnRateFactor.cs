using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System;
using System.Collections;

namespace AlphaSkills
{

    [HarmonyPatch(typeof(SkillRecord))]
    [HarmonyPatch("LearnRateFactor")]
    public static class AlphaSkills_SkillRecord_LearnRateFactor_Patch
    {
    
        [HarmonyPostfix]
        public static void ModifyLearnFactor(SkillRecord __instance, ref float __result)
        {

            /*if (WorldComponent_DrunkenPassion.Instance.drunkenPassionPawns.ContainsKey(__instance.Pawn)
                && WorldComponent_DrunkenPassion.Instance.drunkenPassionPawns[__instance.Pawn] ==__instance.def
                )
            {
                __result *= 4;
            }*/
           

        }


    }













}

