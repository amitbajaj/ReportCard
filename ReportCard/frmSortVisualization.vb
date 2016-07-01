Imports System.Data
Imports System.Data.OleDb
Imports System.Threading
Public Class frmSortVisualization
    Private CurrentDatabase As String
    Private Connection As OleDbConnection
    Private LastError As String
    Private colCollection As Collection
    Private dLeftPosition As Double = 150
    Private dMaxWidth As Double = 200
    Private iSwapSpeed As Integer = 0

    Private Sub btnLoadDB_Click(sender As Object, e As EventArgs) Handles btnLoadDB.Click
        Dim oFlDlg As New OpenFileDialog
        oFlDlg.Filter = "Access Database|*.mdb"
        If oFlDlg.ShowDialog() = DialogResult.OK Then
            If OpenConnection(oFlDlg.FileName) Then
                LoadData()
            Else
                MsgBox("Error loading database!" & vbCrLf & LastError)
            End If
        End If
    End Sub

    Private Sub LoadData()
        Dim da As OleDbDataAdapter
        Dim ds As New DataSet
        Dim sSQL As String
        Dim iRowCount As Integer
        Dim iRecords As Integer
        Dim lblRecord As Label
        Dim dLabelHeight As Double
        Dim fLabelFont As Font
        Dim pMargin As Padding
        Dim iFontSize As Integer
        Dim dMaxValue As Double
        Dim dValue As Double
        sSQL = "SELECT * FROM STUDENT"
        da = New OleDbDataAdapter(sSQL, Connection)
        iRecords = da.Fill(ds)
        dLabelHeight = (Me.Height - 30) / (iRecords + 1)
        iFontSize = 20
        fLabelFont = New Font("Arial", iFontSize)
        While fLabelFont.Height > dLabelHeight
            iFontSize = iFontSize - 1
            fLabelFont.Dispose()
            fLabelFont = New Font("Arial", iFontSize)
        End While
        pMargin = New Padding(0)
        dMaxValue = 0
        For iRowCount = 0 To iRecords - 1
            If Double.Parse(ds.Tables(0).Rows.Item(iRowCount).Item(1).ToString()) > dMaxValue Then
                dMaxValue = Double.Parse(ds.Tables(0).Rows.Item(iRowCount).Item(1).ToString())
            End If
        Next
        colCollection = New Collection()
        For iRowCount = 0 To iRecords - 1
            lblRecord = New Label()
            lblRecord.AutoSize = False
            lblRecord.AutoEllipsis = True
            lblRecord.Height = dLabelHeight
            lblRecord.Text = ds.Tables(0).Rows.Item(iRowCount).Item(1).ToString()
            lblRecord.Padding = pMargin
            dValue = Double.Parse(ds.Tables(0).Rows.Item(iRowCount).Item(1).ToString())
            lblRecord.Left = dLeftPosition
            lblRecord.Width = dMaxWidth * (dValue / dMaxValue)
            lblRecord.Top = (dLabelHeight * iRowCount) + 1
            lblRecord.Font = fLabelFont
            lblRecord.BorderStyle = BorderStyle.FixedSingle
            lblRecord.BackColor = Color.Aquamarine
            colCollection.Add(lblRecord, "L:" & iRowCount)
            Me.Controls.Add(lblRecord)
        Next
        ds.Clear()
        da.Dispose()
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

    Private Sub btnSortData_Click(sender As Object, e As EventArgs) Handles btnSortData.Click
        Dim iCount As Integer
        Dim lblCurrent As Label
        Dim lblNext As Label
        Dim bSwap As Boolean
        Dim iLoopCount As Integer
        iCount = colCollection.Count
        iLoopCount = 0
        Do
            bSwap = False
            For iCount = 0 To colCollection.Count - 2
                lblCurrent = colCollection.Item("L:" & iCount)
                lblNext = colCollection.Item("L:" & (iCount + 1))
                If chkReverseSort.Checked Then
                    If Double.Parse(lblCurrent.Text) < Double.Parse(lblNext.Text) Then
                        colCollection.Remove("L:" & iCount)
                        colCollection.Remove("L:" & (iCount + 1))
                        colCollection.Add(lblNext, "L:" & iCount)
                        colCollection.Add(lblCurrent, "L:" & (iCount + 1))
                        SwapLabels(lblCurrent, lblNext)
                        bSwap = True
                    End If
                Else
                    If Double.Parse(lblCurrent.Text) > Double.Parse(lblNext.Text) Then
                        colCollection.Remove("L:" & iCount)
                        colCollection.Remove("L:" & (iCount + 1))
                        colCollection.Add(lblNext, "L:" & iCount)
                        colCollection.Add(lblCurrent, "L:" & (iCount + 1))
                        SwapLabels(lblCurrent, lblNext)
                        bSwap = True
                    End If
                End If
            Next
            iLoopCount = iLoopCount + 1
            Debug.Print("Loop : " & iLoopCount)
        Loop While bSwap
        For iCount = 0 To colCollection.Count - 1
            Debug.Print(colCollection.Item("L:" & iCount).text)
        Next
        MsgBox("Sorting complete!!")
    End Sub

    Private Sub SwapLabels(lblCurrent As Label, lblNext As Label)
        Dim dCurrentTop As Double
        Dim dNextTop As Double
        Dim bChange As Boolean
        Dim iCount As Integer

        For iCount = 1 To 20
            lblCurrent.Left = lblCurrent.Left - 1
            lblNext.Left = lblNext.Left + 1
            Application.DoEvents()
            Thread.Sleep(iSwapSpeed)
        Next
        dCurrentTop = lblCurrent.Top
        dNextTop = lblNext.Top
        bChange = True
        While bChange
            bChange = False
            If lblCurrent.Top > dNextTop Then
                lblCurrent.Top = lblCurrent.Top - 1
                bChange = True
            ElseIf lblCurrent.Top < dNextTop Then
                lblCurrent.Top = lblCurrent.Top + 1
                bChange = True
            End If

            If lblNext.Top > dCurrentTop Then
                lblNext.Top = lblNext.Top - 1
                bChange = True
            ElseIf lblNext.Top < dCurrentTop Then
                lblNext.Top = lblNext.Top + 1
                bChange = True
            End If
            Application.DoEvents()
            Thread.Sleep(iSwapSpeed)
        End While
        For iCount = 1 To 20
            lblCurrent.Left = lblCurrent.Left + 1
            lblNext.Left = lblNext.Left - 1
            Application.DoEvents()
            Thread.Sleep(iSwapSpeed)
        Next
    End Sub

    Private Sub tbSpeed_Scroll(sender As Object, e As EventArgs) Handles tbSpeed.Scroll
        iSwapSpeed = tbSpeed.Value
    End Sub
End Class