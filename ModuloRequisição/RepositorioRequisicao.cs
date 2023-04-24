using ControleDeMedicamentos.Compartilhado;
using ControleDeMedicamentos.ModuloFornecedor;
using ControleDeMedicamentos.ModuloFuncionario;
using ControleDeMedicamentos.ModuloMedicamento;
using ControleDeMedicamentos.ModuloPaciente;
using ControleDeMedicamentos.ModuloRequisição;
using System;
using System.Collections;

namespace ControleDeMedicamentos.ModuloRequisicao
{
     class RepositorioRequisicao : RepositorioMae
    {
        
        public RepositorioRequisicao()
        {
            repositorioPaciente = new RepositorioPaciente();
            repositorioRemedio = new RepositorioRemedio();
            repositorioFuncionario = new RepositorioFuncionario();
        }
        public bool VerificarPreRequisitosRequisicao(Paciente paciente, Remedio remedio, Funcionario funcionario)
        {
            // Verifica se o fornecedor está cadastrado
            if (!repositorioFornecedor.VerificarExistenciaFornecedor(paciente.Nome))
            {
                Console.WriteLine($"Erro: o fornecedor {paciente.Nome} não está cadastrado.");
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

        public void CriarRequisicao(Paciente paciente, Remedio remedio, int quantidadeSolicitada, Funcionario funcionario, string nome)
        {
            if (VerificarPreRequisitosRequisicao(paciente, remedio, funcionario))
            {
                // Atualiza a quantidade existente de remédios
                remedio.quantidadeDeRemedio -= quantidadeSolicitada;

                // Cria uma nova requisição
                Requisicao novaRequisicao = new Requisicao();
                novaRequisicao.paciente = paciente;
                novaRequisicao.remedio = remedio;
                novaRequisicao.funcionario = funcionario;
                novaRequisicao.dataDeRequisicao = DateTime.Now.ToString("dd/MM/yyyy");
                novaRequisicao.quantidadeDeRemedioSolicitada = quantidadeSolicitada;

                // Adiciona a nova requisição à lista de registros
                listaRegistros.Add(novaRequisicao);

                Console.WriteLine($"Requisição de {quantidadeSolicitada} unidades de {remedio.Nome} criada com sucesso para o paciente {paciente.Nome}.");
            }
        }



        public void ExcluirRequisicao(string dataDeRequisicao)
        {
            Requisicao requisicao = ConsultarRequisicao(dataDeRequisicao);
            if (requisicao != null)
            {
                listaRegistros.Remove(requisicao);
            }
        }

        public void EditarRequisicao(string dataDeRequisicao, Paciente novoPaciente, Remedio novoRemedio, int novaQuantidade, Funcionario novoFuncionario)
        {
            Requisicao requisicao = ConsultarRequisicao(dataDeRequisicao);
            if (requisicao != null)
            {
                requisicao.paciente = novoPaciente;
                requisicao.remedio = novoRemedio;
                requisicao.quantidadeDeRemedioSolicitada = novaQuantidade;
                requisicao.funcionario = novoFuncionario;
            }
        }


        public Requisicao ConsultarRequisicao(string dataDeRequisicao)
        {
            foreach (Requisicao requisicao in listaRegistros)
            {
                if (requisicao.dataDeRequisicao == dataDeRequisicao)
                {
                    return requisicao;
                }
            }
            return null;
        }

        public void ListarRequisicoes()
        {
            Console.WriteLine("==== LISTAGEM DE TODAS AS REQUISIÇÕES ====");
            if (listaRegistros.Count == 0)
            {
                Console.WriteLine("Nenhuma requisição encontrada.");
            }
            else
            {
                Console.WriteLine("Paciente\t\tRemédio\t\tData de requisição\tQuantidade solicitada\tFuncionário responsável");
                foreach (Requisicao requisicao in listaRegistros)
                {
                    Console.WriteLine($"{requisicao.paciente.Nome}\t\t{requisicao.remedio.Nome}\t\t{requisicao.dataDeRequisicao}\t\t{requisicao.quantidadeDeRemedioSolicitada}\t\t{requisicao.funcionario.Nome}");
                }
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void ListarRequisicoesPorPaciente(string nomePaciente)
        {
            Paciente paciente = repositorioPaciente.ConsultarPaciente(nomePaciente);
            if (paciente != null)
            {
                ArrayList requisicoesPorPaciente = new ArrayList();
                foreach (Requisicao requisicao in listaRegistros)
                {
                    if (requisicao.paciente.Equals(paciente))
                    {
                        requisicoesPorPaciente.Add(requisicao);
                    }
                }
                if (requisicoesPorPaciente.Count > 0)
                {
                    Console.WriteLine($"Requisições do Paciente {nomePaciente}:");
                    foreach (Requisicao requisicao in requisicoesPorPaciente)
                    {
                        Console.WriteLine($"ID: {requisicao.id} | Remédio: {requisicao.remedio.Nome} | Data da Requisição: {requisicao.dataDeRequisicao} | Quantidade Solicitada: {requisicao.quantidadeDeRemedioSolicitada}");
                    }
                }
                else
                {
                    Console.WriteLine($"O paciente {nomePaciente} não tem nenhuma requisição.");
                }
            }
            else
            {
                Console.WriteLine($"O paciente {nomePaciente} não foi encontrado.");
            }
        }

    }
}
