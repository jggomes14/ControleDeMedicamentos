using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.ModuloAquisição
{
    internal class RepositorioAquisicao : RepositorioMae
    {
        public bool VerificarPreRequisitosAquisicao(Fornecedor fornecedor, Remedio remedio, Funcionario funcionario)
        {
            // Verifica se o fornecedor está cadastrado
            if (!repositorioFornecedor.VerificarExistenciaFornecedor(fornecedor.Nome))
            {
                Console.WriteLine($"Erro: o fornecedor {fornecedor.Nome} não está cadastrado.");
                return false;
            }

            // Verifica se o remédio está cadastrado
            if (!repositorioRemedio.VerificarExistenciaRemedio(remedio.Nome))
            {
                Console.WriteLine($"Erro: o remédio {remedio.Nome} não está cadastrado.");
                return false;
            }

            // Verifica se o funcionário está cadastrado
            if (!repositorioFuncionario.VerificarExistenciaFuncionario(funcionario.Nome))
            {
                Console.WriteLine($"Erro: o funcionário {funcionario.Nome} não está cadastrado.");
                return false;
            }

            return true;
        }
        public void CriarAquisicao(Fornecedor fornecedor, Remedio remedio, Funcionario funcionario, int quantidadeDeReposicao)
        {
            if (!VerificarPreRequisitosAquisicao(fornecedor, remedio, funcionario))
            {
                return;
            }

            // Atualiza a quantidade existente de remédios
            remedio.quantidadeDeRemedio += quantidadeDeReposicao;

            // Cria uma nova aquisição
            Aquisicao novaAquisicao = new Aquisicao();
            novaAquisicao.fornecedor = fornecedor;
            novaAquisicao.remedio = remedio;
            novaAquisicao.funcionario = funcionario;
            novaAquisicao.dataDeSolicitacao = DateTime.Now.ToString("dd/MM/yyyy");
            novaAquisicao.quantidadeDeReposicao = quantidadeDeReposicao;

            // Adiciona a nova aquisição à lista de registros
            listaRegistros.Add(novaAquisicao);

            Console.WriteLine($"Aquisição de {quantidadeDeReposicao} unidades de {remedio.Nome} criada com sucesso do fornecedor {fornecedor.Nome}.");
        }



        public Aquisicao ConsultarAquisicao(string dataDeSolicitacao)
        {
            foreach (Aquisicao aquisicao in listaRegistros)
            {
                if (aquisicao.dataDeSolicitacao == dataDeSolicitacao)
                {
                    return aquisicao;
                }
            }
            return null;
        }

        public void ListarAquisicoes()
        {
            foreach (Aquisicao aquisicao in listaRegistros)
            {
                Console.WriteLine($"Fornecedor: {aquisicao.fornecedor.Nome} | Remédio: {aquisicao.remedio.Nome} | Funcionário: {aquisicao.funcionario.Nome} | Data de solicitação: {aquisicao.dataDeSolicitacao} | Quantidade de reposição: {aquisicao.quantidadeDeReposicao}");
            }
        }

        public void ExcluirAquisicao(string dataDeSolicitacao)
        {
            Aquisicao aquisicao = ConsultarAquisicao(dataDeSolicitacao);
            if (aquisicao != null)
            {
                listaRegistros.Remove(aquisicao);
                Console.WriteLine("Aquisição Removida!");
            }
        }

        public void EditarAquisicao(string dataDeSolicitacao, Fornecedor fornecedor, Remedio remedio, Funcionario funcionario, int novaQuantidadeDeReposicao)
        {
            Aquisicao aquisicao = ConsultarAquisicao(dataDeSolicitacao);
            if (aquisicao != null)
            {
                aquisicao.fornecedor = fornecedor;
                aquisicao.remedio = remedio;
                aquisicao.funcionario = funcionario;
                aquisicao.quantidadeDeReposicao = novaQuantidadeDeReposicao;
            }
        }
    }

}
