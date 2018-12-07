using System;
using Bogus;
using Dominio.Entities;

namespace meuapp.unitTests.Builders
{
    public class AtividadeBuilder
    {
        private string Titulo;
        private string Descricao;
        private TipoAtividade Tipo;
        private DateTime Data;
        private int Id;
        private bool Concluida;

        public static AtividadeBuilder Novo()
        {
            var faker = new Faker();

            var dataMinima = new DateTime(2018, 11, 24);
            var dataMaxima = new DateTime(2018, 11, 29);
            return new AtividadeBuilder
            {
                Id = 0,
                Titulo = faker.Name.JobTitle(),
                Descricao = faker.Hacker.Phrase(),
                Tipo = faker.Random.Enum<TipoAtividade>(),
                Concluida = false,
                Data = faker.Date.Between(dataMinima, dataMaxima)
            };

        }

        public AtividadeBuilder ComTitulo(string titulo)
        {
            Titulo = titulo;
            return this;
        }

        public AtividadeBuilder ComDescricao(string descricao)
        {
            Descricao = descricao;
            return this;
        }

        public AtividadeBuilder ComTipoAtividade(TipoAtividade tipo)
        {
            Tipo = tipo;
            return this;
        }

        public AtividadeBuilder ComData(DateTime data)
        {
            Data = data;
            return this;
        }

        public AtividadeBuilder ComId(int id)
        {
            Id = id;
            return this;
        }
        public AtividadeBuilder JaConcluida(bool concluida)
        {
            if (concluida)
                Descricao = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's";

            Concluida = concluida;
            return this;
        }

        public Atividade Build()
        {
            var atividade = new Atividade(Titulo, Descricao, Tipo, Data);

            if (Concluida)
                atividade.Concluir();

            if (atividade.Id < 0) return atividade;

            var propertyInfo = atividade.GetType().GetProperty("Id");
            propertyInfo.SetValue(atividade, Convert.ChangeType(Id, propertyInfo.PropertyType), null);

            return atividade;
        }


    }
}