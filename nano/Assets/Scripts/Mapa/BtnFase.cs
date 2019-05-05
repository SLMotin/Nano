using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnFase : MonoBehaviour{
    public int numFase;
    public string FaseName;
    public VariableString faseNameObj;
    public VariableBoolean2 modalOpen;
    public FaseScriptableModel fases;
    public GameObject modal;
    public GameObject LowPanel;
    Button btn;

    public void Awake(){
        fases.WakeUp += WakeUp;
        fases.Sleep += Sleep;
        btn = GetComponent<Button>();
    }
    public void Update(){
        btn.interactable = !modalOpen.value;
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
        faseNameObj.value = FaseName;
        print(FaseName);
        print(faseNameObj.value);
        modal.GetComponent<Animator>().SetTrigger("openModal");
        LowPanel.GetComponent<Animator>().SetTrigger("godown");
        modalOpen.value = true;
    }
}