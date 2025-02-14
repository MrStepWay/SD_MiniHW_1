using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SD_MiniHW_1.Domain.Entities.Animals.Abstract;
using SD_MiniHW_1.Domain.Entities.Animals.Concrete;
using SD_MiniHW_1.Domain.Entities.Things.Abstract;
using SD_MiniHW_1.Domain.Entities.Things.Concrete;
using SD_MiniHW_1.Domain.Services;
using SD_MiniHW_1.Infrastructure.DependencyInjection;

namespace SD_MiniHW_1.Console;

class Program
{
    static void Main(string[] args)
    {
        // Настраиваем DI-контейнер
        ServiceCollection services = new ServiceCollection();
        services.AddDomainServices();
        ServiceProvider provider = services.BuildServiceProvider();

        ZooService zoo = provider.GetRequiredService<ZooService>();
        VeterinaryClinic vet = provider.GetRequiredService<VeterinaryClinic>();

        bool exit = false;
        List<ConsoleKey> availableKeys = new List<ConsoleKey>()
        {
            ConsoleKey.D1, ConsoleKey.NumPad1,
            ConsoleKey.D2, ConsoleKey.NumPad2,
            ConsoleKey.D3, ConsoleKey.NumPad3,
            ConsoleKey.D4, ConsoleKey.NumPad4,
            ConsoleKey.D5, ConsoleKey.NumPad5,
            ConsoleKey.D6, ConsoleKey.NumPad6
        };
        while (!exit)
        {
            System.Console.WriteLine("Введите номер пункта меню для запуска действия:\n");
            System.Console.WriteLine("[1] Добавить новое животное.");
            System.Console.WriteLine("[2] Показать отчёт по животным и потреблению еды.");
            System.Console.WriteLine("[3] Показать животных для контактного зоопарка.");
            System.Console.WriteLine("[4] Показать все объекты инвентаря.");
            System.Console.WriteLine("[5] Добавить новый предмет.");
            System.Console.WriteLine("[6] Выход.");
            
            ConsoleKey choice = System.Console.ReadKey(true).Key;
            while (!availableKeys.Contains(choice))
            {
                System.Console.WriteLine("Пожалуйста, укажите корректный номер пункта меню!");
                choice = System.Console.ReadKey(true).Key;
            }
            System.Console.Clear();

            switch (choice)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    AddNewAnimal(zoo, vet);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ShowReport(zoo);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ShowContactAnimals(zoo);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ShowInventory(zoo);
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    AddNewItem(zoo);
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    exit = true;
                    break;
                default:
                    System.Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }

    private static void AddNewAnimal(ZooService zoo, VeterinaryClinic vet)
    {
        List<ConsoleKey> availableKeys = new List<ConsoleKey>()
        {
            ConsoleKey.D1, ConsoleKey.NumPad1,
            ConsoleKey.D2, ConsoleKey.NumPad2,
            ConsoleKey.D3, ConsoleKey.NumPad3,
            ConsoleKey.D4, ConsoleKey.NumPad4,
            ConsoleKey.D5, ConsoleKey.NumPad5,
        };
        System.Console.WriteLine("Выберите тип животного:");
        System.Console.WriteLine("[1] Monkey");
        System.Console.WriteLine("[2] Rabbit");
        System.Console.WriteLine("[3] Tiger");
        System.Console.WriteLine("[4] Wolf");
        System.Console.WriteLine("[5] Обратно в меню.");
        
        ConsoleKey choice = System.Console.ReadKey(true).Key;
        while (!availableKeys.Contains(choice))
        {
            System.Console.WriteLine("Пожалуйста, укажите корректный номер пункта меню!");
            choice = System.Console.ReadKey(true).Key;
        }

        if (choice == ConsoleKey.D5 || choice == ConsoleKey.NumPad5)
        {
            System.Console.Clear();
            return;
        }

        System.Console.Write("Введите имя: ");
        string? name = System.Console.ReadLine();
        while (name == null)
        {
            System.Console.Write("Некорректное значение имени! Повторите ввод: ");
            name = System.Console.ReadLine();
        }

        int food;
        System.Console.Write("Введите количество еды (кг/день): ");
        while (!int.TryParse(System.Console.ReadLine(), out food) || food < 0)
        {
            System.Console.Write("Некорректное значение еды! Повторите ввод: ");
        }

        int number;
        System.Console.Write("Введите инвентарный номер: ");
        while (!int.TryParse(System.Console.ReadLine(), out number) || number < 0)
        {
            System.Console.Write("Некорректное значение номера! Повторите ввод: ");
        }

        Animal animal = null;
        switch (choice)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                int kindnessM;
                System.Console.Write("Введите уровень доброты (0 - 10): ");
                while (!int.TryParse(System.Console.ReadLine(), out kindnessM) || kindnessM < 0 || kindnessM > 10)
                {
                    System.Console.Write("Некорректное значение доброты! Повторите ввод: ");
                }
                animal = new Monkey(name, food, number, kindnessM);
                System.Console.Clear();
                break;
            
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                int kindnessR;
                System.Console.Write("Введите уровень доброты (0 - 10): ");
                while (!int.TryParse(System.Console.ReadLine(), out kindnessR) || kindnessR < 0 || kindnessR > 10)
                {
                    System.Console.Write("Некорректное значение доброты! Повторите ввод: ");
                }
                animal = new Rabbit(name, food, number, kindnessR);
                System.Console.Clear();
                break;
            
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                animal = new Tiger(name, food, number);
                System.Console.Clear();
                break;
            
            case ConsoleKey.D4:
            case ConsoleKey.NumPad4:
                animal = new Wolf(name, food, number);
                System.Console.Clear();
                break;
        }

        if (vet.CheckHealth(animal))
        {
            zoo.AddItem(animal);
            System.Console.WriteLine("Животное прошло осмотр в ветиринарной клинике и было добавлено.");
        }
        else
        {
            System.Console.WriteLine("Животное не прошло осмотр в ветиринарной клинике и не было добавлено.");
        }
        System.Console.WriteLine();
        System.Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
        while (!System.Console.ReadKey(true).Key.Equals(ConsoleKey.Enter)) {}
        System.Console.Clear();
    }

