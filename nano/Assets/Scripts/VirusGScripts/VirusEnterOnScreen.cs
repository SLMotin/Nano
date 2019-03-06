using System;
using UnityEngine;
public class VirusEnterOnScreen : MonoBehaviour, IEnterOnScreen{
    public bool HasEndedEnterOnScreen { get; set; }
    public ICanEnterOnScreen CanEnterOnScreen { get; set; }
    private float animationTime = 0f;
    private Vector3 origin;
    private bool instantiateOrigin = false;
    public float a, b;
    void Awake(){
        CanEnterOnScreen = GetComponent<ICanEnterOnScreen>();
        HasEndedEnterOnScreen = false;
    }
    public void EnterOnScreen(){
        if(CanEnterOnScreen.CanEnterOnScreen()){
            CalculateOrigin();    
            if(b < 0 && PontoDaCurva() < animationTime || b >= 0 && PontoDaCurva() >= animationTime){
                HasEndedEnterOnScreen = true;
            }
            else{
                float x = animationTime;
                float y = a*x*x + b*x;
                transform.position = origin + new Vector3(x, y, 0);
                if(b < 0)
                    animationTime += Time.deltaTime;
                else
                    animationTime -= Time.deltaTime;
            }
        }
    }

    private float PontoDaCurva(){
        return -b/(a*2);
    }
    private void CalculateOrigin(){
        if(!instantiateOrigin)
            origin = transform.position;
        instantiateOrigin = true;
    }
}