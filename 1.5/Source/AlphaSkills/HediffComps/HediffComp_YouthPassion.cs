﻿using RimWorld;
using System.Security.Cryptography;
using Verse;
using VSE.Passions;
namespace AlphaSkills
{
    public class HediffComp_YouthPassion : HediffComp
    {


        public HediffCompProperties_YouthPassion Props => (HediffCompProperties_YouthPassion)props;



        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (this.parent.pawn.IsHashIntervalTick(60000))
            {
                if (this.parent.pawn.ageTracker.AgeBiologicalYears >= 15)
                {
                    foreach (SkillRecord skill in parent.pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_YouthPassion.index)
                        {
                            skill.passion = (Passion)PassionDefOf.Minor.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }
                    this.parent.pawn.health.RemoveHediff(parent);

                }
             

            }


        }
    }
}
