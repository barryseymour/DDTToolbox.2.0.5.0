Imports System.IO

Public Class DDT_ItemInfo
    Inherits System.Windows.Forms.ListViewItem

    Public TreeLevelID, TreeLevelID_Parent As Long
    Public ImageID, ImageIDExpanded As Integer
    Public SpecialID, TabIndex As Integer
    Public ItemType, NodeID As String
    Public IsRootNode, IsEnabled As Boolean
    Public IsActive As Boolean
    Public NodeType As DDT_NodeType
    Public ReportStatus As DDT_ReportStatus
    Public IsStatic, UseTabs As Boolean
    Public ReportID, ReportFormatID As Integer  'either the ReportID or FolderID
    Public PrimaryLocation, ReportDescription As String
    Public ReportNumber, ReportName, ReportFullName, ReportFileName, ReportFormat, HelpFile, CommandString As String
    Public ReportTitle As String    '<-- Added 9/14/2011 MSG - This field should be used rather than ReportName when auto-populating report Title (see Crystal reports).
    Public NodeName As String
    Public ControlIDs() As Integer

    'Extended for editing the tree
    Public HelpEnabled, ScheduleEnabled As Boolean
    Public ItemTypeID As Integer
    Public CreationDate, ModifiedDate As Date
    Public ModifiedBy_EmpNum, ImageType As String
    Public SortOrder As Decimal

    Public Function GetReportFullPath() As String
        'HTML: don't check for existence.  Just return the url
        If ReportFormat = "HTML" Then
            If PrimaryLocation <> "" Then
                Return PrimaryLocation + ReportFileName
            Else
                Return ""
            End If
        Else
            'All other file formats.
            'Make sure that the file exists
            If File.Exists(PrimaryLocation + ReportFileName) Then
                Return PrimaryLocation + ReportFileName
            Else
                Return ""
            End If
        End If
    End Function
End Class
