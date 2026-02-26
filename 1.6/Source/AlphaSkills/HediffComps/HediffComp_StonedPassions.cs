using RimWorld;
using Verse;
using VSE.Passions;
namespace AlphaSkills
{
    public class HediffComp_StonedPassions : HediffComp
    {


        public HediffCompProperties_StonedPassions Props => (HediffCompProperties_StonedPassions)props;



        public override void CompPostPostAdd(DamageInfo? dinfo)
        {
            if (parent.pawn?.skills?.skills != null)
            {
                foreach (SkillRecord skill in parent.pawn.skills.skills)
                {
                    if (skill.passion == (Passion)InternalDefOf.AS_StonedPassion.index)
                    {
                        skill.passion = (Passion)InternalDefOf.AS_StonedPassion_Active.index;
                        LearnRateFactorCache.ClearCacheFor(skill);
                    }

                }
            }

        }

        public override void CompPostPostRemoved()
        {
            RevertPassion();
        }

        public override void Notify_PawnDied(DamageInfo? dinfo, Hediff culprit = null)
        {
            RevertPassion();
        }

        public override void Notify_PawnKilled()
        {
            RevertPassion();
        }

        public void RevertPassion()
        {
            if (parent.pawn?.skills?.skills != null)
            {
                foreach (SkillRecord skill in parent.pawn.skills.skills)
                {
                    if (skill.passion == (Passion)InternalDefOf.AS_StonedPassion_Active.index)
                    {
                        skill.passion = (Passion)InternalDefOf.AS_StonedPassion.index;
                        LearnRateFactorCache.ClearCacheFor(skill);
                    }

                }
            }
        }
    }
}
