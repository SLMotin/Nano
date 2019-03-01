using System;
using UnityEngine;
public class VirusDetachFromTrack : MonoBehaviour, IDetachFromTrack{
    public ICanDetachFromTrack CanDetach { get; set; }
    public bool HasDetached { get; set; }

    void Awake(){
        CanDetach = GetComponent<ICanDetachFromTrack>();
        HasDetached = false;
    }

    public void DetachFromTrack(){
        if(CanDetach.CanDetach()){
            transform.parent = null;
            HasDetached = true;
        }
    }
}