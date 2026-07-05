using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Modulos.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.Modulos.ModuloProduto;

public class TelaProduto : TelaBase<Produto>, ITelaOpcoes, ITelaCrud
{
    private readonly RepositorioProduto repositorioProduto;
    private readonly RepositorioCategoria repositorioCategoria;

    public TelaProduto(
        RepositorioProduto repositorioProduto,
        RepositorioCategoria repositorioCategoria) : base("Produto", repositorioProduto)
    {
        this.repositorioProduto = repositorioProduto;
        this.repositorioCategoria = repositorioCategoria;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Produtos");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20} | {3, -10} | {4, -17}",
            "Id", "Nome", "Categoria", "Unidade", "Preço Aproximado"
        );

        List<Produto> registros = repositorioProduto.SelecionarTodos();

        foreach (Produto p in registros)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -10} | {4, -17}",
                p.Id,
                p.Nome,
                p.Categoria.Nome,
                string.Join(" ", p.ValorUnidadeMedida, p.UnidadeMedida),
                p.PrecoAproximado.ToString("C2")
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
    }

    protected override Produto ObterDadosCadastrais()
    {
        Console.Write("Informe o nome do produto: ");
        string? nome = Console.ReadLine();

        Console.WriteLine("---------------------------------");

        VisualizarCategorias();

        Console.WriteLine("---------------------------------");

        Console.Write("Informe o ID da categoria do produto: ");
        int idCategoria = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------------");

        Categoria? categoriaSelecionada = repositorioCategoria.SelecionarPorId(idCategoria);

        Console.Write("Informe o valor/quantidade da unidade de medida do produto: ");
        int valorUnidadeMedida = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Selecione uma unidade de medida disponível para o produto");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Unidade (Padrão)");
        Console.WriteLine("2 - Caixa");
        Console.WriteLine("3 - Duzia");
        Console.WriteLine("4 - Kg");
        Console.WriteLine("5 - L");
        Console.WriteLine("6 - Ml");
        Console.WriteLine("7 - G");
        Console.WriteLine("---------------------------------");
        Console.Write("Informe a unidade de medida escolhida: ");
        string? unidadeSelecionada = Console.ReadLine();

        UnidadeMedidaProduto unidadeMedida;

        switch (unidadeSelecionada)
        {
            case "1":
                unidadeMedida = UnidadeMedidaProduto.Unidade;
                break;

            case "2":
                unidadeMedida = UnidadeMedidaProduto.Caixa;
                break;

            case "3":
                unidadeMedida = UnidadeMedidaProduto.Duzia;
                break;

            case "4":
                unidadeMedida = UnidadeMedidaProduto.Kg;
                break;

            case "5":
                unidadeMedida = UnidadeMedidaProduto.L;
                break;

            case "6":
                unidadeMedida = UnidadeMedidaProduto.Ml;
                break;

            case "7":
                unidadeMedida = UnidadeMedidaProduto.G;
                break;

            default:
                unidadeMedida = UnidadeMedidaProduto.Unidade;
                break;
        }

        Console.Write("Informe o preço aproximado do produto: ");
        decimal precoAproximado = Convert.ToDecimal(Console.ReadLine());

        return new Produto(
            nome!,
            categoriaSelecionada!,
            valorUnidadeMedida,
            unidadeMedida,
            precoAproximado);
    }

    protected override bool ExisteRegistroComInformacoesExclusivas(
        Produto entidade, int? idIgnorado = null)
    {
        List<Produto> produtos = repositorioProduto.SelecionarTodos();

        foreach (Produto p in produtos)
        {
            if (
                p.Id != idIgnorado &&
                p.Nome.ToLower() == entidade.Nome.ToLower() &&
                p.Categoria == entidade.Categoria
            )
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Já existe um produto com o nome {p.Nome} na categoria!");
                Console.WriteLine("---------------------------------");

                return true;
            }
        }

        return base.ExisteRegistroComInformacoesExclusivas(entidade, idIgnorado);
    }

    private void VisualizarCategorias()
    {
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10}",
            "Id", "Nome", "Cor"
        );

        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        foreach (Categoria c in categorias)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10}",
                c.Id, c.Nome, c.Cor
            );
        }
    }
}
