using Gamebook.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamebook.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private string KEY; //identifikátor session proměnné

        private readonly IHttpContextAccessor _hca; //HttpContextAccessor zpřístupní HttpContext
        private ISession _session => _hca.HttpContext.Session;
        private IConfiguration _conf;

        private SessionStorage<GameState> _ss;
        public GameState State { get; set; }

        public int ID { get; set; } = 0;

        public IndexModel(ILogger<IndexModel> logger, IHttpContextAccessor hca, SessionStorage<GameState> ss, IConfiguration config)
        {
            _logger = logger;
            _hca = hca;
            _ss = ss;
            _conf = config;
        }

        public void OnGet()
        {
            KEY = _conf["KEY"];
            _session.Clear();
        }
        public IActionResult OnGetStore(int id)
        {
            KEY = _conf["KEY"];
            ID = id;
            State = _ss.LoadOrCreate(KEY);
            _ss.Save(KEY, new GameState());
            return RedirectToPage("Game");
        }
    }
}