using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BaseScriptable : ScriptableObject{
    public string ID;

    public BaseModel ListValue { get; set; }
    public void Save(){
        ListValue = new BaseModel();
        Type fieldsType = this.GetType();
        FieldInfo[] fields = fieldsType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        for(int i = 0; i < fields.Length; i++)
            AddValueToList(fields[i]);
        StorageData.SaveData(ListValue, ID);
    }
    public void Load(){
        Type fieldsType = this.GetType();
        FieldInfo[] fields = fieldsType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        ListValue = StorageData.LoadData(ID);
        if(ListValue == null){
            ListValue = new BaseModel();
            for(int i = 0; i < fields.Length; i++){
                //Debug.Log(fields[i].Name + " : " + fields[i].GetValue(this) + " : " + fields[i].ReflectedType + " : " + fields[i].FieldType);
                AddValueToList(fields[i]);
            }
        }
        else{
            for(int i = 0; i < fields.Length; i++)
                if(ListValue[fields[i].Name] != null)
                    fields[i].SetValue(this, ListValue[fields[i].Name].value);
        }
    }
    private void AddValueToList(FieldInfo f){
        IBaseVariable variable = null;
        if(f.FieldType.ToString() == "System.String")
            variable = new StringVariable();
        else if(f.FieldType.ToString() == "System.Int32")
            variable = new IntegerVariable();
        else if(f.FieldType.ToString() == "System.Single")
            variable = new FloatVariable();
        else if(f.FieldType.ToString() == "System.Boolean")
            variable = new BooleanVariable();
        else if(f.FieldType.ToString() == "System.String[]")
            variable = new StringVariableArray();
        else if(f.FieldType.ToString() == "System.Int32[]")
            variable = new IntegerVariableArray();
        else if(f.FieldType.ToString() == "System.Single[]")
            variable = new FloatVariableArray();
        else if(f.FieldType.ToString() == "System.Boolean[]")
            variable = new BooleanVariableArray();
        else if(f.FieldType.ToString() == "UnityEngine.Vector2")
            variable = new Vector2Variable();
        else if(f.FieldType.ToString() == "UnityEngine.Vector3")
            variable = new Vector3Variable();
        else if(f.FieldType.ToString() == "UnityEngine.Vector2[]")
            variable = new Vector2VariableArray();
        else if(f.FieldType.ToString() == "UnityEngine.Vector3[]")
            variable = new Vector3VariableArray();
        if(variable != null){
            variable.value = f.GetValue(this);
            ListValue.Add((string) f.Name, variable);
        }
    }
}