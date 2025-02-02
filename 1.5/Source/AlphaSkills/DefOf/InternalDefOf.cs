
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

        public static VSE.Passions.PassionDef AS_YouthPassion;


        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }
    }
}
