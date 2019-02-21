using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEnemy : BaseEnemy{
    GameObject player;
    float speed = 0.8f;

    new void Start(){
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
        life = 3f;

        //face = transform.GetChild(0).GetComponent<SpriteRenderer>();
        //faceSprites = Resources.LoadAll<Sprite>("Images/Face1");
        animation = GetComponent<Animator>();
    }

    new void Update(){
        base.Update();
        if(CanMove())
            Move();
        CheckSpriteFace();
    }
    void Move(){
        Vector3 direction = (player.transform.position - transform.position).normalized;
        /*if(direction.x > direction.y)
            direction.x *= 2;
        else
            direction.y *= 2;
        */
        direction.x *= 0.5f;
        direction.y *= 1.8f;

        transform.position += ((Vector3)CameraMoviment.Speed + (direction * speed)) * Time.deltaTime;
    }
}