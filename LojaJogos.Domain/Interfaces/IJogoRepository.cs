using LojaJogos.Domain.Entities;

namespace LojaJogos.Domain.Interfaces;

public interface IJogoRepository
{
    Task<IEnumerable<Jogo>> GetAllAsync();
    Task<Jogo?> GetByIdAsync(int id);
    Task<int> CreateAsync(Jogo jogo);
    Task<int> UpdateAsync(Jogo jogo);
    Task DeactivateAsync(int id);
}