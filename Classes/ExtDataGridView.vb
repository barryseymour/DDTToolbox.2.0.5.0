Imports System.Windows.Forms
Imports System.Drawing

Public Class ExtDataGridView
    Inherits DataGridView

    Private RowHeaderNumbersLocationX_value As Integer = 5
    Private RowHeaderNumberLocationY_value As Integer = 4

    Private RowHeaderNumbers_value As Boolean = False
    ''' <summary>
    ''' Set X Location for painted numbers in cell.
    ''' </summary>
    ''' <remarks>by Joey Cruz</remarks>
    Public Property RowHeaderNumbersLocationX() As Integer
        Get
            Return RowHeaderNumbersLocationX_value
        End Get
        Set(ByVal value As Integer)
            RowHeaderNumbersLocationX_value = value
        End Set
    End Property

    Public Property RowHeaderNumbersLocationY() As Integer
        Get
            Return RowHeaderNumberLocationY_value
        End Get
        Set(ByVal value As Integer)
            RowHeaderNumberLocationY_value = value
        End Set
    End Property

    Public Property RowHeaderNumbers() As Boolean
        Get
            Return RowHeaderNumbers_value
        End Get
        Set(ByVal value As Boolean)
            RowHeaderNumbers_value = value
        End Set
    End Property

    '--- Paint the row numbers into the Row Headers. ---
    Private Sub myDGV_RowPostPaint(ByVal sender As Object, ByVal e As DataGridViewRowPostPaintEventArgs) Handles Me.RowPostPaint
        If RowHeaderNumbers_value And Me.RowHeadersVisible Then
            ' Paint the row number on the row header.
            ' The using statement automatically disposes the brush.
            Using b As SolidBrush = New SolidBrush(Me.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), _
                                       Me.DefaultCellStyle.Font, _
                                       b, _
                                       e.RowBounds.Location.X + RowHeaderNumbersLocationX_value, _
                                       e.RowBounds.Location.Y + RowHeaderNumberLocationY_value)
            End Using
        End If
    End Sub

    Public Function GetWidth_AllDgvColumns(Optional ByVal VisibleColsOnly As Boolean = False) As Integer
        Dim TotalColumnsWidth As Integer = 0
        For Each col As DataGridViewColumn In Me.Columns
            If (VisibleColsOnly And col.Visible = True) Or (Not VisibleColsOnly) Then
                TotalColumnsWidth += col.Width
            End If
        Next
        Return TotalColumnsWidth
    End Function

    Public Function GetHeight_AllDgvRows() As Integer
        Dim TotalRowsHeight As Integer = 0
        For Each row As DataGridViewRow In Me.Rows
            TotalRowsHeight += row.Height
        Next
        Return TotalRowsHeight
    End Function

    Public Function SelectRowByValue(ByVal CellValue As String, Optional ByVal Col As Object = "", Optional ByVal SelectRow As Boolean = True) As DataGridViewRow
        Return SelectRowByValue_PROCESS(CellValue, Col, SelectRow)
    End Function

    Private Function SelectRowByValue_PROCESS(ByVal CellValue As Object, Optional ByVal ColObject As Object = "", Optional ByVal SelectRow As Boolean = True) As DataGridViewRow
        Dim r As Integer, c As Integer
        Try
            Me.ClearSelection()
            For r = 0 To Me.Rows.Count - 1
                If ColObject.ToString = Nothing Then
                    For c = 0 To Me.Columns.Count - 1
                        If Me.Rows(r).Cells(c).Value.ToString.ToUpper = CellValue.ToString.ToUpper Then Return Me.SelectRow(r)
                    Next
                Else
                    If Me.Rows(r).Cells(ColObject).Value.ToString.ToUpper = CellValue.ToString.ToUpper Then Return Me.SelectRow(r)
                End If
            Next
        Catch
        End Try
        Return Nothing
    End Function

    '======================================================
    Public Function GetCell(ByVal rowIndex As Integer, ByVal colIndex As Integer) As DataGridViewCell
        Return Me.Rows(rowIndex).Cells(colIndex)
    End Function
    Public Function GetCell(ByVal rowIndex As Integer, ByVal colName As String) As DataGridViewCell
        Return Me.Rows(rowIndex).Cells(colName)
    End Function
    Public Function GetCell(ByVal row As DataGridViewRow, ByVal col As DataGridViewColumn) As DataGridViewCell
        Return Me.Rows(row.Index).Cells(col.Index)
    End Function

    '======================================================
    '--- The only reason for this function is to allow the row select as part of a return statement.  Otherwise, you could just do Me.rows(r) in the calling sub. ---
    Public Function SelectRow(ByVal rowIndex As Integer) As DataGridViewRow
        Try
            Me.Rows(rowIndex).Selected = True : Return Me.Rows(rowIndex)
        Catch
            Return Nothing
        End Try
    End Function

    '======================================================
    Public Function SelectCell(ByVal rowIndex As Integer, ByVal colIndex As Integer) As DataGridViewCell
        Try
            Me.Rows(rowIndex).Cells(colIndex).Selected = True : Return Me.Rows(rowIndex).Cells(colIndex)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function SelectCell(ByVal rowIndex As Integer, ByVal colName As String) As DataGridViewCell
        Try
            Me.Rows(rowIndex).Cells(colName).Selected = True : Return Me.Rows(rowIndex).Cells(colName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function SelectCell(ByVal row As DataGridViewRow, ByVal col As DataGridViewColumn) As DataGridViewCell
        Try
            Me.Rows(row.Index).Cells(col.Index).Selected = True : Return Me.Rows(row.Index).Cells(col.Index)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    '======================================================
End Class
