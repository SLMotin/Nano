using System;
[Serializable]
public class StringVariable : IBaseVariable{
    string _value;
    public Object value {
        get{
            return (Object) _value;
        }
        set{
            _value = (string) value;
        }
    }
}