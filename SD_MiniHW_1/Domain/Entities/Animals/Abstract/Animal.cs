using SD_MiniHW_1.Domain.Interfaces;

namespace SD_MiniHW_1.Domain.Entities.Animals.Abstract;

/// <summary>
/// Абстрактный базовый класс для животных.
/// Реализует IAlive и IInventory.
/// </summary>
public abstract class Animal : IAlive, IInventory
{
    public int Number { get; set; }
    public string Name { get; set; }
    public int Food { get; set; }

    protected Animal(string name, int food, int number)
    {
        Name = name;
        Food = food;
        Number = number;
    }
}