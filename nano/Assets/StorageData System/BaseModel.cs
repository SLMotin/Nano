using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BaseModel{
    public List<string> key { get; set; }
    public List<IBaseVariable> value { get; set; }
    public BaseModel(){
        key = new List<string>();
        value = new List<IBaseVariable>();
    }
    public void Add(string key, IBaseVariable value){
        this.key.Add(key);
        this.value.Add(value);
    }
    public IBaseVariable this[string key]{
        get{
            for (int i = 0; i < this.key.Count; i++)
                if(this.key[i] == key)
                    return value[i];
            return null;
        }
        set{
            for (int i = 0; i < this.key.Count; i++)
                if(this.key[i] == key)
                    this.value[i] = value;
        }
    }
    public IBaseVariable this[int index]{
        get{
            if(index >= 0 && index < this.key.Count)
                return this.value[index];
            return null;
        }
        set{
            if(index >= 0 && index < this.key.Count)
                this.value[index] = value;
        }
    }
}