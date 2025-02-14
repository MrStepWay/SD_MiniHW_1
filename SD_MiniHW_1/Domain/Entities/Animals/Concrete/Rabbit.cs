using SD_MiniHW_1.Domain.Entities.Animals.Abstract;
namespace SD_MiniHW_1.Domain.Entities.Animals.Concrete;

/// <summary>
/// Кролик – травоядное животное.
/// </summary>
public class Rabbit : Herbo
{
    public Rabbit(string name, int food, int number, int kindness) : base(name, food, number, kindness)
    {
    }

    public override string ToString()
    {
        return $"Rabbit: {Name} (Инв. номер: {Number}, Еда: {Food} кг/день, Доброта: {Kindness})";
    }
}