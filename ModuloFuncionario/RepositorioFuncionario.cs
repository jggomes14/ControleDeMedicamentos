using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloFuncionario;

namespace ControleDeMedicamentos.ModuloFuncionario
{
    internal class RepositorioFuncionario : RepositorioMae
    {
        public void Inserir(Funcionario funcionario)
        {
            listaRegistros.Add(funcionario);
        }

        public void ExcluirFuncionario(string nome)
        {
            Funcionario funcionario = ConsultarFuncionario(nome);
            if (funcionario != null)
            {
                listaRegistros.Remove(funcionario);
            }
        }

        public void EditarFuncionario(string nome, string cpf, string telefone, string endereco, string novoNome)
        {
            Funcionario funcionario = ConsultarFuncionario(nome);
            if (funcionario != null)
            {
                funcionario.Nome = novoNome;
                funcionario.CPF = cpf;
                funcionario.Telefone = telefone;
                funcionario.Endereco = endereco;
            }
        }


        public Funcionario ConsultarFuncionario(string nome)
        {
            foreach (Funcionario funcionario in listaRegistros)
            {
                if (funcionario.Nome == nome)
                {
                    return funcionario;
                }
            }
            return null;
        }
        public bool VerificarExistenciaFuncionario(string nome)
        {
            Funcionario funcionario = ConsultarFuncionario(nome);
            if (funcionario != null)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Funcionário com nome {nome} não encontrado.");
                return false;
            }
        }


    }
}
