using ControleDeMedicamentos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloMedicamento
{
    internal class RepositorioRemedio : RepositorioMae
    {
        public void Inserir(Remedio remedio)
        {
            listaRegistros.Add(remedio);
        }

        public int Contador(string nomeRemedio)
        {
            int contador = 0;

            foreach (Remedio remedio in listaRegistros)
            {
                if (remedio.Nome == nomeRemedio)
                {
                    contador++;
                }
            }

            return contador;
        }
        public Remedio ConsultarRemedio(string nome)
        {
            foreach (Remedio remedio in listaRegistros)
            {
                if (remedio.Nome == nome)
                {
                    return remedio;
                }
            }
            return null;
        }

        public void AtualizarQuantidadeDeRemedio(string nome, int novaQuantidade)
        {
            Remedio remedio = ConsultarRemedio(nome);
            if (remedio != null)
            {
                remedio.quantidadeDeRemedio = novaQuantidade;
            }
        }
        public void VisualizarRemediosAbaixoDoLimite()
        {
            foreach (Remedio remedio in listaRegistros)
            {
                if (remedio.quantidadeDeRemedio < remedio.quantidadeLimite)
                {
                    Console.WriteLine($"O remédio {remedio.Nome} está abaixo do limite de quantidade. Quantidade atual: {remedio.quantidadeDeRemedio}. Quantidade limite: {remedio.quantidadeLimite}");
                }
            }
        }

        public void EditarRemedio(string nome, string novoNome, string novaDescricao, int novaQuantidade, int novaQuantidadeLimite)
        {
            Remedio remedio = ConsultarRemedio(nome);
            if (remedio != null)
            {
                remedio.Nome = novoNome;
                remedio.descricao = novaDescricao;
                remedio.quantidadeDeRemedio = novaQuantidade;
                remedio.quantidadeLimite = novaQuantidadeLimite;
            }
        }
        public void ExcluirRemedio(string nome)
        {
            Remedio remedio = ConsultarRemedio(nome);
            if (remedio != null)
            {
                listaRegistros.Remove(remedio);
            }
        }
        public bool VerificarExistenciaRemedio(string nome)
        {
            Remedio remedio = ConsultarRemedio(nome);
            if (remedio != null)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"O remédio {nome} não existe na lista.");
                return false;
            }
        }




    }

}
