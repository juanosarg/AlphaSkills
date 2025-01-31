using System;
using RimWorld;
using Verse;
using UnityEngine;
using System.Collections.Generic;
using RimWorld.Planet;
using System.Linq;
using AlphaSkills;


namespace AlphaSkills
{
    public class WorldComponent_DrunkenPassion : WorldComponent
    {

        public int tickCounter = tickInterval;
        public const int tickInterval = 10000;
        public Dictionary<Pawn, SkillDef> drunkenPassionPawns = new Dictionary<Pawn, SkillDef>();
        List<Pawn> list2;
        List<SkillDef> list3;

        public static WorldComponent_DrunkenPassion Instance;

        public WorldComponent_DrunkenPassion(World world) : base(world) => Instance = this;



        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Collections.Look(ref drunkenPassionPawns, "drunkenPassionPawns", LookMode.Reference, LookMode.Def, ref list2, ref list3);
            Scribe_Values.Look<int>(ref this.tickCounter, "tickCounterDrunkenPassion", 0, true);

        }

        public override void WorldComponentTick()
        {


            tickCounter++;
            if (tickCounter > tickInterval)
            {
                foreach(Pawn pawn in PawnsFinder.AllMaps_FreeColonistsAndPrisonersSpawned)
                {
                    Hediff firstHediffOfDef = pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.AlcoholHigh);
                    if (firstHediffOfDef != null && firstHediffOfDef.Visible)
                    {
                        foreach (SkillRecord skill in pawn.skills.skills)
                        {
                            if (skill.passion == (Passion)InternalDefOf.AS_DrunkenPassion.index)
                            {
                                drunkenPassionPawns[pawn] = skill.def;
                            }

                        }
                    }
                    else
                    {
                        if (drunkenPassionPawns.ContainsKey(pawn))
                        {
                            drunkenPassionPawns.Remove(pawn);
                        }
                    }

                }


                tickCounter = 0;
            }



        }

        


    }


}
