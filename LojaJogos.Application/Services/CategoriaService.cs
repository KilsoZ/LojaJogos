using LojaJogos.Application.DTOs;
using LojaJogos.Domain.Entities;
using LojaJogos.Domain.Interfaces;

namespace LojaJogos.Application.Services;

public class CategoriaService
{
    private readonly ICategoriaRepository _repository;

    public CategoriaService(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CategoriaDto>> GetAllAsync()
    {
        var categorias = await _repository.GetAllAsync(); 
        return categorias.Select(c => new CategoriaDto
        {
            Id = c.Id,
            Nome = c.Nome
        });
    }

    public async Task<CategoriaDto?> GetByIdAsync(int id)
    {
        var categoria = await _repository.GetByIdAsync(id);
        if (categoria == null) return null;

        return new CategoriaDto
        {
            Id = categoria.Id,
            Nome = categoria.Nome
        };
    }

    public async Task<int> CreateAsync(CategoriaDto categoriaDto)
    {
        var categoria = new Categoria
        {
            Nome = categoriaDto.Nome,
            Ativo = true
        };
        return await _repository.CreateAsync(categoria);
    }

    public async Task<int> UpdateAsync(CategoriaDto categoriaDto)
    {
        var categoria = new Categoria
        {
            Id = categoriaDto.Id,
            Nome = categoriaDto.Nome
        };
        return await _repository.UpdateAsync(categoria);
    }

    public async Task DeactivateAsync(int id)
    {
        await _repository.DeactivateAsync(id);
    }

}