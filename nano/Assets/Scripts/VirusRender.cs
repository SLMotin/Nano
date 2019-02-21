using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusRender : MonoBehaviour{
    Animator virusAnimation;
    void Start(){
        virusAnimation = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    void Update(){
        Vector2 botLeftCamera = Camera.main.ScreenToWorldPoint(new Vector3(-Screen.width/10f, -Screen.height/10f, 0));
        Vector2 topRightCamera = Camera.main.ScreenToWorldPoint(new Vector3(11f*Screen.width/10, 11f*Screen.height/10, 0));

        if(transform.position.x > botLeftCamera.x && transform.position.x < topRightCamera.x && transform.position.y > botLeftCamera.y && transform.position.y < topRightCamera.y)
            virusAnimation.enabled = true;
        else
            virusAnimation.enabled = false;
            
    }
}