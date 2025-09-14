using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemTest
    {
    [Fact]
    public void TestandoOfertavalidacao()
        {
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 10));
        double preco = 1000.0;
        var validacao = true;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
        Assert.Equal(validacao, oferta.EhValido);
        }
    }