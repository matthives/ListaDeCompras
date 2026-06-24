using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.Modulos.ModuloListaDeCompras;

public static class GeradorIdsListaDeCompras
{
    private static int contadorIds = 1;

    public static int GerarId()
    {
        return contadorIds++;
    }
}

public enum StatusLista
{
    Aberta,
    Concluida
}

public class ListaDeCompras : EntidadeBase
{
    public string Nome { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public StatusLista Status { get; private set; }

    // Esses dois serão calculados com base nos itens (futuro módulo ItemLista)
    public int TotalItens { get; private set; }
    public decimal TotalEstimado { get; private set; }

    public ListaDeCompras(string nome)
    {
        ValidarNome(nome);

        Id = GeradorIdsListaDeCompras.GerarId();

        Nome = nome;
        DataCriacao = DateTime.Now;
        Status = StatusLista.Aberta;

        TotalItens = 0;
        TotalEstimado = 0;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        ListaDeCompras listaAtualizada = (ListaDeCompras)entidadeAtualizada;

        ValidarNome(listaAtualizada.Nome);

        Nome = listaAtualizada.Nome;
        Status = listaAtualizada.Status;

        // DataCriacao não muda
        // Totais serão recalculados via itens futuramente
    }

    private void ValidarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new Exception("O nome da lista é obrigatório.");

        if (nome.Length < 3 || nome.Length > 100)
            throw new Exception("O nome da lista deve ter entre 3 e 100 caracteres.");
    }

    // Métodos futuros (quando criarmos itens)
    public void AtualizarTotais(int totalItens, decimal totalEstimado)
    {
        TotalItens = totalItens;
        TotalEstimado = totalEstimado;
    }
}
