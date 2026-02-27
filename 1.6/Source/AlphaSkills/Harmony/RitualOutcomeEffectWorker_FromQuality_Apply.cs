using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Verse.AI;
using Verse;

using RimWorld;

namespace AlphaSkills
{
    [HarmonyPatch]
    public static class AlphaSkills_RitualOutcomeEffectWorker_FromQuality_Apply_Patches
    {
        [HarmonyTargetMethods]
        public static IEnumerable<MethodBase> TargetMethods()
        {
            var targetMethod = AccessTools.DeclaredMethod(typeof(RitualOutcomeEffectWorker_FromQuality), "Apply");
            yield return targetMethod;
            foreach (var subclass in typeof(RitualOutcomeEffectWorker_FromQuality).AllSubclasses())
            {
                var method = AccessTools.DeclaredMethod(subclass, "Apply");
                if (method != null)
                {
                    yield return method;
                }
            }
        }

        public static void Postfix(Dictionary<Pawn, int> totalPresence)
        {
            foreach (KeyValuePair<Pawn, int> item in totalPresence)
            {
                if (item.Key.health?.hediffSet?.GetFirstHediffOfDef(InternalDefOf.AS_IdeologicalPassion_Hediff) != null)
                {
                    Hediff hediff = item.Key.health.hediffSet.GetFirstHediffOfDef(InternalDefOf.AS_IdeologicalPassion_Hediff);
                    HediffComp_IdeologicalPassion comp = hediff.TryGetComp<HediffComp_IdeologicalPassion>();
                    if (comp != null)
                    {
                        comp.Notify_Active();
                    }
                }

            }
        }
    }
}


