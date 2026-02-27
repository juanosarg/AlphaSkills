using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System;
using System.Collections;

namespace AlphaSkills
{
    [HarmonyPatch(typeof(JobDriver_Lovin))]
    [HarmonyPatch("GenerateRandomMinTicksToNextLovin")]
    public static class AlphaSkills_JobDriver_Lovin_GenerateRandomMinTicksToNextLovin_Patch
    {
        [HarmonyPostfix]
        public static void GiveLovinPassion(Pawn pawn)
        {
            if (pawn.health?.hediffSet?.GetFirstHediffOfDef(InternalDefOf.AS_IntimatePassion_Hediff) != null)
            {
                Hediff hediff = pawn.health.hediffSet.GetFirstHediffOfDef(InternalDefOf.AS_IntimatePassion_Hediff);
                HediffComp_IntimatePassion comp = hediff.TryGetComp<HediffComp_IntimatePassion>();
                if (comp != null)
                {
                    comp.Notify_Active();
                }
            }
        }
    }
}

