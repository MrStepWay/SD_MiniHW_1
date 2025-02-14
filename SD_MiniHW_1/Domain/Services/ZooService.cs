using SD_MiniHW_1.Domain.Entities.Animals.Abstract;
using SD_MiniHW_1.Domain.Interfaces;

namespace SD_MiniHW_1.Domain.Services;

/// <summary>
/// Доменный сервис для управления зоопарком.
/// Отвечает за учет животных и инвентарных объектов.
/// </summary>
public class ZooService
{
    private readonly List<IInventory> _items = new List<IInventory>();

    public void AddItem(IInventory item) => _items.Add(item);

    public IEnumerable<IInventory> GetItems() => _items;

    public int AnimalCount() => _items.OfType<Animal>().Count();

    public int TotalFoodConsumption() => _items.OfType<Animal>().Sum(a => a.Food);

    /// <summary>
    /// Возвращает животных, пригодных для контактного зоопарка.
    /// Критерий: животное должно быть травоядным с уровнем доброты > 5.
    /// </summary>
    public IEnumerable<Animal> GetContactZooAnimals()
    {
        return _items
            .OfType<Herbo>()
            .Where(a => a.Kindness > 5)
            .Cast<Animal>();
    }
}
