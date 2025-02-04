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

            if (this.parent.pawn.IsHashIntervalTick(1000) && this.parent.pawn.Spawned && this.parent.pawn.Map!=null)
            {
                if (parent.pawn.genes?.HasActiveGene(InternalDefOf.PollutionRush) != true)
                {
                    foreach (SkillRecord skill in parent.pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_ToxicPassion.index || skill.passion == (Passion)InternalDefOf.AS_ToxicPassion_Active.index)
                        {
                            skill.passion = (Passion)PassionDefOf.None.index;
                        }
                    }
                    this.parent.pawn.health.RemoveHediff(parent);
                }


                if (parent.pawn.Position.IsPolluted(parent.pawn.Map))
                {
                    foreach (SkillRecord skill in parent.pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_ToxicPassion.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_ToxicPassion_Active.index;

                        }

                    }
                }
                else
                {
                    foreach (SkillRecord skill in parent.pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_ToxicPassion_Active.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_ToxicPassion.index;

                        }

                    }
                }





            }


        }
    }
}
