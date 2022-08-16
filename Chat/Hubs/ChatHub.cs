
using Chat.Models;
using Chat.Repository;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace Chat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionsRepository _connections = new ConnectionsRepository();

        public override Task OnConnectedAsync()
        {
            var user = JsonConvert.DeserializeObject<Usuario>(Context.GetHttpContext().Request.Query["user"]);
            _connections.Adicionar(Context.ConnectionId, user);

            Clients.All.SendAsync("chat", _connections.ObterTodosUsuarios(), user);
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(Mensagem chat)
        {
            await Clients.Client(_connections.ObterUsuarioPorId(chat.Destination)).SendAsync("Receive", chat.Sender, chat.Message);
        }
    }
}