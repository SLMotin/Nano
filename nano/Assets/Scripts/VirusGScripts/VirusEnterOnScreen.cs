using System;
using UnityEngine;
public class VirusEnterOnScreen : MonoBehaviour, IEnterOnScreen{
    public bool HasEndedEnterOnScreen { get; set; }
    private bool HasEndedAnimation;
    private float IdleTimeAfterAnimation;
    public bool HasStartedAnimation { get; set; }
    public ICanEnterOnScreen CanEnterOnScreen { get; set; }
    Animator animator;
    public int EnterScreenAnimationNumber;
    void Awake(){
        CanEnterOnScreen = GetComponent<ICanEnterOnScreen>();
        animator = GetComponent<Animator>();
        HasEndedEnterOnScreen = false;
        HasStartedAnimation = false;
        HasEndedAnimation = false;
        IdleTimeAfterAnimation = 60f;
    }

    public void EnterOnScreen(){
        if(CanEnterOnScreen.CanEnterOnScreen() && !HasStartedAnimation){
            HasStartedAnimation = true;
            animator.SetInteger("PlayAnimationNumber", EnterScreenAnimationNumber);
        }
        else if(IdleTimeAfterAnimation > 0f && HasEndedAnimation){
            IdleTimeAfterAnimation -= Time.deltaTime;
        }
        else if(IdleTimeAfterAnimation <= 0f)
            HasEndedEnterOnScreen = true;
    }
    public void EndedEnterOnScreenAnimation(){
        Vector3 position = transform.position;
        HasEndedAnimation = true;
        animator.enabled = false;
        transform.position = position;
    }
}