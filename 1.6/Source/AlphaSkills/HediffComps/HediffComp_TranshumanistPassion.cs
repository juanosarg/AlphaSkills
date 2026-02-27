using RimWorld;
using System.Collections.Generic;
using Verse;
using VSE.Passions;
using static UnityEngine.GraphicsBuffer;
namespace AlphaSkills
{
    public class HediffComp_TranshumanistPassion : HediffComp
    {
        public HediffCompProperties_TranshumanistPassion Props => (HediffCompProperties_TranshumanistPassion)props;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (Pawn.IsHashIntervalTick(6000))
            {

                if (IsBionic(Pawn))
                {
                    foreach (SkillRecord skill in Pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_TranshumanistPassion.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_TranshumanistPassion_Active.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }
                }
                else
                {
                    foreach (SkillRecord skill in Pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_TranshumanistPassion_Active.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_TranshumanistPassion.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }
                }
            }
        }

        public bool IsBionic(Pawn p)
        {
            return ThoughtWorker_Precept_HasProsthetic_Count.ProstheticsCount(p) > 0;

        }

    }
}
