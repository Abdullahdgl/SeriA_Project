using Microsoft.AspNetCore.Mvc;

namespace SeriA.UI.ViewComponents.Fixtures
{
	public class _WeekInfoViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
