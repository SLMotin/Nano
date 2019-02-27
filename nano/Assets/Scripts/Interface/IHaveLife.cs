using System;
using UnityEngine;
public interface IHaveLife{
    int Life { get; set; }
    event Action OnGotHit;
    event Action OnDied;
    void OnTriggerEnter2D(Collider2D col);
}