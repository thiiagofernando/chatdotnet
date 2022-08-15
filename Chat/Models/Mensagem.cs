using System;
namespace Chat.Models
{
    public class Mensagem
    {
        public long Destino { get; set; }
        public Usuario Remetente{get;set;}
        public string Texto{get;set;}
    }
}