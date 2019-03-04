using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShipChangeAmmo : MonoBehaviour, IChangeAmmo{
    public IShoot Shooter { get; set; }
    List<GameObject> Ammos = new List<GameObject>();
    int ammoIndex;
    void Awake(){
        ammoIndex = 0;
        Shooter = GetComponent<IShoot>();
        Ammos.Add(Resources.Load<GameObject>("Prefab/Bullet"));
        Ammos.Add(Resources.Load<GameObject>("Prefab/ShockBullet"));
        GameObject.Find("GameBtns").GetComponent<GameBtns>().OnChangeAmmo += Change;
    }
    void Update(){
        if(Input.GetKeyDown("space"))
            Change();
    }
    public void Change(){
        ammoIndex = (ammoIndex + 1) % Ammos.Count;
        Shooter.ProjectilePrefab = Ammos[ammoIndex];
    }
}