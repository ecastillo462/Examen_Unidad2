using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Examen_Unidad2.Vistas
{
    public partial class MenuView : Syncfusion.Windows.Forms.Office2010Form
    {
        public MenuView()
        {
            InitializeComponent();
        }
        TiposView vistaTipos;
        EstadosView vistaEstados;
        TicketsView vistaTickests;
        DetallesView vistaDetalles;
        private void RegistroTiposToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaTipos == null)
            {
                vistaTipos = new TiposView();
                vistaTipos.MdiParent = this;
                vistaTipos.FormClosed += VistaTipos_FormClosed;
                vistaTipos.Show();
            }
            else
            {
                vistaTipos.Activate();
            }
        }
        private void VistaTipos_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaTipos = null;
        }
        private void RegistroEstadosToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaEstados == null)
            {
                vistaEstados = new EstadosView();
                vistaEstados.MdiParent = this;
                vistaEstados.FormClosed += VistaEstados_FormClosed;
                vistaEstados.Show();
            }
            else
            {
                vistaEstados.Activate();
            }
        }
        private void VistaEstados_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaEstados = null;
        }
        private void GenerarTicketToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaTickests == null)
            {
                vistaTickests = new TicketsView();
                vistaTickests.MdiParent = this;
                vistaTickests.FormClosed += VistaTickests_FormClosed;
                vistaTickests.Show();
            }
            else
            {
                vistaTickests.Activate();
            }
        }
        private void VistaTickests_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaTickests = null;
        }
        private void DetallesToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaTipos == null)
            {
                vistaDetalles = new DetallesView();
                vistaDetalles.MdiParent = this;
                vistaDetalles.FormClosed += VistaDetalles_FormClosed;
                vistaDetalles.Show();
            }
            else
            {
                vistaDetalles.Activate();
            }
        }
        private void VistaDetalles_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaDetalles = null;
        }
    }
}
