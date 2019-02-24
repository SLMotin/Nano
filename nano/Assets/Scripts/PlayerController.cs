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
	Vector2 lastPosition;
	float lastYCameraValue, lastYCameraValueTouch;

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
        Touch touch;
		if(Input.touchCount > 0){
            touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began){
				lastYCameraValueTouch = CameraMoviment.YCameraValue;
				lastPosition = Camera.main.ScreenToWorldPoint(touch.position);
			}
			else if(touch.phase == TouchPhase.Moved)
				inTouch = true;
			else//if(touch.phase == TouchPhase.Ended)
				inTouch = false;
		}
		else
			inTouch = false;

		if(inTouch){
            touch = Input.GetTouch(0);
			Vector2 posicaoAtual = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 deltaPosition = posicaoAtual - lastPosition;
			deltaPosition.y -= CameraMoviment.YCameraValue - lastYCameraValueTouch;
			lastPosition = posicaoAtual;
            rb.position += deltaPosition;
			HorizontalAxis = VesticalAxis = 0;
			lastYCameraValueTouch = CameraMoviment.YCameraValue;
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
        rb.position += new Vector2(0f, CameraMoviment.YCameraValue - lastYCameraValue);

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
		lastYCameraValue = CameraMoviment.YCameraValue;
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