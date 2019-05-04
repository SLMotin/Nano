using System;
[Serializable]
public class BooleanVariable : IBaseVariable{
    bool _value;
    public Object value {
        get{
            return (Object) _value;
        }
        set{
            _value = (bool) value;
        }
    }
}