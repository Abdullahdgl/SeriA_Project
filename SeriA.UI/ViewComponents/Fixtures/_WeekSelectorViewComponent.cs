using Microsoft.AspNetCore.Mvc;

namespace SeriA.UI.ViewComponents.Fixtures
{
	public class _WeekSelectorViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
