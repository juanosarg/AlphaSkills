using HarmonyLib;
using RimWorld;
using Verse;


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

