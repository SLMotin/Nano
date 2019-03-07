using UnityEngine;
public class VirusCanMove : MonoBehaviour, ICanMove{
    public IEnterOnScreen EnterOnScreen;
    public IDetachFromTrack DetachFromTrack;

    void Awake(){
        EnterOnScreen = GetComponent<IEnterOnScreen>();
        DetachFromTrack = GetComponent<IDetachFromTrack>();
    }
    public bool CanMove() {
        if(EnterOnScreen != null)
            return EnterOnScreen.HasEndedEnterOnScreen;
        else if(DetachFromTrack != null)
            return DetachFromTrack.HasDetached;
        else
            return true;
    }
}