# Alura-Linq: Explorando Músicas com C#

Este projeto é uma aplicação de console em C# desenvolvida para explorar o uso do **LINQ (Language Integrated Query)** e a manipulação de arquivos JSON. O sistema consome uma API externa de músicas, filtra os dados, organiza listas de artistas e permite que o usuário crie sua própria lista de favoritos, exportando-a para um arquivo físico.

## 🚀 O que é o LINQ?

O **LINQ** é uma funcionalidade poderosa do C# que permite realizar consultas em coleções de dados (como listas) de forma declarativa. Em vez de escrever loops `foreach` complexos com várias condições `if`, usamos o LINQ para dizer **o que** queremos obter, e não **como** o computador deve fazer isso passo a passo.

### A Analogia da "Linha de Produção"

No arquivo `LinqOrder.cs`, o código utiliza o conceito de **Encadeamento**. Imagine uma esteira de produção em uma fábrica:

1. **Entrada:** Uma lista bruta com milhares de músicas.
2. **OrderBy (O Organizador):** Coloca as músicas em ordem alfabética pelo nome do artista.
3. **Select (O Selecionador):** Atua como uma "pinça" que remove as informações desnecessárias (gênero, duração) e deixa passar apenas o nome do artista.
4. **Distinct (O Filtro):** Remove duplicatas. Se um artista aparece 10 vezes, ele deixa apenas uma instância.
5. **ToList (O Empacotador):** Pega o resultado final da esteira e coloca em uma nova lista pronta para o uso.

### A Arrow Function (`=>`)

Você verá em várias partes do código (como em `musica => musica.Artista`) o uso do operador `=>`. Isso é chamado de **Expressão Lambda**.

* Ela funciona como uma "função de seta" anônima.
* No LINQ, ela serve como um parâmetro que diz: "Para cada item (musica) que passar por aqui, execute esta ação ou acesse este campo (Artista)".

---

## 📂 Serialização e Desserialização

O projeto lida com a conversão de dados entre objetos C# e o formato JSON (texto), essencial para comunicação na web.

### 1. Desserialização (JSON para Objeto)

No `Program.cs`, o programa baixa uma string gigante de texto da API. Para que o C# entenda que aquilo são músicas, usamos o `JsonSerializer.Deserialize`.

* **O que faz:** Transforma o texto bruto (`string`) em uma lista de objetos do tipo `Musica` que o C# consegue manipular.

### 2. Serialização (Objeto para JSON)

No arquivo `MusicasPreferidas.cs`, existe o método `GerarArquivoJson()`.

* **O que faz:** Pega o objeto `MusicasPreferidas` (com o nome do usuário e sua lista de músicas) e o transforma novamente em um texto formatado em JSON.
* **Resultado:** O método `File.WriteAllText` salva esse texto em um arquivo `.json` no seu computador, permitindo que os dados sejam salvos permanentemente.

---

## 🛠️ Tecnologias Utilizadas

* **C# / .NET 10**
* **HttpClient:** Para requisições HTTP.
* **System.Text.Json:** Para manipulação de arquivos JSON.
* **LINQ:** Para filtragem e ordenação de dados.

## 📝 Como executar

1. Clone o repositório.
2. Certifique-se de ter o SDK do .NET instalado.
3. Execute o comando:
```bash
dotnet run

```



O programa exibirá detalhes de músicas no console e gerará um arquivo chamado `Emy_musicas_favoritas.json` com os dados selecionados.
