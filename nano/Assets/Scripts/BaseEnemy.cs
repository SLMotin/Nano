using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour{

    public float life = 1f;
    public float repelForce = 0.5f;
    //public SpriteRenderer face;
    //public Sprite[] faceSprites;
    public bool gotHit = false;
    private float hitTimer = 0f;
    public Animator animation;

    public void Start(){
        animation = transform.GetChild(0).gameObject.GetComponent<Animator>();
        //animation.SetTrigger(true);
        //animation.SetInteger("sentiuDor", 2);
        //animation.SetFloat("sentiuDor", 2.1f);

    }
    public void Update(){

    }

    public bool CanMove(){
        if(CameraMoviment.YCameraValue >= transform.position.y)
            return true;
        else
            return false;
    }
    public bool CanShoot(){
        Vector2 botLeftCamera = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2 topRightCamera = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if(transform.position.x > botLeftCamera.x && transform.position.x < topRightCamera.x && transform.position.y > botLeftCamera.y && transform.position.y < topRightCamera.y)
            return true;
        else
            return false;
    }

    public void GotHit(){
        hitTimer = 0.5f;
    }

    public void CheckSpriteFace(){
        if(hitTimer <= 0 && gotHit){
            animation.SetBool("inPain", false);
            gotHit = false;
        }
        else if(hitTimer > 0 && !gotHit){
            animation.SetBool("inPain", true);
            gotHit = true;
        }
        if(hitTimer > 0)
            hitTimer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "NormalBullet"){
            life -= 1f;
            GotHit();
        }
        else if(col.tag == "Enemy"){
            float repelDistance = 0f;
            if(((CircleCollider2D)col).radius != null)
                repelDistance += ((CircleCollider2D)col).radius/2;
            repelDistance += gameObject.GetComponent<CircleCollider2D>().radius/2;

            Vector3 direction = (transform.position - col.transform.position).normalized;
            transform.position += direction * repelDistance * Time.deltaTime;
        }
        if(life <= 0)
            Destroy(gameObject);
    }
}