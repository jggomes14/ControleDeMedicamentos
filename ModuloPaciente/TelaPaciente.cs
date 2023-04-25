using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloRequisicao;
using ControleDeMedicamentos.ModuloRequisição;

namespace ControleDeMedicamentos.ModuloPaciente
{
    using System;

    class TelaPaciente : TelaMae
    {
        public void ExibirMenu()
        {
            int escolha = 0;

            do
            {
                Console.WriteLine("===== MENU PACIENTE =====");
                Console.WriteLine("1. Cadastrar Paciente");
                Console.WriteLine("2. Excluir Paciente");
                Console.WriteLine("3. Editar Paciente");
                Console.WriteLine("4. Consultar Paciente");
                Console.WriteLine("5. Listar Pacientes");
                Console.WriteLine("0. Voltar ao menu principal");
                Console.Write("Escolha uma opção: ");
                escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 0:
                        Console.WriteLine("Retornando ao menu principal...");
                        break;
                    case 1:
                        CadastrarPaciente();
                        break;
                    case 2:
                        ExcluirPaciente();
                        break;
                    case 3:
                        EditarPaciente();
                        break;
                    case 4:
                        ConsultarPaciente();
                        break;
                    case 5:
                        ListarPacientes();
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

        private void CadastrarPaciente()
        {
            Console.WriteLine("===== CADASTRAR PACIENTE =====");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Cartão do SUS: ");
            string cartaoDoSUS = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();

            Paciente paciente = new Paciente();

            if (repositorioPaciente.VerificarExistenciaPaciente(nome))
            {
                Console.WriteLine($"O paciente {nome} já está cadastrado.");
            }
            else
            {
                repositorioPaciente.Inserir(paciente);
                Console.WriteLine($"O paciente {nome} foi cadastrado com sucesso.");
            }
        }

        private void ExcluirPaciente()
        {
            Console.WriteLine("===== EXCLUIR PACIENTE =====");
            Console.Write("Nome do paciente a ser excluído: ");
            string nome = Console.ReadLine();

            if (repositorioPaciente.VerificarExistenciaPaciente(nome))
            {
                repositorioPaciente.ExcluirPaciente(nome);
                Console.WriteLine($"O paciente {nome} foi excluído com sucesso.");
            }
        }

        private void EditarPaciente()
        {
            Console.WriteLine("===== EDITAR PACIENTE =====");
            Console.Write("Nome do paciente a ser editado: ");
            string nome = Console.ReadLine();

            if (repositorioPaciente.VerificarExistenciaPaciente(nome))
            {
                Paciente paciente = repositorioPaciente.ConsultarPaciente(nome);

                Console.Write("Novo CPF (ou deixe em branco para manter o CPF atual): ");
                string cpf = Console.ReadLine();
                if (!string.IsNullOrEmpty(cpf))
                {
                    paciente.CPF = cpf;
                }

                Console.Write("Novo Cartão do SUS (ou deixe em branco para manter o Cartão do SUS atual): ");
                string cartaoDoSUS = Console.ReadLine();
                if (!string.IsNullOrEmpty(cartaoDoSUS))
                {
                    paciente.CartaoDoSUS = cartaoDoSUS;
                }

                Console.Write("Novo Telefone (ou deixe em branco para manter o Telefone atual): ");
                string telefone = Console.ReadLine();
                if (!string.IsNullOrEmpty(telefone))
                {
                    paciente.Telefone = telefone;
                }

                Console.Write("Novo Endereço (ou deixe em branco para manter o Endereço atual): ");
                string endereco = Console.ReadLine();
                if (!string.IsNullOrEmpty(endereco))
                {
                    paciente.Endereco = endereco;
                }

                Console.WriteLine($"O paciente {nome} foi atualizado com sucesso.");
            }
        }
        private void ConsultarPaciente()
        {
            Console.WriteLine("===== CONSULTAR PACIENTE =====");
            Console.Write("Nome do paciente a ser consultado: ");
            string nome = Console.ReadLine();

            Paciente paciente = repositorioPaciente.ConsultarPaciente(nome);

            if (paciente == null)
            {
                Console.WriteLine($"O paciente {nome} não foi encontrado.");
            }
            else
            {
                Console.WriteLine($"Nome: {paciente.Nome} | CPF: {paciente.CPF} | Cartão do SUS: {paciente.CartaoDoSUS} | Telefone: {paciente.Telefone} | Endereço: {paciente.Endereco}");
            }
        }
        private void ListarPacientes()
        {
            Console.WriteLine("===== LISTAR PACIENTES =====");
            if (repositorioPaciente.listaRegistros.Count == 0)
            {
                Console.WriteLine("Não há pacientes cadastrados.");
            }
            else
            {
                Console.WriteLine("Pacientes cadastrados:");
                repositorioPaciente.ListarPacientes();
            }
        }

    }
}

