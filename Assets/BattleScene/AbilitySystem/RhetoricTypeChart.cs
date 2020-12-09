using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RhetoricTypeChart
{
    public enum Type
    {
        //Fun -> Logic -> Emotion -> Fun
        Fun,
        Logical,
        Emotional
    }

    static float[,] typeAdvantageChart = new float[,]
    {
        //Fun Abil  Logi Abil   Emo Abil
        {1.0f,      0.5f,       1.5f }, // Fun Target       // Rows are for target
        {1.5f,      1.0f,       0.5f }, // Logical Target
        {0.5f,      1.5f,       1.0f }  // Emotional Target
    };

   public static float GetMultiplier(Type target, Type ability)
    {
        return typeAdvantageChart[(int)target, (int)ability];
    }
}
