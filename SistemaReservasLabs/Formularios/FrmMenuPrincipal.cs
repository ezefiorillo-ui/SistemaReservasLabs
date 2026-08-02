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

        public FrmMenuPrincipal(Usuario usuarioLogueado, IRepositorio<Usuario> repoUsuarios)
        {
            InitializeComponent();
            _usuarioLogueado = usuarioLogueado;
            _repoUsuarios = repoUsuarios;
            this.Text = $"Menú Principal - {_usuarioLogueado.Nombre} ({_usuarioLogueado.ObtenerTipoUsuario()})";
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            var frm = new FrmGestionUsuarios(_repoUsuarios);
            frm.Show();
        }
    }
}