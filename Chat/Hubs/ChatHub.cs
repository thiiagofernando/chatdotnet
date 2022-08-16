
using Chat.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using Chat.Repository;
using Newtonsoft.Json;


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
            await Clients.Client(_connections.ObterUsuarioPorId(chat.Destination )).SendAsync("Receive", chat.Sender , chat.Message );
        }
    }
}