using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemConstrutor
    {
    //[Fact]
    [Theory]
    [InlineData("", null, "2024-01-01", "2024-01-05", 0, false)]
    [InlineData("OrigemTeste", "DestinoTeste", "2024-01-01", "2024-01-05", 1000, true)]
    [InlineData("OrigemTeste", "DestinoTeste", "2024-01-01", "2024-01-05", -500, false)]
    [InlineData("OrigemTeste", "DestinoTeste", "2024-01-10", "2024-01-05", 1000, false)]
    [InlineData("OrigemTeste", "DestinoTeste", "2024-01-01", "2024-01-05", 0, false)]
    public void RetornaEhValidoDeAcordoComDadosDeEntrada(string orige, string destino, string dataIda, string dataVolta, double vr, bool valido)
    //cenario - arrange
        {
        Rota rota = new Rota(orige, destino);
        Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));
        double preco = vr;
        var validacao = valido;

        //acao - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //validação - assert
        Assert.Equal(validacao, oferta.EhValido);


        }
    [Fact]
    public void RetornaMensagemErroDeRotaOuPeriodoInvalidoQuandoRotaNula()
    //cenario - arrange
        {
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 10));
        double preco = 1000.0;

        //acao - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //validação - assert
        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);

        }

    // [Fact]
    [Theory]
    [InlineData(0)]

    public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorOuIgualaZero(double preco)
        {
        //Arrange
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(new DateTime(2024 - 01 - 05), new DateTime(2024 - 02 - 01));
        //Act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //Assert
        Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);


        }
    [Fact]
    public void RetornaMensagemDeErroQuandoPrecoForNegatico()
        {
        //arrange
        var Origem = "OrigemTeste";
        var Destino = "DestinoTeste";
        double preco = -500.0;
        //act
        Rota rota = new Rota(Origem, Destino);
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 10));
        OfertaViagem ofertaNegativa = new OfertaViagem(rota, periodo, preco);
        //assert
        Assert.Contains("O preço da oferta de viagem deve ser maior que zero", ofertaNegativa.Erros.Sumario);
        }

    }