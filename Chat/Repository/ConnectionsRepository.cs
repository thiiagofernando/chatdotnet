
using Chat.Models;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Repository
{
    public class ConnectionsRepository
    {
        private readonly Dictionary<string, Usuario> connections = new Dictionary<string, Usuario>();

        public void Adicionar(string uniqueID, Usuario usuario)
        {
            if (!connections.ContainsKey(uniqueID))
                connections.Add(uniqueID, usuario);
        }

        public string ObterUsuarioPorId(long id)
        {
            return (from con in connections
                    where con.Value.Key == id
                    select con.Key).FirstOrDefault();
        }

        public List<Usuario> ObterTodosUsuarios() => (from con in connections select con.Value).ToList();
    }
}