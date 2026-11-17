# ViewTask — Practics 2. Views

Виконання всіх 8 завдань з https://github.com/ChNU-Classes/Views.
Оригінальна умова та зображення збережені в `reference/`.

## Запуск

Потрібен .NET SDK 9.

```sh
dotnet restore
dotnet run --no-launch-profile --urls http://localhost:5050
```

Відкрийте http://localhost:5050 і пункт **Sprint Tasks**.

## Реалізація

- `Home/Index`: назва вкладки, навігація та посилання на GitHub.
- `Tasks/SprintTasks`: посилання на всі сторінки.
- `Greetings`: змінні Razor, DateTime та умовне привітання за часом України.
- `ProductInfo`: список об’єктів Product безпосередньо у view, виведення циклом.
- `SuperMarkets`: список і кількість через ViewBag.
- `ShoppingList`: Dictionary<string, int> з контролера та partial TimeToBuy.
- `TimeToBuy`: @inject ITimeService, реєстрація в Startup.ConfigureServices.
- `ShoppingCart`: HTML helpers, GET/POST, дати на сьогодні та наступні два дні, вибір товарів зі словника, підтвердження. Додано серверну валідацію та захист від CSRF.

Проєкт використовує сучасний Program.cs, який викликає Startup.ConfigureServices,
щоб зберегти вимогу практичної щодо реєстрації залежностей у Startup.
Замовлення демонстраційне: підтвердження показується без збереження у базі.
Репозиторій проєкту: https://github.com/sarccasm/ViewTask.
Посилання «our project» на головній сторінці веде на цей репозиторій.
