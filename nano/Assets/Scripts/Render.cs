using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Render : MonoBehaviour{
    GameObject graph;
    void Start(){
        graph = gameObject.transform.GetChild(0).gameObject;
    }

    void Update(){
        Vector2 botLeftCamera = Camera.main.ScreenToWorldPoint(new Vector3(-Screen.width/2f, -Screen.height/5f, 0));
        Vector2 topRightCamera = Camera.main.ScreenToWorldPoint(new Vector3(1.5f*Screen.width, 1.2f*Screen.height, 0));

        if(transform.position.x > botLeftCamera.x && transform.position.x < topRightCamera.x && transform.position.y > botLeftCamera.y && transform.position.y < topRightCamera.y)
            graph.SetActive(true);
        else
            graph.SetActive(false);
    }
}