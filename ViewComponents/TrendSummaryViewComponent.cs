using DashboardAdmin.Models;
using DashboardAdmin.Services;
using Microsoft.AspNetCore.Mvc;

namespace DashboardAdmin.ViewComponents;

public class TrendSummaryViewComponent : ViewComponent
{
    private readonly IDashboardRepository _repo;

    public TrendSummaryViewComponent(IDashboardRepository repo)
    {
        _repo = repo;
    }

    public IViewComponentResult Invoke()
    {
        var summaries = _repo.GetAllCards()
            .GroupBy(c => c.Trend)
            .Select(g => new TrendSummaryItem
            {
                Trend = g.Key,
                Count = g.Count(),
                Total = g.Sum(c => c.Value)
            })
            .ToList();

        return View(summaries);
    }
}

public class TrendSummaryItem
{
    public Trend Trend { get; set; }
    public int Count { get; set; }
    public decimal Total { get; set; }
}
