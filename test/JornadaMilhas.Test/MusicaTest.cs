using JornadaMilhas.Modelos;

namespace JornadaMilhas.Test;

public class MusicaTest
    {
    [Fact]
    public void TestandoMusicaValidacaoNome()
        {
        //Arrange
        var nome = "Nova ordem mundial";
        var nomeErrado = "Musica sem nome";
        //Act
        Musica musica = new Musica(nome);
        //Assert
        Assert.Equal(nome, musica.Nome);

        }
    [Fact]
    public void TestandoMusicaValidacaoId()
        {
        //arrange
        var id = 1;
        var nome = "Nova ordem mundial";

        //act
        Musica musica = new Musica(nome) { Id = id };

        //assert
        Assert.Equal(id, musica.Id);
        }
    [Fact]
    public void TestandoMusicaValidacaoToStrig()
        {
        //arrenge
        var id = 10;
        var nome = "O mundo é um moinho";

        //act
        Musica musica = new Musica(nome);
        musica.Id = id;
        var resutadoEsperado = @$"Id: {musica.Id} Nome: {musica.Nome}";
        //assert
        Assert.Equal(resutadoEsperado, musica.ToString());
        }

    }