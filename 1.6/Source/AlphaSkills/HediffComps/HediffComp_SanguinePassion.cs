using RimWorld;
using Verse;
using VSE.Passions;
using static UnityEngine.GraphicsBuffer;
namespace AlphaSkills
{
    public class HediffComp_SanguinePassion : HediffComp
    {


        public HediffCompProperties_SanguinePassion Props => (HediffCompProperties_SanguinePassion)props;



        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (Pawn.IsHashIntervalTick(1000) && Pawn.Spawned)
            {
                if (Pawn.genes?.HasActiveGene(GeneDefOf.Hemogenic) != true)
                {
                    foreach (SkillRecord skill in Pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_SanguinePassion.index || skill.passion == (Passion)InternalDefOf.AS_SanguinePassion_Active.index)
                        {
                            skill.passion = (Passion)PassionDefOf.None.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }
                    }
                    Pawn.health.RemoveHediff(parent);
                }

                Gene_Hemogen firstGeneOfType = Pawn.genes?.GetFirstGeneOfType<Gene_Hemogen>();
                if (firstGeneOfType != null)
                {
                    if (firstGeneOfType.Value > 0.5)
                    {
                        foreach (SkillRecord skill in Pawn.skills.skills)
                        {
                            if (skill.passion == (Passion)InternalDefOf.AS_SanguinePassion.index)
                            {
                                skill.passion = (Passion)InternalDefOf.AS_SanguinePassion_Active.index;
                                LearnRateFactorCache.ClearCacheFor(skill);
                            }

                        }
                    }
                    else
                    {
                        foreach (SkillRecord skill in Pawn.skills.skills)
                        {
                            if (skill.passion == (Passion)InternalDefOf.AS_SanguinePassion_Active.index)
                            {
                                skill.passion = (Passion)InternalDefOf.AS_SanguinePassion.index;
                                LearnRateFactorCache.ClearCacheFor(skill);
                            }

                        }
                    }
                } 


              

            }


        }
    }
}
