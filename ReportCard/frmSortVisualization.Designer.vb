﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLoadDB
        '
        Me.btnLoadDB.Location = New System.Drawing.Point(393, 12)
        Me.btnLoadDB.Name = "btnLoadDB"
        Me.btnLoadDB.Size = New System.Drawing.Size(111, 23)
        Me.btnLoadDB.TabIndex = 2
        Me.btnLoadDB.Text = "Load Database"
        Me.btnLoadDB.UseVisualStyleBackColor = True
        '
        'btnSortData
        '
        Me.btnSortData.Location = New System.Drawing.Point(393, 41)
        Me.btnSortData.Name = "btnSortData"
        Me.btnSortData.Size = New System.Drawing.Size(111, 23)
        Me.btnSortData.TabIndex = 3
        Me.btnSortData.Text = "Sort Data"
        Me.btnSortData.UseVisualStyleBackColor = True
        '
        'tbSpeed
        '
        Me.tbSpeed.Location = New System.Drawing.Point(393, 88)
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
        Me.Label1.Location = New System.Drawing.Point(405, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Animation Speed"
        '
        'chkReverseSort
        '
        Me.chkReverseSort.AutoSize = True
        Me.chkReverseSort.Location = New System.Drawing.Point(402, 67)
        Me.chkReverseSort.Name = "chkReverseSort"
        Me.chkReverseSort.Size = New System.Drawing.Size(94, 17)
        Me.chkReverseSort.TabIndex = 6
        Me.chkReverseSort.Text = "Reverse Sort?"
        Me.chkReverseSort.UseVisualStyleBackColor = True
        '
        'frmSortVisualization
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 458)
        Me.Controls.Add(Me.chkReverseSort)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbSpeed)
        Me.Controls.Add(Me.btnSortData)
        Me.Controls.Add(Me.btnLoadDB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
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
End Class
