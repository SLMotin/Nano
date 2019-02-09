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
		Vector2 cornerTopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		Vector2 cornerLeftBot = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

		rb.position += new Vector2(
			Input.GetAxis("Horizontal") * speed * Time.deltaTime,
			Input.GetAxis("Vertical") * speed * Time.deltaTime
		);
		//camera follow
        rb.position += new Vector2(0, 0.01f);

		//fix position
		Vector2 fixedPosition = new Vector2(rb.position.x, rb.position.y);
		if(rb.position.x > cornerTopRight.x)
			fixedPosition.x = cornerTopRight.x;
		else if(rb.position.x < cornerLeftBot.x)
			fixedPosition.x = cornerLeftBot.x;
		if(rb.position.y > cornerTopRight.y)
			fixedPosition.y = cornerTopRight.y;
		else if(rb.position.y < cornerLeftBot.y)
			fixedPosition.y = cornerLeftBot.y;
		
		rb.position = fixedPosition;
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
