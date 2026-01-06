namespace Models;

public class MusicasPreferidas
{
	public string? Nome { get; set; }
	public List<Musica> listaDeMusicasFavoritas { get; }

	public MusicasPreferidas(string Nome)
	{
		this.Nome = Nome;
        listaDeMusicasFavoritas = new List<Musica>();
    }

	public void AdicionarMusicasFavoritas(Musica musica)
	{
		listaDeMusicasFavoritas.Add(musica);
    }

	public void ExibirMusicasFavoritas()
	{
		Console.WriteLine("Essas são as músicas favoritas:");
		foreach (var m in listaDeMusicasFavoritas)
		{
			Console.WriteLine($" - {m.Nome} | Artista: {m.Artista} | Gênero: {m.Genero}");
		}
		Console.WriteLine("");
    }

	public void GerarArquivoJson()
	{
		string json = System.Text.Json.JsonSerializer.Serialize(new
		{
			nome = Nome,
			musicas = listaDeMusicasFavoritas
		});
		string nomeDoArquivo = $"{Nome}_musicas_favoritas.json";
		File.WriteAllText(nomeDoArquivo, json);
		Console.WriteLine($"Arquivo {nomeDoArquivo} gerado com sucesso! {Path.GetFullPath(nomeDoArquivo)} ");
    }

}
