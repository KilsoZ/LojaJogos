using LojaJogos.Application.DTOs;
using LojaJogos.Domain.Interfaces;

namespace LojaJogos.Application.Services;

public class JogoService
{
    private readonly IJogoRepository _repository;

    public JogoService(IJogoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<JogoDto>> GetAllAsync()
    { 
        var jogos = await _repository.GetAllAsync();
        return jogos.Select(j => new JogoDto
        {
            Id = j.Id,
            Titulo = j.Titulo,
            Descricao = j.Descricao,
            Preco = j.Preco,
            DataLancamento = j.DataLancamento,
            ImagemUrl = j.ImagemUrl,
            CategoriaNome = j.Categoria?.Nome ?? "Sem Categoria",
            CategoriaId = j.CategoriaId,
        });
    }

    public async Task<JogoDto?> GetByIdAsync(int id)
    {
        var jogo = await _repository.GetByIdAsync(id);
        if (jogo == null) return null;
        return new JogoDto
        {
            Id = jogo.Id,
            Titulo = jogo.Titulo,
            Descricao = jogo.Descricao,
            Preco = jogo.Preco,
            DataLancamento = jogo.DataLancamento,
            ImagemUrl = jogo.ImagemUrl,
            CategoriaNome = jogo.Categoria?.Nome ?? "Sem Categoria",
            CategoriaId = jogo.CategoriaId,
        };
    }

    public async Task<int> CreateAsync(JogoCreateDto jogoCreateDto)
    {
        var jogo = new Domain.Entities.Jogo
        {
            Titulo = jogoCreateDto.Titulo,
            Descricao = jogoCreateDto.Descricao,
            Preco = jogoCreateDto.Preco,
            DataLancamento = jogoCreateDto.DataLancamento,
            ImagemUrl = jogoCreateDto.ImagemUrl,
            CategoriaId = jogoCreateDto.CategoriaId
        };
        return await _repository.CreateAsync(jogo);
    }

    public async Task<int> UpdateAsync(JogoEditDto jogoEditDto)
    {
        var jogo = new Domain.Entities.Jogo
        {
            Id = jogoEditDto.Id,
            Titulo = jogoEditDto.Titulo,
            Descricao = jogoEditDto.Descricao,
            Preco = jogoEditDto.Preco,
            DataLancamento = jogoEditDto.DataLancamento,
            ImagemUrl = jogoEditDto.ImagemUrl,
            CategoriaId = jogoEditDto.CategoriaId
        };
        return await _repository.UpdateAsync(jogo);
    }

    public async Task DeactivateAsync(int id)
        {
            await _repository.DeactivateAsync(id);
    }
}
