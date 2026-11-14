using Microsoft.AspNetCore.Mvc;

namespace SeriA.UI.ViewComponents.Standings
{
	public class _StandingsSidebarViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
