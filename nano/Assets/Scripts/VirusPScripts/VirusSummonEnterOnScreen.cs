using UnityEngine;
public class VirusSummonEnterOnScreen : MonoBehaviour, IEnterOnScreen{
    public bool HasEndedEnterOnScreen { get; set; }
    public ICanEnterOnScreen CanEnterOnScreen { get; set; }
    public Vector3 direction;
    private float timeShoot;
    void Awake(){
        gameObject.AddComponent(typeof(VirusCanEnterOnScreen));
        CanEnterOnScreen = GetComponent<ICanEnterOnScreen>();
        
        gameObject.GetComponent<VirusCanMove>().EnterOnScreen = gameObject.GetComponent<IEnterOnScreen>();

        gameObject.GetComponent<VirusPMove>().EnterOnScreen = gameObject.GetComponent<IEnterOnScreen>();

        direction = Random.insideUnitCircle.normalized;
        timeShoot = 1f;

        HasEndedEnterOnScreen = false;
    }
    public void EnterOnScreen(){
        if(!HasEndedEnterOnScreen){
            transform.position += (Vector3)direction * timeShoot * 0.12f;

            timeShoot -= Time.deltaTime;
            if(timeShoot <= 0)
                HasEndedEnterOnScreen = true;
        }
    }
}