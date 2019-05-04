using System;
using UnityEngine;
[Serializable]
public class Vector2VariableArray : IBaseVariable{
    float[] val1;
    float[] val2;

    public System.Object value {
        get{
            Vector2[] vector2 = new Vector2[val1.Length];
            for(int i = 0; i < val1.Length; i++)
                vector2[i] = new Vector2(val1[i], val2[i]);
            return (System.Object)vector2;
        }
        set{
            Vector2[] vector2 = (Vector2[]) value;
            val1 = new float[vector2.Length];
            val2 = new float[vector2.Length];
            for(int i = 0; i < vector2.Length; i++){
                val1[i] = vector2[i].x;
                val2[i] = vector2[i].y;
            }
        }
    }
}