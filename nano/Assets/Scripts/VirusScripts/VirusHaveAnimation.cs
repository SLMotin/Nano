using UnityEngine;
public class VirusHaveAnimation : MonoBehaviour, IHaveAnimation{
    public Animator animator { get; set; }
    public VirusLife HitTrigger;
    float hitTimer;
    bool gotHit;
    void Awake(){
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        HitTrigger = GetComponent<VirusLife>();
        HitTrigger.OnGotHit += GotHit;
        hitTimer = 0f;
        gotHit = false;
    }
    void Update(){
        PlayAnimation();
    }
    public void PlayAnimation(){
        PainAnimation();
    }
    public void PainAnimation(){
        if(hitTimer <= 0 && gotHit){
            animator.SetBool("inPain", false);
            gotHit = false;
        }
        else if(hitTimer > 0 && !gotHit){
            animator.SetBool("inPain", true);
            gotHit = true;
        }
        if(hitTimer > 0)
            hitTimer -= Time.deltaTime;
    }
    public void GotHit(){
        hitTimer = 0.5f;
        PlayAnimation();
    }
}