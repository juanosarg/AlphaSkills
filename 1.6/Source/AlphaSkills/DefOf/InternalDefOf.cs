
using RimWorld;
using Verse;


namespace AlphaSkills
{
    [DefOf]
    public static class InternalDefOf
    {
        public static VSE.Passions.PassionDef AS_DrunkenPassion;
        public static VSE.Passions.PassionDef AS_DrunkenPassion_Active;

        public static VSE.Passions.PassionDef AS_NightPassion;
        public static VSE.Passions.PassionDef AS_NightPassion_Active;

        public static VSE.Passions.PassionDef AS_NomadicPassion;
        public static VSE.Passions.PassionDef AS_NomadicPassion_Active;

        public static VSE.Passions.PassionDef AS_VengefulPassion;
        public static VSE.Passions.PassionDef AS_VengefulPassion_Active;

        public static VSE.Passions.PassionDef AS_ForbiddenPassion;

        public static VSE.Passions.PassionDef AS_MoodyPassion;
        public static VSE.Passions.PassionDef AS_MoodyPassion_Apathy;
        public static VSE.Passions.PassionDef AS_MoodyPassion_NoPassion;
        public static VSE.Passions.PassionDef AS_MoodyPassion_Major;
        public static VSE.Passions.PassionDef AS_MoodyPassion_Greater;

        public static VSE.Passions.PassionDef AS_PsychicPassion_Nullified;
        public static VSE.Passions.PassionDef AS_PsychicPassion_Minor;
        public static VSE.Passions.PassionDef AS_PsychicPassion;
        public static VSE.Passions.PassionDef AS_PsychicPassion_Major;
        public static VSE.Passions.PassionDef AS_PsychicPassion_Critical;

        public static VSE.Passions.PassionDef AS_LikeMindedPassion;

        public static VSE.Passions.PassionDef AS_RainyDayPassion;
        public static VSE.Passions.PassionDef AS_RainyDayPassion_Active;

        public static VSE.Passions.PassionDef AS_CompetitivePassion;
        public static VSE.Passions.PassionDef AS_CompetitivePassion_Active;

        public static VSE.Passions.PassionDef AS_StonedPassion;
        public static VSE.Passions.PassionDef AS_StonedPassion_Active;

        public static VSE.Passions.PassionDef AS_NudistPassion;
        public static VSE.Passions.PassionDef AS_NudistPassion_Active;

        public static VSE.Passions.PassionDef AS_IntimatePassion;
        public static VSE.Passions.PassionDef AS_IntimatePassion_Active;

        [MayRequireBiotech]
        public static VSE.Passions.PassionDef AS_SanguinePassion;
        [MayRequireBiotech]
        public static VSE.Passions.PassionDef AS_SanguinePassion_Active;

        [MayRequireBiotech]
        public static VSE.Passions.PassionDef AS_ToxicPassion;
        [MayRequireBiotech]
        public static VSE.Passions.PassionDef AS_ToxicPassion_Active;

        public static VSE.Passions.PassionDef AS_YouthPassion;

        [MayRequireIdeology]
        public static VSE.Passions.PassionDef AS_PainDrivenPassion;
        [MayRequireIdeology]
        public static VSE.Passions.PassionDef AS_PainDrivenPassion_Active;
        [MayRequireIdeology]
        public static VSE.Passions.PassionDef AS_IdeologicalPassion;
        [MayRequireIdeology]
        public static VSE.Passions.PassionDef AS_IdeologicalPassion_Active;
        [MayRequireIdeology]
        public static VSE.Passions.PassionDef AS_BlindPassion_Elevated;
        [MayRequireIdeology]
        public static VSE.Passions.PassionDef AS_BlindPassion_Elevated_Active;
        [MayRequireIdeology]
        public static VSE.Passions.PassionDef AS_BlindPassion_Sublime;
        [MayRequireIdeology]
        public static VSE.Passions.PassionDef AS_BlindPassion_Sublime_Active;
        [MayRequireIdeology]
        public static VSE.Passions.PassionDef AS_TranshumanistPassion;
        [MayRequireIdeology]
        public static VSE.Passions.PassionDef AS_TranshumanistPassion_Active;

        [MayRequireBiotech]
        public static GeneDef PollutionRush;

        public static HediffDef AS_VengefulPassion_Hediff;
        public static HediffDef AS_IntimatePassion_Hediff;
        public static HediffDef AS_IdeologicalPassion_Hediff;

        public static StatDef AS_MortarDamageFactor;
        public static StatDef AS_CraftingYield;
        public static StatDef AS_ExtraGoldYield;
        public static StatDef AS_ExtraComponentsYield;
        public static StatDef AS_FireStarter;

        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }
    }
}
