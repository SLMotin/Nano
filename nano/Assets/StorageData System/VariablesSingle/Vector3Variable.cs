using System;
using UnityEngine;
[Serializable]
public class Vector3Variable : IBaseVariable{
    float val1;
    float val2;
    float val3;

    public System.Object value {
        get{
            return (System.Object)new Vector3(val1, val2, val3);
        }
        set{
            Vector3 vector3 = (Vector3) value;
            val1 = vector3.x;
            val2 = vector3.y;
            val3 = vector3.z;
        }
    }
}