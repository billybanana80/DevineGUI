<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Config
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Config))
        rtbConfig = New RichTextBox()
        btnSave = New Button()
        btnClose = New Button()
        lblConfig = New Label()
        SuspendLayout()
        ' 
        ' rtbConfig
        ' 
        rtbConfig.Location = New Point(12, 41)
        rtbConfig.Name = "rtbConfig"
        rtbConfig.Size = New Size(550, 669)
        rtbConfig.TabIndex = 0
        rtbConfig.Text = ""
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(406, 716)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 30)
        btnSave.TabIndex = 1
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(487, 716)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 30)
        btnClose.TabIndex = 2
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' lblConfig
        ' 
        lblConfig.AutoSize = True
        lblConfig.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point)
        lblConfig.ForeColor = Color.CornflowerBlue
        lblConfig.Location = New Point(12, 11)
        lblConfig.Name = "lblConfig"
        lblConfig.Size = New Size(356, 15)
        lblConfig.TabIndex = 3
        lblConfig.Text = "Click Save to retain any changes you make to your devine.yaml file"
        ' 
        ' Config
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(574, 754)
        Controls.Add(lblConfig)
        Controls.Add(btnClose)
        Controls.Add(btnSave)
        Controls.Add(rtbConfig)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Config"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Devine GUI - Config"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents rtbConfig As RichTextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents lblConfig As Label
End Class
