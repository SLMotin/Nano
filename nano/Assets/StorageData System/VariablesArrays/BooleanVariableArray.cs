using System;
[Serializable]
public class BooleanVariableArray : IBaseVariable{
    bool[] _value;
    public Object value {
        get{
            return (Object) _value;
        }
        set{
            _value = (bool[]) value;
        }
    }
}