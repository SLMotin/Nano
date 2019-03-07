using UnityEngine;
public class VirusPMoveDown : MonoBehaviour, IMove{
    float speed;
    public ICanMove CanMove { get; set; }
    public IDetachFromTrack DetachFromTrack { get; set; }
    public IEnterOnScreen EnterOnScreen { get; set; }

    void Awake(){
        CanMove = GetComponent<ICanMove>();
        DetachFromTrack = GetComponent<IDetachFromTrack>();
        EnterOnScreen = GetComponent<IEnterOnScreen>();
        speed = 0.8f;
    }
    void Update(){
        if(DetachFromTrack != null)
            DetachFromTrack.DetachFromTrack();
        if(EnterOnScreen != null)
            EnterOnScreen.EnterOnScreen();
        Move();
    }
    public void Move(){
        if(CanMove.CanMove()){
            Vector3 direction = new Vector3(0f, -1f, 0f);

            transform.position += direction * speed * Time.deltaTime;
        }
    }
}