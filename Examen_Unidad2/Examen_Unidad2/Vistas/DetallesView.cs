﻿using Examen_Unidad2.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_Unidad2.Vistas
{
    public partial class DetallesView : Form
    {
        public DetallesView()
        {
            InitializeComponent();
            DetallesController controlador = new DetallesController(this);
        }
    }
}
