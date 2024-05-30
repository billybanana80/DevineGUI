<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        GroupBox1 = New GroupBox()
        TBfolder = New TextBox()
        BtnBrowse = New Button()
        Label1 = New Label()
        BtnClose = New Button()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        BtnSave = New Button()
        BtnClear = New Button()
        GroupBox2 = New GroupBox()
        TBfolder2 = New TextBox()
        BtnBrowse2 = New Button()
        Label2 = New Label()
        FolderBrowserDialog2 = New FolderBrowserDialog()
        Label3 = New Label()
        GroupBox3 = New GroupBox()
        cbService = New TextBox()
        btnCreate = New Button()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        tbPassword = New TextBox()
        tbUsername = New TextBox()
        Label4 = New Label()
        GroupBox4 = New GroupBox()
        btnRequests = New RadioButton()
        btnSetDown = New Button()
        btnCurl = New RadioButton()
        btnAria = New RadioButton()
        Label8 = New Label()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        GroupBox4.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TBfolder)
        GroupBox1.Controls.Add(BtnBrowse)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.ForeColor = Color.FromArgb(CByte(91), CByte(91), CByte(91))
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(505, 94)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Devine Folder Location (Mandatory)"
        ' 
        ' TBfolder
        ' 
        TBfolder.Location = New Point(6, 49)
        TBfolder.Name = "TBfolder"
        TBfolder.Size = New Size(396, 23)
        TBfolder.TabIndex = 4
        ' 
        ' BtnBrowse
        ' 
        BtnBrowse.ForeColor = SystemColors.ControlText
        BtnBrowse.Location = New Point(417, 44)
        BtnBrowse.Name = "BtnBrowse"
        BtnBrowse.Size = New Size(75, 30)
        BtnBrowse.TabIndex = 3
        BtnBrowse.Text = "Browse"
        BtnBrowse.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point)
        Label1.ForeColor = Color.CornflowerBlue
        Label1.Location = New Point(6, 21)
        Label1.Name = "Label1"
        Label1.Size = New Size(304, 15)
        Label1.TabIndex = 0
        Label1.Text = "Choose the location of your Devine folder, then click Save"
        ' 
        ' BtnClose
        ' 
        BtnClose.Location = New Point(429, 243)
        BtnClose.Name = "BtnClose"
        BtnClose.Size = New Size(75, 30)
        BtnClose.TabIndex = 2
        BtnClose.Text = "Close"
        BtnClose.UseVisualStyleBackColor = True
        ' 
        ' BtnSave
        ' 
        BtnSave.Location = New Point(348, 243)
        BtnSave.Name = "BtnSave"
        BtnSave.Size = New Size(75, 30)
        BtnSave.TabIndex = 3
        BtnSave.Text = "Save"
        BtnSave.UseVisualStyleBackColor = True
        ' 
        ' BtnClear
        ' 
        BtnClear.Location = New Point(267, 243)
        BtnClear.Name = "BtnClear"
        BtnClear.Size = New Size(75, 30)
        BtnClear.TabIndex = 4
        BtnClear.Text = "Clear"
        BtnClear.UseVisualStyleBackColor = True
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(TBfolder2)
        GroupBox2.Controls.Add(BtnBrowse2)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.ForeColor = Color.FromArgb(CByte(91), CByte(91), CByte(91))
        GroupBox2.Location = New Point(12, 112)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(505, 94)
        GroupBox2.TabIndex = 5
        GroupBox2.TabStop = False
        GroupBox2.Text = "Devine Downloads Location (Optional)"
        ' 
        ' TBfolder2
        ' 
        TBfolder2.Location = New Point(6, 49)
        TBfolder2.Name = "TBfolder2"
        TBfolder2.Size = New Size(396, 23)
        TBfolder2.TabIndex = 4
        ' 
        ' BtnBrowse2
        ' 
        BtnBrowse2.ForeColor = SystemColors.ControlText
        BtnBrowse2.Location = New Point(417, 44)
        BtnBrowse2.Name = "BtnBrowse2"
        BtnBrowse2.Size = New Size(75, 30)
        BtnBrowse2.TabIndex = 3
        BtnBrowse2.Text = "Browse"
        BtnBrowse2.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point)
        Label2.ForeColor = Color.CornflowerBlue
        Label2.Location = New Point(6, 21)
        Label2.Name = "Label2"
        Label2.Size = New Size(492, 15)
        Label2.TabIndex = 0
        Label2.Text = "Choose the location of your Downloads folder, then click Save to update your devine.yaml file"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.FromArgb(CByte(91), CByte(91), CByte(91))
        Label3.Location = New Point(17, 215)
        Label3.Name = "Label3"
        Label3.Size = New Size(424, 15)
        Label3.TabIndex = 6
        Label3.Text = "Note: you must restart Devine GUI after changing either of these options above"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(cbService)
        GroupBox3.Controls.Add(btnCreate)
        GroupBox3.Controls.Add(Label7)
        GroupBox3.Controls.Add(Label6)
        GroupBox3.Controls.Add(Label5)
        GroupBox3.Controls.Add(tbPassword)
        GroupBox3.Controls.Add(tbUsername)
        GroupBox3.Controls.Add(Label4)
        GroupBox3.ForeColor = Color.FromArgb(CByte(91), CByte(91), CByte(91))
        GroupBox3.Location = New Point(12, 279)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(505, 179)
        GroupBox3.TabIndex = 7
        GroupBox3.TabStop = False
        GroupBox3.Text = "Set Service Profile (Optional)"
        ' 
        ' cbService
        ' 
        cbService.Location = New Point(105, 55)
        cbService.Name = "cbService"
        cbService.Size = New Size(149, 23)
        cbService.TabIndex = 9
        ' 
        ' btnCreate
        ' 
        btnCreate.ForeColor = SystemColors.ControlText
        btnCreate.Location = New Point(416, 122)
        btnCreate.Name = "btnCreate"
        btnCreate.Size = New Size(75, 30)
        btnCreate.TabIndex = 8
        btnCreate.Text = "Create"
        btnCreate.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.ForeColor = SystemColors.ControlText
        Label7.Location = New Point(6, 130)
        Label7.Name = "Label7"
        Label7.Size = New Size(57, 15)
        Label7.TabIndex = 7
        Label7.Text = "Password"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.ForeColor = SystemColors.ControlText
        Label6.Location = New Point(6, 91)
        Label6.Name = "Label6"
        Label6.Size = New Size(60, 15)
        Label6.TabIndex = 6
        Label6.Text = "Username"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.ForeColor = SystemColors.ControlText
        Label5.Location = New Point(6, 55)
        Label5.Name = "Label5"
        Label5.Size = New Size(95, 15)
        Label5.TabIndex = 5
        Label5.Text = "Service Name/ID"
        ' 
        ' tbPassword
        ' 
        tbPassword.Location = New Point(105, 122)
        tbPassword.Name = "tbPassword"
        tbPassword.Size = New Size(279, 23)
        tbPassword.TabIndex = 4
        ' 
        ' tbUsername
        ' 
        tbUsername.Location = New Point(105, 88)
        tbUsername.Name = "tbUsername"
        tbUsername.Size = New Size(279, 23)
        tbUsername.TabIndex = 3
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point)
        Label4.ForeColor = Color.CornflowerBlue
        Label4.Location = New Point(6, 21)
        Label4.Name = "Label4"
        Label4.Size = New Size(443, 15)
        Label4.TabIndex = 1
        Label4.Text = "Type the Service name (eg: ALL4), enter a Username and Password and click Create"
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(btnRequests)
        GroupBox4.Controls.Add(btnSetDown)
        GroupBox4.Controls.Add(btnCurl)
        GroupBox4.Controls.Add(btnAria)
        GroupBox4.Controls.Add(Label8)
        GroupBox4.ForeColor = Color.FromArgb(CByte(91), CByte(91), CByte(91))
        GroupBox4.Location = New Point(12, 464)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(505, 75)
        GroupBox4.TabIndex = 8
        GroupBox4.TabStop = False
        GroupBox4.Text = "Downloader (Optional)"
        ' 
        ' btnRequests
        ' 
        btnRequests.AutoSize = True
        btnRequests.ForeColor = SystemColors.ControlText
        btnRequests.Location = New Point(199, 39)
        btnRequests.Name = "btnRequests"
        btnRequests.Size = New Size(69, 19)
        btnRequests.TabIndex = 10
        btnRequests.TabStop = True
        btnRequests.Text = "requests"
        btnRequests.UseVisualStyleBackColor = True
        ' 
        ' btnSetDown
        ' 
        btnSetDown.ForeColor = SystemColors.ControlText
        btnSetDown.Location = New Point(416, 32)
        btnSetDown.Name = "btnSetDown"
        btnSetDown.Size = New Size(75, 30)
        btnSetDown.TabIndex = 9
        btnSetDown.Text = "Set"
        btnSetDown.UseVisualStyleBackColor = True
        ' 
        ' btnCurl
        ' 
        btnCurl.AutoSize = True
        btnCurl.ForeColor = SystemColors.ControlText
        btnCurl.Location = New Point(77, 39)
        btnCurl.Name = "btnCurl"
        btnCurl.Size = New Size(116, 19)
        btnCurl.TabIndex = 3
        btnCurl.TabStop = True
        btnCurl.Text = "curl_impersonate"
        btnCurl.UseVisualStyleBackColor = True
        ' 
        ' btnAria
        ' 
        btnAria.AutoSize = True
        btnAria.ForeColor = SystemColors.ControlText
        btnAria.Location = New Point(15, 39)
        btnAria.Name = "btnAria"
        btnAria.Size = New Size(56, 19)
        btnAria.TabIndex = 2
        btnAria.TabStop = True
        btnAria.Text = "aria2c"
        btnAria.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point)
        Label8.ForeColor = Color.CornflowerBlue
        Label8.Location = New Point(6, 19)
        Label8.Name = "Label8"
        Label8.Size = New Size(234, 15)
        Label8.TabIndex = 1
        Label8.Text = "Choose the downloader option and click Set"
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(529, 552)
        Controls.Add(GroupBox4)
        Controls.Add(GroupBox3)
        Controls.Add(Label3)
        Controls.Add(GroupBox2)
        Controls.Add(BtnClear)
        Controls.Add(BtnSave)
        Controls.Add(BtnClose)
        Controls.Add(GroupBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form2"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Devine GUI - Options"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnBrowse As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents TBfolder As TextBox
    Friend WithEvents BtnSave As Button
    Friend WithEvents BtnClear As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TBfolder2 As TextBox
    Friend WithEvents BtnBrowse2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents FolderBrowserDialog2 As FolderBrowserDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tbPassword As TextBox
    Friend WithEvents tbUsername As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCreate As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cbService As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnCurl As RadioButton
    Friend WithEvents btnAria As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents btnSetDown As Button
    Friend WithEvents btnRequests As RadioButton
End Class
