Public Class FormInicial
    Private Sub btnSocios_Click(sender As Object, e As EventArgs) Handles btnSocios.Click
        Dim soc As New FrmMtSocios
        soc.ShowDialog()
    End Sub
End Class