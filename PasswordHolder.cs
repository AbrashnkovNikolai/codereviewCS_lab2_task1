public class PasswordHolder : StringHolder
{

    //public int X
    //{
    //    get => _x;
    //    set => _x = value;
    //}
    //protected string _value;
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
            Console.Write("Задайте пароль (пароль должен содержать минимум {0} символов): ", _minLength);
            ConsoleKeyInfo key;
            _value = ""; // Сброс пароля перед новым вводом
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
                Console.WriteLine($"Пароль должен содержать минимум {_minLength} символов. Попробуйте еще раз.");
            }
            else
            {
                _length = _value.Length;
            }
        } while (_value.Length < _minLength);
    }
    public void ShowPassword()
    {
        Console.WriteLine($"Введенный пароль: {_value}");
    }

}
