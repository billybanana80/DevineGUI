Public Class AboutForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ' Handle the link click event
        ' Open the website in the default web browser

        Dim startexternal As New Process()

        startexternal.StartInfo.FileName = LinkLabel1.Text
        startexternal.StartInfo.UseShellExecute = True

        startexternal.Start()

    End Sub


End Class