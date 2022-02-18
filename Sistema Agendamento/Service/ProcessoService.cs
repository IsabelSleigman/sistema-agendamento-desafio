using Sistema_Agendamento.Data;
using Sistema_Agendamento.Entidades;
using Sistema_Agendamento.Enum;
using System;
using System.Linq;

namespace Sistema_Agendamento.Service
{
    public static class ProcessoService
    {
        public static ClienteRepository clienteRepository = new ClienteRepository();
        public static ProcessoRepository processoRepository = new ProcessoRepository(clienteRepository);

        public static void Listar()
        {
            Console.WriteLine();
            Console.WriteLine("Processos\n");

            var lista = processoRepository.Listar();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma processo Cadastrado.");
            }
            else
            {
                foreach (var processo in lista)
                {
                    Console.WriteLine(processo.ToString());
                }
            }
        }
        public static void NovoProcesso()
        {
            Console.WriteLine("\nNovo Processo\n");

            Console.Write("Digite o id do Cliente: ");

            int clienteId = int.Parse(Console.ReadLine());

            while (!(clienteRepository.VerificarClienteId(clienteId)))
            {
                Console.Write("Cliente não  encontrado, digite novamente o id do Cliente: ");

                clienteId = int.Parse(Console.ReadLine());
            }

            var cliente = clienteRepository.RetornaPorId(clienteId);

            Console.Clear();

            Console.WriteLine("Cliente: " + cliente.ToString());

            Console.Write("\nNúmero do Processo: ");

            string numeroProcesso = Console.ReadLine();

            Console.Clear();

            foreach (int i in EstadosEnum.GetValues(typeof(EstadosEnum)))
            {
                Console.WriteLine("{0}-{1}", i, EstadosEnum.GetName(typeof(EstadosEnum), i));
            }

            Console.Write("Digite o estado entre as opções acima: ");

            int estadoProcesso = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.Write("Valor do Processo: ");

            double valorProcesso = double.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Data de Inicio: \n");

            var dataInicio = NovaDataValida();

            var processo = new Processo
            {
                ClienteId = cliente.ClienteId,
                NomeCliente = cliente.Nome,
                EstadoProcessoEnum = (EstadosEnum)estadoProcesso,
                NumeroProcesso = numeroProcesso,
                ProcessoId = ClienteRepository.contadorProcesso += 1,
                Status = StatusProcessoEnum.Ativo,
                DataInicio = dataInicio,
                Excluido = false,
                Valor = valorProcesso
            };

            Console.WriteLine(processo.ToString());
            Console.WriteLine("Processo criado, Deseja salvar processo? (S/n)\n");
            Console.WriteLine();

            var opcaoUsuario = Console.ReadLine().ToUpper();

            Console.Clear();

            if (opcaoUsuario == "S")
            {
                processoRepository.Criar(processo);

                Console.Write("Processo salvo com sucesso, aperte enter para continuar");
                Console.ReadLine();
                Console.Clear();
            }

            Console.Clear();
        }
        public static void EditarProcesso()
        {
            Console.Write("\nDigite o id do Processo: ");

            int processoId = int.Parse(Console.ReadLine());

            while (!(processoRepository.VerificarProcessoId(processoId)))
            {
                Console.Write("Processo não encontrado, digite novamente o Id do Processo: ");

                processoId = int.Parse(Console.ReadLine());
            };

            var processo = processoRepository.RetornaPorId(processoId);

            Console.Clear();

            Console.WriteLine(processo.ToString());
            Console.WriteLine("Deseja realmente editar esse Processo? (S/n)\n");
            Console.WriteLine();

            var opcaoUsuario = Console.ReadLine().ToUpper();

            if (opcaoUsuario == "S")
            {
                Console.Write("Digite o número do processo: ");

                string numeroProcesso = Console.ReadLine();
           
                foreach (int i in EstadosEnum.GetValues(typeof(EstadosEnum)))
                {
                    Console.WriteLine("{0}-{1}", i, EstadosEnum.GetName(typeof(EstadosEnum), i));
                };

                Console.Write("Digite o estado entre as opções acima: ");

                int estadoprocesso = int.Parse(Console.ReadLine());

                Console.Clear();

                Console.Write("Valor do Processo: ");

                double valorProcesso = double.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Data de Inicio: \n");

                var dataInicio = NovaDataValida();

                var processoEditado = new Processo
                {
                    ClienteId = processo.ClienteId,
                    NomeCliente = processo.NomeCliente,
                    EstadoProcessoEnum = (EstadosEnum)estadoprocesso,
                    NumeroProcesso = numeroProcesso,
                    ProcessoId = ClienteRepository.contadorProcesso += 1,
                    Status = StatusProcessoEnum.Ativo,
                    DataInicio = dataInicio,
                    Excluido = false,
                    Valor = valorProcesso
                };

                Console.Clear();

                processoRepository.Editar(processoEditado);

                Console.WriteLine("Processo Editado com sucesso, aperte enter para continuar");
                Console.ReadLine();
                Console.Clear();
            }
        }
        public static void ExcluirProcesso()
        {
            Console.Write("\nDigite o id do Processo: ");

            int processoId = int.Parse(Console.ReadLine());

            while (!(processoRepository.VerificarProcessoId(processoId)))
            {
                Console.Write("Processo não encontrado, digite novamente o Id do Processo: ");

                processoId = int.Parse(Console.ReadLine());
            };

            var processo = processoRepository.RetornaPorId(processoId);

            Console.Clear();

            Console.WriteLine(processo.ToString());
            Console.WriteLine("Deseja Realmente excluir esse Processo? (S/n)\n");
            Console.WriteLine();

            var opcaoUsuario = Console.ReadLine().ToUpper();

            if (opcaoUsuario == "S")
            {
                processoRepository.Excluir(processoId);

                Console.WriteLine("Processo excluido com sucesso, aperte enter para continuar");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public static void SomaProcessosAtivos()
        {
            var total = processoRepository.CalcularSomaAtivos();

            Console.WriteLine("A soma total dos processo ativos é: \n");

            Console.Write("R$ " + total);

            Console.WriteLine("\n\nAperte enter para voltar ao menu");

            Console.ReadLine();

        }

        public static void CalcularMediaPorEstado()
        {
            Console.Write("\nDigite o id do Cliente que deseja calcular: ");

            int clienteId = int.Parse(Console.ReadLine());

            while (!(clienteRepository.VerificarClienteId(clienteId)))
            {
                Console.Write("Cliente não  encontrado, digite novamente o id do Cliente: ");

                clienteId = int.Parse(Console.ReadLine());
            };

            var cliente = clienteRepository.RetornaPorId(clienteId);

            Console.Clear();

            foreach (int i in EstadosEnum.GetValues(typeof(EstadosEnum)))
            {
                Console.WriteLine("{0}-{1}", i, EstadosEnum.GetName(typeof(EstadosEnum), i));
            };

            Console.Write("Digite o estado entre as opções acima que deseja calcular: ");

            int estadoprocesso = int.Parse(Console.ReadLine());

            Console.Clear();

            var total = processoRepository.CalcularMediaPorEstado((Enum.EstadosEnum)estadoprocesso, cliente.ClienteId);

            if(total == 0)
            {
                Console.WriteLine(cliente.ToString());

                Console.WriteLine($"Não possuiu processos no estado de {(Enum.EstadosEnum)estadoprocesso}! \n");

                Console.WriteLine("Aperte enter para voltar ao menu");

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(cliente.ToString());

                Console.WriteLine($"A Media total do estado de {(Enum.EstadosEnum)estadoprocesso} é : \n");

                Console.Write("R$ " + total);

                Console.WriteLine("\n\nAperte enter para voltar ao menu");

                Console.ReadLine();
            }

        }
        public static void ListarProcessoMesAno()
        {
            Console.Write("Digite o mês: ");

            var mes = int.Parse(Console.ReadLine());

            Console.WriteLine("");

            while (mes < 1 || mes > 12)
            {
                Console.Clear();

                Console.WriteLine("Mês Invalido: \n");

                Console.Write("Digite o Mês: ");

                mes = int.Parse(Console.ReadLine());

            };

            Console.WriteLine("Digite o ano: ");

            var ano = int.Parse(Console.ReadLine());

            Console.WriteLine("");

            DateTime dataDeHoje = DateTime.Now;

            while (ano < 1 || ano > dataDeHoje.Year)
            {
                Console.Clear();

                Console.WriteLine("Ano Invalido: \n");

                Console.Write("Digite o Ano: ");

                ano = int.Parse(Console.ReadLine());

            };

            Console.Clear();

            var numeroProcessos = processoRepository.ListarPorMesAno(mes, ano);

            if(numeroProcessos.Count > 0)
            {
                foreach (var item in numeroProcessos)
                {
                    Console.WriteLine("Processos");
                    Console.WriteLine("");
                    Console.Write($" / Número - {item} - / ");
                }
                Console.WriteLine("\n\nAperte enter para voltar ao menu");

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Nenhum Processo encontrado!");

                Console.WriteLine("\n\nAperte enter para voltar ao menu");

                Console.ReadLine();
            }

        }
        public static void ListarProcessoEstadoCliente()
        {
            var processos = processoRepository.ListarPorEstadoCliente();

            if (processos.Count > 0)
            {
                foreach (var item in processos)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Empresa - {item.NomeCliente}");
                    Console.WriteLine($"Número Processo: {item.NumeroProcesso}");
                }

                Console.WriteLine("\n\nAperte enter para voltar ao menu");

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Nenhum Processo encontrado!");

                Console.WriteLine("\n\nAperte enter para voltar ao menu");

                Console.ReadLine();
            }

        }
        private static DateTime NovaDataValida()
        {
            Console.Write("Digite o dia: ");

            var dia = int.Parse(Console.ReadLine());

            Console.WriteLine("");

            while (dia < 1 || dia > 31)
            {
                Console.Clear();

                Console.WriteLine("Dia Invalido: \n");

                Console.Write("Digite o dia: ");

                dia = int.Parse(Console.ReadLine());

            };

            Console.Write("Digite o mês: ");

            var mes = int.Parse(Console.ReadLine());

            Console.WriteLine("");

            while (mes < 1 || mes > 12)
            {
                Console.Clear();

                Console.WriteLine("Mês Invalido: \n");

                Console.Write("Digite o Mês: ");

                mes = int.Parse(Console.ReadLine());

            };

            Console.WriteLine("Digite o ano: ");

            var ano = int.Parse(Console.ReadLine());

            Console.WriteLine("");

            DateTime dataDeHoje = DateTime.Now;

            while (ano < 1 || ano > dataDeHoje.Year)
            {
                Console.Clear();

                Console.WriteLine("Ano Invalido: \n");

                Console.Write("Digite o Ano: ");

                ano = int.Parse(Console.ReadLine());

            };

            DateTime dataValida = new DateTime(dia, mes, ano);

            return dataValida;
        }
    }
}
