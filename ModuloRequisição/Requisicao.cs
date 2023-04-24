using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloPaciente;
using ControleDeMedicamentos.ModuloMedicamento;

namespace ControleDeMedicamentos.ModuloRequisição
{
    class Requisicao
    {
       public int id { get; set; }
       public Paciente paciente {get;set;}
       public Remedio remedio { get;set;}
       public Funcionario funcionario { get;set;}
       public string dataDeRequisicao { get; set;}
       public Remedio quantidadeDeRemedio { get; set;}
       public int quantidadeDeRemedioSolicitada { get; set;}

       
        

    }
}