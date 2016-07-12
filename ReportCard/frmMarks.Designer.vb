<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMarks
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
        Me.DGVMarks = New System.Windows.Forms.DataGridView()
        Me.btnLoadDB = New System.Windows.Forms.Button()
        Me.cboColumn = New System.Windows.Forms.ComboBox()
        Me.cmdSort = New System.Windows.Forms.Button()
        Me.tbSpeed = New System.Windows.Forms.TrackBar()
        Me.cboRankColumn = New System.Windows.Forms.ComboBox()
        CType(Me.DGVMarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGVMarks
        '
        Me.DGVMarks.AllowUserToAddRows = False
        Me.DGVMarks.AllowUserToDeleteRows = False
        Me.DGVMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVMarks.Location = New System.Drawing.Point(12, 12)
        Me.DGVMarks.Name = "DGVMarks"
        Me.DGVMarks.ReadOnly = True
        Me.DGVMarks.Size = New System.Drawing.Size(401, 397)
        Me.DGVMarks.TabIndex = 0
        '
        'btnLoadDB
        '
        Me.btnLoadDB.Location = New System.Drawing.Point(532, 415)
        Me.btnLoadDB.Name = "btnLoadDB"
        Me.btnLoadDB.Size = New System.Drawing.Size(111, 23)
        Me.btnLoadDB.TabIndex = 1
        Me.btnLoadDB.Text = "Load Database"
        Me.btnLoadDB.UseVisualStyleBackColor = True
        '
        'cboColumn
        '
        Me.cboColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColumn.FormattingEnabled = True
        Me.cboColumn.Location = New System.Drawing.Point(12, 417)
        Me.cboColumn.Name = "cboColumn"
        Me.cboColumn.Size = New System.Drawing.Size(121, 21)
        Me.cboColumn.TabIndex = 2
        '
        'cmdSort
        '
        Me.cmdSort.Location = New System.Drawing.Point(374, 415)
        Me.cmdSort.Name = "cmdSort"
        Me.cmdSort.Size = New System.Drawing.Size(71, 23)
        Me.cmdSort.TabIndex = 3
        Me.cmdSort.Text = "Sort Data"
        Me.cmdSort.UseVisualStyleBackColor = True
        '
        'tbSpeed
        '
        Me.tbSpeed.Location = New System.Drawing.Point(264, 415)
        Me.tbSpeed.Maximum = 20
        Me.tbSpeed.Name = "tbSpeed"
        Me.tbSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbSpeed.Size = New System.Drawing.Size(104, 45)
        Me.tbSpeed.TabIndex = 4
        '
        'cboRankColumn
        '
        Me.cboRankColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRankColumn.FormattingEnabled = True
        Me.cboRankColumn.Location = New System.Drawing.Point(139, 417)
        Me.cboRankColumn.Name = "cboRankColumn"
        Me.cboRankColumn.Size = New System.Drawing.Size(121, 21)
        Me.cboRankColumn.TabIndex = 5
        '
        'frmMarks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 450)
        Me.Controls.Add(Me.cboRankColumn)
        Me.Controls.Add(Me.tbSpeed)
        Me.Controls.Add(Me.cmdSort)
        Me.Controls.Add(Me.cboColumn)
        Me.Controls.Add(Me.btnLoadDB)
        Me.Controls.Add(Me.DGVMarks)
        Me.Name = "frmMarks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Marks"
        CType(Me.DGVMarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGVMarks As DataGridView
    Friend WithEvents btnLoadDB As Button
    Friend WithEvents cboColumn As ComboBox
    Friend WithEvents cmdSort As Button
    Friend WithEvents tbSpeed As TrackBar
    Friend WithEvents cboRankColumn As ComboBox
End Class
