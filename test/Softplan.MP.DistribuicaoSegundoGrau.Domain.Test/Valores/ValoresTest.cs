using FluentAssertions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Test.Valores.Fakers;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Test.Valores
{
    public class ValoresTest
    {
        [Theory]
        [ClassData(typeof(EnumsData<Area>))]
        public void Test_Enum_Value_Area(Area area)
        {
            var sut = area.GetType();
            sut.Should().Be(typeof(Area));
        }
        
        [Theory]
        [ClassData(typeof(EnumsData<EscopoEquilibrio>))]
        public void Test_Enum_Value_EscopoEquilibrio(EscopoEquilibrio escopo)
        {
            var sut = escopo.GetType();
            sut.Should().Be(typeof(EscopoEquilibrio));
        }
        
        [Theory]
        [ClassData(typeof(EnumsData<Origem>))]
        public void Test_Enum_Value_Origem(Origem origem)
        {
            var sut = origem.GetType();
            sut.Should().Be(typeof(Origem));
        }
        
        [Theory]
        [ClassData(typeof(EnumsData<Situacao>))]
        public void Test_Enum_Value_Situacao(Situacao situacao)
        {
            var sut = situacao.GetType();
            sut.Should().Be(typeof(Situacao));
        }
        
        [Theory]
        [ClassData(typeof(EnumsData<TipoDistribuicao>))]
        public void Test_Enum_Value_TipoDistribuicao(TipoDistribuicao tipoDistribuicao)
        {
            var sut = tipoDistribuicao.GetType();
            sut.Should().Be(typeof(TipoDistribuicao));
        }
        
        [Theory]
        [ClassData(typeof(EnumsData<TipoProcesso>))]
        public void Test_Enum_Value_TipoProcesso(TipoProcesso tipoProcesso)
        {
            var sut = tipoProcesso.GetType();
            sut.Should().Be(typeof(TipoProcesso));
        }
        
        [Theory]
        [ClassData(typeof(EnumsData<VariavelEquilibrio>))]
        public void Test_Enum_Value_VariavelEquilibrio(VariavelEquilibrio variavelEquilibrio)
        {
            var sut = variavelEquilibrio.GetType();
            sut.Should().Be(typeof(VariavelEquilibrio));
        }
    }
}