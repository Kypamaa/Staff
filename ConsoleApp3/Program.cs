using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ConsoleApp3
{
    internal class Program
    {
        private SQLiteConnection sqlite;
        static int countNames = 0;
        static int countEmployees = 0;
        static void Main(string[] args)
        {
            List<string> Names = new List<string>();
            List<string> Employees = new List<string>();
            List<int> Salary = new List<int>();
            List<string> Roles = new List<string>() { "Дизайнер", "Программист", "Уборщик", "Сценарист" };
            List<string> Role = new List<string>();
            List<string> Factories = new List<string>() { "Intel", "AMD", "Байкал" };
            List<string> Factory = new List<string>();
            Workers worker = new Workers();
            Fabric fabric = new Fabric();
            while (true)
            {
                Console.Clear();
                Console.ResetColor();

                Console.WriteLine("Выберите действие:\n\n1) Создать работника\n2) Нанять работника\n3) Уволить работника\n4) Изменить должность\n5) Перевести на другое предприятие\n6) Изменить зарплату\n7) Список сотрудников\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Выбор: ");
                Console.ResetColor();
                int num = Convert.ToInt32(Console.ReadLine());

                if (num == 1)
                {
                    Console.Clear();
                    worker.Create(Names, countNames);
                }
                else if (num == 2)
                {
                    Console.Clear();
                    fabric.Invite(Factory, Factories, Role, Roles, Salary, Names, Employees, countEmployees);
                }
                else if (num == 3)
                {
                    Console.Clear();
                    fabric.Fire(Factory, Role, Salary, Employees);
                }
                else if (num == 4)
                {
                    Console.Clear();
                    fabric.Change_R(Factory, Factories, Role, Roles, Salary, Names, Employees, countEmployees);
                }
                else if (num == 5)
                {
                    Console.Clear();
                    fabric.Change_F(Factory, Factories, Role, Roles, Salary, Names, Employees, countEmployees);
                }
                else if (num == 6)
                {
                    Console.Clear();
                    fabric.Change_S(Factory, Factories, Role, Roles, Salary, Names, Employees, countEmployees);
                }
                else if (num == 7)
                {
                    Console.Clear();
                    fabric.Catalog(Factory, Role, Salary, Employees);
                }
            }
        }

        class Workers
        {
            public void Create(List<string> _name, int index)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.Write("Впишите ФИО сотрудника: ");
                Console.ResetColor();
                _name.Add(Convert.ToString(Console.ReadLine()));

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Создан сотрудник: " + _name[index]);
                countNames++;

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                Console.ReadKey();
            }

        }

        class Fabric
        {
            public void Invite(List<string> _factory, List<string> _factories, List<string> _role, List<string> _roles, List<int> _salary, List<string> _name, List<string> _employee, int index)
            {
                for (int i = 0; i < _name.Count; i++)
                {
                    Console.WriteLine(i + 1 + ") " + _name[i]);
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Выберите сотрудника: ");
                Console.ResetColor();
                int num = Convert.ToInt32(Console.ReadLine()) - 1;
                _employee.Add(_name[num]);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Выберите предприятие: ");
                Console.ResetColor();
                Console.WriteLine();
                for (int i = 0; i < _factories.Count; i++)
                {
                    Console.WriteLine(i + 1 + ") " + _factories[i]);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Выбор: ");
                Console.ResetColor();
                int num2 = Convert.ToInt32(Console.ReadLine()) - 1;
                _factory.Add(_factories[num2]);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Выберите должность: ");
                Console.ResetColor();
                Console.WriteLine();
                for (int i = 0; i < _roles.Count; i++)
                {
                    Console.WriteLine(i + 1 + ") " + _roles[i]);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Выбор: ");
                Console.ResetColor();
                int num1 = Convert.ToInt32(Console.ReadLine()) - 1;
                _role.Add(_roles[num1]);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(_name[num]);
                Console.Write(", выберите зарплату для сотрудника: ");
                Console.ResetColor();
                int s = Convert.ToInt32(Console.ReadLine());
                _salary.Add(s);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("Сотрудник " + _name[num] + " нанят на должность " + _roles[num1] + " и будет получать " + s + "$" + " на предприятии " + _factories[num2]);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                Console.ReadKey();
            }

            public void Fire(List<string> _factory, List<string> _role, List<int> _salary, List<string> _employee)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Выберите сотрудника:");
                Console.ResetColor();
                Console.WriteLine();
                for (int i = 0; i < _employee.Count; i++)
                {
                    Console.WriteLine(i + 1 + ") " + _employee[i] + ", " + _role[i] + ", работает на " + _factory[i] + ". Зарплата: " + _salary[i] + "$");
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Выбор: ");
                Console.ResetColor();
                int num = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Сотрудник " + _employee[num] + " уволен.");
                _employee.Remove(_employee[num]);
                _salary.Remove(_salary[num]);
                _factory.Remove(_factory[num]);
                _role.Remove(_role[num]);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                Console.ReadKey();
            }

            public void Catalog(List<string> _factory, List<string> _role, List<int> _salary, List<string> _employee)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Список сотрудников: ");
                Console.WriteLine();
                Console.ResetColor();
                for (int i = 0; i < _employee.Count; i++)
                {
                    Console.WriteLine(i + 1 + ") " + _employee[i] + ", " + _role[i] + ", работает на " + _factory[i] + ". Зарплата: " + _salary[i] + "$");
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                Console.ReadKey();
            }

            public void Change_R(List<string> _factory, List<string> _factories, List<string> _role, List<string> _roles, List<int> _salary, List<string> _name, List<string> _employee, int index)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Выберите сотрудника: ");
                Console.WriteLine();
                Console.ResetColor();
                for (int i = 0; i < _employee.Count; i++)
                {
                    Console.WriteLine(i + 1 + ") " + _employee[i] + ", " + _role[i] + ", работает на " + _factory[i] + ". Зарплата: " + _salary[i] + "$");
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Выбор: ");
                Console.ResetColor();
                int num = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nВыбран сотрудник " + _employee[num] + ". Нынешняя должность: " + _role[num] + ".");
                Console.WriteLine("\nВыберите новую должность: ");
                Console.ResetColor();
                Console.WriteLine();
                for (int i = 0; i < _roles.Count; i++)
                {
                    Console.WriteLine(i + 1 + ") " + _roles[i]);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Выбор: ");
                Console.ResetColor();
                int num1 = Convert.ToInt32(Console.ReadLine()) - 1;
                _role.Insert(num, _roles[num1]);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("Сотруднику " + _employee[num] + " была изменина должность на " + _role[num] + ".");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                Console.ReadKey();
            }

            public void Change_F(List<string> _factory, List<string> _factories, List<string> _role, List<string> _roles, List<int> _salary, List<string> _name, List<string> _employee, int index)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Выберите сотрудника: ");
                Console.WriteLine();
                Console.ResetColor();
                for (int i = 0; i < _employee.Count; i++)
                {
                    Console.WriteLine(i + 1 + ") " + _employee[i] + ", " + _role[i] + ", работает на " + _factory[i] + ". Зарплата: " + _salary[i] + "$");
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Выбор: ");
                Console.ResetColor();
                int num = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nВыбран сотрудник " + _employee[num] + ". Место работы: " + _factory[num] + ".");
                Console.WriteLine("\nВыберите новое предприятие: ");
                Console.ResetColor();
                Console.WriteLine();
                for (int i = 0; i < _factories.Count; i++)
                {
                    Console.WriteLine(i + 1 + ") " + _factories[i]);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Выбор: ");
                Console.ResetColor();
                int num1 = Convert.ToInt32(Console.ReadLine()) - 1;
                _factory.Insert(num, _factories[num1]);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("Сотрудник " + _employee[num] + " был назначен на предприятие " + _factory[num] + ".");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                Console.ReadKey();
            }

            public void Change_S(List<string> _factory, List<string> _factories, List<string> _role, List<string> _roles, List<int> _salary, List<string> _name, List<string> _employee, int index)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Выберите сотрудника: ");
                Console.WriteLine();
                Console.ResetColor();
                for (int i = 0; i < _employee.Count; i++)
                {
                    Console.WriteLine(i + 1 + ") " + _employee[i] + ", " + _role[i] + ", работает на " + _factory[i] + ". Зарплата: " + _salary[i] + "$");
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Выбор: ");
                Console.ResetColor();
                int num = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nВыбран сотрудник " + _employee[num] + ". Зарплата: " + _salary[num] + "$");

                Console.Write("\nВыберите новую зарплату: ");
                Console.ResetColor();
                int s = Convert.ToInt32(Console.ReadLine());
                _salary.Insert(num, s);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("Сотруднику " + _employee[num] + " была назначена новая зарплата: " + _salary[num] + "$");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                Console.ReadKey();
            }
        }

    }
}
