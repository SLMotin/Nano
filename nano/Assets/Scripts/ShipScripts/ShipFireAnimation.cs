using UnityEngine;
public class ShipFireAnimation : MonoBehaviour, IHaveAnimation{//TODO
    public Animator animator { get; set; }
    float lastYPosition;
    int state, lastState; //-1 decreaseBurst - 0 idle - 1 increaseBurst
    void Awake(){
        animator = transform.Find("fire").GetComponent<Animator>();
        lastYPosition = transform.position.y;
        state = 0;
    }
    void Update(){
        PlayAnimation();
    }
    public void PlayAnimation(){
        if(transform.position.y > lastYPosition)
            state = 1;
        else if(transform.position.y < lastYPosition)
            state = -1;
        else 
            state = 0;
        
        if(lastState != state)
            animator.SetInteger("burst", state);
        lastState = state;
        lastYPosition = transform.position.y;
    }
}