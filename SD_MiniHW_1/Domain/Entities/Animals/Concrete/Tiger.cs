using SD_MiniHW_1.Domain.Entities.Animals.Abstract;
namespace SD_MiniHW_1.Domain.Entities.Animals.Concrete;

/// <summary>
/// Тигр – хищник.
/// </summary>
public class Tiger : Predator
{
    public Tiger(string name, int food, int number) : base(name, food, number)
    {
    }

    public override string ToString()
    {
        return $"Tiger: {Name} (Инв. номер: {Number}, Еда: {Food} кг/день)";
    }
}