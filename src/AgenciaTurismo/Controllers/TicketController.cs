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

        public int Update(Ticket ticket)
        {
            return new TicketService().Update(ticket);
        }

        public int Delete(Ticket ticket)
        {
            return new TicketService().Delete(ticket);
        }
    }
}
