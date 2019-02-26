using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : BaseEnemy{
    float speed = 0.9f;
    float spanwTime = 2.5f;
    Vector3 direction;
    GameObject touchEnemy, virusM;
    new void Start(){
        base.Start();
        life = 80f;

        touchEnemy = Resources.Load<GameObject>("Prefab/virusP");
        virusM = Resources.Load<GameObject>("Prefab/virusM");

        direction = new Vector3(
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, 0, 0)).x - transform.position.x,
            0,
            0
        ).normalized;
    }

    new void Update(){
        base.Update();
        if(CanMove())
            Move();
        if(CanShoot())
            Shoot();
        CheckSpriteFace();
    }
    void Move(){
        transform.position += ((Vector3)CameraMoviment.Speed * speed  + direction * 0.2f) * Time.deltaTime;
    }
    void Shoot(){
        if(spanwTime <= 0){
            GameObject te = Instantiate(touchEnemy);
            te.transform.position = transform.position;

            spanwTime = 1.5f;
        }
        else
            spanwTime -= Time.deltaTime;
    }
    public override void Defeated(){
        GameObject virus = Instantiate(virusM);
        float radius = gameObject.GetComponent<CircleCollider2D>().radius;
        virus.transform.position = new Vector2(transform.position.x + radius/2, transform.position.y);
        virus = Instantiate(virusM);
        virus.transform.position = new Vector2(transform.position.x - radius/2, transform.position.y);
    }
}