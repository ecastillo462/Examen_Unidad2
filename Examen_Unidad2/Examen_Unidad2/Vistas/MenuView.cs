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
    }
}
