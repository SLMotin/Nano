using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour{
    public float speed;
    private Vector3 speedV;

    void Start(){
        speedV = new Vector3(0, speed, 0);
    }

    void Update(){
        transform.position += speedV * Time.deltaTime;
    }
}