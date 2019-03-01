using UnityEngine;
public class ShipMove : MonoBehaviour, IMove{
    public ICanMove CanMove { get; set; }
    Vector2 lastPosition;
    Rigidbody2D rb;
	float speed = 5f;

    void Awake(){
        CanMove = GetComponent<ICanMove>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        Move();
    }
    public void Move(){
        if(Input.touchCount > 0)
            TouchMove();
        else
            KeyMove();
    }

    void TouchMove(){
        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began)
            lastPosition = Camera.main.ScreenToWorldPoint(touch.position);
        else if(touch.phase == TouchPhase.Moved){
            Vector2 posicaoAtual = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 deltaPosition = posicaoAtual - lastPosition;
            lastPosition = posicaoAtual;
            rb.position += deltaPosition;
        }
    }
    void KeyMove(){
        float HorizontalAxis = Input.GetAxis("Horizontal");
        float VesticalAxis = Input.GetAxis("Vertical");
        rb.position += new Vector2(
			HorizontalAxis * speed * Time.deltaTime,
			VesticalAxis * speed * Time.deltaTime
		);
    }
}