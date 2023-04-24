using ControleDeMedicamentos.ModuloFornecedor;
using System;

class TelaFornecedor
{
    private RepositorioFornecedor repositorioFornecedor;

    public TelaFornecedor()
    {
        repositorioFornecedor = new RepositorioFornecedor();
    }

    public void MostrarMenu()
    {
        int opcao = 0;

        do
        {
            Console.WriteLine("===== MENU FORNECEDOR =====");
            Console.WriteLine("1 - Cadastrar Fornecedor");
            Console.WriteLine("2 - Consultar Fornecedor");
            Console.WriteLine("3 - Excluir Fornecedor");
            Console.WriteLine("4 - Editar Fornecedor");
            Console.WriteLine("0 - Sair");

            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarFornecedor();
                    break;
                case 2:
                    ConsultarFornecedor();
                    break;
                case 3:
                    ExcluirFornecedor();
                    break;
                case 4:
                    EditarFornecedor();
                    break;
                case 0:
                    Console.WriteLine("Saindo do Menu Fornecedor...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine();
        } while (opcao != 0);
    }

    private void CadastrarFornecedor()
    {
        Console.WriteLine("===== CADASTRAR FORNECEDOR =====");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("CNPJ: ");
        string cnpj = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("E-mail: ");
        string email = Console.ReadLine();

        Console.Write("Endereço: ");
        string endereco = Console.ReadLine();

        Fornecedor fornecedor = new Fornecedor();
        repositorioFornecedor.Inserir(fornecedor);

        Console.WriteLine("Fornecedor cadastrado com sucesso.");
    }

    private void ConsultarFornecedor()
    {
        Console.WriteLine("===== CONSULTAR FORNECEDOR =====");

        Console.Write("Nome do Fornecedor: ");
        string nome = Console.ReadLine();

        Fornecedor fornecedor = repositorioFornecedor.ConsultarFornecedor(nome);
        if (fornecedor != null)
        {
            Console.WriteLine(fornecedor);
        }
    }

    private void ExcluirFornecedor()
    {
        Console.WriteLine("===== EXCLUIR FORNECEDOR =====");

        Console.Write("Nome do Fornecedor: ");
        string nome = Console.ReadLine();

        bool existeFornecedor = repositorioFornecedor.VerificarExistenciaFornecedor(nome);
        if (existeFornecedor)
        {
            repositorioFornecedor.ExcluirFornecedor(nome);
            Console.WriteLine("Fornecedor excluído com sucesso.");
        }
    }

    private void EditarFornecedor()
    {
        Console.WriteLine("===== EDITAR FORNECEDOR =====");

        Console.Write("Nome do Fornecedor: ");
        string nomeAntigo = Console.ReadLine();

        bool existeFornecedor = repositorioFornecedor.VerificarExistenciaFornecedor(nomeAntigo);
        if (existeFornecedor)
        {
            Console.Write("Novo nome: ");
            string novoNome = Console.ReadLine();

            Console.Write("CNPJ: ");
            string cnpj = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("E-mail: ");
            string email = Console.ReadLine();

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();

            repositorioFornecedor.EditarFornecedor(nomeAntigo, novoNome, cnpj, telefone, email, endereco);
        }
    }
}
