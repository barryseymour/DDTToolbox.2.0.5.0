Imports System.IO
Imports Microsoft.Win32
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
'Allows you to work with Excel objects via .NET interop. 
'Includes the COMException class, allowing you to properly handle COM-related exceptions.
Imports System.Runtime.InteropServices

Public Class DDT_Utility
    Public Enum MSApplications
        Excel
        Outlook
        Word
    End Enum

    'Copies the data into an multidimensional array of strings.
    'Note: The Array Class serves as the base class for all arrays in the common language runtime.
    Public Function GetRowsOfData_MultiArray(ByVal data As DataTable) As Object(,)

        Try
            'get the row and column count for the data
            Dim columnCount As Integer = data.Columns.Count
            Dim rowCount As Integer = data.Rows.Count

            'define the array dimensions
            Dim dataArray(rowCount - 1, columnCount - 1) As Object
            Dim columnNamesArray(columnCount - 1) As String

            For rowIndex As Integer = 0 To rowCount - 1
                For columnIndex As Integer = 0 To columnCount - 1
                    dataArray(rowIndex, columnIndex) = data.Rows.Item(rowIndex).Item(columnIndex)
                Next columnIndex
            Next rowIndex

            Return dataArray

        Catch ex As Exception

            MessageBox.Show(ex.Message & "; Method Name: " & Reflection.MethodBase.GetCurrentMethod.Name, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim dataArray(0, 0) As String
            Return dataArray
        End Try
    End Function

    Public Function GetDataTable(ByVal ColumnNames() As String, ByVal RowsOfData_JaggedArray()() As Object) As DataTable
        Try
            Dim columnCountForData As Integer = RowsOfData_JaggedArray(0).GetLength(0) 'get the number of columns
            Dim rowCountForData As Integer = RowsOfData_JaggedArray.GetLength(0)    'get the number of rows
            Dim dtData As New DataTable
            Dim i, j As Integer

            'the number of columns from the columnNames and of RowOfData must match
            If columnCountForData <> ColumnNames.Length() Then
                Return Nothing
            End If

            'add columns to the datatable
            For i = 0 To ColumnNames.Length() - 1
                dtData.Columns.Add(ColumnNames(i))
            Next

            'add rows to the datatable
            Dim values(columnCountForData - 1) As Object
            For i = 0 To rowCountForData - 1 'iterate thru the rows
                For j = 0 To columnCountForData - 1  'create a row of data by iterating thru the columns of a row
                    values(j) = RowsOfData_JaggedArray(i)(j)
                Next
                dtData.Rows.Add(values) 'copy the row of data into the data table
            Next

            Return dtData

        Catch ex As Exception
            MessageBox.Show(ex.Message & Reflection.MethodBase.GetCurrentMethod.Name)
            Return Nothing
        End Try
    End Function

    Public Function GetDataTable(ByVal ColumnNames() As String, ByVal RowsOfData_MultiDimArray(,) As Object) As DataTable
        Try
            Dim columnCountForData As Integer = RowsOfData_MultiDimArray.GetLength(1) 'get the number of columns
            Dim rowCountForData As Integer = RowsOfData_MultiDimArray.GetLength(0)    'get the number of rows
            Dim dtData As New DataTable
            Dim i, j As Integer

            'the number of columns from the columnNames and of RowOfData must match
            If columnCountForData <> ColumnNames.Length() Then
                Return Nothing
            End If

            'add columns to the datatable
            For i = 0 To ColumnNames.Length() - 1
                dtData.Columns.Add(ColumnNames(i))
            Next

            'add rows to the datatable
            Dim values(columnCountForData - 1) As Object
            For i = 0 To rowCountForData - 1 'iterate thru the rows
                For j = 0 To columnCountForData - 1  'create a row of data by iterating thru the columns of a row
                    values(j) = RowsOfData_MultiDimArray.GetValue(i, j)
                Next
                dtData.Rows.Add(values) 'copy the row of data into the data table
            Next

            Return dtData

        Catch ex As Exception
            MessageBox.Show(ex.Message & "; Method Name: " & Reflection.MethodBase.GetCurrentMethod.Name, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Function GetColumnNames(ByVal data As DataTable) As String()
        Try
            Dim columnCount As Integer = data.Columns.Count
            Dim columnNames(columnCount - 1) As String

            For j As Integer = 0 To columnCount - 1
                If IsDBNull(data.Columns.Item(j).ColumnName) Then
                    columnNames(j) = Nothing
                Else
                    columnNames(j) = data.Columns.Item(j).ColumnName
                End If
            Next j

            Return columnNames

        Catch ex As Exception
            MessageBox.Show(ex.Message & "; Method Name: " & Reflection.MethodBase.GetCurrentMethod.Name, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'return an empty array of strings
            Dim columnNames(0) As String
            Return columnNames
        End Try
    End Function

    Public Function DownLoadReportTemplateFile(ByVal TemplateFileNameOnServer As String) As String
        Try
            Dim localDestination As String
            Dim serverFileDateTime, localFileDateTime As Date

            If File.Exists(TemplateFileNameOnServer) = False Then Return Nothing
            localDestination = Application.StartupPath() & "\" & System.IO.Path.GetFileName(TemplateFileNameOnServer)

            If File.Exists(localDestination) Then
                File.SetAttributes(localDestination, FileAttributes.Normal)
                localFileDateTime = File.GetLastWriteTime(localDestination)
                serverFileDateTime = File.GetLastWriteTime(TemplateFileNameOnServer)
                If localFileDateTime = serverFileDateTime Then Return localDestination

                Try
                    File.Delete(localDestination)
                Catch ex As UnauthorizedAccessException
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return Nothing
                Catch ex As IOException
                    Return localDestination
                End Try

            End If

            File.Copy(TemplateFileNameOnServer, localDestination, True)
            File.SetAttributes(localDestination, FileAttributes.Normal)
            Return localDestination

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Shared Sub FixFonts(TheObject As Object)

        'DESCRIPTION
        'Sub updates all fonts on a form, container or control 
        'to match Windows 7/8/10 font standards using Segoe UI.
        'Also sets font scaling mode to DPI to accomodate high resolution monitors
        'This sub is re-entrant: Call it passing in a form and it will call itself again for every container and control on the form.

        'Note the sub slightly decreases the width of forms to accomodate the fact that
        'Segoe UI 9 is a bit wider than Arial 8.

        'Note also we use VB6 style error handling so we can ignore any error
        'and resume code execution on the next line. ("Resume Next")

        'HISTORY
        '2017.09.12 Created - Barry
        '2017.09.21 Modified to better set up a SplitPanel control - Barry
        '===========================================================================================

        'DATA Dictionary
        Dim TheControl As Control = Nothing
        Dim TheChildControl As Control = Nothing
        Dim TheForm As Form = Nothing
        Dim FixFont As Boolean = False
        Dim CurrentFont As Font
        Dim MyContainer As SplitContainer = Nothing, MyPanel As SplitterPanel = Nothing

        Static NewFont As Font = Nothing

        '===========================================================================================

        Try
            If NewFont Is Nothing Then NewFont = New Font("Segoe UI", 9)

            If TypeOf (TheObject) Is Form Then
                TheForm = CType(TheObject, Form)

                With TheForm
                    .Font = NewFont
                    .Width = TheForm.Width * 0.95
                    .AutoScaleMode = AutoScaleMode.Dpi
                End With

                For Each TheControl In TheForm.Controls
                    FixFonts(TheControl)
                Next

            ElseIf TypeOf (TheObject) Is Control Then
                TheControl = CType(TheObject, Control)
                With TheControl
                    If .Font.Size >= 7 And .Font.Size <= 11 Then
                        .Font = NewFont
                        If TypeOf (TheControl) Is Button And TheControl.Height < 25 Then TheControl.Height = 25
                    Else
                        CurrentFont = .Font
                        .Font = New Font("Segoe UI", CurrentFont.Size, FontStyle.Bold)
                    End If

                    If .HasChildren Then
                        For Each TheChildControl In .Controls
                            FixFonts(TheChildControl)
                        Next
                    Else
                    End If
                End With
            End If

        Catch ex As Exception
            If Debugger.IsAttached Then
                MessageBox.Show("Error in DDT_Utility.FixFonts: " & ex.Message, "Error in FixFonts", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Stop
            End If
        End Try

    End Sub

End Class
