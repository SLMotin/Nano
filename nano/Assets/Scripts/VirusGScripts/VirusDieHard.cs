using UnityEngine;
public class VirusDieHard : MonoBehaviour, IDie{
    public GameObject virusM;
    public IHaveLife HaveLife { get; set; }
    void Awake(){
        HaveLife = GetComponent<IHaveLife>();
        HaveLife.OnDied += Die;
        virusM = Resources.Load<GameObject>("Prefab/virusM");
    }
    public void Die(){
        float radius = GetComponent<CircleCollider2D>().radius;
        GameObject virus = Instantiate(virusM);
        virus.transform.position = transform.position + new Vector3(radius, 0, 0);
        virus = Instantiate(virusM);
        virus.transform.position = transform.position - new Vector3(radius, 0, 0);
        Destroy(gameObject);
    }
}