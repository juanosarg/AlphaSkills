using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Text;
using System.Reflection;

namespace AlphaSkills
{

    [HarmonyPatch(typeof(SkillUI))]
    [HarmonyPatch("GetSkillDescription")]
    public static class AlphaSkills_SkillUI_GetSkillDescription_Patch
    {

        [HarmonyPostfix]
        public static void AddPassionDescription(SkillRecord sk, ref string __result)
        {

            if (sk.passion != Passion.None)
            {
                VSE.Passions.PassionDef passion = VSE.Passions.PassionManager.PassionToDef(sk.passion);
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine();
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("AS_Passion".Translate(passion.LabelCap) + " - "+ passion.description.CapitalizeFirst());
                __result += stringBuilder.ToString();
            }


        }


    }













}

