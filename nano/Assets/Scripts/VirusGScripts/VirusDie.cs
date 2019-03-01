using UnityEngine;
public class VirusDie : MonoBehaviour, IDie{
    public IHaveLife HaveLife { get; set; }
    void Awake(){
        HaveLife = GetComponent<IHaveLife>();
        HaveLife.OnDied += Die;
    }
    public void Die(){
        Destroy(gameObject);
    }
}