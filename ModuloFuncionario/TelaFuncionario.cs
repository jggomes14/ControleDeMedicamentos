using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloFuncionario
{
    class TelaFuncionario
    {
        private RepositorioFuncionario repositorio;

        public TelaFuncionario()
        {
            repositorio = new RepositorioFuncionario();
        }

        public void Menu()
        {
            int opcao = 0;

            do
            {
                Console.WriteLine("----- Menu Funcionário -----");
                Console.WriteLine("1 - Inserir Funcionário");
                Console.WriteLine("2 - Excluir Funcionário");
                Console.WriteLine("3 - Editar Funcionário");
                Console.WriteLine("4 - Consultar Funcionário");
                Console.WriteLine("5 - Verificar Existência de Funcionário");
                Console.WriteLine("0 - Sair");

                Console.Write("Digite a opção desejada: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        InserirFuncionario();
                        break;
                    case 2:
                        ExcluirFuncionario();
                        break;
                    case 3:
                        EditarFuncionario();
                        break;
                    case 4:
                       ConsultarFuncionario();
                        break;
                    case 5:
                        VerificarExistenciaFuncionario();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine();
            
            } while (opcao != 0);
        }
        public void InserirFuncionario()
        {
           
            Console.WriteLine("Digite o nome do funcionário:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o CPF do funcionário:");
            string cpf = Console.ReadLine();

            Console.WriteLine("Digite o telefone do funcionário:");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o endereço do funcionário:");
            string endereco = Console.ReadLine();

            Console.WriteLine("Digite o id do funcionário");
            int id = int.Parse(Console.ReadLine());
            Funcionario funcionario = new Funcionario();



            repositorio.Inserir(funcionario);

            Console.WriteLine("Funcionário cadastrado com sucesso!");
        }

        public void ExcluirFuncionario()
        {
            Console.WriteLine("Digite o nome do funcionário a ser excluído:");
            string nome = Console.ReadLine();

            repositorio.ExcluirFuncionario(nome);

            Console.WriteLine("Funcionário excluído com sucesso!");
        }

        public void EditarFuncionario()
        {
            Console.WriteLine("Digite o nome do funcionário a ser editado:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o novo nome do funcionário:");
            string novoNome = Console.ReadLine();

            Console.WriteLine("Digite o CPF do funcionário:");
            string cpf = Console.ReadLine();

            Console.WriteLine("Digite o telefone do funcionário:");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o endereço do funcionário:");
            string endereco = Console.ReadLine();

            repositorio.EditarFuncionario(nome, cpf, telefone, endereco, novoNome);

            Console.WriteLine("Funcionário editado com sucesso!");
        }

        public void ConsultarFuncionario()
        {
            Console.WriteLine("Digite o nome do funcionário a ser consultado:");
            string nome = Console.ReadLine();

            Funcionario funcionario = repositorio.ConsultarFuncionario(nome);

            if (funcionario != null)
            {
                Console.WriteLine($"Nome: {funcionario.Nome}");
                Console.WriteLine($"CPF: {funcionario.CPF}");
                Console.WriteLine($"Telefone: {funcionario.Telefone}");
                Console.WriteLine($"Endereço: {funcionario.Endereco}");
            }
        }

        public void VerificarExistenciaFuncionario()
        {
            Console.WriteLine("Digite o nome do funcionário:");
            string nome = Console.ReadLine();

            bool existe = repositorio.VerificarExistenciaFuncionario(nome);

            if (existe)
            {
                Console.WriteLine($"Funcionário {nome} encontrado.");
            }
        }
    }

}
