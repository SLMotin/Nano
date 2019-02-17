using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour{
    public static float YCameraValue = 0f; //global Y position of the camera
    private static float speed = 1f; //speed of the camera
    public static Vector2 Speed {
        get{
            return  new Vector2(0, speed);
        }
    }

    void LateUpdate(){
        transform.position += (Vector3) CameraMoviment.Speed * Time.deltaTime;
        CameraMoviment.YCameraValue = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
    }
}