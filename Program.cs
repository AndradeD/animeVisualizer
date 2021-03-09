using System;
using System.Collections.Generic;
using Animes.Classes;

namespace Animes
{
    class Program
    {
        static AnimeRepository animeRepository = new AnimeRepository();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();
            
            while (opcaoUsuario != "X") {
                switch(opcaoUsuario) {
                    case "1":
                        ListarAnimes();
                        break;
                    case "2":
                        InserirAnime();
                        break;
                    case "3":
                        AtualizarAnime();
                        break;
                    case "4":
                        ExcluirAnime();
                        break;
                    case "5":
                        VisualizarAnime();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new Exception();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarAnime()
        {
            Console.WriteLine("Selecione o anime que deseja visualizar pelo Id:");
            List<Anime> listaAnimes = animeRepository.ReturnAll();
            foreach(Anime anime in listaAnimes) {
                Console.WriteLine ("ID: {0} - Anime: {1}", anime.Id, anime.Titulo);
            }
            int idChosen = int.Parse(Console.ReadLine());

            Anime animeChosen = animeRepository.GetByID(idChosen);
            Console.WriteLine("Info Anime:");
            Console.WriteLine(animeChosen.ToString());
        }

        private static void ExcluirAnime()
        {
            Console.WriteLine("Selecione o anime que deseja excluir pelo Id:");
            List<Anime> listaAnimes = animeRepository.ReturnAll();
            foreach(Anime anime in listaAnimes) {
                Console.WriteLine ("ID: {0} - Anime: {1}", anime.Id, anime.Titulo);
            }
            int idChosen = int.Parse(Console.ReadLine());

            animeRepository.Delete(idChosen);
        }

        private static void AtualizarAnime()
        {
            Console.WriteLine("Selecione o anime que deseja atualizar pelo Id:");
            List<Anime> listaAnimes = animeRepository.ReturnAll();
            foreach(Anime anime in listaAnimes) {
                Console.WriteLine ("ID: {0} - Anime: {1}", anime.Id, anime.Titulo);
            }
            int idChosen = int.Parse(Console.ReadLine());
            Anime animeChosen = animeRepository.GetByID(idChosen);

            string tituloAnime = "", descricaoAnime = "";
            int anoAnime = 0, generoSelected = 0;

            string opcaoUpdate = ObterOpcaoUpdateAnime();

            while (opcaoUpdate != "X") {
                switch(opcaoUpdate) {
                    case "1":
                        Console.WriteLine("Novo Titulo:");
                        tituloAnime = Console.ReadLine();
                        break;
                    case "2":
                        foreach (int i in Enum.GetValues(typeof(Genero))) {
                            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                        }
                        Console.WriteLine("Selecione o número correspondente ao gênero:");
                        generoSelected = int.Parse(Console.ReadLine());
                        break;
                    case "3":
                        Console.WriteLine("Nova Descrição:");
                        descricaoAnime = Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Novo Ano:");
                        anoAnime = int.Parse(Console.ReadLine());
                        break;
                    default:
                        throw new Exception();
                }
                opcaoUpdate = ObterOpcaoUpdateAnime();
            }
            Anime updateAnime = new Anime(idChosen,
            generoSelected == 0 ? animeChosen.Genero : (Genero)generoSelected,
            tituloAnime == null ? animeChosen.Titulo : tituloAnime, 
            descricaoAnime == null ? animeChosen.Descricao : descricaoAnime, 
            anoAnime == 0 ? animeChosen.Ano : anoAnime);

            animeRepository.Update(idChosen, updateAnime);
        }

        private static void ListarAnimes() {

            List<Anime> lista = animeRepository.ReturnAll();
            if (lista.Count == 0) {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach(Anime anime in lista) {
                Console.WriteLine($"#Id: {anime.Id} # Anime: {anime.Titulo}");
            }
            
        }

        private static void InserirAnime() {
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero))) {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Selecione o número correspondente ao gênero:");
            int generoSelected = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o título do Anime:");
            string tituloAnime = Console.ReadLine();
            Console.WriteLine("Digite o ano de início do Anime:");
            int anoAnime = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição do anime:");
            string descricaoAnime = Console.ReadLine();

            Anime novoAnime = new Anime(animeRepository.NextId(),
            (Genero)generoSelected, tituloAnime, descricaoAnime, anoAnime);

            animeRepository.Insert(novoAnime);
        }

        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("Banco de Animes");
            Console.WriteLine("Informe a opção:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar animes");
            Console.WriteLine("2 - Inserir anime");
            Console.WriteLine("3 - Atualizar anime");
            Console.WriteLine("4 - Excluir anime");
            Console.WriteLine("5 - Visualizar anime");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static string ObterOpcaoUpdateAnime() {
            Console.WriteLine();
            Console.WriteLine("Update Anime");
            Console.WriteLine("Informe a opção:");
            Console.WriteLine();
            Console.WriteLine("1 - Atualizar Titulo");
            Console.WriteLine("2 - Atualizar Genero");
            Console.WriteLine("3 - Atualizar Descrição");
            Console.WriteLine("4 - Atualizar Ano");
            Console.WriteLine("X - Salvar");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
