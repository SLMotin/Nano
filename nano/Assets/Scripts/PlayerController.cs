using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;

	public GameObject BulletPrefab;	

	float speed = 5f;
	float shootTime = 0.1f;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

		Shoot();

		UpdatePosition();
	}
	void UpdatePosition(){
		rb.position += new Vector2(
			Input.GetAxis("Horizontal") * speed * Time.deltaTime,
			Input.GetAxis("Vertical") * speed * Time.deltaTime
		);
        rb.position += new Vector2(0, 0.01f); //camera follow
	}

	void Shoot(){
		shootTime -= Time.deltaTime;
		if(shootTime < 0){
			shootTime = 0.1f;
			GameObject ob = Instantiate(BulletPrefab);
			ob.transform.position = rb.position;
		}
	}
}
