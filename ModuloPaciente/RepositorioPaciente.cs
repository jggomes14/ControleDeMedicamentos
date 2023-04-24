using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloMedicamento;

namespace ControleDeMedicamentos.ModuloPaciente
{
    class RepositorioPaciente : RepositorioMae
    {
        public void Inserir(Paciente paciente)
        {
            listaRegistros.Add(paciente);
        }

        public void ExcluirPaciente(string nome)
        {
            Paciente paciente = ConsultarPaciente(nome);
            if (paciente != null)
            {
                listaRegistros.Remove(paciente);
            }
        }

        public void EditarPaciente(string nome, string cpf, string cartaoDoSUS, string telefone, string endereco)
        {
            Paciente paciente = ConsultarPaciente(nome);
            if (paciente != null)
            {
                paciente.CPF = cpf;
                paciente.CartaoDoSUS = cartaoDoSUS;
                paciente.Telefone = telefone;
                paciente.Endereco = endereco;
            }
        }

        public Paciente ConsultarPaciente(string nome)
        {
            foreach (Paciente paciente in listaRegistros)
            {
                if (paciente.Nome == nome)
                {
                    return paciente;
                }
            }
            return null;
        }

        public void ListarPacientes()
        {
            foreach (Paciente paciente in listaRegistros)
            {
                Console.WriteLine($"Nome: {paciente.Nome} | CPF: {paciente.CPF} | Cartão do SUS: {paciente.CartaoDoSUS} | Telefone: {paciente.Telefone} | Endereço: {paciente.Endereco}");
            }
        }
        public bool VerificarExistenciaPaciente(string nome)
        {
            Paciente paciente = ConsultarPaciente(nome);
            if (paciente != null)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"O paciente {nome} não existe.");
                return false;
            }
        }


    }
}