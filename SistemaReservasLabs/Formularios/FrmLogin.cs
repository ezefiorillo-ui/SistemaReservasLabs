using SistemaReservasLaboratorios.Modelos;
using SistemaReservasLabs.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaReservasLabs.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // usuarios de prueba hasta que esté el repositorio
            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Administrador("A001", "Ana Torres"));
            usuarios.Add(new Docente("D001", "Carlos Gomez"));
            usuarios.Add(new Alumno("AL001", "Lucia Fernandez"));

            
            cmbUsuarios.DataSource = usuarios;
            cmbUsuarios.SelectedIndex = -1; //inicializo vacio
        }
    }
}
