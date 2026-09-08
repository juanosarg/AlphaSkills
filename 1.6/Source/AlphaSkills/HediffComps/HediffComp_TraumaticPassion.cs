using RimWorld;
using Verse;
using VSE.Passions;
using static UnityEngine.GraphicsBuffer;
namespace AlphaSkills
{
    public class HediffComp_TraumaticPassion : HediffComp
    {

        public HediffCompProperties_TraumaticPassion Props => (HediffCompProperties_TraumaticPassion)props;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (Pawn.IsHashIntervalTick(1000))
            {
                this.parent.Severity = 0.1f;
                if (Pawn.Map != null && Pawn.jobs.curJob != null)
                {
                    foreach (SkillRecord skill in Pawn.skills.skills)
                    {
                        if (Pawn.jobs.curDriver?.ActiveSkill == skill.def && skill.passion == (Passion)InternalDefOf.AS_TraumaticPassion.index)
                        {
                            this.parent.Severity = 1;
                            break;
                        }

                    }
                }

            }

        }
    }
}
