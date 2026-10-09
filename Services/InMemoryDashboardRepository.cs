using DashboardAdmin.Models;

namespace DashboardAdmin.Services;

public class InMemoryDashboardRepository : IDashboardRepository
{
    private static readonly List<DashboardCard> _cards = new()
    {
        new DashboardCard
        {
            Id = 1, Title = "Выручка", Value = 1523400m, Trend = Trend.Up,
            Unit = "руб.", Description = "Общая выручка за период"
        },
        new DashboardCard
        {
            Id = 2, Title = "Заказов", Value = 8450m, Trend = Trend.Up,
            Unit = "шт.", Description = "Количество оформленных заказов"
        },
        new DashboardCard
        {
            Id = 3, Title = "Средний чек", Value = 1780m, Trend = Trend.Stable,
            Unit = "руб.", Description = "Средняя стоимость заказа"
        },
        new DashboardCard
        {
            Id = 4, Title = "Возвраты", Value = -45200m, Trend = Trend.Down,
            Unit = "руб.", Description = "Сумма возвратов клиентам"
        },
        new DashboardCard
        {
            Id = 5, Title = "Конверсия", Value = 3.8m, Trend = Trend.Up,
            Unit = "%", Description = "Конверсия посетителей в покупателей"
        },
        new DashboardCard
        {
            Id = 6, Title = "Активные клиенты", Value = 1240m, Trend = Trend.Stable,
            Unit = "шт.", Description = "Клиенты с покупками за 30 дней"
        }
    };

    public IEnumerable<DashboardCard> GetAllCards() => _cards.ToList();

    public DashboardCard? GetById(int id) => _cards.FirstOrDefault(c => c.Id == id);

    public IEnumerable<DashboardCard> GetLatest(int count) =>
        _cards.OrderByDescending(c => c.Id).Take(count).ToList();
}