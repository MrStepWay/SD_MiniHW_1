using SD_MiniHW_1.Domain.Entities.Things.Abstract;
namespace SD_MiniHW_1.Domain.Entities.Things.Concrete;

public class Computer : Thing
{
    public int Number { get; set; }
    public string Name { get; set; }

    public Computer(string name, int number) : base(name, number)
    {
    }
    
    public override string ToString() => $"Computer: {Name} (Инв. номер: {Number})";
}