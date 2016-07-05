Imports System.Data
Imports System.Data.OleDb
Imports System.Threading
Public Class frmMarks
    Private CurrentDatabase As String
    Private Connection As OleDbConnection
    Private LastError As String
    Private colCollection As Collection
    Private iSwapSpeed As Integer

    Private Sub frmMarks_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        DGVMarks.Width = Me.Width - 40
        DGVMarks.Height = Me.Height - 90
        btnLoadDB.Left = Me.Width - 27 - btnLoadDB.Width
        btnLoadDB.Top = Me.Height - 50 - btnLoadDB.Height
    End Sub

    Private Sub LoadData()
        Dim cmd As OleDbCommand
        Dim rs As OleDbDataReader
        Dim sSQL As String
        Dim iFieldCount As Integer
        Dim iRowCount As Integer
        cmd = Connection.CreateCommand()
        sSQL = "SELECT * FROM STUDENT"
        cmd.CommandText = sSQL
        rs = cmd.ExecuteReader()
        If rs.HasRows() Then
            InitializeGrid(rs)
            While rs.Read()
                With DGVMarks.Rows
                    iRowCount = .Add()
                    For iFieldCount = 0 To rs.FieldCount - 1
                        .Item(iRowCount).Cells.Item(iFieldCount + 1).Value = (rs.Item(iFieldCount).ToString())
                    Next
                End With
            End While
            cmdSort.Enabled = True
            cboColumn.Enabled = True
        Else
            MsgBox("No records found!")
        End If
    End Sub

    Private Function OpenConnection(sDatabase As String) As Boolean
        Dim sConnectString As String
        'Microsoft.Jet.OLEDB.4.0
        'Microsoft.ACE.OLEDB.12.0
        sConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & sDatabase & ";"
        If CurrentDatabase <> sDatabase Then
            If Connection IsNot Nothing Then
                If Connection.State = 1 Then
                    Try
                        Connection.Close()
                        Connection.ConnectionString = sConnectString
                        Connection.Open()
                        OpenConnection = True
                        CurrentDatabase = sDatabase
                        Exit Function
                    Catch ex As Exception
                        LastError = ex.Message()
                        Connection = Nothing
                        OpenConnection = False
                    End Try
                Else
                    Connection = Nothing
                    Connection = New OleDbConnection()
                    Connection.ConnectionString = sConnectString
                    Try
                        Connection.Open()
                        OpenConnection = True
                        CurrentDatabase = sDatabase
                        Exit Function
                    Catch ex As Exception
                        LastError = ex.Message()
                        OpenConnection = False
                        Connection = Nothing
                        Exit Function
                    End Try
                End If
            Else
                Connection = New OleDbConnection()
                Connection.ConnectionString = sConnectString
                Try
                    Connection.Open()
                    OpenConnection = True
                    CurrentDatabase = sDatabase
                    Exit Function
                Catch ex As Exception
                    LastError = ex.Message()
                    OpenConnection = False
                    Connection = Nothing
                    Exit Function
                End Try
            End If
        Else
            If Connection IsNot Nothing Then
                If Connection.State = 1 Then
                    OpenConnection = True
                    Exit Function
                Else
                    Try
                        Connection.Close()
                        Connection.ConnectionString = sConnectString
                        Connection.Open()
                        OpenConnection = True
                        Exit Function
                    Catch ex As Exception
                        LastError = ex.Message()
                        Connection = Nothing
                        OpenConnection = False
                    End Try
                End If
            Else
                Connection = New OleDbConnection()
                Connection.ConnectionString = sConnectString
                Try
                    Connection.Open()
                    OpenConnection = True
                    Exit Function
                Catch ex As Exception
                    LastError = ex.Message()
                    OpenConnection = False
                    Connection = Nothing
                    Exit Function
                End Try
            End If
        End If
    End Function

    Private Sub InitializeGrid(rs As OleDbDataReader)
        Dim iColCount As Integer
        For iColCount = 0 To DGVMarks.Columns.Count - 1
            DGVMarks.Columns.RemoveAt(0)
        Next
        Dim col1 As DataGridViewTextBoxColumn
        colCollection = New Collection()
        cboColumn.Items.Clear()

        col1 = New DataGridViewTextBoxColumn()
        col1.Name = "RANKING"
        col1.HeaderText = "Ranking"
        col1.ReadOnly = True
        col1.SortMode = DataGridViewColumnSortMode.NotSortable
        col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        DGVMarks.Columns.Add(col1)
        For iColCount = 0 To rs.FieldCount - 1
            With DGVMarks.Columns
                col1 = New DataGridViewTextBoxColumn()
                col1.Name = rs.GetName(iColCount)
                col1.HeaderText = rs.GetName(iColCount)
                Select Case rs.GetFieldType(iColCount).Name
                    Case "Int32"
                        col1.DefaultCellStyle.Format = "N2"
                        colCollection.Add("I", "KEY::" & iColCount)
                        cboColumn.Items.Add(col1.Name)
                    Case Else
                        colCollection.Add("S", "KEY::" & iColCount)
                End Select
                col1.ReadOnly = True
                col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                col1.SortMode = DataGridViewColumnSortMode.NotSortable
                .Add(col1)
            End With
        Next
        DGVMarks.MultiSelect = False

    End Sub

    Private Sub btnLoadDB_Click(sender As Object, e As EventArgs) Handles btnLoadDB.Click
        Dim oFlDlg As New OpenFileDialog
        oFlDlg.Filter = "Access Database|*.mdb;*.accdb"
        If oFlDlg.ShowDialog() = DialogResult.OK Then
            If OpenConnection(oFlDlg.FileName) Then
                LoadData()
                If DGVMarks.Rows.Count > 1 Then
                    DGVMarks.Focus()
                    DGVMarks.Rows.Item(0).Selected = True
                End If
            Else
                MsgBox("Error loading database!" & vbCrLf & LastError)
            End If
        End If
    End Sub

    Private Sub DGVMarks_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles DGVMarks.SortCompare
        If colCollection("KEY::" & e.Column.Index) = "I" Then
            If Integer.Parse(e.CellValue1) > Integer.Parse(e.CellValue2) Then
                e.SortResult = 1
            Else
                e.SortResult = -1
            End If
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub DGVMarks_KeyDown(sender As Object, e As KeyEventArgs) Handles DGVMarks.KeyDown
        If e.KeyCode = Asc(vbCr) Then
            If DGVMarks.CurrentCell IsNot Nothing Then
                If DGVMarks.CurrentCell.ColumnIndex < DGVMarks.ColumnCount - 2 Then
                    DGVMarks.CurrentCell = DGVMarks.CurrentRow.Cells.Item(DGVMarks.CurrentCell.ColumnIndex + 1)
                    DGVMarks.CurrentCell.OwningRow.Selected = True
                ElseIf DGVMarks.CurrentRow.Index < DGVMarks.Rows.Count - 1 Then
                    DGVMarks.CurrentCell = DGVMarks.Rows.Item(DGVMarks.CurrentRow.Index + 1).Cells.Item(0)
                    DGVMarks.CurrentCell.OwningRow.Selected = True
                End If
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub frmMarks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdSort.Enabled = False
        cboColumn.Enabled = False
        cboColumn.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub cmdSort_Click(sender As Object, e As EventArgs) Handles cmdSort.Click
        If cboColumn.SelectedIndex > 0 Then
            BubbleSort()
            MsgBox("Sorting complete!")
        Else
            MsgBox("Select a column to sort on!!")
        End If
    End Sub

    Private Sub tbSpeed_Scroll(sender As Object, e As EventArgs) Handles tbSpeed.Scroll
        iSwapSpeed = tbSpeed.Value
    End Sub

    Private Sub BubbleSort()
        Dim sColumn As String
        Dim iRowCount As Integer
        Dim bSwap As Boolean
        sColumn = cboColumn.Items(cboColumn.SelectedIndex)
        btnLoadDB.Enabled = False
        cmdSort.Enabled = False
        cboColumn.Enabled = False
        Do
            bSwap = False
            For iRowCount = 0 To DGVMarks.Rows.Count - 2
                If Double.Parse(DGVMarks.Rows(iRowCount).Cells(sColumn).Value) > Double.Parse(DGVMarks.Rows(iRowCount + 1).Cells(sColumn).Value) Then
                    SwapRows(DGVMarks.Rows(iRowCount), DGVMarks.Rows(iRowCount + 1))
                    bSwap = True
                End If
            Next
        Loop While bSwap
        For iRowCount = 0 To DGVMarks.Rows.Count - 1
            DGVMarks.Rows(iRowCount).Cells(0).Value = iRowCount + 1
        Next
        btnLoadDB.Enabled = True
        cmdSort.Enabled = True
        cboColumn.Enabled = True
    End Sub

    Private Sub SwapRows(rCurrent As DataGridViewRow, rNext As DataGridViewRow)
        Dim sTemp As String
        Dim iColumnCount As Integer
        rCurrent.DefaultCellStyle.BackColor = Color.Aqua
        rNext.DefaultCellStyle.BackColor = Color.Violet
        For iColumnCount = 0 To rCurrent.Cells.Count - 1

            sTemp = rCurrent.Cells(iColumnCount).Value
            rCurrent.Cells(iColumnCount).Value = rNext.Cells(iColumnCount).Value
            rNext.Cells(iColumnCount).Value = sTemp
            Application.DoEvents()
            Thread.Sleep(iSwapSpeed)
        Next
        rCurrent.DefaultCellStyle.BackColor = Color.White
        rNext.DefaultCellStyle.BackColor = Color.White
    End Sub

End Class
