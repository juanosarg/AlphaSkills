using RimWorld;
using Verse;
using VSE.Passions;
using static UnityEngine.GraphicsBuffer;
namespace AlphaSkills
{
    public class HediffComp_ToxicPassion : HediffComp
    {


        public HediffCompProperties_ToxicPassion Props => (HediffCompProperties_ToxicPassion)props;



        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (Pawn.IsHashIntervalTick(1000) && Pawn.Spawned && Pawn.Map!=null)
            {
                if (Pawn.genes?.HasActiveGene(InternalDefOf.PollutionRush) != true)
                {
                    foreach (SkillRecord skill in Pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_ToxicPassion.index || skill.passion == (Passion)InternalDefOf.AS_ToxicPassion_Active.index)
                        {
                            skill.passion = (Passion)PassionDefOf.None.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }
                    }
                    Pawn.health.RemoveHediff(parent);
                }


                if (Pawn.Position.IsPolluted(Pawn.Map))
                {
                    foreach (SkillRecord skill in Pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_ToxicPassion.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_ToxicPassion_Active.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }
                }
                else
                {
                    foreach (SkillRecord skill in Pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_ToxicPassion_Active.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_ToxicPassion.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }
                }





            }


        }
    }
}
