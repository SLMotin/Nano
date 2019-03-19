using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBtns : MonoBehaviour{

    GameObject BlackLayer;
    GameObject ChangeAmmoBtn;
    void Awake(){
        BlackLayer = GameObject.Find("BlackLayer"); BlackLayer.SetActive(false);
        ChangeAmmoBtn = GameObject.Find("ChangeAmmo");
    }


    public event Action OnChangeAmmo = delegate{};
    public void ChangeAmmo(){
        OnChangeAmmo();
    }


    public event Action OnPause = delegate{};
    public void Pause(){
        Time.timeScale = (Time.timeScale + 1) % 2;
        BlackLayer.SetActive(!BlackLayer.activeSelf);
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
}
