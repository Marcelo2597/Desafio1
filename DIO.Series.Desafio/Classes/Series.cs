namespace DIO.Series.Desafio
{
    public class Series : EntidadeBase
    {
        private Genero Genero {get; set; }
        private string Titulo {get; set; }
        private string Descricao {get; set;}
        private int Ano {get; set; }
        private bool Excluido {get; set; }
        private ClassificacaoIndicativa Classificacao {get; set; }

        public Series(int id, Genero genero, string titulo, string descricao, int ano, ClassificacaoIndicativa classificacao)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Classificacao = classificacao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero " + this.Genero + "\n";
            retorno += "Título " + this.Titulo + "\n";
            retorno += "Descrição: " + this.Descricao + "\n";
            retorno += "Ano de Lançamento: " + this.Ano + "\n";
            retorno += "Classificação Etária" + this.Classificacao + "\n";
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornoTitulo()
        {
            return this.Titulo;
        }
        
        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        
        public void Excluir()
        {
            this.Excluido = true;
        }
    }


}