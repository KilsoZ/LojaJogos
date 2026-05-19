using LojaJogos.Application.DTOs;
using LojaJogos.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LojaJogos.Web.Pages.Jogos;

public class EditModel : PageModel
{
    private readonly JogoService _jogoService;
    private readonly CategoriaService _categoriaService;

    public EditModel(JogoService jogoService, CategoriaService categoriaService)
    {
        _jogoService = jogoService;
        _categoriaService = categoriaService;
    }

    [BindProperty]
    public JogoEditDto Jogo { get; set; } = new();

    public IEnumerable<CategoriaDto> Categorias { get; set; } = [];

    public async Task<IActionResult> OnGetAsync(int id)
    { 
        var jogo = await _jogoService.GetByIdAsync(id);
        if (jogo == null)
        {
            return NotFound();
        }

        Jogo = new JogoEditDto
        {
            Id = jogo.Id,
            Titulo = jogo.Titulo,
            Descricao = jogo.Descricao,
            Preco = jogo.Preco,
            DataLancamento = jogo.DataLancamento,
            ImagemUrl = jogo.ImagemUrl,
            CategoriaId = jogo.CategoriaId
        };

        Categorias = await _categoriaService.GetAllAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Categorias = await _categoriaService.GetAllAsync();
            return Page();
        }
        await _jogoService.UpdateAsync(Jogo);
        return RedirectToPage("Index");
    }
}