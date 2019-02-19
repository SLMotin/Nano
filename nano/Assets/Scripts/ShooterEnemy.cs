using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : BaseEnemy{
    GameObject player;
    float speed = 0.8f;
    float spanwTime = 2.5f;
    Vector3 direction;
    GameObject touchEnemy;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        direction = new Vector3(
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, 0, 0)).x - transform.position.x,
            0,
            0
        ).normalized;
        life = 30f;

        face = transform.GetChild(0).GetComponent<SpriteRenderer>();
        faceSprites = Resources.LoadAll<Sprite>("Images/Face1");

        touchEnemy = Resources.Load<GameObject>("Prefab/touchenemy");
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
            GameObject te = Instantiate(touchEnemy);
            te.transform.position = transform.position;
            spanwTime = 2.5f;
        }
        else
            spanwTime -= Time.deltaTime;
    }
}