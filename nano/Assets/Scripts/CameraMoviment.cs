using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour{
    private static Vector2 speed = new Vector2(0, 1f);
    public static Vector2 Speed {
        get{
            return speed;
        }
    }

    void LateUpdate(){
        transform.position += (Vector3) CameraMoviment.Speed * Time.deltaTime;
    }
}
