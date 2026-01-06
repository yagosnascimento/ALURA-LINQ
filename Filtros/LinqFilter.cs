using Models;
namespace Filtros;

internal class LinqFilter
{
    public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
    {
        var todosOsGeneros = musicas.Select(musica => musica.Genero).Distinct().ToList();
        foreach (var genero in todosOsGeneros)
        {
            Console.WriteLine($" - {genero}");
        }
    }

    public static void FiltrarArtistaPorGeneroMusical(List<Musica> musicas, string genero)
    {
        var artistasPorGenero = musicas
            .Where(m => m.Genero.Contains(genero)) // 1. FILTRA: "O gênero dessa música tem o que eu quero?"
            .Select(m => m.Artista)               // 2. SELECIONA: "Dessa música que passou, me dê só o nome do Artista"
            .Distinct()                           // 3. LIMPA: "Tire os artistas repetidos"
            .ToList();                            // 4. GUARDA: "Coloca tudo na lista final"

        Console.WriteLine($"Exibindo os artistas do gênero: {genero}");

        foreach (var artista in artistasPorGenero)
        {
            // Aqui no WriteLine, usamos a variável 'artista' que criamos no foreach
            Console.WriteLine($" - Artista | {artista}");
        }
    }

    public static void FiltrarMusicasDeUmArtista(List<Musica> musicas, string nomeDoArtista)
    {
        var musicasDoArtistaFiltradas = musicas.Where(musica => musica.Artista!.Equals(nomeDoArtista)).ToList();
        Console.WriteLine(nomeDoArtista);
        foreach (var musica in musicasDoArtistaFiltradas)
        {
            Console.WriteLine($" - {musica.Nome}");
        }
    }


}
