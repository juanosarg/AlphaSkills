
using RimWorld;
using Verse;


namespace AlphaSkills
{
    [DefOf]
    public static class InternalDefOf
    {
        public static VSE.Passions.PassionDef AS_DrunkenPassion;
       

        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }
    }
}
