using Microsoft.AspNetCore.Mvc;

namespace SeriA.UI.ViewComponents.Standings
{
	public class _StandingsTableViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
