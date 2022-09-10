using System.Collections.Generic;
using FluentAssertions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC.Test.Serializers
{
    public class SerializersTest
    {
        [Fact]
        public void Dado_String_Quando_Serializar_Entao_Serializacao_EhStatisfeita()
        {
            var str = "testeSerializacao";
            var sut = Serializadores.Serializers.JsonSerialize(str);
            sut.Should().NotBeEmpty();
        }

        [Fact]
        public void Dado_Collection_Quando_Serializar_Entao_Serializacao_EhStatisfeita()
        {
            List<string> strList = new List<string>
                { "ListOne", "ListTwo" };
            var sut = Serializadores.Serializers.JsonSerialize(strList);
            sut.Should().NotBeEmpty();
        }
        
        [Fact]
        public void Dado_Objeto_Quando_Deserializar_Entao_Deserializacao_EhStatisfeita()
        {
            var excecoes = ExcecaoVagaFaker.Entidade.Generate();
            var serialize = Serializadores.Serializers.JsonSerialize(excecoes);
            var sut = Serializadores.Serializers.JsonDeserialize<ExcecaoVaga>(serialize);
            sut.Should().NotBeNull();
        }
    }
}