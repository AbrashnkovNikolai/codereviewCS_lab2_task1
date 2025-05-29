public class StringHolder
{
    protected string _value;
    protected string value
    {
        get => _value;
        set => _value = value;
    }

    public StringHolder(string value)
    {
        _value = value;
    }

    public StringHolder(StringHolder other)
    {
        _value = other._value;
    }


    public string GetFirstAndLastChars()
    {
        if (_value.Length < 2)
        {
            return _value;
        }
        return _value[0] + "" + _value[^1];
    }


    public override string ToString()
    {
        return $"StringHolder: {_value}";
    }
}
