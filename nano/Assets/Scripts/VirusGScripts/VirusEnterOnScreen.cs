using System;
using UnityEngine;
public class VirusEnterOnScreen : MonoBehaviour, IEnterOnScreen{
    public bool HasEndedEnterOnScreen { get; set; }
    public ICanEnterOnScreen CanEnterOnScreen { get; set; }
    public float animationTime = 0f;
    public Vector3 origin;
    public bool instantiateOrigin = false;
    void Awake(){
        CanEnterOnScreen = GetComponent<ICanEnterOnScreen>();
        HasEndedEnterOnScreen = false;
    }
    public void EnterOnScreen(){
        if(CanEnterOnScreen.CanEnterOnScreen()){
            if(!instantiateOrigin)
                origin = transform.position;
            instantiateOrigin = true;

            float x = animationTime;
            float y = x*x - 6f*x;
            transform.position = origin + new Vector3(x, y, 0);
            print(origin + " " + transform.position + " " + animationTime + " " + new Vector3(x, y, 0));
            animationTime += Time.deltaTime;
        }
        else
            print(transform.position);
    }

}