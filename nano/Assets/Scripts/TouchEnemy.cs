using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEnemy : BaseEnemy{
    GameObject player;
    float speed = 0.8f;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        life = 10f;

        face = transform.GetChild(0).GetComponent<SpriteRenderer>();
        faceSprites = Resources.LoadAll<Sprite>("Face1");
    }

    void Update(){
        if(CanMove())
            Move();
    }
    void Move(){
        Vector3 direction = (player.transform.position - transform.position).normalized;
        if(direction.x > direction.y)
            direction.x *= 2;
        else
            direction.y *= 2;
        transform.position += ((Vector3)CameraMoviment.Speed + (direction * speed)) * Time.deltaTime;
    }
}