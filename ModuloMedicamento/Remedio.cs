using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloFornecedor;

namespace ControleDeMedicamentos.ModuloMedicamento
{
    public class Remedio:EntidadeMae
    {
       
     public string descricao { get; set; }
     public int quantidadeDeRemedio { get; set; }
     public int quantidadeLimite { get; set; }
     public Fornecedor fornecedor { get; set; }
    }
}
