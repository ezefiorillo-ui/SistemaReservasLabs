using SistemaReservasLabs.Logica;
using SistemaReservasLabs.Modelos;
using SistemaReservasLabs.Repositorios;
using System;
using System.Windows.Forms;

namespace SistemaReservasLabs.Formularios
{
    public partial class FrmMenuPrincipal : Form
    {
        private readonly Usuario _usuarioLogueado;
        private readonly IRepositorio<Usuario> _repoUsuarios;
        private readonly IRepositorio<Laboratorio> _repoLaboratorios;
        private readonly GestorReservas _gestorReservas;
        private readonly IRepositorio<Reserva> _repoReservas;
        private readonly GeneradorReportes _generadorReportes;

        public FrmMenuPrincipal(Usuario usuarioLogueado, IRepositorio<Usuario> repoUsuarios,
                                 IRepositorio<Laboratorio> repoLaboratorios, IRepositorio<Reserva> repoReservas,
                                 GestorReservas gestorReservas, GeneradorReportes generadorReportes)
        {
            InitializeComponent();
            _usuarioLogueado = usuarioLogueado;
            _repoUsuarios = repoUsuarios;
            _repoLaboratorios = repoLaboratorios;
            _repoReservas = repoReservas;
            _gestorReservas = gestorReservas;
            _generadorReportes = generadorReportes;
            this.Text = $"Menú Principal - {_usuarioLogueado.Nombre} ({_usuarioLogueado.ObtenerTipoUsuario()})";
            lblUsuario.Text = $"Usuario: {_usuarioLogueado.Nombre} ({_usuarioLogueado.ObtenerTipoUsuario()})";

            // Restricción por rol: solo Administrador gestiona laboratorios y usuarios
            bool esAdministrador = _usuarioLogueado is Administrador;
            button1.Visible = esAdministrador;       // Gestión de Laboratorios
            btnUsuarios.Visible = esAdministrador;   // Gestión de Usuarios
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            new FrmGestionUsuarios(_repoUsuarios).Show();
        }

        private void btnGestionLaboratorios_Click(object sender, EventArgs e)
        {
            new FrmGestionLaboratorios(_repoLaboratorios).Show();
        }

        private void btnAltaReserva_Click(object sender, EventArgs e)
        {
            new FrmAltaReserva(_gestorReservas, _repoLaboratorios, _usuarioLogueado).Show();
        }

        private void btnGrillaReservas_Click(object sender, EventArgs e)
        {
            new FrmGrillaReservas(_repoReservas, _repoLaboratorios, _gestorReservas, _usuarioLogueado).Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            new FrmReportes(_generadorReportes).Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var frmLogin = new FrmLogin(_repoUsuarios, _repoLaboratorios, _repoReservas, _gestorReservas, _generadorReportes);
            frmLogin.Show();
            this.Close();
        }
    }
}