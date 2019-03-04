using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBtns : MonoBehaviour{
    public event Action OnChangeAmmo = delegate{};
    public void ChangeAmmo(){
        OnChangeAmmo();
    }
}
