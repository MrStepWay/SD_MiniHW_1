using SD_MiniHW_1.Domain.Interfaces;
namespace SD_MiniHW_1.Domain.Entities.Things.Abstract;

/// <summary>
/// Абстрактный класс для инвентаризационных вещей.
/// </summary>
public abstract class Thing : IInventory
{
    public int Number { get; set; }
    public string Name { get; set; }

    protected Thing(string name, int number)
    {
        Name = name;
        Number = number;
    }
}