using ControleDeMedicamentos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloFuncionario
{
    internal class Funcionario:EntidadeMae
    {
       public string CPF { get; set; }
       public string Telefone { get; set; }
       public string Endereco { get; set; }
    }
}
