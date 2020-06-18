<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DisplayDGV = New System.Windows.Forms.DataGridView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MicrosoftAccess2007ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DropboxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoogleDriveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SAPCrystalReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.DateLabel = New System.Windows.Forms.ToolStripLabel()
        Me.LblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.DropLblUid = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.StopStrip = New System.Windows.Forms.ToolStripButton()
        Me.ChildrenTextBox = New System.Windows.Forms.TextBox()
        Me.FullNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BasicInfoGroupBox = New System.Windows.Forms.GroupBox()
        Me.MaritalComboBox = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BirthDateDTP = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FullAddressTextBox = New System.Windows.Forms.TextBox()
        Me.PersonalPictureBox = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        CType(Me.DisplayDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.BasicInfoGroupBox.SuspendLayout()
        CType(Me.PersonalPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DisplayDGV
        '
        Me.DisplayDGV.AllowUserToDeleteRows = False
        Me.DisplayDGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DisplayDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DisplayDGV.Location = New System.Drawing.Point(12, 228)
        Me.DisplayDGV.Name = "DisplayDGV"
        Me.DisplayDGV.Size = New System.Drawing.Size(874, 168)
        Me.DisplayDGV.TabIndex = 3
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Acc32Ico")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MicrosoftAccess2007ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.ShowItemToolTips = True
        Me.MenuStrip1.Size = New System.Drawing.Size(898, 39)
        Me.MenuStrip1.TabIndex = 8
        '
        'MicrosoftAccess2007ToolStripMenuItem
        '
        Me.MicrosoftAccess2007ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SearchToolStripMenuItem, Me.UpdateToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem1, Me.BackupToolStripMenuItem, Me.ToolStripMenuItem2, Me.SAPCrystalReportsToolStripMenuItem, Me.ToolStripMenuItem3, Me.CloseToolStripMenuItem})
        Me.MicrosoftAccess2007ToolStripMenuItem.Image = Global.MSAccess2007.My.Resources.Resources.Office_Access_2007_Icon_64
        Me.MicrosoftAccess2007ToolStripMenuItem.Name = "MicrosoftAccess2007ToolStripMenuItem"
        Me.MicrosoftAccess2007ToolStripMenuItem.Size = New System.Drawing.Size(109, 35)
        Me.MicrosoftAccess2007ToolStripMenuItem.Text = "Microsoft Access"
        Me.MicrosoftAccess2007ToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = Global.MSAccess2007.My.Resources.Resources.folder_new
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = Global.MSAccess2007.My.Resources.Resources.folder_add
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Image = Global.MSAccess2007.My.Resources.Resources.folder_search
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F"
        Me.SearchToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SearchToolStripMenuItem.Text = "Search"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Enabled = False
        Me.UpdateToolStripMenuItem.Image = Global.MSAccess2007.My.Resources.Resources.folder_edit
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.UpdateToolStripMenuItem.Text = "Update"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Enabled = False
        Me.DeleteToolStripMenuItem.Image = Global.MSAccess2007.My.Resources.Resources.folder_delete
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeyDisplayString = "Del"
        Me.DeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(174, 6)
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DropboxToolStripMenuItem, Me.GoogleDriveToolStripMenuItem})
        Me.BackupToolStripMenuItem.Image = Global.MSAccess2007.My.Resources.Resources.folder_wrench
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'DropboxToolStripMenuItem
        '
        Me.DropboxToolStripMenuItem.Image = Global.MSAccess2007.My.Resources.Resources.Dropbox175x175
        Me.DropboxToolStripMenuItem.Name = "DropboxToolStripMenuItem"
        Me.DropboxToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.DropboxToolStripMenuItem.Text = "Dropbox"
        '
        'GoogleDriveToolStripMenuItem
        '
        Me.GoogleDriveToolStripMenuItem.Image = Global.MSAccess2007.My.Resources.Resources.Google_Drive_icon
        Me.GoogleDriveToolStripMenuItem.Name = "GoogleDriveToolStripMenuItem"
        Me.GoogleDriveToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.GoogleDriveToolStripMenuItem.Text = "Google Drive"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(174, 6)
        '
        'SAPCrystalReportsToolStripMenuItem
        '
        Me.SAPCrystalReportsToolStripMenuItem.Image = Global.MSAccess2007.My.Resources.Resources.folder_picture
        Me.SAPCrystalReportsToolStripMenuItem.Name = "SAPCrystalReportsToolStripMenuItem"
        Me.SAPCrystalReportsToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SAPCrystalReportsToolStripMenuItem.Text = "SAP Crystal Reports"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(174, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Image = Global.MSAccess2007.My.Resources.Resources.close_2
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateLabel, Me.LblStatus, Me.DropLblUid, Me.ToolStripProgressBar1, Me.StopStrip})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 399)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(898, 25)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 10
        '
        'DateLabel
        '
        Me.DateLabel.BackColor = System.Drawing.Color.Transparent
        Me.DateLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.DateLabel.Name = "DateLabel"
        Me.DateLabel.Size = New System.Drawing.Size(0, 22)
        '
        'LblStatus
        '
        Me.LblStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(0, 22)
        '
        'DropLblUid
        '
        Me.DropLblUid.Name = "DropLblUid"
        Me.DropLblUid.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 22)
        Me.ToolStripProgressBar1.Visible = False
        '
        'StopStrip
        '
        Me.StopStrip.BackColor = System.Drawing.Color.Transparent
        Me.StopStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StopStrip.Image = Global.MSAccess2007.My.Resources.Resources.StopBlue
        Me.StopStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.StopStrip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.StopStrip.Name = "StopStrip"
        Me.StopStrip.Size = New System.Drawing.Size(23, 22)
        Me.StopStrip.ToolTipText = "Stop"
        Me.StopStrip.Visible = False
        '
        'ChildrenTextBox
        '
        Me.ChildrenTextBox.Location = New System.Drawing.Point(143, 135)
        Me.ChildrenTextBox.Name = "ChildrenTextBox"
        Me.ChildrenTextBox.Size = New System.Drawing.Size(103, 20)
        Me.ChildrenTextBox.TabIndex = 3
        Me.ChildrenTextBox.Text = "0"
        Me.ChildrenTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FullNameTextBox
        '
        Me.FullNameTextBox.Location = New System.Drawing.Point(143, 32)
        Me.FullNameTextBox.Name = "FullNameTextBox"
        Me.FullNameTextBox.Size = New System.Drawing.Size(228, 20)
        Me.FullNameTextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(140, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Full Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Click on photo to change it"
        '
        'BasicInfoGroupBox
        '
        Me.BasicInfoGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BasicInfoGroupBox.Controls.Add(Me.MaritalComboBox)
        Me.BasicInfoGroupBox.Controls.Add(Me.ChildrenTextBox)
        Me.BasicInfoGroupBox.Controls.Add(Me.Label6)
        Me.BasicInfoGroupBox.Controls.Add(Me.BirthDateDTP)
        Me.BasicInfoGroupBox.Controls.Add(Me.Label5)
        Me.BasicInfoGroupBox.Controls.Add(Me.Label4)
        Me.BasicInfoGroupBox.Controls.Add(Me.Label3)
        Me.BasicInfoGroupBox.Controls.Add(Me.FullAddressTextBox)
        Me.BasicInfoGroupBox.Controls.Add(Me.Label1)
        Me.BasicInfoGroupBox.Controls.Add(Me.Label2)
        Me.BasicInfoGroupBox.Controls.Add(Me.FullNameTextBox)
        Me.BasicInfoGroupBox.Controls.Add(Me.PersonalPictureBox)
        Me.BasicInfoGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BasicInfoGroupBox.Location = New System.Drawing.Point(188, 42)
        Me.BasicInfoGroupBox.Name = "BasicInfoGroupBox"
        Me.BasicInfoGroupBox.Size = New System.Drawing.Size(698, 180)
        Me.BasicInfoGroupBox.TabIndex = 15
        Me.BasicInfoGroupBox.TabStop = False
        Me.BasicInfoGroupBox.Text = "Basic Info Section"
        '
        'MaritalComboBox
        '
        Me.MaritalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MaritalComboBox.FormattingEnabled = True
        Me.MaritalComboBox.Location = New System.Drawing.Point(464, 71)
        Me.MaritalComboBox.MaxDropDownItems = 5
        Me.MaritalComboBox.Name = "MaritalComboBox"
        Me.MaritalComboBox.Size = New System.Drawing.Size(200, 21)
        Me.MaritalComboBox.Sorted = True
        Me.MaritalComboBox.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(461, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Marital Status"
        '
        'BirthDateDTP
        '
        Me.BirthDateDTP.Checked = False
        Me.BirthDateDTP.CustomFormat = "dd/MMMM/yyyy"
        Me.BirthDateDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.BirthDateDTP.Location = New System.Drawing.Point(464, 29)
        Me.BirthDateDTP.Name = "BirthDateDTP"
        Me.BirthDateDTP.Size = New System.Drawing.Size(200, 20)
        Me.BirthDateDTP.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(461, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Birth Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(140, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "How many children ?"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(140, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Full Address"
        '
        'FullAddressTextBox
        '
        Me.FullAddressTextBox.Location = New System.Drawing.Point(143, 71)
        Me.FullAddressTextBox.Multiline = True
        Me.FullAddressTextBox.Name = "FullAddressTextBox"
        Me.FullAddressTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.FullAddressTextBox.Size = New System.Drawing.Size(228, 45)
        Me.FullAddressTextBox.TabIndex = 2
        '
        'PersonalPictureBox
        '
        Me.PersonalPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.PersonalPictureBox.ErrorImage = Global.MSAccess2007.My.Resources.Resources.no_photo
        Me.PersonalPictureBox.Image = Global.MSAccess2007.My.Resources.Resources.no_photo
        Me.PersonalPictureBox.Location = New System.Drawing.Point(6, 19)
        Me.PersonalPictureBox.Name = "PersonalPictureBox"
        Me.PersonalPictureBox.Size = New System.Drawing.Size(128, 128)
        Me.PersonalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PersonalPictureBox.TabIndex = 12
        Me.PersonalPictureBox.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 424)
        Me.Controls.Add(Me.BasicInfoGroupBox)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DisplayDGV)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Visual Basic 2015 with Microsoft Access Database 2007 Tutorial - Evry1falls"
        CType(Me.DisplayDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.BasicInfoGroupBox.ResumeLayout(False)
        Me.BasicInfoGroupBox.PerformLayout()
        CType(Me.PersonalPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DisplayDGV As DataGridView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MicrosoftAccess2007ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents BackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents SAPCrystalReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DateLabel As ToolStripLabel
    Friend WithEvents FullNameTextBox As TextBox
    Friend WithEvents PersonalPictureBox As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BasicInfoGroupBox As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents FullAddressTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BirthDateDTP As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ChildrenTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents MaritalComboBox As ComboBox
    Friend WithEvents DropboxToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GoogleDriveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LblStatus As ToolStripLabel
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents DropLblUid As ToolStripLabel
    Public WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents StopStrip As ToolStripButton
End Class
