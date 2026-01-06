using System.Text.Json;
using Models;
using Filtros;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        Console.WriteLine(resposta);
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta);
        Console.WriteLine(musicas.Count);
        musicas[0].ExibirDetalhes();
        musicas[1998].ExibirDetalhes();
        //  LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //  LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        //  LinqFilter.FiltrarArtistaPorGeneroMusical(musicas, "rock");
        LinqFilter.FiltrarMusicasDeUmArtista(musicas, "Michel Teló");

        var musicasPreferidasDoDaniel = new MusicasPreferidas("Daniel");
        musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[0]);
        musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[35]);
        musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[126]);
        musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[570]);
        musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[1930]);

        var musicasPreferidasEmilly = new MusicasPreferidas("Emy");

        musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[500]);
        musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[637]);
        musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[428]);
        musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[13]);
        musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[71]);

        musicasPreferidasEmilly.ExibirMusicasFavoritas();

        musicasPreferidasDoDaniel.ExibirMusicasFavoritas();

        musicasPreferidasEmilly.GerarArquivoJson();

        Console.ReadKey();
    }
    catch (Exception ex)
    {
               Console.WriteLine("Ocorreu um erro: " + ex.Message);
    }
}