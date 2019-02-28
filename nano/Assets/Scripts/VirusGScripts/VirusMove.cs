using UnityEngine;
public class VirusMove : MonoBehaviour, IMove{
    float speed;
    Vector3 direction;
    public ICanMove CanMove { get; set; }
    public IDetachFromTrack DetachFromTrack { get; set; }
    public IEnterOnScreen EnterOnScreen { get; set; }
    void Awake(){
        CanMove = GetComponent<VirusCanMove>();
        DetachFromTrack = GetComponent<VirusDetachFromTrack>();
        EnterOnScreen = GetComponent<VirusEnterOnScreen>();
        speed = 0.2f;
        direction = new Vector3(
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, 0, 0)).x - transform.position.x,
            0,
            0
        ).normalized;
    }

    void Update(){
        DetachFromTrack.DetachFromTrack();
        EnterOnScreen.EnterOnScreen();
        Move();
    }
    public void Move(){
        if(CanMove.CanMove())
            gameObject.transform.position += direction * speed * Time.deltaTime;
    }
}