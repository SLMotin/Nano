using UnityEngine;
public class VirusMove : MonoBehaviour, IMove{
    float speed;
    public Vector3 direction;
    public ICanMove CanMove { get; set; }
    public IDetachFromTrack DetachFromTrack { get; set; }
    public IEnterOnScreen EnterOnScreen { get; set; }
    void Awake(){
        CanMove = GetComponent<ICanMove>();
        DetachFromTrack = GetComponent<IDetachFromTrack>();
        EnterOnScreen = GetComponent<IEnterOnScreen>();
        speed = 0.2f;
        if(direction.Equals(Vector3.zero))
            direction = new Vector3(
                //Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, 0, 0)).x - transform.position.x,
                1f,
                0,
                0
            ).normalized;
    }

    void Update(){
        if(DetachFromTrack != null)
            DetachFromTrack.DetachFromTrack();
        if(EnterOnScreen != null)
            EnterOnScreen.EnterOnScreen();
        Move();
    }
    public void Move(){
        if(CanMove.CanMove())
            transform.position += direction * speed * Time.deltaTime;
    }
}