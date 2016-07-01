<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarks
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
        Me.DGVMarks = New System.Windows.Forms.DataGridView()
        Me.btnLoadDB = New System.Windows.Forms.Button()
        Me.txtValue = New System.Windows.Forms.TextBox()
        CType(Me.DGVMarks, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnLoadDB.Location = New System.Drawing.Point(302, 415)
        Me.btnLoadDB.Name = "btnLoadDB"
        Me.btnLoadDB.Size = New System.Drawing.Size(111, 23)
        Me.btnLoadDB.TabIndex = 1
        Me.btnLoadDB.Text = "Load Database"
        Me.btnLoadDB.UseVisualStyleBackColor = True
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(13, 415)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(198, 20)
        Me.txtValue.TabIndex = 2
        '
        'frmMarks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 450)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.btnLoadDB)
        Me.Controls.Add(Me.DGVMarks)
        Me.Name = "frmMarks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Marks"
        CType(Me.DGVMarks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGVMarks As DataGridView
    Friend WithEvents btnLoadDB As Button
    Friend WithEvents txtValue As TextBox
End Class
