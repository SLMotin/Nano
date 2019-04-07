using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameBtns : MonoBehaviour{

    public GameObject BlackLayer;
    GameObject ChangeAmmoBtn;
    void Awake(){
        if(BlackLayer == null)
            BlackLayer = GameObject.Find("BlackLayer");
        if(BlackLayer != null)
            BlackLayer.SetActive(false);
        ChangeAmmoBtn = GameObject.Find("ChangeAmmo");
    }


    public event Action OnChangeAmmo = delegate{};
    public void ChangeAmmo(){
        OnChangeAmmo();
    }


    public event Action OnPause = delegate{};
    public void Pause(){
        Time.timeScale = (Time.timeScale + 1) % 2;
        if(BlackLayer != null)
            BlackLayer.SetActive(!BlackLayer.activeSelf);
        if(ChangeAmmoBtn != null)
            ChangeAmmoBtn.SetActive(!ChangeAmmoBtn.activeSelf);
        OnPause();
    }

    int enemyDown = 0;
    TextMeshProUGUI text;
    public void OnEnemyDie(){
        text = transform.Find("CounterStrike").GetComponent<TextMeshProUGUI>();
        enemyDown++;
        text.text = enemyDown.ToString();
    }


    public void LoadFase1(){
        SceneManager.LoadScene("Fase 1");
    }
}
