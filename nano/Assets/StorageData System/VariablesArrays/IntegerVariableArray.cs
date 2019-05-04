using System;
[Serializable]
public class IntegerVariableArray : IBaseVariable{
    int[] _value;
    public Object value {
        get{
            return (Object) _value;
        }
        set{
            _value = (int[]) value;
        }
    }
}