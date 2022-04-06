using Gamebook.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamebook.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private const string KEY = "Player"; //identifikátor session proměnné

        private readonly IHttpContextAccessor _hca; //HttpContextAccessor zpřístupní HttpContext
        private ISession _session => _hca.HttpContext.Session;

        private SessionStorage<GameState> _ss;
        public GameState State { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHttpContextAccessor hca, SessionStorage<GameState> ss)
        {
            _logger = logger;
            _hca = hca;
            _ss = ss;
        }

        public void OnGet()
        {

        }
        public IActionResult OnGetStore()
        {
            State = _ss.LoadOrCreate(KEY);
            _ss.Save(KEY, new GameState());
            return RedirectToPage("Start");
        }
    }
}