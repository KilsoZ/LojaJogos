namespace LojaJogos.Application.DTOs;

public class JogoDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public DateTime? DataLancamento { get; set; }
    public string? ImagemUrl { get; set; }
    public string CategoriaNome { get; set; } = string.Empty;
    public int CategoriaId { get; set; }
}
