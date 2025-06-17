using RimWorld;
using Verse;
using VSE.Passions;
using static UnityEngine.GraphicsBuffer;
namespace AlphaSkills
{
    public class HediffComp_NomadicPassion : HediffComp
    {


        public HediffCompProperties_NomadicPassion Props => (HediffCompProperties_NomadicPassion)props;



        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (this.parent.pawn.IsHashIntervalTick(1000))
            {
                


                if (parent.pawn.Map is null ||! parent.pawn.Map.IsPlayerHome)
                {
                    foreach (SkillRecord skill in parent.pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_NomadicPassion.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_NomadicPassion_Active.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }
                }
                else
                {
                    foreach (SkillRecord skill in parent.pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_NomadicPassion_Active.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_NomadicPassion.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }
                }





            }


        }
    }
}
