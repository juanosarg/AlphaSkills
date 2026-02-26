using RimWorld;
using Verse;
using VSE.Passions;

namespace AlphaSkills
{
    public class ThoughtWorker_LikeMindedPassion : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn other)
        {
            if (!p.RaceProps.Humanlike)
            {
                return false;
            }
            foreach (SkillRecord skill in p.skills.skills)
            {
                if (skill.passion == (Passion)InternalDefOf.AS_LikeMindedPassion.index)
                {
                    if(other.skills.GetSkill(skill.def).passion != Passion.None)
                    {
                        return true;
                    }
                }

            }


            return false;
        }
    }
}