using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Security.Cryptography;

namespace AlphaSkills
{

    [HarmonyPatch(typeof(Mineable))]
    [HarmonyPatch("TrySpawnYield")]
    [HarmonyPatch(new Type[] { typeof(Map), typeof(bool), typeof(Pawn) })]
    public static class AlphaSkills_Mineable_TrySpawnYield_Patch
    {

        [HarmonyPostfix]
        public static void ExtraYields(Map map, bool moteOnWaste, Pawn pawn, Mineable __instance)
        {
            if (pawn != null)
            {
                if (Rand.Chance(pawn.GetStatValue(InternalDefOf.AS_ExtraGoldYield)))
                {
                    Thing thing = ThingMaker.MakeThing(ThingDefOf.Gold);
                    thing.stackCount = new IntRange(1, 5).RandomInRange;
                    GenPlace.TryPlaceThing(thing, __instance.Position, map, ThingPlaceMode.Near);

                }
                if (Rand.Chance(pawn.GetStatValue(InternalDefOf.AS_ExtraComponentsYield)))
                {
                    Thing thing2 = ThingMaker.MakeThing(ThingDefOf.ComponentSpacer);
                    thing2.stackCount = 1;
                    GenPlace.TryPlaceThing(thing2, __instance.Position, map, ThingPlaceMode.Near);

                }
            }
            


        }

    


    }













}

