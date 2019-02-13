using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEnemy : MonoBehaviour{
    GameObject player;
    float speed = 0.8f;
    float life = 10f;
    float repelForce = 0.5f;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
        Vector3 direction = (player.transform.position - transform.position).normalized;
        if(direction.x > direction.y)
            direction.x *= 2;
        else
            direction.y *= 2;
        transform.position += ((Vector3)CameraMoviment.Speed + (direction * speed)) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "NormalBullet")
            life -= 1f;
        else if(col.tag == "Enemy"){
            Vector3 direction = transform.position - col.transform.position;
            transform.position += direction * repelForce * Time.deltaTime;
        }
        if(life <= 0)
            Destroy(gameObject);
    }
}