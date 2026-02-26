using RimWorld;
using Verse;
using VSE.Passions;
using static UnityEngine.GraphicsBuffer;
namespace AlphaSkills
{
    public class HediffComp_RainyDayPassion : HediffComp
    {


        public HediffCompProperties_RainyDayPassion Props => (HediffCompProperties_RainyDayPassion)props;



        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (this.parent.pawn.IsHashIntervalTick(1000) && this.parent.pawn.Spawned && this.parent.pawn.Map != null)
            {


                if (parent.pawn.Map.weatherManager?.curWeather?.rainRate > 0)
                {
                    foreach (SkillRecord skill in parent.pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_RainyDayPassion.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_RainyDayPassion_Active.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }
                }
                else
                {
                    foreach (SkillRecord skill in parent.pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_RainyDayPassion_Active.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_RainyDayPassion.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }
                }





            }


        }
    }
}
