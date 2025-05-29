
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Тестирование задания 1:");

        PasswordHolder password = new PasswordHolder("", 0, 8);
        password.InputPassword();
        Console.WriteLine("запомните эти два символа, они понадобятся для входа в систему:" + password.GetFirstAndLastChars());
        Console.WriteLine("Показать пароль? (y/n)");
        string? answer = Console.ReadLine();
        if (answer.ToLower() == "y") // proverka na 0
        {
            password.ShowPassword();
        }
        else
        {
            Console.WriteLine($"Маскированный пароль: {password.MaskPassword()}");
        }

        Console.WriteLine($"проверка конструктора копирования {password}");
        PasswordHolder savedPassword = new PasswordHolder(password);
        Console.WriteLine("скопированный пароль: "+savedPassword);
    }
}