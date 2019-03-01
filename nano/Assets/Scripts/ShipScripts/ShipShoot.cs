using UnityEngine;
public class ShipShoot : MonoBehaviour, IShoot{//TODO
    public GameObject ProjectilePrefab { get; set; }
    public bool CanShoot(){
        return true;
    }
    public void Shoot(){
        
    }
}