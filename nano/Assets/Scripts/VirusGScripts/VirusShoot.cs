using UnityEngine;
public class VirusShoot : MonoBehaviour, IShoot{
    public GameObject projectilePrefab;
    public GameObject ProjectilePrefab {
        get{
            return projectilePrefab;
        }
        set{
            projectilePrefab = value;
        }
    }
    private float maxSpanwTime = 1.5f;
    private float spanwTime = 1.5f;

    void Awake(){
        spanwTime = maxSpanwTime;
    }
    void FixedUpdate(){
        Shoot();
    }
    public bool CanShoot(){
        Vector2 botLeftCamera = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2 topRightCamera = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if(transform.position.x > botLeftCamera.x && transform.position.x < topRightCamera.x && transform.position.y > botLeftCamera.y && transform.position.y < topRightCamera.y){
            if(spanwTime <= 0){
                spanwTime = maxSpanwTime;
                return true;
            }
            else{
                spanwTime -= Time.deltaTime;
                return false;
            }
        }
        else
            return false;
    }
    public void Shoot(){
        if(CanShoot()){
            GameObject te = Instantiate(ProjectilePrefab);
            te.AddComponent(typeof(VirusSummonEnterOnScreen));
            te.transform.position = transform.position;
        }
    }
}