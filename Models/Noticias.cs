using System;
using System.Collections.Generic;
using System.IO;
using EPlayers.Interfaces;

namespace EPlayers.Models
{
    public class Noticias : EPlayersBase , INoticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/noticias.csv";

        public Noticias ()
        {
            CreateFolderAndFile(PATH);
        }

        /// <summary>
        /// Inserindo novas noticias
        /// </summary>
        /// <param name="n"></param>
        
        public void Create(Noticias n)
        {
            string [] linhas = { PrepararLinha(n)};
            File.AppendAllLines(PATH, linhas);
            
        }

        /// <summary>
        /// Preparando como os dados serão armazenados no arquivo Database
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        
        private string PrepararLinha(Noticias n)
        {
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }

        /// <summary>
        /// Remove noticia filtrando o argumento
        /// </summary>
        /// <param name="IdNoticia">codigo de identificação da noticia</param>

        public void Delete(int IdNoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(a => a.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        /// Lê todas as linhas do arquivo Database atraves da lista
        /// </summary>
        /// <returns></returns>

        public List<Noticias> ReadAll()
        {
            List<Noticias> news = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias noticia = new Noticias();
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                news.Add(noticia);
            }
            return news;
        }

        /// <summary>
        /// Altera a noticia, primeiro excluindo e depois reescreve 
        /// </summary>
        /// <param name="n"></param>
    
        public void Update(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(a => a.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add( PrepararLinha(n) );
            RewriteCSV(PATH, linhas);
        }
    }
}
