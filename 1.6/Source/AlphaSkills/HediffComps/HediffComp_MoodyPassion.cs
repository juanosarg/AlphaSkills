using RimWorld;
using System.Collections.Generic;
using Verse;
using VSE.Passions;
namespace AlphaSkills
{
    public class HediffComp_MoodyPassion : HediffComp
    {
        public List<VSE.Passions.PassionDef> possiblePassions = new List<VSE.Passions.PassionDef>() {  InternalDefOf.AS_MoodyPassion,
            InternalDefOf.AS_MoodyPassion_Apathy,InternalDefOf.AS_MoodyPassion_NoPassion,InternalDefOf.AS_MoodyPassion_Major,InternalDefOf.AS_MoodyPassion_Greater
    };

        public HediffCompProperties_MoodyPassion Props => (HediffCompProperties_MoodyPassion)props;



        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (Pawn.IsHashIntervalTick(60000) && Pawn.Spawned)
            {

                foreach (SkillRecord skill in Pawn.skills.skills)
                {
                    if (skill.passion == (Passion)InternalDefOf.AS_MoodyPassion.index || skill.passion == (Passion)InternalDefOf.AS_MoodyPassion_Apathy.index
                        || skill.passion == (Passion)InternalDefOf.AS_MoodyPassion_NoPassion.index || skill.passion == (Passion)InternalDefOf.AS_MoodyPassion_Major.index
                        || skill.passion == (Passion)InternalDefOf.AS_MoodyPassion_Greater.index)
                    {
                        skill.passion = (Passion)possiblePassions.RandomElement().index;
                        LearnRateFactorCache.ClearCacheFor(skill);
                    }

                }

            }


        }
    }
}
