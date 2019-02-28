using System;
using UnityEngine;
public class VirusEnterOnScreen : MonoBehaviour, IEnterOnScreen{
    public bool HasEndedEnterOnScreen { get; set; }
    public bool HasStartedAnimation { get; set; }
    public ICanEnterOnScreen CanEnterOnScreen { get; set; }
    Animator animator;

    void Awake(){
        CanEnterOnScreen = GetComponent<VirusCanEnterOnScreen>();
        animator = GetComponent<Animator>();
        HasEndedEnterOnScreen = false;
        HasStartedAnimation = false;
    }

    public void EnterOnScreen(){
        if(CanEnterOnScreen.CanEnterOnScreen() && !HasStartedAnimation){
            HasStartedAnimation = true;
            animator.SetBool("CanEnter", true);
        }
    }
    public void EndedEnterOnScreenAnimation(){
        HasEndedEnterOnScreen = true;
        animator.enabled = false;
    }
}