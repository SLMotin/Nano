using UnityEngine;
using UnityEngine.SceneManagement;
public class ShipDie : MonoBehaviour, IDie{
    public IHaveLife HaveLife { get; set; }
    void Awake(){
        HaveLife = GetComponent<IHaveLife>();
        HaveLife.OnDied += Die;
    }
    public void Die(){
		  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}