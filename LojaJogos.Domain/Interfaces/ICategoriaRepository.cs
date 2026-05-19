using LojaJogos.Domain.Entities;

namespace LojaJogos.Domain.Interfaces;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> GetAllAsync();
    Task<Categoria?> GetByIdAsync(int id);
    Task<int> CreateAsync(Categoria categoria);
    Task<int> UpdateAsync(Categoria categoria);
    Task DeactivateAsync(int id);

}