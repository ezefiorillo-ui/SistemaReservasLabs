using SistemaReservasLabs.Logica;
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
        private readonly IRepositorio<Laboratorio> _repoLaboratorios;
        private readonly GestorReservas _gestorReservas;
        private readonly IRepositorio<Reserva> _repoReservas;
        private readonly GeneradorReportes _generadorReportes;

        public FrmLogin(IRepositorio<Usuario> repoUsuarios, IRepositorio<Laboratorio> repoLaboratorios,
                         IRepositorio<Reserva> repoReservas, GestorReservas gestorReservas, GeneradorReportes generadorReportes)
        {
            InitializeComponent();
            _repoUsuarios = repoUsuarios;
            _repoLaboratorios = repoLaboratorios;
            _repoReservas = repoReservas;
            _gestorReservas = gestorReservas;
            _generadorReportes = generadorReportes;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            List<Usuario> usuarios = _repoUsuarios.ListarTodos();
            cmbUsuarios.DataSource = usuarios;
            cmbUsuarios.DisplayMember = "Nombre";
            cmbUsuarios.SelectedIndex = -1;
        }

        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e) { }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (cmbUsuarios.SelectedItem is not Usuario usuarioSeleccionado)
            {
                MessageBox.Show("Seleccioná un usuario para ingresar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frmMenu = new FrmMenuPrincipal(usuarioSeleccionado, _repoUsuarios, _repoLaboratorios,
                                     _repoReservas, _gestorReservas, _generadorReportes);
            frmMenu.Show();
            this.Hide();
        }
    }
}