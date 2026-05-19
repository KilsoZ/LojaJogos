using LojaJogos.Application.DTOs;
using LojaJogos.Application.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LojaJogos.Web.Pages.Jogos
{
    public class IndexModel : PageModel
    {
        private readonly JogoService _service;

        public IndexModel(JogoService service)
        {
            _service = service;
        }

        public IEnumerable<JogoDto> Jogos { get; set; } = [];

        public async Task OnGetAsync()
        {
            Jogos = await _service.GetAllAsync();
        }
    }
}
