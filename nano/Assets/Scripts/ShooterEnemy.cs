using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour{
    GameObject player;
    float speed = 0.8f;
    float spanwTime = 1f;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
        if(CameraMoviment.YCameraValue >= transform.position.y)
            transform.position += ((Vector3)CameraMoviment.Speed * 0.8f + (new Vector3(1, 0, 0) * speed)) * Time.deltaTime;

        Vector2 botLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if(transform.position.x > botLeft.x && transform.position.x < topRight.x && transform.position.y > botLeft.y && transform.position.y < topRight.y)
            Shoot();
    }

    void Shoot(){
        if(spanwTime <= 0){
            Debug.Log("Shoot little touch enemys");
            spanwTime = 1f;
        }
        else
            spanwTime -= Time.deltaTime;
    }
}