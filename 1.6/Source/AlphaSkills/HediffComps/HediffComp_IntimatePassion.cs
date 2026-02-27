using RimWorld;
using Verse;
using VSE.Passions;
using static UnityEngine.GraphicsBuffer;
namespace AlphaSkills
{
    public class HediffComp_IntimatePassion : HediffComp
    {
        public int coolDownCounter = coolDown;
        public const int coolDown = 60000; //1 day
        public bool isActive = false;


        public HediffCompProperties_IntimatePassion Props => (HediffCompProperties_IntimatePassion)props;

        public void Notify_Active()
        {
            isActive = true;
            coolDownCounter = coolDown;

            foreach (SkillRecord skill in Pawn.skills.skills)
            {
                if (skill.passion == (Passion)InternalDefOf.AS_IntimatePassion.index)
                {
                    skill.passion = (Passion)InternalDefOf.AS_IntimatePassion_Active.index;
                    LearnRateFactorCache.ClearCacheFor(skill);
                }

            }

        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (isActive)
            {
                coolDownCounter--;
                if (coolDownCounter < 0)
                {
                    foreach (SkillRecord skill in Pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_IntimatePassion_Active.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_IntimatePassion.index;
                            LearnRateFactorCache.ClearCacheFor(skill);
                        }

                    }
                    coolDownCounter = coolDown;
                    isActive = false;
                }
            }
        }

        public override void CompExposeData()
        {
            base.CompExposeData();
            Scribe_Values.Look(ref this.coolDownCounter, nameof(this.coolDownCounter));
            Scribe_Values.Look(ref this.isActive, nameof(this.isActive));
        }


    }
}
