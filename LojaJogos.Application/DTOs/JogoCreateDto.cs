namespace LojaJogos.Application.DTOs;

public class JogoCreateDto
{
    public string Titulo { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public DateTime? DataLancamento { get; set; }
    public string? ImagemUrl { get; set; }
    public int CategoriaId { get; set; }
}
