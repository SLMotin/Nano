using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Boolean2")]
public class VariableBoolean2 : ScriptableObject{
    public bool value;
    public void OnEnable(){
        value = false;
    }
}