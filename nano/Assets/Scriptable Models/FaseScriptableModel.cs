using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Miscellaneous/Fases")]
public class FaseScriptableModel : BaseScriptable{
    public bool[] jogadorCompletou;
    public event Action WakeUp = delegate{};
    public event Action Sleep = delegate{};

    public void FireWakeUp(){ WakeUp(); }
    public void FireSleep(){ Sleep(); }
}