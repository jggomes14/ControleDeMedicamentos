using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloMedicamento;

namespace ControleDeMedicamentos.ModuloFornecedor
{
    class RepositorioFornecedor:RepositorioMae
    {
        public void Inserir(Fornecedor fornecedor)
        {
            listaRegistros.Add(fornecedor);
        }
        public Fornecedor ConsultarFornecedor(string nome)
        {
            foreach (Fornecedor fornecedor in listaRegistros)
            {
                if (fornecedor.Nome == nome)
                {
                    return fornecedor;
                }
            }
            return null;
        }
        public bool VerificarExistenciaFornecedor(string nome)
        {
            Fornecedor fornecedor = ConsultarFornecedor(nome);
            if (fornecedor != null)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"O fornecedor {nome} não existe.");
                return false;
            }
        }

        public void ExcluirFornecedor(string nome)
        {
            foreach (Fornecedor fornecedor in listaRegistros)
            {
                if (fornecedor.Nome == nome)
                {
                    listaRegistros.Remove(fornecedor);
                    return;
                }
            }
        }
        public void EditarFornecedor(string nomeAntigo, string novoNome, string cnpj, string telefone, string email, string endereco)
        {
            foreach (Fornecedor fornecedor in listaRegistros)
            {
                if (fornecedor.Nome == nomeAntigo)
                {
                    fornecedor.Nome = novoNome;
                    fornecedor.CNPJ = cnpj;
                    fornecedor.Telefone = telefone;
                    fornecedor.Email = email;
                    fornecedor.Endereco = endereco;
                    return;
                }
            }
        }



    }
}