
Imports System.Reflection.Emit
Imports System.IO


Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load saved Settings upon opening Favorites form
        Dim showNames As String() = My.Settings.ShowName.Split("|"c, StringSplitOptions.RemoveEmptyEntries)
        Dim services As String() = My.Settings.Service.Split("|"c, StringSplitOptions.RemoveEmptyEntries)
        Dim seriesURLs As String() = My.Settings.SeriesURL.Split("|"c, StringSplitOptions.RemoveEmptyEntries)

        Dim maxLength As Integer = Math.Max(showNames.Length, Math.Max(services.Length, seriesURLs.Length))

        For i As Integer = 0 To maxLength - 1
            Dim index As Integer = DataGridView1.Rows.Add()
            If i < showNames.Length Then
                DataGridView1.Rows(index).Cells("ShowNameColumn").Value = showNames(i)
            End If
            If i < services.Length Then
                DataGridView1.Rows(index).Cells("ServiceColumn").Value = services(i)
            End If
            If i < seriesURLs.Length Then
                DataGridView1.Rows(index).Cells("SeriesURLColumn").Value = seriesURLs(i)
            End If
        Next
    End Sub

    Private Sub btnClose2_Click(sender As Object, e As EventArgs) Handles btnClose2.Click
        ' Close the Favorites form
        Me.Close()
    End Sub

    Private Sub btnSave2_Click(sender As Object, e As EventArgs) Handles btnSave2.Click

        ' Clear the existing data in settings before adding new data
        My.Settings.ShowName = ""
        My.Settings.Service = ""
        My.Settings.SeriesURL = ""

        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                ' Assuming "ShowNameColumn", "ServiceColumn", and "SeriesURLColumn" are the actual column names
                My.Settings.ShowName = My.Settings.ShowName & "|" & row.Cells("ShowNameColumn").Value.ToString()
                My.Settings.Service = My.Settings.Service & "|" & row.Cells("ServiceColumn").Value.ToString()
                My.Settings.SeriesURL = My.Settings.SeriesURL & "|" & row.Cells("SeriesURLColumn").Value.ToString()
            End If
        Next

        My.Settings.Save()

    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        ' Check if any row is selected
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Get the value from the "SeriesURL" column of the selected row
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim seriesURL As String = selectedRow.Cells("SeriesURLColumn").Value.ToString()

            ' Check if the SeriesURL is not empty
            If Not String.IsNullOrEmpty(seriesURL) Then
                ' Copy the SeriesURL to the clipboard
                Clipboard.SetText(seriesURL)

                ' Paste the SeriesURL into txtInput.Text
                Form1.TextBox1.Text = seriesURL

                ' Optionally, provide feedback to the user
                ' MessageBox.Show("SeriesURL copied to clipboard.", "Copy Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' Handle the case where SeriesURL is empty
                MessageBox.Show("Selected row does not have a SeriesURL.", "Empty SeriesURL", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            ' Handle the case where no row is selected
            MessageBox.Show("Please select a row before copying.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnClear2_Click(sender As Object, e As EventArgs) Handles btnClear2.Click
        ' Clear all rows in the DataGridView
        DataGridView1.Rows.Clear()

        ' Clear the existing data in settings to save
        My.Settings.ShowName = ""
        My.Settings.Service = ""
        My.Settings.SeriesURL = ""

    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click

        ' Configure the SaveFileDialog
        SaveFileDialog1.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
        SaveFileDialog1.DefaultExt = "csv"
        SaveFileDialog1.FilterIndex = 1

        ' Show the SaveFileDialog to choose the CSV file location
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                ' Get the selected file path
                Dim filePath As String = SaveFileDialog1.FileName

                ' Create a StreamWriter to write to the CSV file
                Using writer As New StreamWriter(filePath)
                    ' Write the header row
                    Dim header As String = String.Join(",", DataGridView1.Columns.Cast(Of DataGridViewColumn).Select(Function(c) c.HeaderText))
                    writer.WriteLine(header)

                    ' Write the data rows
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        If Not row.IsNewRow Then
                            Dim data As String = String.Join(",", row.Cells.Cast(Of DataGridViewCell).Select(Function(cell) cell.Value.ToString()))
                            writer.WriteLine(data)
                        End If
                    Next
                End Using

                MessageBox.Show("Export favorites successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error exporting favorites data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        ' Show the OpenFileDialog to choose the CSV file
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Clear existing entries in the DataGridView
            DataGridView1.Rows.Clear()

            Try
                ' Get the selected file path
                Dim filePath As String = OpenFileDialog1.FileName

                ' Read the CSV file and populate the DataGridView
                Using reader As New StreamReader(filePath)
                    ' Read the header row
                    Dim header As String = reader.ReadLine()
                    Dim headerColumns As String() = header.Split(","c)

                    ' Map the actual column names in DataGridView to My.Settings column names
                    Dim columnNameMapping As New Dictionary(Of String, String) From {
                        {"Show Name", "ShowNameColumn"},
                        {"Service", "ServiceColumn"},
                        {"Series URL", "SeriesURLColumn"}
                    }

                    ' Add columns to the DataGridView based on the header
                    DataGridView1.Columns.Clear()
                    For Each columnName In headerColumns
                        ' Map the actual column name if there's a mapping, otherwise, use the original column name
                        Dim actualColumnName As String = If(columnNameMapping.ContainsKey(columnName), columnNameMapping(columnName), columnName)

                        ' Add columns to the DataGridView based on the header
                        If actualColumnName = "ServiceColumn" Then
                            ' If it's the "ServiceColumn," add a DataGridViewComboBoxColumn
                            Dim newColumnIndex As Integer = DataGridView1.Columns.Add(New DataGridViewComboBoxColumn() With {
            .Name = actualColumnName,
            .HeaderText = columnName
        })

                            ' Set the dropdown items for the "ServiceColumn"
                            Dim serviceColumn As DataGridViewComboBoxColumn = CType(DataGridView1.Columns(newColumnIndex), DataGridViewComboBoxColumn)
                            serviceColumn.Items.AddRange({
            "ABC iView", "All 4", "BBC iPlayer", "CBC Gem", "Crackle",
            "CTV", "CWTV", "ITV", "My 5", "Plex", "Pluto", "Roku",
            "STV", "SVT Play", "Tubi", "TV4 Play", "UKTV Play"
        })
                            serviceColumn.Width = 100 ' Set the width for the "ServiceColumn"
                        Else
                            ' If it's not the "ServiceColumn," add a regular column
                            Dim newColumnIndex As Integer = DataGridView1.Columns.Add(actualColumnName, columnName)

                            ' Set the width for each column
                            Select Case actualColumnName
                                Case "ShowNameColumn"
                                    DataGridView1.Columns(newColumnIndex).Width = 200
                                Case "SeriesURLColumn"
                                    DataGridView1.Columns(newColumnIndex).Width = 500
                            End Select
                        End If
                    Next

                    ' Read the data rows
                    While Not reader.EndOfStream
                        Dim data As String = reader.ReadLine()
                        Dim dataColumns As String() = data.Split(","c)

                        ' Add a new row to the DataGridView and fill it with data
                        Dim rowIndex As Integer = DataGridView1.Rows.Add()
                        For columnIndex As Integer = 0 To dataColumns.Length - 1
                            ' Map the actual column name if there's a mapping, otherwise, use the original column name
                            Dim actualColumnName As String = If(columnNameMapping.ContainsKey(headerColumns(columnIndex)), columnNameMapping(headerColumns(columnIndex)), headerColumns(columnIndex))
                            DataGridView1.Rows(rowIndex).Cells(actualColumnName).Value = dataColumns(columnIndex)
                        Next
                    End While
                End Using

                MessageBox.Show("Import favorites successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error importing favorites data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class