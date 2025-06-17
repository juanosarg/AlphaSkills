using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System;
using System.Collections;

namespace AlphaSkills
{

    [HarmonyPatch(typeof(PawnDiedOrDownedThoughtsUtility))]
    [HarmonyPatch("TryGiveThoughts")]
    [HarmonyPatch(new Type[] { typeof(Pawn), typeof(DamageInfo?), typeof(PawnDiedOrDownedThoughtsKind) })]
    public static class AlphaSkills_PawnDiedOrDownedThoughtsUtility_TryGiveThoughts_Patch
    {
       
        [HarmonyPostfix]
        public static void GiveColonyDeathThought(Pawn victim)
        {

            if(victim.Faction == Faction.OfPlayerSilentFail) {

                foreach (Pawn pawn in PawnsFinder.AllMapsCaravansAndTravellingTransporters_Alive_Colonists)
                {
                    if (pawn != victim)
                    {
                        if (pawn.health?.hediffSet?.GetFirstHediffOfDef(InternalDefOf.AS_VengefulPassion_Hediff) != null)
                        {
                            Hediff hediff = pawn.health.hediffSet.GetFirstHediffOfDef(InternalDefOf.AS_VengefulPassion_Hediff);
                            HediffComp_VengefulPassion comp = hediff.TryGetComp<HediffComp_VengefulPassion>();
                            if(comp != null)
                            {
                                comp.Notify_Active();
                            }
                        }
                    }
                }

            }


        }


    }













}

