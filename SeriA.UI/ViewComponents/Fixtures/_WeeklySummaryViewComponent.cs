using Microsoft.AspNetCore.Mvc;

namespace SeriA.UI.ViewComponents.Fixtures
{
	public class _WeeklySummaryViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
