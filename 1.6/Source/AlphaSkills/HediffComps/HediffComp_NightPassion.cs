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

            if (Pawn.IsHashIntervalTick(1000) && Pawn.Spawned)
            {
                if((GenLocalDate.HourInteger(Pawn) >= 20 || GenLocalDate.HourInteger(Pawn) <= 5))
                {
                    foreach (SkillRecord skill in Pawn.skills.skills)
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
                    foreach (SkillRecord skill in Pawn.skills.skills)
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
