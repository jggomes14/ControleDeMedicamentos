using ControleDeMedicamentos.ModuloMedicamento;
using System;

using System;
namespace ControleDeMedicamentos.ModuloMedicamento;


public class TelaRemedio
{
    static RepositorioRemedio repositorio = new RepositorioRemedio();

   
    public void MostrarMenu()
        {
            int opcao = 0;

            do
            {
                Console.WriteLine("===== MENU =====");
                Console.WriteLine("1 - Inserir novo remédio");
                Console.WriteLine("2 - Consultar remédio por nome");
                Console.WriteLine("3 - Atualizar quantidade de remédio");
                Console.WriteLine("4 - Visualizar remédios abaixo do limite");
                Console.WriteLine("5 - Editar remédio");
                Console.WriteLine("6 - Excluir remédio");
                Console.WriteLine("7 - Verificar existência de remédio");
                Console.WriteLine("0 - Sair");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        InserirRemedio();
                        break;
                    case 2:
                        ConsultarRemedio();
                        break;
                    case 3:
                        AtualizarQuantidadeDeRemedio();
                        break;
                    case 4:
                        VisualizarRemediosAbaixoDoLimite();
                        break;
                    case 5:
                        EditarRemedio();
                        break;
                    case 6:
                        ExcluirRemedio();
                        break;
                    case 7:
                        VerificarExistenciaRemedio();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.WriteLine();
            } while (opcao != 0);
        } 

    static void InserirRemedio()
    {
        Console.WriteLine("===== INSERIR REMÉDIO =====");
        Remedio remedio = new Remedio();
        Console.Write("Nome do remédio: ");
        string nome = Console.ReadLine();

        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();

        Console.Write("Quantidade de remédio: ");
        int quantidade = int.Parse(Console.ReadLine());

        Console.Write("Quantidade limite: ");
        int quantidadeLimite = int.Parse(Console.ReadLine());

        repositorio.Inserir(remedio);

        Console.WriteLine("Remédio inserido com sucesso!");
    }

    static void ConsultarRemedio()
    {
        Console.WriteLine("===== CONSULTAR REMÉDIO =====");

        Console.Write("Nome do remédio: ");
        string nome = Console.ReadLine();

        Remedio remedio = repositorio.ConsultarRemedio(nome);

        if (remedio != null)
        {
            Console.WriteLine($"Nome: {remedio.Nome}");
            Console.WriteLine($"Descrição: {remedio.descricao}");
            Console.WriteLine($"Quantidade de remédio: {remedio.quantidadeDeRemedio}");
            Console.WriteLine($"Quantidade limite: {remedio.quantidadeLimite}");
        }
        else
        {
            Console.WriteLine("Remédio não encontrado");
        }
    }

    static void AtualizarQuantidadeDeRemedio()
    {
        Console.WriteLine("===== ATUALIZAR QUANTIDADE DE REMÉDIO =====");

        Console.Write("Nome do remédio: ");
        string nome = Console.ReadLine();

        Console.Write("Nova quantidade de remédio: ");
        int novaQuantidade = int.Parse(Console.ReadLine());

        repositorio.AtualizarQuantidadeDeRemedio(nome, novaQuantidade);

        Console.WriteLine("Quantidade de remédio atualizada com sucesso!");
    }
    private static void VisualizarRemediosAbaixoDoLimite()
    {
        repositorio.VisualizarRemediosAbaixoDoLimite();
    }
    private static void EditarRemedio()
    {
        Console.WriteLine("Editar remédio:");
        Console.Write("Digite o nome do remédio que deseja editar: ");
        string nome = Console.ReadLine();

        if (repositorio.VerificarExistenciaRemedio(nome))
        {
            Console.Write("Digite o novo nome: ");
            string novoNome = Console.ReadLine();

            Console.Write("Digite a nova descrição: ");
            string novaDescricao = Console.ReadLine();

            Console.Write("Digite a nova quantidade: ");
            int novaQuantidade = int.Parse(Console.ReadLine());

            Console.Write("Digite a nova quantidade limite: ");
            int novaQuantidadeLimite = int.Parse(Console.ReadLine());

            repositorio.EditarRemedio(nome, novoNome, novaDescricao, novaQuantidade, novaQuantidadeLimite);

            Console.WriteLine("Remédio editado com sucesso!");
        }
    }
    private static void ExcluirRemedio()
    {
        Console.WriteLine("Excluir remédio:");
        Console.Write("Digite o nome do remédio que deseja excluir: ");
        string nome = Console.ReadLine();

        if (repositorio.VerificarExistenciaRemedio(nome))
        {
            repositorio.ExcluirRemedio(nome);

            Console.WriteLine("Remédio excluído com sucesso!");
        }
    }
    private static void VerificarExistenciaRemedio()
    {
        Console.WriteLine("Verificar existência de remédio:");
        Console.Write("Digite o nome do remédio que deseja verificar: ");
        string nome = Console.ReadLine();

        repositorio.VerificarExistenciaRemedio(nome);
    }





}