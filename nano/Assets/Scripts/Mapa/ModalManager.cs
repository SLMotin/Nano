using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalManager : MonoBehaviour{
    public VariableInteger fase;
    public GameObject LowPanel;
    public VariableBoolean2 modalOpen;

    public void play(){
        SceneManager.LoadScene("Fase " + fase.value);
    }
    public void closeModal(){
        GetComponent<Animator>().SetTrigger("closeModal");
        LowPanel.GetComponent<Animator>().SetTrigger("goup");
        modalOpen.value = false;
    }
}