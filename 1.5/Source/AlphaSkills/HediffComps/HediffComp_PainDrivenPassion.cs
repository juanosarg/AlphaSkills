using RimWorld;
using Verse;
using VSE.Passions;
using static UnityEngine.GraphicsBuffer;
namespace AlphaSkills
{
    public class HediffComp_PainDrivenPassion : HediffComp
    {


        public HediffCompProperties_PainDrivenPassion Props => (HediffCompProperties_PainDrivenPassion)props;



        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (this.parent.pawn.IsHashIntervalTick(1000) && this.parent.pawn.Spawned)
            {

                float painTotal = parent.pawn.health.hediffSet.PainTotal;

                if (painTotal > 0.3)
                    {
                        foreach (SkillRecord skill in parent.pawn.skills.skills)
                        {
                            if (skill.passion == (Passion)InternalDefOf.AS_PainDrivenPassion.index)
                            {
                                skill.passion = (Passion)InternalDefOf.AS_PainDrivenPassion_Active.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                        }
                    }
                    else
                    {
                        foreach (SkillRecord skill in parent.pawn.skills.skills)
                        {
                            if (skill.passion == (Passion)InternalDefOf.AS_PainDrivenPassion_Active.index)
                            {
                                skill.passion = (Passion)InternalDefOf.AS_PainDrivenPassion.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                        }
                    }
                




            }


        }
    }
}
