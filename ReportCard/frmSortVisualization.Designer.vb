<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSortVisualization
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
        Me.btnLoadDB = New System.Windows.Forms.Button()
        Me.btnSortData = New System.Windows.Forms.Button()
        Me.tbSpeed = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkReverseSort = New System.Windows.Forms.CheckBox()
        Me.cboColumn = New System.Windows.Forms.ComboBox()
        Me.cmdLoadData = New System.Windows.Forms.Button()
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLoadDB
        '
        Me.btnLoadDB.Location = New System.Drawing.Point(367, 12)
        Me.btnLoadDB.Name = "btnLoadDB"
        Me.btnLoadDB.Size = New System.Drawing.Size(120, 23)
        Me.btnLoadDB.TabIndex = 2
        Me.btnLoadDB.Text = "Load Database"
        Me.btnLoadDB.UseVisualStyleBackColor = True
        '
        'btnSortData
        '
        Me.btnSortData.Location = New System.Drawing.Point(367, 90)
        Me.btnSortData.Name = "btnSortData"
        Me.btnSortData.Size = New System.Drawing.Size(120, 23)
        Me.btnSortData.TabIndex = 3
        Me.btnSortData.Text = "Sort Data"
        Me.btnSortData.UseVisualStyleBackColor = True
        '
        'tbSpeed
        '
        Me.tbSpeed.Location = New System.Drawing.Point(374, 142)
        Me.tbSpeed.Maximum = 20
        Me.tbSpeed.Name = "tbSpeed"
        Me.tbSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbSpeed.Size = New System.Drawing.Size(111, 45)
        Me.tbSpeed.TabIndex = 4
        Me.tbSpeed.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(386, 173)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Animation Speed"
        '
        'chkReverseSort
        '
        Me.chkReverseSort.AutoSize = True
        Me.chkReverseSort.Location = New System.Drawing.Point(383, 121)
        Me.chkReverseSort.Name = "chkReverseSort"
        Me.chkReverseSort.Size = New System.Drawing.Size(94, 17)
        Me.chkReverseSort.TabIndex = 6
        Me.chkReverseSort.Text = "Reverse Sort?"
        Me.chkReverseSort.UseVisualStyleBackColor = True
        '
        'cboColumn
        '
        Me.cboColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColumn.FormattingEnabled = True
        Me.cboColumn.Location = New System.Drawing.Point(367, 39)
        Me.cboColumn.Name = "cboColumn"
        Me.cboColumn.Size = New System.Drawing.Size(120, 21)
        Me.cboColumn.TabIndex = 7
        '
        'cmdLoadData
        '
        Me.cmdLoadData.Location = New System.Drawing.Point(367, 64)
        Me.cmdLoadData.Name = "cmdLoadData"
        Me.cmdLoadData.Size = New System.Drawing.Size(120, 23)
        Me.cmdLoadData.TabIndex = 8
        Me.cmdLoadData.Text = "Load Data"
        Me.cmdLoadData.UseVisualStyleBackColor = True
        '
        'frmSortVisualization
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 458)
        Me.Controls.Add(Me.cmdLoadData)
        Me.Controls.Add(Me.cboColumn)
        Me.Controls.Add(Me.chkReverseSort)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbSpeed)
        Me.Controls.Add(Me.btnSortData)
        Me.Controls.Add(Me.btnLoadDB)
        Me.Name = "frmSortVisualization"
        Me.Text = "Sort Visualization"
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnLoadDB As Button
    Friend WithEvents btnSortData As Button
    Friend WithEvents tbSpeed As TrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents chkReverseSort As CheckBox
    Friend WithEvents cboColumn As ComboBox
    Friend WithEvents cmdLoadData As Button
End Class
