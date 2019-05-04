using System;
using UnityEngine;
[Serializable]
public class Vector3VariableArray : IBaseVariable{
    float[] val1;
    float[] val2;
    float[] val3;

    public System.Object value {
        get{
            Vector3[] vector3 = new Vector3[val1.Length];
            for(int i = 0; i < val1.Length; i++)
                vector3[i] = new Vector3(val1[i], val2[i], val3[i]);
            return (System.Object)vector3;
        }
        set{
            Vector3[] vector3 = (Vector3[]) value;
            val1 = new float[vector3.Length];
            val2 = new float[vector3.Length];
            val3 = new float[vector3.Length];
            for(int i = 0; i < vector3.Length; i++){
                val1[i] = vector3[i].x;
                val2[i] = vector3[i].y;
                val3[i] = vector3[i].z;
            }
        }
    }
}