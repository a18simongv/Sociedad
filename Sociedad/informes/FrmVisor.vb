Public Class FrmVisor
    Private Sub FrmVisor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'dtsSociedad.Beneficiarios' Puede moverla o quitarla según sea necesario.
        Me.BeneficiariosTableAdapter.Fill(Me.dtsSociedad.Beneficiarios)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class