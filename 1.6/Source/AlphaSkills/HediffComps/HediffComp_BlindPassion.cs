using RimWorld;
using System.Collections.Generic;
using Verse;
using VSE.Passions;
using static UnityEngine.GraphicsBuffer;
namespace AlphaSkills
{
    public class HediffComp_BlindPassion : HediffComp
    {
        public HediffCompProperties_BlindPassion Props => (HediffCompProperties_BlindPassion)props;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (Pawn.IsHashIntervalTick(6000))
            {

                if (PawnUtility.IsBiologicallyBlind(Pawn))
                {
                    foreach (SkillRecord skill in Pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_BlindPassion_Elevated.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_BlindPassion_Elevated_Active.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }
                        if (skill.passion == (Passion)InternalDefOf.AS_BlindPassion_Sublime.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_BlindPassion_Sublime_Active.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }
                }
                else
                {
                    foreach (SkillRecord skill in Pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_BlindPassion_Elevated_Active.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_BlindPassion_Elevated.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }
                        if (skill.passion == (Passion)InternalDefOf.AS_BlindPassion_Sublime_Active.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_BlindPassion_Sublime.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }
                }
            }
        }

      

    }
}
