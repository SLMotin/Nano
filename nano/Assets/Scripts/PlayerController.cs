using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;

	public GameObject BulletPrefab;	

	int down = 0, up = 0, left = 0, right = 0;

	float speed = 0.1f;
	float shootTime = 0.1f;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

		shoot();

		if(Input.GetKeyDown("down"))
			down++;
		else if(Input.GetKeyDown("up"))
			up++;
		else if(Input.GetKeyDown("right"))
			right++;
		else if(Input.GetKeyDown("left"))
			left++;
		
		if(Input.GetKeyUp("down"))
			down--;
		else if(Input.GetKeyUp("up"))
			up--;
		else if(Input.GetKeyUp("right"))
			right--;
		else if(Input.GetKeyUp("left"))
			left--;

		if(down + up + left + right > 0)
			UpdatePosition();
	}
	void UpdatePosition(){
		Vector2 leftVector = new Vector2(-1f, 0f) * left * speed;
		Vector2 rightVector = new Vector2(1f, 0f) * right * speed;
		Vector2 upVector = new Vector2(0f, 1f) * up * speed;
		Vector2 downVector = new Vector2(0f, -1f) * down * speed;
		rb.position += leftVector  + rightVector  + upVector + downVector;
	}

	void shoot(){
		shootTime -= Time.deltaTime;
		if(shootTime < 0){
			shootTime = 0.1f;
			GameObject ob = Instantiate(BulletPrefab);
			ob.transform.position = rb.position;
		}
	}
}
