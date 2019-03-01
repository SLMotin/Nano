using System;
using UnityEngine;
public class ShipLife : MonoBehaviour, IHaveLife{//TODO
    public int Life { get; set; }
    public event Action OnGotHit = delegate { };
    public event Action OnDied = delegate { };
    public void OnTriggerEnter2D(Collider2D col){

    }
}