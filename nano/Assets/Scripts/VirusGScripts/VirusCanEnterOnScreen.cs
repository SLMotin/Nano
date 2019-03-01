using System;
using UnityEngine;
public class VirusCanEnterOnScreen : MonoBehaviour, ICanEnterOnScreen{
    public IDetachFromTrack DetachFromTrack { get; set; }
    void Awake(){
        DetachFromTrack = GetComponent<IDetachFromTrack>();
    }

    public bool CanEnterOnScreen(){
        return DetachFromTrack.HasDetached;
    }
}