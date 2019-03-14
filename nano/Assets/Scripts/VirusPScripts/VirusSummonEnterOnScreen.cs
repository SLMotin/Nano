using System;
using UnityEngine;
public class VirusSummonEnterOnScreen : MonoBehaviour, IEnterOnScreen{
    public bool HasEndedEnterOnScreen { get; set; }
    public ICanEnterOnScreen CanEnterOnScreen { get; set; }
    public Vector3 direction;
    void Awake(){
        gameObject.AddComponent(typeof(VirusCanEnterOnScreen));
        CanEnterOnScreen = GetComponent<ICanEnterOnScreen>();
        
        gameObject.GetComponent<VirusCanMove>().EnterOnScreen = gameObject.GetComponent<IEnterOnScreen>();

        gameObject.GetComponent<VirusPMove>().EnterOnScreen = gameObject.GetComponent<IEnterOnScreen>();

        HasEndedEnterOnScreen = false;
    }
    public void EnterOnScreen(){

    }
}