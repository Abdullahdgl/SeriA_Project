using Microsoft.AspNetCore.Mvc;

namespace SeriA.UI.ViewComponents.Fixtures
{
	public class _FeaturedMatchViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
