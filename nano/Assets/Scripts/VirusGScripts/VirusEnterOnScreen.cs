using System;
using UnityEngine;
public class VirusEnterOnScreen : MonoBehaviour, IEnterOnScreen{
    public bool HasEndedEnterOnScreen { get; set; }
    public ICanEnterOnScreen CanEnterOnScreen { get; set; }
    private float animationTime = 0f;
    private Vector3 origin;
    private bool instantiateOrigin = false;
    public float a, b, c, secondPhaseTime, speed = 1f;
    private float directionAnimation;
    private bool EnterOnScreenPhaseOne = true;
    void Awake(){
        CanEnterOnScreen = GetComponent<ICanEnterOnScreen>();
        HasEndedEnterOnScreen = false;
    }
    public void EnterOnScreen(){
        if(CanEnterOnScreen.CanEnterOnScreen()){
            CalculateOrigin();

            if(EnterOnScreenPhaseOne){
                float x = animationTime;
                float y = a*x*x + b*x + c;
                transform.position = origin + new Vector3(x, y, 0);

                animationTime += directionAnimation * Time.deltaTime * speed;
            }
            if(!HasEndedEnterOnScreen && directionAnimation * PontoDaCurva() < directionAnimation * animationTime){
                EnterOnScreenPhaseOne = false;
                if(secondPhaseTime > 0)
                    secondPhaseTime -= Time.deltaTime;
                else
                    HasEndedEnterOnScreen = true;
            }
        }
    }

    private float PontoDaCurva(){
        return -b/(a*2);
    }
    private void CalculateOrigin(){
        if(!instantiateOrigin){
            origin = transform.position;
            if(b >= 0)
                directionAnimation = -1;
            else
                directionAnimation = 1;
        }
        if(a == 0 && b == 0 && c == 0)
            HasEndedEnterOnScreen = true;
        instantiateOrigin = true;
    }
}