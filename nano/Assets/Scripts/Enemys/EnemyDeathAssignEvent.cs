using UnityEngine;
public class EnemyDeathAssignEvent : MonoBehaviour, IAssignEvent{
    IHaveLife HaveLife;
    void Awake(){
        Assign();
    }
    public void Assign(){
        HaveLife = GetComponent<IHaveLife>();
        HaveLife.OnDied += GameObject.Find("GameBtns").GetComponent<GameBtns>().OnEnemyDie;
    }
}