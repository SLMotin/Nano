using UnityEngine;
public class ShipShoot : MonoBehaviour, IShoot{
    public GameObject projectilePrefab;
    public GameObject ProjectilePrefab {
        get{
            return projectilePrefab;
        }
        set{
            projectilePrefab = value;
        }
    }
    float shootTime;
    float shootInterval;
    void Awake(){
        shootInterval = 0.1f;
        shootTime = shootInterval;
    }
    void Update(){
        if(CanShoot())
            Shoot();
    }
    public bool CanShoot(){
        return true;
    }
    public void Shoot(){
        shootTime -= Time.deltaTime;
		if(shootTime < 0){
			shootTime = 0.1f;
			GameObject ob = Instantiate(ProjectilePrefab);
			ob.transform.position = transform.position;
			ob.transform.position += new Vector3(0f, 0f, 0.1f);
		}
    }
}