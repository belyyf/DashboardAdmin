namespace DashboardAdmin.Models;

public class DashboardViewModel
{
    public IEnumerable<DashboardCard> Cards { get; set; } = new List<DashboardCard>();
}