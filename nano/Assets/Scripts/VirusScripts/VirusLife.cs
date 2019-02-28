using System;
using UnityEngine;
public class VirusLife : MonoBehaviour, IHaveLife{
    public int Life { get; set; }
    public event Action OnGotHit = delegate { };
    public event Action OnDied = delegate { };
    void Awake(){
        Life = 80;
    }
    public void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "NormalBullet"){
            Life -= 1;
            OnGotHit();
        }
        else if(col.tag == "Enemy"){
            // to do remove this from here (some collision treatment)
            float repelDistance = 0f;
            if(((CircleCollider2D)col).radius >= gameObject.GetComponent<CircleCollider2D>().radius)
                repelDistance += gameObject.GetComponent<CircleCollider2D>().radius/10;

            Vector3 ndirection = (transform.position - col.transform.position).normalized;
            transform.position += ndirection * repelDistance;
        }
        if(Life <= 0)
            OnDied();
    }
}