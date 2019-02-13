using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour{
    private static float speed = 1f;
    public static Vector2 Speed {
        get{
            return  new Vector2(0, speed);
        }
    }

    void LateUpdate(){
        transform.position += (Vector3) CameraMoviment.Speed * Time.deltaTime;
    }
}