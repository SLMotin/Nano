using System;
using UnityEngine;
[Serializable]
public class Vector2Variable : IBaseVariable{
    float val1;
    float val2;

    public System.Object value {
        get{
            return (System.Object)new Vector2(val1, val2);
        }
        set{
            Vector2 vector2 = (Vector2) value;
            val1 = vector2.x;
            val2 = vector2.y;
        }
    }
}