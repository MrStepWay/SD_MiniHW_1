namespace SD_MiniHW_1.Domain.Interfaces;

/// <summary>
/// Интерфейс для объектов, подлежащих инвентаризации.
/// </summary>
public interface IInventory
{
    int Number { get; set; }
    string Name { get; set; }
}