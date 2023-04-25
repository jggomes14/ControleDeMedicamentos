namespace ControleDeMedicamentos
{
    using ControleDeMedicamentos.ModuloAquisição;
    using ControleDeMedicamentos.ModuloFuncionario;
    using ControleDeMedicamentos.ModuloMedicamento;
    using ControleDeMedicamentos.ModuloAquisição;
    using ControleDeMedicamentos.ModuloPaciente;

    using System;

    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int escolha = 0;

            do
            {
                Console.WriteLine("===== MENU =====");
                Console.WriteLine("1. Aquisição");
                Console.WriteLine("2. Remédio");
                Console.WriteLine("3. Paciente");
                Console.WriteLine("4. Funcionário");
                Console.WriteLine("5. Requisição");
                Console.WriteLine("6. Fornecedor");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 0:
                        Console.WriteLine("Saindo do sistema...");
                        break;
                    case 1:
                        Console.WriteLine("Opção Aquisição selecionada.");
                        TelaAquisicao telaAquisicao = new TelaAquisicao();
                        telaAquisicao.Menu();
                        break;
                    case 2:
                        Console.WriteLine("Opção Remédio selecionada.");
                        TelaRemedio telaRemedio = new TelaRemedio();
                        telaRemedio.MostrarMenu();
                        break;
                    case 3:
                        Console.WriteLine("Opção Paciente selecionada.");
                        TelaPaciente telaPaciente = new TelaPaciente();
                        telaPaciente.ExibirMenu();
                        break;
                    case 4:
                        Console.WriteLine("Opção Funcionário selecionada.");
                        TelaFuncionario telaFuncionario = new TelaFuncionario();
                        telaFuncionario.Menu();
                        break;
                    case 5:
                        Console.WriteLine("Opção Requisição selecionada.");
                        TelaRequisicao telaRequisicao = new TelaRequisicao();
                        telaRequisicao.MostrarMenu();
                        break;
                    case 6:
                        Console.WriteLine("Opção Fornecedor selecionada.");
                        TelaFornecedor telaFornecedor = new TelaFornecedor();
                        telaFornecedor.MostrarMenu();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            } while (escolha != 0);
        }
    }


}