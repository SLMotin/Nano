using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.position += new Vector2(0f, 10f * Time.deltaTime);
		if(rb.position.y > Camera.main.ScreenToWorldPoint(new Vector2(0f, Screen.height)).y)
            Destroy(gameObject);
	}
	void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Enemy")
            Destroy(gameObject);
	}
}