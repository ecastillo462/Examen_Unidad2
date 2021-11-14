﻿using Examen_Unidad2.Modelos.DAO;
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
    public class EstadosController
    {
        EstadosView vista;
        EstadosDAO estadosDAO = new EstadosDAO();
        Estados estados = new Estados();
        string operacion = string.Empty;
        public EstadosController(EstadosView view)
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
        }
        private void Guardar(object serder, EventArgs e)
        {
            if (vista.EstadoTicketTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.EstadoTicketTextBox, "Ingrese un tipo de soporte");
                vista.EstadoTicketTextBox.Focus();
                return;
            }

            estados.EstadoTicket = vista.EstadoTicketTextBox.Text;
            if (operacion == "Nuevo")
            {
                bool inserto = estadosDAO.InsertarNuevoEstado(estados);

                if (inserto)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    ListarEstados();
                    MessageBox.Show("Nuevo estado registrado exitosamente ", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el estado", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else if (operacion == "Modificar")
            {
                estados.Id = Convert.ToInt32(vista.IdTextBox.Text);
                bool modifico = estadosDAO.ActualizarEstados(estados);
                if (modifico)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    ListarEstados();
                    MessageBox.Show("Estado modificado Exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el estado", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }

        }
        private void Load(object sender, EventArgs e)
        {
            ListarEstados();
        }
        private void Modificar(object serder, EventArgs e)
        {
            operacion = "Modificar";

            if (vista.EstadosDataGridView.SelectedRows.Count > 0)
            {
                vista.IdTextBox.Text = vista.EstadosDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.EstadoTicketTextBox.Text = vista.EstadosDataGridView.CurrentRow.Cells["ESTADOTICKET"].Value.ToString();
                HabilitarControles();
            }
        }
        private void Eliminar(object serder, EventArgs e)
        {
            if (vista.EstadosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = estadosDAO.EliminarEstados(Convert.ToInt32(vista.EstadosDataGridView.CurrentRow.Cells[0].Value.ToString()));

                if (elimino)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    ListarEstados();
                    MessageBox.Show("Estado eliminado exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
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
            vista.EstadoTicketTextBox.Enabled = true;

            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;
            vista.ModificarButton.Enabled = false;
            vista.NuevoButton.Enabled = false;
            vista.EliminarButton.Enabled = false;
        }
        private void DesabilitarControles()
        {
            vista.IdTextBox.Enabled = false;
            vista.EstadoTicketTextBox.Enabled = false;

            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;
            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;
            vista.EliminarButton.Enabled = true;
        }
        private void LimpiarControles()
        {
            vista.IdTextBox.Clear();
            vista.EstadoTicketTextBox.Clear();
        }
        private void ListarEstados()
        {
            vista.EstadosDataGridView.DataSource = estadosDAO.GetEstados();
        }
    }
}
