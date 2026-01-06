namespace Filtros;
using Models;

internal class LinqOrder
{
    public static void ExibirListaDeArtistasOrdenados(List<Musica> musicas)
    {
        var ArtistasOrdenados = musicas
            // => É SÓ UM FOREACH COMO PARÂMETRO!
            // Se você fosse usar um foreach, precisaria de uma boneca russa de código e várias listas.
            // Aqui, tudo é feito em cadeia, como uma esteira de produção.
            // Chamados esse conceito de ENCADEAMENTO.

            // 2. O ORGANIZADOR: Pega a fila de músicas e coloca em ordem (A-Z) 
            // baseada no Artista. Imagine que ele troca os CDs de lugar na caixa.
            // [musica =>] "Para cada música que eu segurar..."
            // [musica.Artista] "...use o nome do artista como critério de ordem."
            .OrderBy(musica => musica.Artista)

            // 3. O SELECIONADOR: Agora que está ordenado, ele passa a "pinça".
            // Ele joga fora o Nome, o Gênero e a Duração. 
            // Só deixa passar o texto com o nome do Artista.
            .Select(musica => musica.Artista)

            // 4. O FILTRO DE REPETIÇÃO: Se o "Artista X" tem 10 músicas, 
            // ele apareceu 10 vezes no Select. O Distinct apaga 9 e deixa só 1.
            .Distinct()

            // 5. O EMPACOTADOR: Pega esses nomes soltos que sobraram e 
            // coloca dentro de uma lista definitiva (o balde final).
            .ToList();

            foreach (var artista in ArtistasOrdenados)
            {
                Console.WriteLine($" - {artista}");
            }
    }
}