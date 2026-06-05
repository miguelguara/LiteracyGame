using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dados_fases
{
   public List<FasePalavra> fasePalavras = new List<FasePalavra>();
   public List<FaseNumero> faseNumeros = new List<FaseNumero>(); 
}

[Serializable]
public class FasePalavra
{
   public int ID;
   public int imageIndex;
   public string palavra;
   public int pontuacao;

   public FasePalavra(int id, int imgIndex, string plv, int point)
   {
    ID = id;
    imageIndex = imgIndex;
    palavra = plv;
    pontuacao = point;
   }
}

[Serializable]
public class FaseNumero
{
   int ID;
   int NumIni, NumFinal;
   int pontuacao;

   public FaseNumero(int id, int NumIni, int NumFinal, int pontuacao)
   {
    ID = id;
    this.NumIni = NumIni;
    this.NumFinal = NumFinal;
    this.pontuacao = pontuacao;
   }
}
