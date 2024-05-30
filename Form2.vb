Imports System.Reflection.Emit
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Text

Public Class Form2



    Private Function GetConfigValue(fileContent As String, key As String) As String
        ' Extract the value associated with the specified key from the YAML content
        ' This is a simple example and may need to be adapted based on the actual structure of your YAML file
        Dim regex As New Regex($"{key}: (.+)")
        Dim match As Match = regex.Match(fileContent)

        If match.Success Then
            Return match.Groups(1).Value.Trim()
        Else
            Return String.Empty
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        ' Show the FolderBrowserDialog to choose Devine path
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            ' Get the selected folder path
            Dim selectedPath As String = FolderBrowserDialog1.SelectedPath

            ' Save the selected folder path to application settings
            My.Settings.FolderPath = selectedPath
            My.Settings.Save()

            ' Update the TextBox with the selected folder path
            TBfolder.Text = selectedPath
        End If
    End Sub

    Private Sub BtnBrowse2_Click(sender As Object, e As EventArgs) Handles BtnBrowse2.Click
        ' Show the FolderBrowserDialog2 to choose Downloads Path
        If FolderBrowserDialog2.ShowDialog() = DialogResult.OK Then
            ' Get the selected folder path
            Dim selectedPath2 As String = FolderBrowserDialog2.SelectedPath

            ' Save the selected folder path to application settings
            My.Settings.FolderPath2 = selectedPath2
            My.Settings.Save()

            ' Update the devine.yaml file with the new downloads path
            UpdateDownloadsPathInYaml(selectedPath2)

            ' Update the TextBox with the selected folder path
            TBfolder2.Text = selectedPath2
        End If
    End Sub

    Private Sub UpdateDownloadsPathInYaml(newDownloadsPath As String)
        ' Construct the path to the devine.yaml file in the %LOCALAPPDATA%\devine directory
        Dim localAppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        Dim devineYamlPath As String = Path.Combine(localAppDataPath, "devine", "devine.yaml")

        ' Check if the file exists
        If Not File.Exists(devineYamlPath) Then
            MessageBox.Show("The devine.yaml file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Read the content of the devine.yaml file
        Dim yamlContent As String = File.ReadAllText(devineYamlPath)

        ' Replace the downloads path
        Dim pattern As String = "(downloads:\s*)(.*)"
        Dim replacement As String = $"downloads: {newDownloadsPath}"
        Dim updatedYamlContent As String = System.Text.RegularExpressions.Regex.Replace(yamlContent, pattern, replacement)

        ' Write the updated content back to the file
        File.WriteAllText(devineYamlPath, updatedYamlContent)

        MessageBox.Show("Download folder location updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'Save the Devine folder location in TBfolder and Downloads location in TBfolder2
        ' Save the folder paths to application settings
        TBfolder.Text = My.Settings.FolderPath
        TBfolder2.Text = My.Settings.FolderPath2

        ' Set ToolStrip text to the folder path from TBfolder
        Form1.ToolStripStatusLabel2.Text = TBfolder.Text

        ' Warning message to set Freevine options
        If TBfolder.Text = "" Then
            Form1.ToolStripStatusLabel2.Text = "Please set your Devine folder location in Options"
        End If

    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ' Clear the Devine and Downloads folder location

        ' Clear TBfolder.Text
        TBfolder.Text = ""
        TBfolder2.Text = ""

        ' Save the empty string to My.Settings.FolderPath
        My.Settings.FolderPath = ""
        My.Settings.FolderPath2 = ""
        My.Settings.Save()

        ' Update ToolStrip Text with the cleared folder path
        Form1.ToolStripStatusLabel2.Text = TBfolder.Text

    End Sub

    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim textService As String = cbService.Text
        Dim textUsername As String = tbUsername.Text
        Dim textPassword As String = tbPassword.Text

        ' Construct the path to the devine.yaml file in the %LOCALAPPDATA%\devine directory
        Dim localAppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        Dim devineYamlPath As String = Path.Combine(localAppDataPath, "devine", "devine.yaml")

        ' Check if the necessary fields are filled
        If String.IsNullOrWhiteSpace(textService) OrElse String.IsNullOrWhiteSpace(textUsername) OrElse String.IsNullOrWhiteSpace(textPassword) Then
            MessageBox.Show("Please complete ALL profile options before pressing Set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if the file exists
        If Not File.Exists(devineYamlPath) Then
            MessageBox.Show("The devine.yaml file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Read all lines from the YAML file
        Dim lines As List(Of String) = File.ReadAllLines(devineYamlPath).ToList()
        Dim newEntry As String = $"  {textService}: {textUsername}:{textPassword}"
        Dim credentialsIndex As Integer = -1
        Dim insertIndex As Integer = -1

        ' Find the index of the credentials section
        For i As Integer = 0 To lines.Count - 1
            If lines(i).Trim() = "credentials:" Then
                credentialsIndex = i
                insertIndex = i + 1
                ' Find the end of the credentials section
                While insertIndex < lines.Count AndAlso (lines(insertIndex).StartsWith("  ") OrElse String.IsNullOrWhiteSpace(lines(insertIndex)))
                    insertIndex += 1
                End While
                Exit For
            End If
        Next

        If credentialsIndex = -1 Then
            MessageBox.Show("The 'credentials:' section was not found in the YAML file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Insert the new entry and a blank line after it
        lines.Insert(insertIndex - 1, newEntry)
        'lines.Insert(insertIndex + 1, "") ' Inserting a blank line after the new credential entry

        ' Write the updated lines back to the YAML file
        File.WriteAllLines(devineYamlPath, lines)

        ' Clear the Combo box and Text Boxes
        cbService.Text = ""
        tbUsername.Text = ""
        tbPassword.Text = ""

        MessageBox.Show("Credentials added successfully to devine.yaml file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub



    Private Sub btnSetDown_Click(sender As Object, e As EventArgs) Handles btnSetDown.Click
        ' Construct the path to the devine.yaml file in the %LOCALAPPDATA%\devine directory
        Dim localAppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        Dim devineYamlPath As String = Path.Combine(localAppDataPath, "devine", "devine.yaml")

        ' Check if the file exists
        If Not File.Exists(devineYamlPath) Then
            MessageBox.Show("The devine.yaml file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Read the content of the devine.yaml file
        Dim yamlContent As String = File.ReadAllText(devineYamlPath)

        ' Determine new downloader based on which button is checked
        Dim newDownloader As String = ""
        If btnAria.Checked Then
            newDownloader = "downloader: aria2c"
        ElseIf btnCurl.Checked Then
            newDownloader = "downloader: curl_impersonate"
        ElseIf btnRequests.Checked Then
            newDownloader = "downloader: requests"
        Else
            ' If neither is checked, do not proceed with the update
            MessageBox.Show("Please select a downloader option.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Replace the current downloader setting with the selected one
        If yamlContent.Contains("downloader: aria2c") Then
            yamlContent = yamlContent.Replace("downloader: aria2c", newDownloader)
        ElseIf yamlContent.Contains("downloader: curl_impersonate") Then
            yamlContent = yamlContent.Replace("downloader: curl_impersonate", newDownloader)
        ElseIf yamlContent.Contains("downloader: requests") Then
            yamlContent = yamlContent.Replace("downloader: requests", newDownloader)
        End If

        ' Write the updated content back to the file
        File.WriteAllText(devineYamlPath, yamlContent)

        MessageBox.Show("Downloader setting updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub




End Class