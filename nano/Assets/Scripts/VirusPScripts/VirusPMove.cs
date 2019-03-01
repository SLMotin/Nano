using UnityEngine;
public class VirusPMove : MonoBehaviour, IMove{
    float speed;
    public ICanMove CanMove { get; set; }
    public IDetachFromTrack DetachFromTrack { get; set; }
    public IEnterOnScreen EnterOnScreen { get; set; }
    GameObject player;

    void Awake(){
        CanMove = GetComponent<ICanMove>();
        DetachFromTrack = GetComponent<IDetachFromTrack>();
        EnterOnScreen = GetComponent<IEnterOnScreen>();
        speed = 0.8f;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update(){
        DetachFromTrack.DetachFromTrack();
        Move();
    }
    public void Move(){
        if(CanMove.CanMove()){
            Vector3 direction = (player.transform.position - transform.position).normalized;

            direction.x *= 0.5f;
            direction.y *= 1.8f;

            transform.position += direction * speed * Time.deltaTime;
        }
    }
}