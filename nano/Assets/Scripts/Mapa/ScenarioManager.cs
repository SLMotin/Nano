using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScenarioManager : MonoBehaviour{
    public GameObject leftbtn, rightbtn, background, menuSuperior;
    public bool zoomIn;
    public FaseScriptableModel fases;
    public TextMeshProUGUI text;
    public void Awake(){
        leftbtn.GetComponent<DefaultButton>().OnClick += LeftBtn;
        rightbtn.GetComponent<DefaultButton>().OnClick += RightBtn;
    }

    public void RightBtn(){
        if(!zoomIn){
            text.text = "Pulmão";
            zoomIn = !zoomIn;
            background.GetComponent<Animator>().SetTrigger("zoomIn");
            menuSuperior.GetComponent<Animator>().SetTrigger("down");
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("zoomIn");
            fases.FireWakeUp();
        }
    }
    public void LeftBtn(){
        if(zoomIn){
            text.text = "";
            zoomIn = !zoomIn;
            menuSuperior.GetComponent<Animator>().SetTrigger("up");
            background.GetComponent<Animator>().SetTrigger("zoomOut");
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("zoomOut");
            fases.FireSleep();
        }
    }
}