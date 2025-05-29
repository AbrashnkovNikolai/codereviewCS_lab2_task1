public class PasswordHolder : StringHolder
{

    private int _length;
    private int length {
        get => _length;
        set => _length = value;
    }

    private int _minLength;
    private int minLength { 
        get => _minLength;
        set => _minLength = value;
    }

    public PasswordHolder(string password, int length, int minLength) : base(password)
    {
        _length = length;
        _minLength = minLength;
    }

    public PasswordHolder(PasswordHolder other) : base(other)
    {
        _length = other._length;
    }

    public bool IsPasswordLongEnough()
    {
        return _value.Length >= _length;
    }


    public string MaskPassword()
    {
        return new string('*', _value.Length);
    }

    public override string ToString()
    {
        return $"PasswordHolder: {MaskPassword()} (length: {_length})";
    }
    public void InputPassword()
    {
        do
        {
            Console.Write("Çàäàéòå ïàðîëü (ïàðîëü äîëæåí ñîäåðæàòü ìèíèìóì {0} ñèìâîëîâ): ", _minLength);
            ConsoleKeyInfo key;
            _value = ""; // Ñáðîñ ïàðîëÿ ïåðåä íîâûì ââîäîì
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace && _value.Length > 0)
                {
                    Console.Write("\b \b");
                    _value = _value.Substring(0, _value.Length - 1);
                }
                else if (key.KeyChar >= ' ' && key.KeyChar <= '~')
                {
                    Console.Write("*");
                    _value += key.KeyChar;
                }
            } while (true);
            Console.WriteLine();


            if (_value.Length < _minLength)
            {
                Console.WriteLine($"Ïàðîëü äîëæåí ñîäåðæàòü ìèíèìóì {_minLength} ñèìâîëîâ. Ïîïðîáóéòå åùå ðàç.");
            }
            else
            {
                _length = _value.Length;
            }
        } while (_value.Length < _minLength);
    }
    public void ShowPassword()
    {
        Console.WriteLine($"Ââåäåííûé ïàðîëü: {_value}");
    }

}
