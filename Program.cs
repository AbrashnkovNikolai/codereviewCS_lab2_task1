public class StringHolder
{

    protected string _value;


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
        return _value[0] + "" + _value[_value.Length - 1];
    }

    // Перегрузка метода ToString для вывода строки.
    public override string ToString()
    {
        return $"StringHolder: {_value}";
    }
}

// Дочерний класс PasswordHolder.
public class PasswordHolder : StringHolder
{
    private int _length;

    public PasswordHolder(string password, int length) : base(password)
    {
        _length = length;
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
        return $"PasswordHolder: {_value} (length: {_length})";
    }
}

// Класс для ввода пароля с маскировкой.
public class PasswordInput
{

    private string _password;


    private int _minLength;


    public PasswordInput(int minLength)
    {
        _minLength = minLength;
        _password = "";
    }


    public void InputPassword()
    {
        do
        {
            Console.Write("Задайте пароль (пароль должен содержать минимум {0} символов): ", _minLength);
            ConsoleKeyInfo key;
            _password = ""; // Сброс пароля перед новым вводом
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace && _password.Length > 0)
                {
                    Console.Write("\b \b");
                    _password = _password.Substring(0, _password.Length - 1);
                }
                else if (key.KeyChar >= ' ' && key.KeyChar <= '~')
                {
                    Console.Write("*");
                    _password += key.KeyChar;
                }
            } while (true);
            Console.WriteLine();

            // Проверка длины пароля
            if (_password.Length < _minLength)
            {
                Console.WriteLine($"Пароль должен содержать минимум {_minLength} символов. Попробуйте еще раз.");
            }
        } while (_password.Length < _minLength);
    }

    // Метод для получения введенного пароля.
    public string GetPassword()
    {
        return _password;
    }


    public void ShowPassword()
    {
        Console.WriteLine($"Введенный пароль: {_password}");
    }


    public string MaskPassword()
    {
        return new string('*', _password.Length);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Тестирование задания 1:");

        PasswordInput passwordInput = new PasswordInput(16);
        passwordInput.InputPassword();

        Console.WriteLine("Показать пароль? (y/n)");
        string answer = Console.ReadLine();
        if (answer.ToLower() == "y")
        {
            passwordInput.ShowPassword();
        }
        else
        {
            Console.WriteLine($"Маскированный пароль: {passwordInput.MaskPassword()}");
        }
    }
}