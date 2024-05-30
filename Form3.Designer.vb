<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        GroupBox1 = New GroupBox()
        Label2 = New Label()
        DataGridView1 = New DataGridView()
        Label1 = New Label()
        btnClose2 = New Button()
        btnCopy = New Button()
        btnSave2 = New Button()
        btnClear2 = New Button()
        BtnImport = New Button()
        BtnExport = New Button()
        SaveFileDialog1 = New SaveFileDialog()
        OpenFileDialog1 = New OpenFileDialog()
        ShowNameColumn = New DataGridViewTextBoxColumn()
        ServiceColumn = New DataGridViewComboBoxColumn()
        SeriesURLColumn = New DataGridViewTextBoxColumn()
        GroupBox1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(DataGridView1)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(870, 479)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Favorites"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = Color.CornflowerBlue
        Label2.Location = New Point(6, 44)
        Label2.Name = "Label2"
        Label2.Size = New Size(389, 15)
        Label2.TabIndex = 2
        Label2.Text = "Select a row and click Copy to add the Series URL to the main Command"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = SystemColors.Control
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = Color.CornflowerBlue
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {ShowNameColumn, ServiceColumn, SeriesURLColumn})
        DataGridView1.GridColor = SystemColors.WindowFrame
        DataGridView1.Location = New Point(13, 76)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(843, 385)
        DataGridView1.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = Color.CornflowerBlue
        Label1.Location = New Point(6, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(450, 15)
        Label1.TabIndex = 0
        Label1.Text = "Click on the * to add a new favorite series, click Save to keep, click Clear to delete all "
        ' 
        ' btnClose2
        ' 
        btnClose2.Location = New Point(793, 499)
        btnClose2.Name = "btnClose2"
        btnClose2.Size = New Size(75, 30)
        btnClose2.TabIndex = 6
        btnClose2.Text = "Close"
        btnClose2.UseVisualStyleBackColor = True
        ' 
        ' btnCopy
        ' 
        btnCopy.BackColor = Color.SteelBlue
        btnCopy.ForeColor = Color.White
        btnCopy.Location = New Point(712, 499)
        btnCopy.Name = "btnCopy"
        btnCopy.Size = New Size(75, 30)
        btnCopy.TabIndex = 5
        btnCopy.Text = "Copy"
        btnCopy.UseVisualStyleBackColor = False
        ' 
        ' btnSave2
        ' 
        btnSave2.Location = New Point(631, 499)
        btnSave2.Name = "btnSave2"
        btnSave2.Size = New Size(75, 30)
        btnSave2.TabIndex = 4
        btnSave2.Text = "Save"
        btnSave2.UseVisualStyleBackColor = True
        ' 
        ' btnClear2
        ' 
        btnClear2.Location = New Point(550, 499)
        btnClear2.Name = "btnClear2"
        btnClear2.Size = New Size(75, 30)
        btnClear2.TabIndex = 3
        btnClear2.Text = "Clear"
        btnClear2.UseVisualStyleBackColor = True
        ' 
        ' BtnImport
        ' 
        BtnImport.Location = New Point(106, 499)
        BtnImport.Name = "BtnImport"
        BtnImport.Size = New Size(75, 30)
        BtnImport.TabIndex = 6
        BtnImport.Text = "Import"
        BtnImport.UseVisualStyleBackColor = True
        ' 
        ' BtnExport
        ' 
        BtnExport.Location = New Point(25, 499)
        BtnExport.Name = "BtnExport"
        BtnExport.Size = New Size(75, 30)
        BtnExport.TabIndex = 5
        BtnExport.Text = "Export"
        BtnExport.UseVisualStyleBackColor = True
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' ShowNameColumn
        ' 
        ShowNameColumn.HeaderText = "Show Name"
        ShowNameColumn.Name = "ShowNameColumn"
        ShowNameColumn.Width = 200
        ' 
        ' ServiceColumn
        ' 
        ServiceColumn.HeaderText = "Service"
        ServiceColumn.Items.AddRange(New Object() {"ABC iView", "7 Plus", "9 Now", "All 4", "Amazon Prime", "BBC iPlayer", "CBC Gem", "CBS", "Crackle", "CTV", "CWTV", "Disney Plus", "ITV", "My 5", "Pluto", "Roku", "RTE Player", "SBS", "STV", "SVT Play", "Three Now", "Tubi", "TV4 Play", "TVNZ", "UKTV Play", "Virgin Media"})
        ServiceColumn.Name = "ServiceColumn"
        ServiceColumn.Resizable = DataGridViewTriState.True
        ServiceColumn.SortMode = DataGridViewColumnSortMode.Automatic
        ' 
        ' SeriesURLColumn
        ' 
        SeriesURLColumn.HeaderText = "Series URL"
        SeriesURLColumn.Name = "SeriesURLColumn"
        SeriesURLColumn.Width = 500
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(896, 538)
        Controls.Add(btnClose2)
        Controls.Add(btnCopy)
        Controls.Add(BtnImport)
        Controls.Add(btnSave2)
        Controls.Add(BtnExport)
        Controls.Add(btnClear2)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form3"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Devine GUI - Favorites"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnClose2 As Button
    Friend WithEvents btnCopy As Button
    Friend WithEvents btnSave2 As Button
    Friend WithEvents btnClear2 As Button
    Friend WithEvents BtnImport As Button
    Friend WithEvents BtnExport As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ShowNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents ServiceColumn As DataGridViewComboBoxColumn
    Friend WithEvents SeriesURLColumn As DataGridViewTextBoxColumn
End Class
