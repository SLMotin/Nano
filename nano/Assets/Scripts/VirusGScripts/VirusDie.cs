using UnityEngine;
public class VirusDie : MonoBehaviour, IDie{
    public IHaveLife VirusLife { get; set; }
    void Awake(){
        VirusLife = GetComponent<VirusLife>();
        VirusLife.OnDied += Die;
    }
    public void Die(){
        Destroy(gameObject);
    }
}