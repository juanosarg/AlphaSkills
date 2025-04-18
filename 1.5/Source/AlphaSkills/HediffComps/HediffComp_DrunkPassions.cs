﻿using RimWorld;
using Verse;
using VSE.Passions;
namespace AlphaSkills
{
    public class HediffComp_DrunkPassions : HediffComp
    {
      

        public HediffCompProperties_DrunkPassions Props => (HediffCompProperties_DrunkPassions)props;



        public override void CompPostPostAdd(DamageInfo? dinfo)
        {
            if (parent.pawn?.skills?.skills != null)
            {
                foreach (SkillRecord skill in parent.pawn.skills.skills)
                {
                    if (skill.passion == (Passion)InternalDefOf.AS_DrunkenPassion.index)
                    {
                        skill.passion = (Passion)InternalDefOf.AS_DrunkenPassion_Active.index;
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
                    if (skill.passion == (Passion)InternalDefOf.AS_DrunkenPassion_Active.index)
                    {
                        skill.passion = (Passion)InternalDefOf.AS_DrunkenPassion.index;
                        LearnRateFactorCache.ClearCacheFor(skill);
                    }

                }
            }
        }
    }
}
