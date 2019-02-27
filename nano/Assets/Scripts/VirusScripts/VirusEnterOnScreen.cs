using System;
using UnityEngine;
public class VirusEnterOnScreen : MonoBehaviour, IEnterOnScreen{
    public bool HasEndedEnterOnScreen { get; set; }
    public ICanEnterOnScreen CanEnterOnScreen { get; set; }

    void Awake(){
        CanEnterOnScreen = GetComponent<VirusCanEnterOnScreen>();
        HasEndedEnterOnScreen = false;
    }

    public void EnterOnScreen(){
        if(CanEnterOnScreen.CanEnterOnScreen())
            HasEndedEnterOnScreen = true;
        //to do enter on screen
    }
}