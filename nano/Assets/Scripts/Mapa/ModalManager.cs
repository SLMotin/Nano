using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalManager : MonoBehaviour{
    public VariableString fase;
    public GameObject LowPanel;
    public VariableBoolean2 modalOpen;

    public void play(){
        SceneManager.LoadScene(fase.value);
    }
    public void closeModal(){
        GetComponent<Animator>().SetTrigger("closeModal");
        LowPanel.GetComponent<Animator>().SetTrigger("goup");
        modalOpen.value = false;
    }
}