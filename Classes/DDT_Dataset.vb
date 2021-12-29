Public Class DDT_Dataset
    Inherits DataSet
    Public Function BuildTable(ByVal SqlStr As String, _
                                 ByVal ConnectionStr As String, _
                                 ByVal TableName As String, _
                                 Optional ByRef ErrorMessage As String = Nothing, _
                                 Optional ByVal CommandTimeout As Integer = 180) _
                      As Integer

        Dim Status As Integer = ReturnStatus.SUCCESS
        Dim SqlDataAd As New System.Data.SqlClient.SqlDataAdapter(SqlStr, ConnectionStr)
        If Not gError Then
            SqlDataAd.SelectCommand.CommandTimeout = CommandTimeout
            If TableName Is Nothing Then
                SqlDataAd.Fill(Me)
            Else
                If Me.Tables(TableName) IsNot Nothing Then
                    Me.Tables.Remove(TableName)
                End If
                Try
                    Me.Tables.Add(TableName)
                    SqlDataAd.Fill(Me.Tables(TableName))
                    If Me.Tables(TableName).Rows.Count = 0 Then Status = ReturnStatus.NO_DATA

                Catch ex As Exception
                    Status = ReturnStatus.FAILED
                    gError = True
                    EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)

                End Try
            End If
            SqlDataAd.Dispose()
        End If
        Return Status
    End Function
    Public Function TableExists(ByVal tName As String) As Boolean
        If Me.Tables(tName) Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub Debug_ListTableNames()
        For Each t As DataTable In Me.Tables
        Next
    End Sub
    Public Sub Debug_ListColumnNamesByTableName(ByVal TableName As String)
        For Each c As DataColumn In Me.Tables(TableName).Columns
        Next
    End Sub
    Public Sub Debug_ListColumnNamesByTableNumber(ByVal TableNumber As Integer)
        For Each c As DataColumn In Me.Tables(TableNumber).Columns
        Next
    End Sub
End Class

Public Enum ReturnStatus
    SUCCESS = 0
    FAILED = -1
    NO_DATA = 1
    _DEV_SUCCESS = 100
    _DEV_FAILED = -100
    _DEV_NO_DATA = 101
End Enum
