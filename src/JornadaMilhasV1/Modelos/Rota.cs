﻿using JornadaMilhasV1.Validador;

namespace JornadaMilhasV1.Modelos;

public class Rota : Valida
    {
    public int Id { get; set; }
    public string Origem { get; set; }
    public string Destino { get; set; }

    public Rota(string origem, string destino)
        {
        Origem = origem;
        Destino = destino;

        }

    protected override void Validar()
        {
        if ((this.Origem is null) || this.Origem.Equals(string.Empty))
            {
            Erros.RegistrarErro("A rota não pode possuir uma origem nula ou vazia.");
            }
        else if ((this.Destino is null) || this.Destino.Equals(string.Empty))
            {
            Erros.RegistrarErro("A rota não pode possuir um destino nulo ou vazio.");
            }
        }
    }
