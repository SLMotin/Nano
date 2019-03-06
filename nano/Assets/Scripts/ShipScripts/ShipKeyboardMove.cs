using UnityEngine;
public class ShipKeyboardMove : MonoBehaviour, IMove{
    public ICanMove CanMove { get; set; }
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
        if(CanMove.CanMove()){
            float HorizontalAxis = Input.GetAxis("Horizontal");
            float VesticalAxis = Input.GetAxis("Vertical");
            rb.position += new Vector2(
                HorizontalAxis * speed * Time.deltaTime,
                VesticalAxis * speed * Time.deltaTime
            );
        }
    }
}