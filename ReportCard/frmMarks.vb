Imports System.Data
Imports System.Data.OleDb
Public Class frmMarks
    Private CurrentDatabase As String
    Private Connection As OleDbConnection
    Private LastError As String
    Private colCollection As Collection
    Private Sub frmMarks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

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
                        .Item(iRowCount).Cells.Item(iFieldCount).Value = (rs.Item(iFieldCount).ToString())
                    Next
                End With
            End While
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
        For iColCount = 0 To rs.FieldCount - 1
            With DGVMarks.Columns
                col1 = New DataGridViewTextBoxColumn()
                col1.Name = rs.GetName(iColCount)
                col1.HeaderText = rs.GetName(iColCount)
                Select Case rs.GetFieldType(iColCount).Name
                    Case "Int32"
                        col1.DefaultCellStyle.Format = "N2"
                        colCollection.Add("I", "KEY::" & iColCount)
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
End Class
