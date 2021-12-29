Imports System.Data.SqlClient
Imports DDTToolbox.CodeUtilities

Public Class DBClass
    Private DBConnect As New SqlConnection
    Private cmd As New SqlCommand
    Private SQL As String
  
    Public Function DBClass_BuildDataSet(SqlString As String, TableName As String, DS As DataSet) As Boolean
        DBConnect.ConnectionString = gConnectionString
        DBConnect.Open()
        Try
            Dim myAdapter As New SqlDataAdapter(SqlString, DBConnect)
            If DS.Tables(TableName) IsNot Nothing Then
                DS.Tables.Remove(TableName)
                DS.Tables.Add(TableName)
            Else
                DS.Tables.Add(TableName)
            End If
            myAdapter.Fill(DS.Tables(TableName))
            DBConnect.Close()
            myAdapter.Dispose()
            myAdapter = Nothing
        Catch ex As Exception
            gError = True
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
            DBConnect.Close()

        End Try
        Return True
    End Function
    Public Function DBClass_Scalar(ByVal sql As String) As String
        DBConnect.ConnectionString = gConnectionString
        Dim ReturnValue As String = Nothing
        Try
            With cmd
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = DBConnect
                If Not .Connection.State = ConnectionState.Open Then .Connection.Open()
                ReturnValue = .ExecuteScalar.ToString
                .Connection.Close()
            End With
        Catch ex As Exception
            gError = True
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)

        End Try
        Return ReturnValue
    End Function

    Public Function DBClassReturnDataTable(ByVal sql As String) As DataTable

        Dim dt As New DataTable
        DBConnect.ConnectionString = gConnectionString
        Dim ReturnValue As String = Nothing
        Dim da As New SqlDataAdapter

        Try
            With cmd
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = DBConnect
                .CommandTimeout = 0
                If Not .Connection.State = ConnectionState.Open Then .Connection.Open()
                da.SelectCommand = cmd
                da.Fill(dt)
                .Connection.Close()
            End With
        Catch ex As Exception

            gError = True
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
        Return dt
    End Function

    Public Function RtnSQLStatus(ByVal sql As String) As Boolean
        Dim cmd As New SqlCommand
        DBConnect.ConnectionString = gConnectionString
        Try
            With cmd
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = DBConnect
                If Not .Connection.State = ConnectionState.Open Then .Connection.Open()
                RtnSQLStatus = CBool(.ExecuteNonQuery())
                If Not GetInputState = 0 Then Application.DoEvents()
                .Connection.Close()
            End With
        Catch ex As Exception
            gError = True
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
    End Function
End Class

