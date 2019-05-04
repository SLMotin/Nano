using System;
[Serializable]
public class IntegerVariable : IBaseVariable{
    int _value;
    public Object value {
        get{
            return (Object) _value;
        }
        set{
            _value = (int) value;
        }
    }
}