/*
- Campos obrigatórios:
- Nome (2 a 100 caracteres)

- Categoria (seleção obrigatória)
- Unidade de medida (ex: kg, unidade, litro, caixa)
- Preço aproximado
- Não pode haver produtos com o mesmo nome na mesma categoria

*/
using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.Modulos.ModuloCategoria;

public static class GeradorIdsProduto
{
    private static int contadorIds = 1;

    public static int GerarId()
    {
        return contadorIds++;
    }
}
public class Produto : EntidadeBase
{
    public string Nome { get; private set; }
    public Categoria Categoria { get; private set; }
    public string UnidadeMedida { get; private set; }
    public decimal PrecoAproximado { get; private set; }

    public Produto(string nome, Categoria categoria, string unidadeMedida, decimal precoAproximado)
    {
        Id = GeradorIdsCategoria.GerarId();

        Nome = nome;
        Categoria = categoria;
        UnidadeMedida = unidadeMedida;
        PrecoAproximado = precoAproximado;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Produto produtoAtualizado = (Produto)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Categoria = produtoAtualizado.Categoria;
        UnidadeMedida = produtoAtualizado.UnidadeMedida;
        PrecoAproximado = produtoAtualizado.PrecoAproximado;
    }
}
