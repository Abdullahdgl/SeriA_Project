using Microsoft.AspNetCore.Mvc;

namespace SeriA.UI.ViewComponents.AdminLayout
{
	public class _AdminTopbarViewComponent : ViewComponent
	{

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
