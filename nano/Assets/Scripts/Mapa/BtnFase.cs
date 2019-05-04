using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFase : MonoBehaviour{
    public int numFase;
    public FaseScriptableModel fases;

    public void Awake(){
        fases.WakeUp += WakeUp;
        fases.Sleep += Sleep;
    }

    public void WakeUp(){
        if(fases.jogadorCompletou[numFase])
            GetComponent<Animator>().SetTrigger("finalizada");
        else if(numFase == 0 || fases.jogadorCompletou[numFase-1])
            GetComponent<Animator>().SetTrigger("atual");
        else
            GetComponent<Animator>().SetTrigger("default");
    }
    public void Sleep(){
        GetComponent<Animator>().SetTrigger("none");
    }

    public void hehe(){
        print("hehe");
    }
}