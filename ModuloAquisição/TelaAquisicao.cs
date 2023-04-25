using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloRequisicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloAquisição
{
    class TelaAquisicao : TelaMae
    {

        public void Menu()
        {
            int opcao = 0;

            while (opcao != 5)
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1. Criar aquisição");
                Console.WriteLine("2. Consultar aquisição");
                Console.WriteLine("3. Listar aquisições");
                Console.WriteLine("4. Excluir aquisição");
                Console.WriteLine("5. Voltar");

                try
                {
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            CriarAquisicao();
                            break;
                        case 2:
                            ConsultarAquisicao();
                            break;
                        case 3:
                            ListarAquisicoes();
                            break;
                        case 4:
                            ExcluirAquisicao();
                            break;
                        case 5:
                            Console.WriteLine("Voltando ao menu principal...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }

                Console.WriteLine();
            }
        }

        public void CriarAquisicao()
        {
            Console.WriteLine("Criação de nova aquisição");
            Console.WriteLine();

            Fornecedor fornecedor = new Fornecedor();
            Console.WriteLine("Digite o nome do fornecedor:");
            fornecedor.Nome = Console.ReadLine();

            Remedio remedio = new Remedio();
            Console.WriteLine("Digite o nome do remédio:");
            remedio.Nome = Console.ReadLine();

            Funcionario funcionario = new Funcionario();
            Console.WriteLine("Digite o nome do funcionário:");
            funcionario.Nome = Console.ReadLine();

            Console.WriteLine("Digite a quantidade de reposição:");
            int quantidadeDeReposicao = int.Parse(Console.ReadLine());

            repositorioAquisicao.CriarAquisicao(fornecedor, remedio, funcionario, quantidadeDeReposicao);

            Console.WriteLine();
        }

        public void ConsultarAquisicao()
        {
            Console.WriteLine("Consulta de aquisição");
            Console.WriteLine();

            Console.WriteLine("Digite a data de solicitação da aquisição (dd/MM/yyyy):");
            string dataDeSolicitacao = Console.ReadLine();

            Aquisicao aquisicao = repositorioAquisicao.ConsultarAquisicao(dataDeSolicitacao);

            if (aquisicao != null)
            {
                Console.WriteLine($"Fornecedor: {aquisicao.fornecedor.Nome}");
                Console.WriteLine($"Remédio: {aquisicao.remedio.Nome}");
                Console.WriteLine($"Funcionário: {aquisicao.funcionario.Nome}");
                Console.WriteLine($"Data de solicitação: {aquisicao.dataDeSolicitacao}");
                Console.WriteLine($"Quantidade de reposição: {aquisicao.quantidadeDeReposicao}");
            }
            else
            {
                Console.WriteLine("Aquisição não encontrada.");
            }
            Console.WriteLine();
        }

        public void ListarAquisicoes()
        {
            Console.WriteLine("Listagem de aquisições");
            Console.WriteLine();

            repositorioAquisicao.ListarAquisicoes();

            Console.WriteLine();
        }

        public void ExcluirAquisicao()
        {
            Console.WriteLine("Exclusão de Aquisições");

            Console.WriteLine("Digite a data de solicitação da aquisição (dd/MM/yyyy):");
            string dataDeSolicitacao = Console.ReadLine();

            repositorioAquisicao.ExcluirAquisicao(dataDeSolicitacao);



        }

    }
}
