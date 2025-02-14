using SD_MiniHW_1.Domain.Entities.Things.Abstract;
namespace SD_MiniHW_1.Domain.Entities.Things.Concrete;

public class Table : Thing
{
    public int Number { get; set; }
    public string Name { get; set; }

    public Table(string name, int number) : base(name, number)
    {
    }
    
    public override string ToString() => $"Table: {Name} (Инв. номер: {Number})";
}