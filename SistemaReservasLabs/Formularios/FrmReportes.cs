using SistemaReservasLabs.Logica;
using System;
using System.Windows.Forms;

namespace SistemaReservasLabs.Formularios
{
    public partial class FrmReportes : Form
    {
        private readonly GeneradorReportes _generadorReportes;

        public FrmReportes(GeneradorReportes generadorReportes)
        {
            InitializeComponent();
            _generadorReportes = generadorReportes;

            cmbTipoReporte.Items.Add("Uso por Laboratorio");
            cmbTipoReporte.Items.Add("Ranking de Usuarios");
            cmbTipoReporte.Items.Add("Ranking de Laboratorios");
            cmbTipoReporte.Items.Add("Reservas de Hoy");
            cmbTipoReporte.SelectedIndex = 0;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            dgvReporte.DataSource = null;

            switch (cmbTipoReporte.SelectedItem?.ToString())
            {
                case "Uso por Laboratorio":
                    dgvReporte.DataSource = _generadorReportes.ObtenerUsoPorLaboratorio();
                    break;

                case "Ranking de Usuarios":
                    dgvReporte.DataSource = _generadorReportes.ObtenerRankingUsuarios();
                    break;

                case "Reservas de Hoy":
                    dgvReporte.DataSource = _generadorReportes.ObtenerReservasDeHoy();
                    break;

                case "Ranking de Laboratorios":
                    dgvReporte.DataSource = _generadorReportes.ObtenerRankingLaboratorios();
                    break;
            }
        }
    }
}