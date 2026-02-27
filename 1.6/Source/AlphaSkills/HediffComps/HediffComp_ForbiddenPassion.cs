using RimWorld;
using System.Security.Cryptography;
using Verse;
using VSE.Passions;
namespace AlphaSkills
{
    public class HediffComp_ForbiddenPassion : HediffComp
    {


        public HediffCompProperties_ForbiddenPassion Props => (HediffCompProperties_ForbiddenPassion)props;



        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (Pawn.IsHashIntervalTick(6000))
            {
                bool flag = false;
                foreach (SkillRecord skill in Pawn.skills.skills)
                {
                    if (skill.passion == (Passion)InternalDefOf.AS_ForbiddenPassion.index)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag) {
                    Pawn.health.RemoveHediff(parent);
                }



            }


        }
    }
}
