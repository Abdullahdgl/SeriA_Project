using Microsoft.AspNetCore.Mvc;

namespace SeriA.UI.ViewComponents.Standings
{
	public class _StandingsHeadViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
