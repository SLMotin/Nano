using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Boolean")]
public class VariableBoolean : ScriptableObject{
    public bool value;
    public void OnEnable(){
        value = true;
    }
}