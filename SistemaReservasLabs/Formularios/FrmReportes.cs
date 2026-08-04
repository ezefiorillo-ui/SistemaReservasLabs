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
            cmbTipoReporte.Items.Add("Ranking de Laboratorios");
            cmbTipoReporte.Items.Add("Ranking de Usuarios");
            cmbTipoReporte.Items.Add("Reservas de Hoy");
            cmbTipoReporte.SelectedIndex = 0;
        }

        private string _reporteActual = "";

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            _reporteActual = cmbTipoReporte.SelectedItem?.ToString() ?? "";
            dgvReporte.DataSource = null;

            switch (_reporteActual)
            {
                case "Uso por Laboratorio":
                    dgvReporte.AutoGenerateColumns = true;
                    dgvReporte.DataSource = _generadorReportes.ObtenerUsoPorLaboratorio();
                    break;

                case "Ranking de Laboratorios":
                    dgvReporte.AutoGenerateColumns = true;
                    dgvReporte.DataSource = _generadorReportes.ObtenerRankingLaboratorios();
                    break;

                case "Ranking de Usuarios":
                    dgvReporte.AutoGenerateColumns = true;
                    dgvReporte.DataSource = _generadorReportes.ObtenerRankingUsuarios();
                    break;

                case "Reservas de Hoy":
                    ConfigurarColumnasReservas();
                    dgvReporte.DataSource = _generadorReportes.ObtenerReservasDeHoy();
                    break;
            }
        }

        private void ConfigurarColumnasReservas()
        {
            dgvReporte.AutoGenerateColumns = false;
            dgvReporte.Columns.Clear();

            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "LaboratorioNombre", HeaderText = "Laboratorio", Width = 150 });

            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "UsuarioNombre", HeaderText = "Usuario", Width = 150 });

            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "Fecha", HeaderText = "Fecha", Width = 90 });

            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "HoraInicio", HeaderText = "Desde", Width = 70 });

            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "HoraFin", HeaderText = "Hasta", Width = 70 });

            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "Estado", HeaderText = "Estado", Width = 90 });

            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

    }
}