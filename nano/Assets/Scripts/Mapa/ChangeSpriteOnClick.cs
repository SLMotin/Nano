using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteOnClick : MonoBehaviour{
    public Sprite ativadoSprite, desativadoSprite;
    public bool right;
    public VariableBoolean ativado;

    public void Awake(){
        GetComponent<DefaultButton>().OnClick += mudaEstado;
    }

    public void Update(){
        changeBtn();
    }
    public void mudaEstado(){
        ativado.value = !ativado.value;
    }
    public void changeBtn(){
        if((!right && !ativado.value) || (right && ativado.value))
            GetComponent<Image>().sprite = ativadoSprite;
        else
            GetComponent<Image>().sprite = desativadoSprite;
    }
}