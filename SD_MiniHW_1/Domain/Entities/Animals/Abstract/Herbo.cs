namespace SD_MiniHW_1.Domain.Entities.Animals.Abstract;

/// <summary>
/// Абстрактный класс для травоядных животных.
/// Добавляет свойство доброты.
/// </summary>
public abstract class Herbo : Animal
{
    public int Kindness { get; set; }

    protected Herbo(string name, int food, int number, int kindness) : base(name, food, number)
    {
        Kindness = kindness;
    }
}