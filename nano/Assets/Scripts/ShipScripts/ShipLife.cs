using System;
using UnityEngine;
public class ShipLife : MonoBehaviour, IHaveLife{
    public int Life { get; set; }
    public event Action OnGotHit = delegate { };
    public event Action OnDied = delegate { };

    void Awake(){
        Life = 1;
    }
    public void OnTriggerEnter2D(Collider2D col){
        bool gotHit = false;
        if(col.tag == "Enemy"){
            Life -= 1;
            gotHit = true;
        }

        if(Life <= 0)
            OnDied();
        else if(gotHit)
            OnGotHit();
    }
}