using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBtns : MonoBehaviour{
    public event Action OnChangeAmmo = delegate{};
    public void ChangeAmmo(){
        OnChangeAmmo();
    }


    public event Action OnPause = delegate{};
    public void Pause(){
        Time.timeScale = (Time.timeScale + 1) % 2;
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
