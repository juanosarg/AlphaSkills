using RimWorld;
using System.Collections.Generic;
using Verse;
using VSE.Passions;
namespace AlphaSkills
{
    public class HediffComp_CompetitivePassion : HediffComp
    {

        public HediffCompProperties_CompetitivePassion Props => (HediffCompProperties_CompetitivePassion)props;


        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (Pawn.IsHashIntervalTick(6000) && Pawn.Spawned && Pawn.Map != null)
            {

                foreach (SkillRecord skill in Pawn.skills.skills)
                {
                    if (skill.passion == (Passion)InternalDefOf.AS_CompetitivePassion.index ||
                    skill.passion == (Passion)InternalDefOf.AS_CompetitivePassion_Active.index)
                    {
                        List<Pawn> colonists = Pawn.Map.mapPawns.FreeColonistsSpawned;
                        int maxSkill = 0;
                        foreach (Pawn colonist in colonists)
                        {
                            if (colonist != this.parent.pawn)
                            {
                                int colonistSkill = colonist.skills.GetSkill(skill.def).Level;
                                if(colonistSkill > maxSkill)
                                {
                                    maxSkill = colonistSkill;
                                }
                            }
                        }

                        if(maxSkill> Pawn.skills.GetSkill(skill.def).Level && skill.passion == (Passion)InternalDefOf.AS_CompetitivePassion.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_CompetitivePassion_Active.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }
                        else if(skill.passion == (Passion)InternalDefOf.AS_CompetitivePassion_Active.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_CompetitivePassion.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }               
                    }
                }
            }
        }
    }
}
