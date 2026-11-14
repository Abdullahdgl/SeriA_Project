using Microsoft.AspNetCore.Mvc;

namespace SeriA.UI.ViewComponents.MatchDetail
{
	public class _MatchHeroViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
