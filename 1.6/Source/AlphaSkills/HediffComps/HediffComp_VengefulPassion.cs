using RimWorld;
using Verse;
using VSE.Passions;
using static UnityEngine.GraphicsBuffer;
namespace AlphaSkills
{
    public class HediffComp_VengefulPassion : HediffComp
    {
        public int coolDownCounter = coolDown;
        public const int coolDown = 180000; //3 days
        public bool isActive = false;


        public HediffCompProperties_VengefulPassion Props => (HediffCompProperties_VengefulPassion)props;

        public void Notify_Active()
        {
            isActive = true;
            coolDownCounter = coolDown;

            foreach (SkillRecord skill in Pawn.skills.skills)
            {
                if (skill.passion == (Passion)InternalDefOf.AS_VengefulPassion.index)
                {
                    skill.passion = (Passion)InternalDefOf.AS_VengefulPassion_Active.index;
                    LearnRateFactorCache.ClearCacheFor(skill);
                }

            }

        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if(isActive )
            {
                coolDownCounter--;
                if( coolDownCounter < 0)
                {
                    foreach (SkillRecord skill in Pawn.skills.skills)
                    {
                        if (skill.passion == (Passion)InternalDefOf.AS_VengefulPassion_Active.index)
                        {
                            skill.passion = (Passion)InternalDefOf.AS_VengefulPassion.index;
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
