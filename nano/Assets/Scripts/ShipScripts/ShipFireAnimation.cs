using UnityEngine;
public class ShipFireAnimation : MonoBehaviour, IHaveAnimation{//TODO
    public Animator animator { get; set; }
    float lastYPosition;
    int state; //-1 decreaseBurst - 0 idle - 1 increaseBurst
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
            animator.SetInteger("burst", 1);
        else if(transform.position.y < lastYPosition)
            animator.SetInteger("burst", -1);
        else 
            animator.SetInteger("burst", 0);

        lastYPosition = transform.position.y;
    }
}