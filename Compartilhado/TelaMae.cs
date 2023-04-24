using ControleDeMedicamentos.ModuloAquisição;
using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloPaciente;
using ControleDeMedicamentos.ModuloRequisicao;

namespace ControleDeMedicamentos.Compartilhado
{
    class TelaMae
    {
        public RepositorioPaciente repositorioPaciente;
        public RepositorioRemedio repositorioRemedio;
        public RepositorioFuncionario repositorioFuncionario;
        public RepositorioFornecedor repositorioFornecedor;
        public RepositorioRequisicao repositorioRequisicao;
        public RepositorioAquisicao repositorioAquisicao;

    }
}