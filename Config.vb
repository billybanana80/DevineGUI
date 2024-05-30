Imports System.IO

Public Class Config
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Construct the path to the devine.yaml file in the %LOCALAPPDATA%\devine directory
        Dim localAppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        Dim devineYamlPath As String = Path.Combine(localAppDataPath, "devine", "devine.yaml")

        ' Get the edited content from the RichTextBox
        Dim editedContent As String = rtbConfig.Text

        ' Save the edited content back to the devine.yaml file
        Try
            File.WriteAllText(devineYamlPath, editedContent)
            MessageBox.Show("The devine.yaml file has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("An error occurred while saving the devine.yaml file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




End Class