    private static void AddNewItem(ZooService zoo)
    {
        List<ConsoleKey> availableKeys = new List<ConsoleKey>()
        {
            ConsoleKey.D1, ConsoleKey.NumPad1,
            ConsoleKey.D2, ConsoleKey.NumPad2,
            ConsoleKey.D3, ConsoleKey.NumPad3,
            ConsoleKey.D4, ConsoleKey.NumPad4,
            ConsoleKey.D5, ConsoleKey.NumPad5
        };

        System.Console.WriteLine("Выберите тип предмета:");
        System.Console.WriteLine("[1] Стол");
        System.Console.WriteLine("[2] Компьютер");
        System.Console.WriteLine("[3] Обратно в меню.");

        ConsoleKey choice = System.Console.ReadKey(true).Key;
        while (!availableKeys.Contains(choice))
        {
            System.Console.WriteLine("Пожалуйста, укажите корректный номер пункта меню!");
            choice = System.Console.ReadKey(true).Key;
        }

        if (choice == ConsoleKey.D3 || choice == ConsoleKey.NumPad3)
        {
            System.Console.Clear();
            return;
        }

        System.Console.Write("Введите название предмета: ");
        string? name = System.Console.ReadLine();
        while (name == null)
        {
            System.Console.Write("Некорректное значение имени! Повторите ввод: ");
            name = System.Console.ReadLine();
        }

        int number;
        System.Console.Write("Введите инвентарный номер: ");
        while (!int.TryParse(System.Console.ReadLine(), out number) || number < 0)
        {
            System.Console.Write("Некорректное значение номера! Повторите ввод: ");
        }

        Thing item = null;
        switch (choice)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                item = new Table(name, number);
                break;

            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                item = new Computer(name, number);
                break;
        }

        zoo.AddItem(item);
        System.Console.WriteLine($"Предмет {name} (Номер: {number}) добавлен в инвентарь.");
        System.Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
        while (!System.Console.ReadKey(true).Key.Equals(ConsoleKey.Enter)) {}
        System.Console.Clear();
    }

    private static void ShowReport(ZooService zoo)
    {
        System.Console.WriteLine($"Количество животных: {zoo.AnimalCount()}");
        System.Console.WriteLine($"Общее потребление еды: {zoo.TotalFoodConsumption()} кг/день");
        System.Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
        while (!System.Console.ReadKey(true).Key.Equals(ConsoleKey.Enter)) {}
        System.Console.Clear();
    }

    private static void ShowContactAnimals(ZooService zoo)
    {
        var contactAnimals = zoo.GetContactZooAnimals();
        if (!contactAnimals.Any())
        {
            System.Console.WriteLine("Нет животных для контактного зоопарка.");
        }
        else
        {
            foreach (var animal in contactAnimals)
            {
                System.Console.WriteLine(animal);
            }
        }
        
        System.Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
        while (!System.Console.ReadKey(true).Key.Equals(ConsoleKey.Enter)) {}
        System.Console.Clear();
    }

    private static void ShowInventory(ZooService zoo)
    {
        var items = zoo.GetItems();
        if (!items.Any())
        {
            System.Console.WriteLine("Инвентарь пуст.");
        }
        else
        {
            foreach (var item in items)
            {
                System.Console.WriteLine($"{item.Name} (Номер: {item.Number})");
            }
        }
        
        System.Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
        while (!System.Console.ReadKey(true).Key.Equals(ConsoleKey.Enter)) {}
        System.Console.Clear();
    }
}
