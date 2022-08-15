using System;
namespace Chat.Models
{
    public class Usuario
    {
        public string Nome {get;set;}
        public long Chave { get; set; } 
        public DateTime DataConexao { get; set; }    
    }
}