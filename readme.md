# Zoo ERP System

### Выполнил Юнда Степан Владимирови, БПИ 235

## Описание проекта

Данная система реализует ERP для Московского зоопарка. Система позволяет вести учёт животных и инвентарных предметов, обеспечивает автоматизацию задач зоопарка и включает функционал для:
- Добавления новых животных (после проверки их состояния здоровья ветеринарной клиникой).
- Добавления новых предметов (например, столов и компьютеров) в инвентарь.
- Вывода отчёта по количеству животных и общему потреблению еды.
- Формирования списка животных, пригодных для контактного зоопарка (на основе уровня доброты).

## Применённые принципы SOLID

### 1. **Single Responsibility Principle (SRP)**
- **Что:** Каждый класс отвечает за одну конкретную задачу.
- **Где применено:**
    - **Доменные сущности** (Animal, Thing и их наследники) отвечают только за представление данных.
    - **Доменные сервисы** (ZooService, VeterinaryClinic) отвечают за бизнес-логику: учет животных, инвентаря и проверку здоровья.
    - **Консольное приложение (UI)** занимается исключительно взаимодействием с пользователем.

### 2. **Open/Closed Principle (OCP)**
- Классы должны быть открыты для расширения, но закрыты для модификации.
- **Где применено:**
    - При добавлении новых типов животных или предметов достаточно создать новые классы, наследуясь от базовых абстрактных классов (например, добавляя новый класс, наследующий Animal или Thing), без изменения существующего кода.
    - Интерфейсы (IAlive, IInventory, IAnimal, IContactable) позволяют расширять функциональность, не изменяя уже существующую реализацию.

### 3. **Liskov Substitution Principle (LSP)**
- Объекты производных классов должны быть взаимозаменяемыми с объектами базового класса.
- **Гприменено в:**
    - Конкретные реализации животных (Monkey, Rabbit, Tiger, Wolf) и инвентарных предметов (Table, Computer) могут использоваться вместо их абстрактных базовых классов (Animal, Thing) без нарушения корректности работы системы.

### 4. **Interface Segregation Principle (ISP)**
- Интерфейсы должны быть специализированными и не обязывать реализующие классы использовать ненужные методы.
- **Применено в:**
    - Интерфейсы IAlive и IInventory выделяют базовые свойства для живых объектов и объектов инвентаря.
    - Специфичные интерфейсы IAnimal и IContactable, расположенные рядом с реализациями животных, позволяют выделить методы и свойства для животных (получение описания или возможность интерактивного контакта).

### 5. **Dependency Inversion Principle (DIP)**
- **Что:** Модули высокого уровня не должны зависеть от модулей низкого уровня. Оба типа модулей должны зависеть от абстракций.
- **Применено в:**
    - Использование DI-контейнера для внедрения зависимостей в классы ZooService и VeterinaryClinic.
    - Регистрация зависимостей вынесена в отдельный класс (ServiceRegistrations) в слое Infrastructure, что позволяет легко заменять или модифицировать реализации без изменения бизнес-логики.

## Применение DI-контейнера

В проекте используется DI-контейнер для регистрации и внедрения зависимостей, что позволяет:
- **Централизованно управлять зависимостями**: Все сервисы (ZooService, VeterinaryClinic) регистрируются в методе `AddDomainServices()`.
- **Поддерживать инверсию управления**: Консольное приложение не создаёт экземпляры сервисов напрямую, а получает их через DI-контейнер.

## Инструкция по запуску
```shell
git clone https://github.com/MrStepWay/SD_MiniHW_1git
cd SD_MiniHW_1
dotnet run
```