using DashboardAdmin.Models;
using DashboardAdmin.Services;
using Microsoft.AspNetCore.Mvc;

namespace DashboardAdmin.Controllers;

public class DashboardController : Controller
{
    private readonly IDashboardRepository _repo;

    public DashboardController(IDashboardRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index()
    {
        var cards = _repo.GetAllCards();
        ViewData["ReportPeriod"] = "Сентябрь 2026";
        ViewBag.Currency = "RUB";
        return View(cards);
    }

    // Доп. задание «Средний»: печатная версия
    public IActionResult Print()
    {
        ViewData["Mode"] = "Print";
        ViewData["ReportPeriod"] = "Сентябрь 2026";
        ViewBag.Currency = "RUB";
        return View("Index", _repo.GetAllCards());
    }
}