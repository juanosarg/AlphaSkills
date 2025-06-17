using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System;
using System.Collections;

namespace AlphaSkills
{

    [HarmonyPatch(typeof(VerbProperties))]
    [HarmonyPatch("GetDamageFactorFor")]
    [HarmonyPatch(new Type[] { typeof(Verb), typeof(Pawn) })]
    public static class AlphaSkills_VerbProperties_GetDamageFactorFor_Patch
    {

        [HarmonyPostfix]
        public static void ApplyMortarStat(Verb ownerVerb, Pawn attacker, ref float __result)
        {

            if (ownerVerb?.EquipmentSource?.def?.building != null && ownerVerb.EquipmentSource.def.building.IsMortar)
            {
                __result*= attacker.GetStatValue(InternalDefOf.AS_MortarDamageFactor);
            }


        }


    }













}

