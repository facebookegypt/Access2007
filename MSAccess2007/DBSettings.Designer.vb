<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DBSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DBSettings))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.LocationTxt = New System.Windows.Forms.TextBox()
        Me.lblBrowse = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DBENGTxt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.AccssInstledTxt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FileSignText = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Database file location"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 429)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(717, 25)
        Me.ToolStrip1.TabIndex = 18
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BackgroundWorker1
        '
        '
        'LocationTxt
        '
        Me.LocationTxt.Location = New System.Drawing.Point(15, 25)
        Me.LocationTxt.Name = "LocationTxt"
        Me.LocationTxt.ReadOnly = True
        Me.LocationTxt.Size = New System.Drawing.Size(627, 20)
        Me.LocationTxt.TabIndex = 19
        '
        'lblBrowse
        '
        Me.lblBrowse.AutoSize = True
        Me.lblBrowse.BackColor = System.Drawing.Color.Transparent
        Me.lblBrowse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblBrowse.Location = New System.Drawing.Point(648, 28)
        Me.lblBrowse.Name = "lblBrowse"
        Me.lblBrowse.Size = New System.Drawing.Size(44, 15)
        Me.lblBrowse.TabIndex = 20
        Me.lblBrowse.Text = "Browse"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 193)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "File Info"
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(12, 209)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(298, 64)
        Me.TreeView1.TabIndex = 23
        '
        'TreeView2
        '
        Me.TreeView2.Location = New System.Drawing.Point(321, 64)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.ShowNodeToolTips = True
        Me.TreeView2.Size = New System.Drawing.Size(204, 209)
        Me.TreeView2.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(318, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Contents"
        '
        'DBENGTxt
        '
        Me.DBENGTxt.Location = New System.Drawing.Point(15, 64)
        Me.DBENGTxt.Multiline = True
        Me.DBENGTxt.Name = "DBENGTxt"
        Me.DBENGTxt.ReadOnly = True
        Me.DBENGTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.DBENGTxt.Size = New System.Drawing.Size(295, 63)
        Me.DBENGTxt.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(157, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Access Database Engine Found"
        '
        'AccssInstledTxt
        '
        Me.AccssInstledTxt.Location = New System.Drawing.Point(12, 146)
        Me.AccssInstledTxt.Multiline = True
        Me.AccssInstledTxt.Name = "AccssInstledTxt"
        Me.AccssInstledTxt.ReadOnly = True
        Me.AccssInstledTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.AccssInstledTxt.Size = New System.Drawing.Size(298, 44)
        Me.AccssInstledTxt.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "MicroSoft Access Installed"
        '
        'FileSignText
        '
        Me.FileSignText.Location = New System.Drawing.Point(531, 64)
        Me.FileSignText.Multiline = True
        Me.FileSignText.Name = "FileSignText"
        Me.FileSignText.ReadOnly = True
        Me.FileSignText.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.FileSignText.Size = New System.Drawing.Size(161, 44)
        Me.FileSignText.TabIndex = 31
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(528, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "File Signiture"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.DarkRed
        Me.Label7.Location = New System.Drawing.Point(534, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 32
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 276)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(693, 166)
        Me.DataGridView1.TabIndex = 33
        '
        'DBSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 454)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.FileSignText)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.AccssInstledTxt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DBENGTxt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TreeView2)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblBrowse)
        Me.Controls.Add(Me.LocationTxt)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "DBSettings"
        Me.Text = "Database Settings"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents LocationTxt As TextBox
    Friend WithEvents lblBrowse As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents TreeView2 As TreeView
    Friend WithEvents Label2 As Label
    Friend WithEvents DBENGTxt As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents AccssInstledTxt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents FileSignText As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents DataGridView1 As DataGridView
End Class
