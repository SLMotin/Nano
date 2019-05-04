using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour{
    public GameObject leftbtn, rightbtn, background;
    public bool zoomIn;
    public FaseScriptableModel fases;
    
    public void Awake(){
        leftbtn.GetComponent<DefaultButton>().OnClick += LeftBtn;
        rightbtn.GetComponent<DefaultButton>().OnClick += RightBtn;
    }

    public void RightBtn(){
        if(!zoomIn){
            zoomIn = !zoomIn;
            background.GetComponent<Animator>().SetTrigger("zoomIn");
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("zoomIn");
            fases.FireWakeUp();
        }
    }
    public void LeftBtn(){
        if(zoomIn){
            zoomIn = !zoomIn;
            background.GetComponent<Animator>().SetTrigger("zoomOut");
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("zoomOut");
            fases.FireSleep();
        }
    }
}