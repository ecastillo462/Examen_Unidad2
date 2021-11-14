using Examen_Unidad2.Modelos.DAO;
using Examen_Unidad2.Modelos.Entidades;
using Examen_Unidad2.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_Unidad2.Controladores
{
    public class TicketsController
    {
        TicketsView vista;
        TicketsDAO ticketsDAO = new TicketsDAO();
        Tickets tickets = new Tickets();
        string operacion = string.Empty;

        public TicketsController(TicketsView view)
        {
            vista = view;
            vista.NuevoButton.Click += new EventHandler(Nuevo);
            vista.GuardarButton.Click += new EventHandler(Guardar);
            vista.Load += new EventHandler(Load);
            vista.ModificarButton.Click += new EventHandler(Modificar);
            vista.EliminarButton.Click += new EventHandler(Eliminar);
            vista.CancelarButton.Click += new EventHandler(Cancelar);
        }
        private void Nuevo(object serder, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
            ListarTipos();
            ListarEstados();
        }
        private void Guardar(object serder, EventArgs e)
        {
            if (vista.NombreClienteTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombreClienteTextBox, "Ingrese el nombre del cliente");
                vista.NombreClienteTextBox.Focus();
                return;
            }
            if (vista.TipoSoporteComboBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.TipoSoporteComboBox, "Seleccione un tipo de soporte");
                vista.TipoSoporteComboBox.Focus();
                return;
            }
            if (vista.EstadoTicketComboBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.EstadoTicketComboBox, "Seleccione el estado del ticket");
                vista.EstadoTicketComboBox.Focus();
                return;
            }

            tickets.NombreCliente = vista.NombreClienteTextBox.Text;
            tickets.FechaInicio = vista.FechaInicioDateTimePicker.Value;
            tickets.FechaFinalizacion = vista.FechaFinalizacionDateTimePicker.Value;
            tickets.TipoSoporte = vista.TipoSoporteComboBox.Text;
            tickets.EstadoTicket = vista.EstadoTicketComboBox.Text;

            if (operacion == "Nuevo")
            {
                bool inserto = ticketsDAO.InsertarNuevoTicket(tickets);

                if (inserto)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    ListarTickets();
                    MessageBox.Show("Nuevo ticket registrado exitosamente ", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el ticket", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else if (operacion == "Modificar")
            {
                tickets.Id = Convert.ToInt32(vista.IdTextBox.Text);
                bool modifico = ticketsDAO.ActualizarTickets(tickets);
                if (modifico)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    ListarTickets();
                    MessageBox.Show("Ticket modificado Exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el ticket", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }

        }
        private void Load(object sender, EventArgs e)
        {
            ListarTickets();
        }
        private void Modificar(object serder, EventArgs e)
        {
            operacion = "Modificar";

            if (vista.TicketsDataGridView.SelectedRows.Count > 0)
            {
                vista.IdTextBox.Text = vista.TicketsDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.NombreClienteTextBox.Text = vista.TicketsDataGridView.CurrentRow.Cells["NOMBRECLIENTE"].Value.ToString();
                vista.TipoSoporteComboBox.Text = vista.TicketsDataGridView.CurrentRow.Cells["TIPOSOPORTE"].Value.ToString();
                vista.EstadoTicketComboBox.Text = vista.TicketsDataGridView.CurrentRow.Cells["ESTADOTICKET"].Value.ToString();
                HabilitarControles();
            }
        }
        private void Eliminar(object serder, EventArgs e)
        {
            if (vista.TicketsDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = ticketsDAO.EliminarTickets(Convert.ToInt32(vista.TicketsDataGridView.CurrentRow.Cells[0].Value.ToString()));

                if (elimino)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    ListarTickets();
                    MessageBox.Show("Ticket eliminado exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    vista.TicketsDataGridView.DataSource = "";
                }
            }
        }
        private void Cancelar(object serder, EventArgs e)
        {
            LimpiarControles();
            DesabilitarControles();
        }
        private void HabilitarControles()
        {
            vista.IdTextBox.Enabled = true;
            vista.NombreClienteTextBox.Enabled = true;
            vista.FechaInicioDateTimePicker.Enabled = true;
            vista.FechaFinalizacionDateTimePicker.Enabled = true;
            vista.TipoSoporteComboBox.Enabled = true;
            vista.EstadoTicketComboBox.Enabled = true;

            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;

            vista.ModificarButton.Enabled = false;
            vista.NuevoButton.Enabled = false;
            vista.EliminarButton.Enabled = false;
        }
        private void DesabilitarControles()
        {
            vista.IdTextBox.Enabled = false;
            vista.NombreClienteTextBox.Enabled = false;
            vista.FechaInicioDateTimePicker.Enabled = false;
            vista.FechaFinalizacionDateTimePicker.Enabled = false;
            vista.TipoSoporteComboBox.Enabled = false;
            vista.EstadoTicketComboBox.Enabled = false;

            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;

            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;
            vista.EliminarButton.Enabled = true;
        }
        private void LimpiarControles()
        {
            vista.IdTextBox.Clear();
            vista.NombreClienteTextBox.Clear();
        }
        private void ListarTipos()
        {
            vista.TipoSoporteComboBox.DataSource = ticketsDAO.GetTipos();
            vista.TipoSoporteComboBox.DisplayMember = "TIPOS";
            vista.TipoSoporteComboBox.ValueMember = "TIPOSOPORTE";
        }
        private void ListarEstados()
        {
            vista.EstadoTicketComboBox.DataSource = ticketsDAO.GetEstados();
            vista.EstadoTicketComboBox.DisplayMember = "ESTADOS";
            vista.EstadoTicketComboBox.ValueMember = "ESTADOTICKET";
        }
        private void ListarTickets()
        {
            vista.TicketsDataGridView.DataSource = ticketsDAO.GetTickets();
        }
    }
}
