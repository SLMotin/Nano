using UnityEngine;
public interface IShoot{
    GameObject ProjectilePrefab { get; set; }
    bool CanShoot();
    void Shoot();
}