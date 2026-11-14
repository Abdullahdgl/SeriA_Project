using Microsoft.AspNetCore.Mvc;

namespace SeriA.UI.ViewComponents.Standings
{
	public class _StandingsHeroViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
