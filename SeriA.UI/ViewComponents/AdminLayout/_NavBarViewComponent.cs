using Microsoft.AspNetCore.Mvc;

namespace SeriA.UI.ViewComponents.AdminLayout
{
	public class _NavBarViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
