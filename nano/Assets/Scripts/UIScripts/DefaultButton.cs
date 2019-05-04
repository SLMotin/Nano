using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultButton : MonoBehaviour, IDefaultButton{
    public event Action OnClick = delegate{};

    public void clicked(){
        OnClick();
    }
}