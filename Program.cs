using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    internal class Program
    {

        static void Main(string[] args)

        {
            String name_user = "", text_comand = "";
            String full_cosmmand = "/help,/start,/info,/exit,/addtask,/showtasks,/removetask";
            bool active_echo = false;
            var l1 = new List<string>();
            int num = 0;
            Console.WriteLine("Привет!!!");

            while (text_comand != "/exit")
            {
                if (name_user != "") { Console.WriteLine("Поработаем, " + name_user + "?)"); }
                Console.WriteLine("Cписок доступных команд: " + full_cosmmand);
                Console.WriteLine("Введитие команду");
                text_comand = Console.ReadLine();
                if (active_echo && text_comand.Split(' ')[0] == "/echo")
                {
                    Console.WriteLine(text_comand.Substring("/echo ".Length));
                    continue;
                }
                switch (text_comand)
                {
                    case "/start":
                        name_user = keys_start(name_user);
                        if (active_echo == false)
                        {
                            full_cosmmand += ",/echo {ваш текст}";
                            active_echo = true;
                        }
                        break;
                    case "/help":
                        keys_help();
                        break;
                    case "/info":
                        keys_help();
                        break;
                    case "/exit":
                        keys_exit(name_user);
                        break;
                    case "/addtask":
                        l1.Add(keys_addtask(name_user));
                        break;
                    case "/showtasks":
                        Console.WriteLine("Список имеющихся задач");
                        if (l1.Count == 0)
                        {
                            Console.WriteLine("Список задач пустой");
                            break;
                        }
                        foreach (var ts in l1)
                        {
                            num += 1;
                            Console.WriteLine(num + ". " + ts);
                        }
                        num = 0;
                        break;
                    case "/removetask":
                        string ageStr;
                        bool b = true;
                        if (l1.Count == 0)
                        {
                            Console.WriteLine("Список задач пустой");
                            break;
                        }
                        while (b)
                        {
                            Console.WriteLine("Введите номер задачи для удаления");
                            ageStr = Console.ReadLine();
                            if (!int.TryParse(ageStr, out num))
                            {
                                Console.WriteLine("введено некорректное значение");
                                continue;
                            }
                            num = int.Parse(ageStr);
                            if (num < 1 || num >l1.Count)
                            {
                                Console.WriteLine("введено некорректное значение");
                                continue;
                            }
                            l1.RemoveAt(num - 1);
                            b = false;
                            num = 0;
                            break;
                        }

                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("такой команды несущеструет");
                        Console.WriteLine("");
                        break;
                }
            }
        }

        static void keys_help()
        {
            Console.WriteLine("");
            Console.WriteLine("1. Приветствие: При запуске программы отображается сообщение приветствия со списком доступных команд: / start, / help, / info, / exit.");
            Console.WriteLine("2. Обработка команды / start: Если пользователь вводит команду / start, программа просит его ввести своё имя.Сохраните введенное имя в переменную.Программа должна обращаться к пользователю по имени в каждом следующем ответе.");
            Console.WriteLine("3. Обработка команды / help: Отображает краткую справочную информацию о том, как пользоваться программой.");
            Console.WriteLine("4. Обработка команды / info: Предоставляет информацию о версии программы и дате её создания.");
            Console.WriteLine("5. Доступ к команде / echo: После ввода имени становится доступной команда / echo.При вводе этой команды с аргументом(например, / echo Hello), программа возвращает введенный текст(в данном примере \"Hello\").");
            Console.WriteLine("6. Обработка команды /addtask:Пользователь сможет добавлять задачи в список");
            Console.WriteLine("7. Обработка команды /showtasks: При вводе команды /showtasks бот должен отобразить список всех добавленных задач");
            Console.WriteLine("8. Обработка команды /removetask: Бот должен позволить пользователю удалять задачи по номеру в списке.");
            Console.WriteLine("9. Основной цикл программы: Программа продолжает ожидать ввод команды от пользователя, пока не будет введена команда / exit");
            Console.WriteLine("");
        }

        static void keys_info()
        {
            Console.WriteLine("");
            Console.WriteLine("Version = " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
            Console.WriteLine("Дата создания проекта: 26.11.2024");
            Console.WriteLine("");
        }

        static string keys_start(string name)
        {
            Console.WriteLine("");
            Console.WriteLine("введите имя");
            name = Console.ReadLine();
            while (name == "")
            {
                Console.WriteLine("имя не может быть пустым,введите имя повторно!!!");
                name = Console.ReadLine();
            }
            return name;

        }

        static void keys_exit(string name)
        {
            Console.WriteLine("удачи! " + name);
        }

        static string keys_addtask(string name)
        {
            Console.WriteLine(name + "Пожалуйста, введите описание задачи:");
            return Console.ReadLine();
        }
    }
}