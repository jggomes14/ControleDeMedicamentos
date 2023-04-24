using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloPaciente;
using ControleDeMedicamentos.ModuloRequisicao;
using ControleDeMedicamentos.ModuloRequisição;
using System;

public class TelaRequisicao
{
    private RepositorioRequisicao repositorioRequisicao;

    public TelaRequisicao()
    {
        repositorioRequisicao = new RepositorioRequisicao();
    }

    public void MostrarMenu()
    {
        bool sair = false;

        while (!sair)
        {
            Console.Clear();
            Console.WriteLine("==== GERENCIAMENTO DE REQUISIÇÕES ====");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Criar nova requisição");
            Console.WriteLine("2 - Excluir requisição");
            Console.WriteLine("3 - Editar requisição");
            Console.WriteLine("4 - Consultar requisição");
            Console.WriteLine("5 - Listar todas as requisições");
            Console.WriteLine("6 - Listar requisições por paciente");
            Console.WriteLine("0 - Voltar");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0:
                    sair = true;
                    break;

                case 1:
                    CriarRequisicao();
                    break;

                case 2:
                    ExcluirRequisicao();
                    break;

                case 3:
                    EditarRequisicao();
                    break;

                case 4:
                    ConsultarRequisicao();
                    break;

                case 5:
                    repositorioRequisicao.ListarRequisicoes();
                    break;

                case 6:
                    ListarRequisicoesPorPaciente();
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    private void CriarRequisicao()
    {
        Console.Clear();
        Console.WriteLine("==== CRIAÇÃO DE NOVA REQUISIÇÃO ====");
        Console.WriteLine("Digite o nome do paciente:");
        string nomePaciente = Console.ReadLine();
        Paciente paciente = repositorioRequisicao.repositorioPaciente.ConsultarPaciente(nomePaciente);
        if (paciente == null)
        {
            Console.WriteLine($"Paciente {nomePaciente} não encontrado.");
            return;
        }

        Console.WriteLine("Digite o nome do remédio:");
        string nomeRemedio = Console.ReadLine();
        Remedio remedio = repositorioRequisicao.repositorioRemedio.ConsultarRemedio(nomeRemedio);
        if (remedio == null)
        {
            Console.WriteLine($"Remédio {nomeRemedio} não encontrado.");
            return;
        }

        Console.WriteLine("Digite a quantidade solicitada:");
        int quantidadeSolicitada = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o nome do funcionário responsável:");
        string nomeFuncionario = Console.ReadLine();
        Funcionario funcionario = repositorioRequisicao.repositorioFuncionario.ConsultarFuncionario(nomeFuncionario);
        if (funcionario == null)
        {
            Console.WriteLine($"Funcionário {nomeFuncionario} não encontrado.");
            return;
        }

        repositorioRequisicao.CriarRequisicao(paciente, remedio, quantidadeSolicitada, funcionario, nomePaciente);
    }

    private void ExcluirRequisicao()
    {
        Console.Clear();
        Console.WriteLine("==== EXCLUSÃO DE REQUISIÇÃO ====");
        Console.WriteLine("Digite a data da requisição (DD/MM/AAAA):");
        string dataDeRequisicao = Console.ReadLine();

        Requisicao requisicaoEncontrada = repositorioRequisicao.ConsultarRequisicao(dataDeRequisicao);

        if (requisicaoEncontrada == null)
        {
            Console.WriteLine("Não foi encontrada uma requisição com a data informada.");
        }
        else
        {
            repositorioRequisicao.ExcluirRequisicao(dataDeRequisicao);
            Console.WriteLine("Requisição excluída com sucesso!");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
    private void EditarRequisicao()
    {
        Console.Clear();
        Console.WriteLine("==== EDIÇÃO DE REQUISIÇÃO ====");
        Console.WriteLine("Digite a data da requisição a ser editada (DD/MM/AAAA):");
        string dataDeRequisicao = Console.ReadLine();

        Requisicao requisicaoEncontrada = repositorioRequisicao.ConsultarRequisicao(dataDeRequisicao);

        if (requisicaoEncontrada == null)
        {
            Console.WriteLine("Não foi encontrada uma requisição com a data informada.");
        }
        else
        {
            Console.WriteLine("Dados da requisição:");
            Console.WriteLine($"Paciente: {requisicaoEncontrada.paciente.Nome}");
            Console.WriteLine($"Remédio: {requisicaoEncontrada.remedio.Nome}");
            Console.WriteLine($"Quantidade solicitada: {requisicaoEncontrada.quantidadeDeRemedioSolicitada}");
            Console.WriteLine($"Funcionário responsável: {requisicaoEncontrada.funcionario.Nome}");
            Console.WriteLine();
            Console.WriteLine("Digite os novos dados da requisição:");

            Console.WriteLine("Digite o nome do paciente:");
            string nomePaciente = Console.ReadLine();
            Paciente paciente = repositorioRequisicao.repositorioPaciente.ConsultarPaciente(nomePaciente);
            if (paciente == null)
            {
                Console.WriteLine($"Paciente {nomePaciente} não encontrado.");
                return;
            }

            Console.WriteLine("Digite o nome do remédio:");
            string nomeRemedio = Console.ReadLine();
            Remedio remedio = repositorioRequisicao.repositorioRemedio.ConsultarRemedio(nomeRemedio);
            if (remedio == null)
            {
                Console.WriteLine($"Remédio {nomeRemedio} não encontrado.");
                return;
            }

            Console.WriteLine("Digite a quantidade solicitada:");
            int quantidadeSolicitada;
            if (!int.TryParse(Console.ReadLine(), out quantidadeSolicitada))
            {
                Console.WriteLine("Quantidade informada inválida. Digite um número inteiro válido.");
                return;
            }

            Console.WriteLine("Digite o nome do funcionário responsável:");
            string nomeFuncionario = Console.ReadLine();
            Funcionario funcionario = repositorioRequisicao.repositorioFuncionario.ConsultarFuncionario(nomeFuncionario);
            if (funcionario == null)
            {
                Console.WriteLine($"Funcionário {nomeFuncionario} não encontrado.");
                return;
            }

            repositorioRequisicao.EditarRequisicao(dataDeRequisicao, paciente, remedio, quantidadeSolicitada, funcionario);
            Console.WriteLine("Requisição editada com sucesso!");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
    private void ConsultarRequisicao()
    {
        Console.Clear();
        Console.WriteLine("==== CONSULTA DE REQUISIÇÃO ====");
        Console.WriteLine("Digite a data da requisição (DD/MM/AAAA):");
        string dataDeRequisicao = Console.ReadLine();

        Requisicao requisicaoEncontrada = repositorioRequisicao.ConsultarRequisicao(dataDeRequisicao);

        if (requisicaoEncontrada == null)
        {
            Console.WriteLine("Não foi encontrada uma requisição com a data informada.");
        }
        else
        {
            Console.WriteLine("Dados da requisição:");
            Console.WriteLine($"Paciente: {requisicaoEncontrada.paciente.Nome}");
            Console.WriteLine($"Remédio: {requisicaoEncontrada.remedio.Nome}");
            Console.WriteLine($"Quantidade solicitada: {requisicaoEncontrada.quantidadeDeRemedioSolicitada}");
            Console.WriteLine($"Funcionário responsável: {requisicaoEncontrada.funcionario.Nome}");
            Console.WriteLine();
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
    private void ListarRequisicoesPorPaciente()
    {
        Console.Clear();
        Console.WriteLine("==== LISTAGEM DE REQUISIÇÕES POR PACIENTE ====");
        Console.WriteLine("Digite o nome do paciente:");
        string nomePaciente = Console.ReadLine();
        RepositorioRequisicao repositorioRequisicao = new RepositorioRequisicao();
        repositorioRequisicao.ListarRequisicoesPorPaciente(nomePaciente);

    }
}



