using Examen_Unidad2.Modelos.DAO;
using Examen_Unidad2.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_Unidad2.Controladores
{
    public class DetallesController
    {
        DetallesView vista;
        TicketsDAO ticketsDAO = new TicketsDAO();
        public DetallesController(DetallesView view)
        {
            vista = view;
            vista.Load += new EventHandler(Load);
            vista.EliminarButton.Click += new EventHandler(Eliminar);
            vista.SalirButton.Click += new EventHandler(Salir);
        }
        private void Load(object sender, EventArgs e)
        {
            ListarTickets();
        }
        private void Eliminar(object serder, EventArgs e)
        {
            if (vista.TicketsDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = ticketsDAO.EliminarTickets(Convert.ToInt32(vista.TicketsDataGridView.CurrentRow.Cells[0].Value.ToString()));

                if (elimino)
                {
                    ListarTickets();
                    MessageBox.Show("Ticket eliminado exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }
        private void Salir(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ListarTickets()
        {
            vista.TicketsDataGridView.DataSource = ticketsDAO.GetTickets();
        }

    }
}
