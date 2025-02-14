using SD_MiniHW_1.Domain.Entities.Animals.Abstract;
namespace SD_MiniHW_1.Domain.Entities.Animals.Concrete;

/// <summary>
/// Волк – хищник.
/// </summary>
public class Wolf : Predator
{
    public Wolf(string name, int food, int number)
        : base(name, food, number)
    {
    }

    public override string ToString()
    {
        return $"Wolf: {Name} (Инв. номер: {Number}, Еда: {Food} кг/день)";
    }
}