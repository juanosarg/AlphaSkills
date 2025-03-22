using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System;
using System.Collections;
using static UnityEngine.UI.GridLayoutGroup;
using UnityEngine.Networking.Types;
using static UnityEngine.GraphicsBuffer;

namespace AlphaSkills
{

    [HarmonyPatch(typeof(Verb_MeleeAttackDamage))]
    [HarmonyPatch("ApplyMeleeDamageToTarget")]
   
    public static class AlphaSkills_Verb_MeleeAttackDamage_ApplyMeleeDamageToTarget_Patch
    {

        [HarmonyPostfix]
        public static void ApplyFlame(Verb_MeleeAttackDamage __instance, LocalTargetInfo target)
        {
            Pawn pawn = __instance.caster as Pawn;
            if (pawn != null)
            {
                float chance = pawn.GetStatValue(InternalDefOf.AS_FireStarter);
                if (Rand.Chance(chance)) {

                    float num = 10;

                    DamageInfo damageInfo = new DamageInfo(DamageDefOf.Flame, num, 0, -1f, pawn, null);
                   
                    target.Thing.TakeDamage(damageInfo);



                }

            }
            

        }


    }













}

