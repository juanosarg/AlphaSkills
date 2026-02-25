using RimWorld;
using Verse;
using VSE.Passions;
using static UnityEngine.GraphicsBuffer;
namespace AlphaSkills
{
    public class HediffComp_PsychicPassion : HediffComp
    {


        public HediffCompProperties_PsychicPassion Props => (HediffCompProperties_PsychicPassion)props;



        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (this.parent.pawn.IsHashIntervalTick(6000) && this.parent.pawn.Spawned)
            {

                float psychicsensitivity = Pawn.GetStatValue(StatDefOf.PsychicSensitivity);


                foreach (SkillRecord skill in parent.pawn.skills.skills)
                {
                    if (skill.passion == (Passion)InternalDefOf.AS_PsychicPassion_Nullified.index ||
                        skill.passion == (Passion)InternalDefOf.AS_PsychicPassion.index ||
                        skill.passion == (Passion)InternalDefOf.AS_PsychicPassion_Minor.index ||
                        skill.passion == (Passion)InternalDefOf.AS_PsychicPassion_Major.index ||
                        skill.passion == (Passion)InternalDefOf.AS_PsychicPassion_Critical.index)
                    {
                        Passion newPassion = skill.passion;
                        Passion originalPassion = newPassion;

                        if (psychicsensitivity < 0.5f)
                        {
                            newPassion = (Passion)InternalDefOf.AS_PsychicPassion_Nullified.index;
                            skill.passion = newPassion;
                        }else
                        if (psychicsensitivity <= 1f)
                        {
                            newPassion = (Passion)InternalDefOf.AS_PsychicPassion_Minor.index;
                            skill.passion = newPassion;
                        }
                        else
                        if (psychicsensitivity <= 1.5f)
                        {
                            newPassion = (Passion)InternalDefOf.AS_PsychicPassion.index;
                            skill.passion = newPassion;
                        }
                        else
                        if (psychicsensitivity <= 2f)
                        {
                            newPassion = (Passion)InternalDefOf.AS_PsychicPassion_Major.index;
                            skill.passion = newPassion;
                        }
                        else
                        {
                            newPassion = (Passion)InternalDefOf.AS_PsychicPassion_Critical.index;
                            skill.passion = newPassion;
                        }

                        if (originalPassion != newPassion) { LearnRateFactorCache.ClearCacheFor(skill); }
                        
                    }

                }






            }


        }
    }
}
