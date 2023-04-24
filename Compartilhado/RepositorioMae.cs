using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloPaciente;
using System.Collections;

namespace ControleDeMedicamentos.Compartilhado
{
    class RepositorioMae
    {
        public ArrayList listaRegistros = new ArrayList();
        public RepositorioPaciente repositorioPaciente;
        public RepositorioRemedio repositorioRemedio;
        public RepositorioFuncionario repositorioFuncionario;
        public RepositorioFornecedor repositorioFornecedor;

    }
}