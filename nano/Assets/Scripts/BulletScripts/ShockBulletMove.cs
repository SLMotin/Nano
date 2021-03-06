using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockBulletMove : MonoBehaviour, IMove {
	Rigidbody2D rb;
	public ICanMove CanMove { get; set; }
	float speed = 10f;
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate () {
		Move();
	}
	public void Move(){
        rb.position += (Vector2)transform.up * speed * Time.deltaTime;
        rb.position += new Vector2(Random.Range(-0.1f, 0.1f), 0f);
        if(rb.position.y > Camera.main.ScreenToWorldPoint(new Vector2(0f, Screen.height*1.3f)).y)
            Destroy(gameObject);
	}
}



