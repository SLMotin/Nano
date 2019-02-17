using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : BaseEnemy{
    GameObject player;
    float speed = 0.8f;
    float spanwTime = 1f;
    Vector3 direction;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        direction = new Vector3(
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, 0, 0)).x - transform.position.x,
            0,
            0
        ).normalized;
        life = 30f;

        //face = transform.GetChild(0).GetComponent<SpriteRenderer>();
        faceSprites = Resources.LoadAll<Sprite>("Face1");
    }

    void Update(){
        if(CanMove())
            Move();
        if(CanShoot())
            Shoot();
        CheckSpriteFace();
    }
    void Move(){
        transform.position += ((Vector3)CameraMoviment.Speed + direction) * speed * Time.deltaTime;
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