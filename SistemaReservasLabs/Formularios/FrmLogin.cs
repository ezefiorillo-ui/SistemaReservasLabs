using SistemaReservasLabs.Modelos;
using SistemaReservasLabs.Repositorios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaReservasLabs.Formularios
{
    public partial class FrmLogin : Form
    {
        private readonly IRepositorio<Usuario> _repoUsuarios;

        public FrmLogin(IRepositorio<Usuario> repoUsuarios)
        {
            InitializeComponent();
            _repoUsuarios = repoUsuarios;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            List<Usuario> usuarios = _repoUsuarios.ListarTodos();

            cmbUsuarios.DataSource = usuarios;
            cmbUsuarios.DisplayMember = "Nombre";
            cmbUsuarios.SelectedIndex = -1;
        }

        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (cmbUsuarios.SelectedItem is not Usuario usuarioSeleccionado)
            {
                MessageBox.Show("Seleccioná un usuario para ingresar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frmMenu = new FrmMenuPrincipal(usuarioSeleccionado, _repoUsuarios);
            frmMenu.Show();
            this.Hide();
        }
    }
}