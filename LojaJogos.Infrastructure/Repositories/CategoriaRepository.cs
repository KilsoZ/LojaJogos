using LojaJogos.Domain.Interfaces;
using LojaJogos.Domain.Entities;
using System.Data;
using Dapper;

namespace LojaJogos.Infrastructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly IDbConnection _db;

    public CategoriaRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Categorias WHERE Ativo = 1";
        return await _db.QueryAsync<Categoria>(sql);
    }

    public async Task<Categoria?> GetByIdAsync(int id)
    {
        const string sql = "SELECT * FROM Categorias WHERE Id = @Id";
        return await _db.QueryFirstOrDefaultAsync<Categoria>(sql, new { Id = id });
    }

    public async Task<int> CreateAsync(Categoria categoria)
    {
        const string sql = @"
            INSERT INTO Categorias (Nome, Ativo) 
            VALUES (@Nome, @Ativo);
            SELECT CAST(SCOPE_IDENTITY() as int)";
        return await _db.ExecuteScalarAsync<int>(sql, categoria);
    }

    public async Task<int> UpdateAsync(Categoria categoria)
    {
        const string sql = @"
            UPDATE Categorias 
            SET Nome = @Nome
            WHERE Id = @Id";
        return await _db.ExecuteAsync(sql, categoria);
    }

    public async Task DeactivateAsync(int id)
    {
        const string sql = "UPDATE Categorias SET Ativo = 0 WHERE Id = @Id";
        await _db.ExecuteAsync(sql, new { Id = id });
    }
}