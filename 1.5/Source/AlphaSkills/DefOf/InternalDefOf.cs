﻿
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

        [MayRequireBiotech]
        public static GeneDef PollutionRush;

        public static HediffDef AS_VengefulPassion_Hediff;

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
