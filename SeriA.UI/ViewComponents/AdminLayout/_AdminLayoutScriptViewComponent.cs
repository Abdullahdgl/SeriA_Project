using Microsoft.AspNetCore.Mvc;

namespace SeriA.UI.ViewComponents.AdminLayout
{
	public class _AdminLayoutScriptViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
