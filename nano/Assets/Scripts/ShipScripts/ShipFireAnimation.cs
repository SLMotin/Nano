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
        if(lastYPosition > transform.position.y && state != 1){
            animator.SetInteger("burst", 1);
            state = 1;
            print("1");
        }
        else if(lastYPosition < transform.position.y && state != -1){
            animator.SetInteger("burst", -1);
            state = -1;
            print("11");
        }
        else if(state != 0){
            animator.SetInteger("burst", 0);
            state = 0;
            print("111");
        }
        lastYPosition = transform.position.y;
    }
}