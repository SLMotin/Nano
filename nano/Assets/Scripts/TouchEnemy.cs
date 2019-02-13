using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEnemy : MonoBehaviour{
    GameObject player;
    float speed = 0.8f;
    float life = 10f;

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
        if(col.tag == "NormalBullet"){
            Debug.Log(1);
            life -= 1f;
        }
        if(life <= 0)
            Destroy(gameObject);
    }
}