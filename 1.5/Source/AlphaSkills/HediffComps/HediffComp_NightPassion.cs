using RimWorld;
using Verse;
using VSE.Passions;
namespace AlphaSkills
{
    public class HediffComp_NightPassion : HediffComp
    {


        public HediffCompProperties_NightPassion Props => (HediffCompProperties_NightPassion)props;



        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (this.parent.pawn.IsHashIntervalTick(1000) && this.parent.pawn.Spawned)
            {
                if((GenLocalDate.HourInteger(this.parent.pawn) >= 20 || GenLocalDate.HourInteger(this.parent.pawn) <= 5))
                {
                    foreach (SkillRecord skill in parent.pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_NightPassion.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_NightPassion_Active.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }


                }
                else
                {
                    foreach (SkillRecord skill in parent.pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_NightPassion_Active.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_NightPassion.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }

                }

            }


        }
    }
}
