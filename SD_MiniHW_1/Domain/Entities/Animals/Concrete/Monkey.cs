using SD_MiniHW_1.Domain.Entities.Animals.Abstract;
namespace SD_MiniHW_1.Domain.Entities.Animals.Concrete;

public class Monkey : Herbo
{
    public Monkey(string name, int food, int number, int kindness) : base(name, food, number, kindness)
    {
    }

    public override string ToString()
    {
        return $"Monkey: {Name} (Инв. номер: {Number}, Еда: {Food} кг/день, Доброта: {Kindness})";
    }
}