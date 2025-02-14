namespace SD_MiniHW_1.Domain.Interfaces;

/// <summary>
/// Интерфейс для живых объектов.
/// Содержит свойство для учёта потребляемой еды.
/// </summary>
public interface IAlive
{
    int Food { get; set; }
}