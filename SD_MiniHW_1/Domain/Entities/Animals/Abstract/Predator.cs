namespace SD_MiniHW_1.Domain.Entities.Animals.Abstract;

/// <summary>
/// Абстрактный класс для хищников.
/// </summary>
public abstract class Predator : Animal
{
    protected Predator(string name, int food, int number) : base(name, food, number)
    {
    }
}