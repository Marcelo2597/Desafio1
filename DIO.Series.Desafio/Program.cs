using System;

namespace DIO.Series.Desafio
{
    class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadasrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
            
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornoTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Lançamento da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(ClassificacaoIndicativa)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(ClassificacaoIndicativa), i));
            }
            Console.WriteLine("Digite a Classificação Etária: ");
            int entradaClassificacao = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        classificacao: (ClassificacaoIndicativa)entradaClassificacao,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Lançamento da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(ClassificacaoIndicativa)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(ClassificacaoIndicativa), i));
            }
            Console.WriteLine("Digite a Classificação Etária: ");
            int entradaClassificacao = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        classificacao: (ClassificacaoIndicativa)entradaClassificacao,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }   

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("Série excluída");

            repositorio.Exclui(indiceSerie);
        }   

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Lista séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
