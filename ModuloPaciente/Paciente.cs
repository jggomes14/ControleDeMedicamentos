using ControleDeMedicamentos.Compartilhado;

namespace ControleDeMedicamentos.ModuloPaciente
{
    class Paciente:EntidadeMae
    {
         public string CPF { get; set; }
         public string CartaoDoSUS { get; set; }
         public string Telefone { get; set; }
         public string Endereco { get; set; }
    }
}