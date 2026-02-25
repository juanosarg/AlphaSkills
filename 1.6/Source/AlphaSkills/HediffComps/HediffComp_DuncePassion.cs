using RimWorld;
using Verse;
using VSE.Passions;
using static UnityEngine.GraphicsBuffer;
namespace AlphaSkills
{
    public class HediffComp_DuncePassion : HediffComp
    {

        public HediffCompProperties_DuncePassion Props => (HediffCompProperties_DuncePassion)props;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (Pawn.IsHashIntervalTick(1000))
            {
                this.parent.Severity = 0.1f;
                if (Pawn.Map != null && Pawn.jobs.curJob!=null)
                {
                    foreach (SkillRecord skill in parent.pawn.skills.skills)
                    {
                        if (Pawn.jobs.curDriver?.ActiveSkill == skill.def)
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
