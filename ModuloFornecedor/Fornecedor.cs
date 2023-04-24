using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloMedicamento;

namespace ControleDeMedicamentos.ModuloFornecedor
{
   public class Fornecedor : EntidadeMae
    {
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public string Endereco { get; set; }

        public Remedio remedio { get; set; }

    }
}