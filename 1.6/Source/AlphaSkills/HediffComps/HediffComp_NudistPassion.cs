using RimWorld;
using System.Collections.Generic;
using Verse;
using VSE.Passions;
using static UnityEngine.GraphicsBuffer;
namespace AlphaSkills
{
    public class HediffComp_NudistPassion : HediffComp
    {
        public HediffCompProperties_NudistPassion Props => (HediffCompProperties_NudistPassion)props;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (Pawn.IsHashIntervalTick(6000))
            {

                if (IsNude(Pawn))
                {
                    foreach (SkillRecord skill in Pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_NudistPassion.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_NudistPassion_Active.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }
                }
                else
                {
                    foreach (SkillRecord skill in Pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_NudistPassion_Active.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_NudistPassion.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }
                }
            }
        }

        public bool IsNude(Pawn p)
        {
            List<Apparel> wornApparel = p.apparel.WornApparel;
            for (int i = 0; i < wornApparel.Count; i++)
            {
                Apparel apparel = wornApparel[i];
                if (!apparel.def.apparel.countsAsClothingForNudity)
                {
                    continue;
                }
                for (int j = 0; j < apparel.def.apparel.bodyPartGroups.Count; j++)
                {
                    if (apparel.def.apparel.bodyPartGroups[j] == BodyPartGroupDefOf.Torso)
                    {
                        return false;
                    }
                    if (apparel.def.apparel.bodyPartGroups[j] == BodyPartGroupDefOf.Legs)
                    {
                        return false;
                    }
                }
            }
            return true;

        }

    }
}
