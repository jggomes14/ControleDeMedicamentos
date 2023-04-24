using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloAquisição
{
    internal class Aquisicao
    {
      public Fornecedor fornecedor { get; set; }
      public Remedio remedio { get; set; }
      public Funcionario funcionario { get; set; }
      public string dataDeSolicitacao { get; set; }
      public int quantidadeDeReposicao { get; set; }
        
    }
}
