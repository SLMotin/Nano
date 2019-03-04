using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBtns : MonoBehaviour{
    public event Action OnChangeAmmo = delegate{};
    public event Action OnPause = delegate{};
    public void ChangeAmmo(){
        OnChangeAmmo();
    }
    public void Pause(){
        Time.timeScale = (Time.timeScale + 1) % 2;
        OnPause();
    }
}
