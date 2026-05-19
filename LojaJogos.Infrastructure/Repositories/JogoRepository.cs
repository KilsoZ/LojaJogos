using LojaJogos.Domain.Interfaces;
using LojaJogos.Domain.Entities;
using System.Data;
using Dapper;

namespace LojaJogos.Infrastructure.Repositories;

public class JogoRepository : IJogoRepository
{
    private readonly IDbConnection _db;

    public JogoRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Jogo>> GetAllAsync()
    {
        const string sql = @"
            SELECT j.*, c.Id, c.Nome, c.Ativo
            FROM Jogos j
            INNER JOIN Categorias c on j.CategoriaId = c.Id
            WHERE j.Ativo = 1";

        var jogos = await _db.QueryAsync<Jogo, Categoria, Jogo>(
            sql,
            (jogo, categoria) =>
            {
                jogo.Categoria = categoria;
                return jogo;
            },
            splitOn: "Id"
        );
        return jogos;
    }

    public async Task<Jogo?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT j.*, c.Id, c.Nome, c.Ativo
            FROM Jogos j
            INNER JOIN Categorias c on j.CategoriaId = c.Id
            WHERE j.Id = @Id";

        var jogo = await _db.QueryAsync<Jogo, Categoria, Jogo>(
            sql,
            (jogo, categoria) =>
            {
                jogo.Categoria = categoria;
                return jogo;
            },
            new { Id = id },
            splitOn: "Id"
        );
        return jogo.FirstOrDefault();
    }
    public async Task<int> CreateAsync(Jogo jogo)
    {
        const string sql = @"
            INSERT INTO Jogos (Titulo, Descricao, Preco, DataLancamento, CategoriaId, ImagemUrl, Ativo)
            VALUES (@Titulo, @Descricao, @Preco, @DataLancamento, @CategoriaId, @ImagemUrl, 1);
            SELECT CAST(SCOPE_IDENTITY() as int)";
        return await _db.ExecuteScalarAsync<int>(sql, new
        {
            jogo.Titulo,
            jogo.Descricao,
            jogo.Preco,
            jogo.DataLancamento,
            jogo.CategoriaId,
            jogo.ImagemUrl
        });
    }

    public async Task<int> UpdateAsync(Jogo jogo)
    {
        const string sql = @"
        UPDATE Jogos
        SET Titulo = @Titulo,
        Descricao = @Descricao,
        Preco = @Preco,
        DataLancamento = @DataLancamento,
        CategoriaId = @CategoriaId,
        ImagemUrl = @ImagemUrl
        WHERE Id = @Id";

        return await _db.ExecuteAsync(sql, new
        {
            jogo.Id,
            jogo.Titulo,
            jogo.Descricao,
            jogo.Preco,
            jogo.DataLancamento,
            jogo.CategoriaId,
            jogo.ImagemUrl
        });
    }

    public async Task DeactivateAsync(int id)
    {
        const string sql = "UPDATE Jogos SET Ativo = 0 WHERE Id = @Id";
        await _db.ExecuteAsync(sql, new { Id = id });
    }
}