using UnityEngine;
public class ShipTouchMove : MonoBehaviour, IMove{
    public ICanMove CanMove { get; set; }
    Vector2 lastPosition;
    Rigidbody2D rb;
    void Awake(){
        CanMove = GetComponent<ICanMove>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        Move();
    }
    public void Move(){
        if(CanMove.CanMove() && Input.touchCount > 0){
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
    }
}