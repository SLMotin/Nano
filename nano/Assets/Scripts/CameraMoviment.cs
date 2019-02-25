using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour{
    public static float YCameraValue = 0f; //global Y position of the camera
    public static float deltaYCameraValue = 0f; //global Y position of the camera
    private static float speed = 0f; //speed of the camera
    public static Vector2 Speed {
        get{
            return  new Vector2(0, speed);
        }
    }

    void Start(){
        CameraMoviment.deltaYCameraValue = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
    }

    void Update(){
        CameraMoviment.deltaYCameraValue = CameraMoviment.Speed.y * Time.deltaTime;
        transform.position += new Vector3(0f, CameraMoviment.deltaYCameraValue, 0f);
        
        CameraMoviment.YCameraValue = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
    }
}