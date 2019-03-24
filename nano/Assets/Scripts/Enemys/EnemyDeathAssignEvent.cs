using UnityEngine;
public class EnemyDeathAssignEvent : MonoBehaviour, IAssignEvent{
    IHaveLife HaveLife;
    void Awake(){
        Assign();
    }
    public void Assign(){
        //comment pra dar um commit fingindo que estou trabalhando hehehehe
        HaveLife = GetComponent<IHaveLife>();
        HaveLife.OnDied += GameObject.Find("GameBtns").GetComponent<GameBtns>().OnEnemyDie;
    }
}