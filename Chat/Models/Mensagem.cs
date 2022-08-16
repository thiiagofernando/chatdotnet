namespace Chat.Models
{
    public class Mensagem
    {
        public long Destination { get; set; }
        public Usuario Sender { get; set; }
        public string Message { get; set; }
    }
}
