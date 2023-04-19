using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Services;

namespace AgenciaTurismo.Controllers
{
    public class TicketController
    {
        public int Insert(Ticket ticket)
        {
            return new TicketService().InsertTicket(ticket);
        }

        public List<Ticket> FindAll()
        {
            return new TicketService().FindAll();
        }

        public int Update()
        {
            return new TicketService().Update();
        }

        public int Delete(int id)
        {
            return new TicketService().DeleteId(id);
        }
    }
}
