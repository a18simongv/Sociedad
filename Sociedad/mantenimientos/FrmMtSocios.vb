Imports Microsoft.Reporting.WinForms

Public Class FrmMtSocios
    Private Sub FrmMtSocios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cta = New dtsSociedadTableAdapters.SociosTableAdapter()
        cta.Fill(DtsSociedad.Socios)
        bindCmb()
    End Sub

    Private Sub bindCmb()
        cmbSocios.DataSource = DtsSociedad.Socios
        cmbSocios.DisplayMember = "Nombre"
        cmbSocios.ValueMember = "NSocio"

        bindData()

        lblNSocio.DataBindings.Add("Text", DtsSociedad.Socios, "NSocio")
        lblNif.DataBindings.Add("Text", DtsSociedad.Socios, "NIF")
        lblNombre.DataBindings.Add("Text", DtsSociedad.Socios, "Nombre")
        dtpFechaAlta.DataBindings.Add("Value", DtsSociedad.Socios, "FechaAlta")
        chbBaja.DataBindings.Add("Checked", DtsSociedad.Socios, "Baja")
        lblTipoSocio.DataBindings.Add("Text", DtsSociedad.Socios, "TipoSocio")
    End Sub

    Private Sub cmbSocios_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbSocios.SelectionChangeCommitted
        bindData()
    End Sub
    Private Sub bindData()
        '<control>.DataBindings.Add("data type", columna,"string") -> para labels, etc
        Dim benefAd = New dtsSociedadTableAdapters.BeneficiariosTableAdapter()
        benefAd.FillByNSocio(DtsSociedad.Beneficiarios, cmbSocios.SelectedValue)

        dtgBeneficiario.DataSource = DtsSociedad.Beneficiarios
    End Sub

    Private Sub ImprimirToolStripButton_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripButton.Click
        Dim visor = New FrmVisor()
        Dim param As New ReportParameter("NSocio", CType(cmbSocios.SelectedValue, String))
        visor.ReportViewer1.LocalReport.SetParameters(param)
        visor.ShowDialog()
    End Sub
End Class