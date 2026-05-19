using LojaJogos.Application.DTOs;
using LojaJogos.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LojaJogos.Web.Pages.Jogos;

public class CreateModel : PageModel
{
    private readonly JogoService _jogoService;
    private readonly CategoriaService _categoriaService;

    public CreateModel(JogoService jogoService, CategoriaService categoriaService)
    {
        _jogoService = jogoService;
        _categoriaService = categoriaService;
    }

    [BindProperty]
    public JogoCreateDto Jogo { get; set; } = new();

    public IEnumerable<CategoriaDto> Categorias { get; set; } = [];

    public async Task OnGetAsync()
    {
        Categorias = await _categoriaService.GetAllAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Categorias = await _categoriaService.GetAllAsync();
            return Page();
        }
        await _jogoService.CreateAsync(Jogo);
        return RedirectToPage("Index");

    }
}