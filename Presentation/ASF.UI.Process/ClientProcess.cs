using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.UI.Process
{
    public class ClientProcess : ProcessComponent, IABMProcess<Client>
    {
        public IList<Client> SelectList()
        {
            return CallHttpGetAll<Client>();
        }

        public Client EditCategory(Client entity)
        {
            return CallHttpPostEdit(entity);
        }

        public Client GetById(int id)
        {
            return CallHttpGetById<Client>(new Dictionary<string, object>() { { "id", id } });
        }

        public Client RemoveCategory(Client entity)
        {
            return CallHttpPostRemove(entity);
        }

        public Client CreateCategory(Client entity)
        {
            return CallHttpPostAdd(entity);
        }
    }
}
