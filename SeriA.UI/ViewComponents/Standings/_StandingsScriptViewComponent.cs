using Microsoft.AspNetCore.Mvc;

namespace SeriA.UI.ViewComponents.Standings
{
	public class _StandingsScriptViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
