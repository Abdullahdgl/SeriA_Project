using Microsoft.AspNetCore.Mvc;

namespace SeriA.UI.ViewComponents.Fixtures
{
	public class _FixturesHeroViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
