using System;

namespace Animes
{
    public class Anime : EntidadeBase
    {
        public Genero Genero { get; init; }
        public string Titulo { get; init; }
        public string Descricao { get; init; }
        public int Ano { get; init; }

        public Anime(long id, Genero genero, string titulo, string descricao, int ano) {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
        }

        public override string ToString() {
            string retorno = "";
            retorno += "Genero: "+ this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descricao: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            return retorno;
        }
    }
}