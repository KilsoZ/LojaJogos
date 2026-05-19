using LojaJogos.Application.DTOs;
using LojaJogos.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LojaJogos.Web.Pages.Jogos;

public class DeleteModel : PageModel
{
    private readonly JogoService _jogoService;

    public DeleteModel(JogoService jogoService)
    {
        _jogoService = jogoService;
    }

    [BindProperty]
    public int Id { get; set; }

    public JogoDto? Jogo { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Jogo = await _jogoService.GetByIdAsync(id);
        if (Jogo == null)
        {
            return NotFound();
        }
        Id = Jogo.Id;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _jogoService.DeactivateAsync(Id);
        return RedirectToPage("Index");
    }
}