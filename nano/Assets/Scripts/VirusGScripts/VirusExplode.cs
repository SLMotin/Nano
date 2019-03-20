using UnityEngine;
public class VirusExplode : MonoBehaviour{
    public IHaveLife HaveLife { get; set; }
    private GameObject ProjectilePrefab;
    public int numberOfProjectiles;
    void Awake(){
        HaveLife = GetComponent<IHaveLife>();
        HaveLife.OnDied += Explode;

        ProjectilePrefab = GetComponent<IShoot>() != null ? GetComponent<IShoot>().ProjectilePrefab : null;
    }
    public void Explode(){
        if(ProjectilePrefab != null)
        for (int i = 0; i < numberOfProjectiles; i++){
            GameObject te = Instantiate(ProjectilePrefab);
            te.AddComponent(typeof(VirusSummonEnterOnScreen));
            te.transform.position = transform.position;    
        }
        
    }
}