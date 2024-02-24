<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Captasst
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Captasst))
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.SFD = New System.Windows.Forms.SaveFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.NUD = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.NUDMinimum = New System.Windows.Forms.NumericUpDown()
        Me.NUDMaximum = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PB = New System.Windows.Forms.PictureBox()
        Me.BtnCaps = New System.Windows.Forms.Button()
        Me.BtnI = New System.Windows.Forms.Button()
        CType(Me.NUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDMinimum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDMaximum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OFD
        '
        Me.OFD.Filter = "SBV Closed Captioning Files|*.sbv|Text Files|*.txt"
        '
        'SFD
        '
        Me.SFD.Filter = "SBV Closed Captioning Files|*.sbv|Text Files|*.txt"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(154, 28)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Load Caption"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'NUD
        '
        Me.NUD.Enabled = False
        Me.NUD.Location = New System.Drawing.Point(630, 12)
        Me.NUD.Name = "NUD"
        Me.NUD.Size = New System.Drawing.Size(80, 23)
        Me.NUD.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(627, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Is Data Shown?"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(172, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "File Data"
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(12, 46)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(154, 28)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Save Caption"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'NUDMinimum
        '
        Me.NUDMinimum.Location = New System.Drawing.Point(379, 10)
        Me.NUDMinimum.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NUDMinimum.Name = "NUDMinimum"
        Me.NUDMinimum.Size = New System.Drawing.Size(90, 23)
        Me.NUDMinimum.TabIndex = 5
        Me.NUDMinimum.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'NUDMaximum
        '
        Me.NUDMaximum.Location = New System.Drawing.Point(379, 44)
        Me.NUDMaximum.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NUDMaximum.Name = "NUDMaximum"
        Me.NUDMaximum.Size = New System.Drawing.Size(89, 23)
        Me.NUDMaximum.TabIndex = 6
        Me.NUDMaximum.Value = New Decimal(New Integer() {10000, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(483, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Minimum"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(483, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Maximum"
        '
        'PB
        '
        Me.PB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PB.Enabled = False
        Me.PB.Location = New System.Drawing.Point(900, 72)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(20, 751)
        Me.PB.TabIndex = 9
        Me.PB.TabStop = False
        '
        'BtnCaps
        '
        Me.BtnCaps.Location = New System.Drawing.Point(740, 11)
        Me.BtnCaps.Name = "BtnCaps"
        Me.BtnCaps.Size = New System.Drawing.Size(180, 24)
        Me.BtnCaps.TabIndex = 10
        Me.BtnCaps.Text = "Capitalize First Word"
        Me.BtnCaps.UseVisualStyleBackColor = True
        '
        'BtnI
        '
        Me.BtnI.Location = New System.Drawing.Point(778, 44)
        Me.BtnI.Name = "BtnI"
        Me.BtnI.Size = New System.Drawing.Size(142, 22)
        Me.BtnI.TabIndex = 11
        Me.BtnI.Text = "Capitalize I"
        Me.BtnI.UseVisualStyleBackColor = True
        '
        'Captasst
        '
        Me.AcceptButton = Me.BtnCaps
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 827)
        Me.Controls.Add(Me.BtnI)
        Me.Controls.Add(Me.BtnCaps)
        Me.Controls.Add(Me.PB)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NUDMaximum)
        Me.Controls.Add(Me.NUDMinimum)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NUD)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Verdana", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Captasst"
        Me.Text = "Caption Assistant"
        CType(Me.NUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDMinimum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDMaximum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents NUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents NUDMinimum As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUDMaximum As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PB As System.Windows.Forms.PictureBox
    Friend WithEvents BtnCaps As System.Windows.Forms.Button
    Friend WithEvents BtnI As System.Windows.Forms.Button

End Class
