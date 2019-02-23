using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;

	public GameObject BulletPrefab;	

	float speed = 5f;
	float shootTime = 0.1f;
	Vector2 shipSize;
	float HorizontalAxis, VesticalAxis;

	bool inTouch = false;
	Vector2 controlTouchOrigin;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		shipSize = GetComponent<BoxCollider2D>().size / 2f;
	}
	
	void Update () {
		UpdateAxis();

		Shoot();

		UpdatePosition();
	}
	void UpdateAxis(){
		Vector2 direction;
        Touch touch;
		if(Input.touchCount > 0){
            touch = Input.GetTouch(0);
			/*if(touch.phase == TouchPhase.Began){
				inTouch = true;
				controlTouchOrigin = touch.position;
				direction = touch.position - controlTouchOrigin;
			}
			else if(touch.phase == TouchPhase.Moved){
				direction = touch.position - controlTouchOrigin;
			}
			else if(touch.phase == TouchPhase.Ended)
				inTouch = false;
			*/
			if(touch.phase == TouchPhase.Moved)
				inTouch = true;
			else if(touch.phase == TouchPhase.Ended)
				inTouch = false;
		}

		/*if(inTouch){
			if(touch.position.x - controlTouchOrigin.x >= 0.5f || touch.position.x - controlTouchOrigin.x <= -0.5f)
				HorizontalAxis = touch.position.x - controlTouchOrigin.x;
			if(touch.position.y - controlTouchOrigin.y >= 0.5f || touch.position.y - controlTouchOrigin.y <= -0.5f)
				VesticalAxis = touch.position.y - controlTouchOrigin.y;
			
			if(HorizontalAxis > 1f)
				HorizontalAxis = 1f;
			if(HorizontalAxis < -1f)
				HorizontalAxis = -1f;
			
			if(VesticalAxis > 1f)
				VesticalAxis = 1f;
			if(VesticalAxis < -1f)
				VesticalAxis = -1f;

			HorizontalAxis /= 2;
			VesticalAxis /= 2;
		}*/
		if(inTouch){
            touch = Input.GetTouch(0);
            Vector2 x = Camera.main.ScreenToWorldPoint(touch.deltaPosition);

            rb.position += x;
			HorizontalAxis = 0;
			VesticalAxis = 0;
		}
		else{
			HorizontalAxis = Input.GetAxis("Horizontal");
			VesticalAxis = Input.GetAxis("Vertical");
		}
	}
	

	void UpdatePosition(){
		Vector2 cornerTopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		Vector2 cornerLeftBot = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

		rb.position += new Vector2(
			HorizontalAxis * speed * Time.deltaTime,
			VesticalAxis * speed * Time.deltaTime
		);
		//camera follow
        rb.position += CameraMoviment.Speed * Time.deltaTime;

		//fix position
		Vector2 fixedPosition = new Vector2(rb.position.x, rb.position.y);
		if(rb.position.x > cornerTopRight.x - shipSize.x)
			fixedPosition.x = cornerTopRight.x - shipSize.x;
		else if(rb.position.x < cornerLeftBot.x + shipSize.x)
			fixedPosition.x = cornerLeftBot.x + shipSize.x;
		if(rb.position.y > cornerTopRight.y - shipSize.y)
			fixedPosition.y = cornerTopRight.y - shipSize.y;
		else if(rb.position.y < cornerLeftBot.y + shipSize.y)
			fixedPosition.y = cornerLeftBot.y + shipSize.y;
		
		rb.position = fixedPosition;
	}

	void Shoot(){
		shootTime -= Time.deltaTime;
		if(shootTime < 0){
			shootTime = 0.1f;
			GameObject ob = Instantiate(BulletPrefab);
			ob.transform.position = rb.position;
			ob.transform.position += new Vector3(0f, 0f, 0.1f);
		}
	}

	void RestartScene(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Enemy"){
			RestartScene();
		}
	}
}