using UnityEngine;
public class VirusPCanMove : MonoBehaviour, ICanMove{
    public IDetachFromTrack DetachFromTrack;

    void Awake(){
        DetachFromTrack = GetComponent<IDetachFromTrack>();
    }
    public bool CanMove() {
        return DetachFromTrack.HasDetached;
    }
}