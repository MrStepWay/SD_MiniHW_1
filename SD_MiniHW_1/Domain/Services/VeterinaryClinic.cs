using SD_MiniHW_1.Domain.Entities.Animals.Abstract;
namespace SD_MiniHW_1.Domain.Services;

/// <summary>
/// Доменный сервис для проверки здоровья животных.
/// В данном случае имитируется осмотр с 80% шансом того, что животное здоровое.
/// </summary>
public class VeterinaryClinic
{
    private readonly Random _rnd = new Random();

    public bool CheckHealth(Animal animal)
    {
        bool healthy = _rnd.NextDouble() < 0.8;
        System.Console.WriteLine($"Ветеринар осмотрел {animal}");
        System.Console.WriteLine($"Вердикт: {(healthy ? "здоров" : "не здоров")}");
        return healthy;
    }
}