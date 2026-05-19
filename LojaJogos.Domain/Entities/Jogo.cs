namespace LojaJogos.Domain.Entities;

public class Jogo
{ 
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public DateTime? DataLancamento { get; set; }
    public int CategoriaId { get; set; }
    public string? ImagemUrl { get; set; }
    public bool Ativo { get; set; }
    public Categoria? Categoria { get; set; }
}

