Imports System.Data.SqlClient

Public Class DDT_ImageList
    Inherits System.ComponentModel.Component

    Private myDR As DataRow()
    Private sqlStr As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        InitializeComponent()
    End Sub

    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If
        InitializeComponent()
    End Sub

    Public Sub New(ByVal drow As DataRow(), Optional ByVal xz As Integer = 16, Optional ByVal yz As Integer = 16, _
    Optional ByVal sql As String = "SELECT * FROM dbo.ftBuildImageList()", Optional ByVal SQLConn As SqlConnection = Nothing)
        MyBase.New()

        myDR = drow
        sqlStr = sql
        'If SQLConn IsNot Nothing Then conn = SQLConn
        'This call is required by the Component Designer.
        InitializeComponent()
        Me.ImageList.ImageSize = New System.Drawing.Size(xz, yz)
        If Me.ImageList.Images.Count = 0 Then BuildImageList()
    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DDT_ImageList))
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "BINOCULR.ICO")
        Me.ImageList.Images.SetKeyName(1, "magglass.ico")
        Me.ImageList.Images.SetKeyName(2, "newfolderclosed.ico")
        Me.ImageList.Images.SetKeyName(3, "newfolderopen.ico")
        Me.ImageList.Images.SetKeyName(4, "newGreenlight.ico")
        Me.ImageList.Images.SetKeyName(5, "newRedlight.ico")
        Me.ImageList.Images.SetKeyName(6, "OrgPubX_3103.ico")
        Me.ImageList.Images.SetKeyName(7, "OrgPubX_3105.ico")
        Me.ImageList.Images.SetKeyName(8, "OrgPubX_3109.ico")
        Me.ImageList.Images.SetKeyName(9, "OrgPubX_3113.ico")
        Me.ImageList.Images.SetKeyName(10, "OSA_2.ico")
        Me.ImageList.Images.SetKeyName(11, "shell32_32.ico")
        Me.ImageList.Images.SetKeyName(12, "wmploc_474.ico")
        Me.ImageList.Images.SetKeyName(13, "tsclosed.ico")
        Me.ImageList.Images.SetKeyName(14, "csclosed.ico")
        Me.ImageList.Images.SetKeyName(15, "factclosed.ico")
        Me.ImageList.Images.SetKeyName(16, "weldingclosed.ico")
        Me.ImageList.Images.SetKeyName(17, "Constclosed.ico")
        Me.ImageList.Images.SetKeyName(18, "Blue Disk.ico")
        Me.ImageList.Images.SetKeyName(19, "PASSTHRU.ICO")
        Me.ImageList.Images.SetKeyName(20, "SPRB0401_900.ico")
        Me.ImageList.Images.SetKeyName(21, "SHDOCVW_20783.ico")
        Me.ImageList.Images.SetKeyName(22, "SPRB0401_800.ico")
        Me.ImageList.Images.SetKeyName(23, "NEWDEV_204.ico")
        Me.ImageList.Images.SetKeyName(24, "EXPLORER_101.ico")
        Me.ImageList.Images.SetKeyName(25, "admparse_1_USER.ico")
        Me.ImageList.Images.SetKeyName(26, "Log Off.ico")
        Me.ImageList.Images.SetKeyName(27, "OUTLLIBR_7507.ico")
        Me.ImageList.Images.SetKeyName(28, "repbrmdc_139.ico")
        Me.ImageList.Images.SetKeyName(29, "OLKFSTUB_1005.ico")
        Me.ImageList.Images.SetKeyName(30, "Organization Chart_213.ico")
        Me.ImageList.Images.SetKeyName(31, "AdressBook.ico")
        Me.ImageList.Images.SetKeyName(32, "COMRES_1.ico")
        Me.ImageList.Images.SetKeyName(33, "qa2.ico")
        Me.ImageList.Images.SetKeyName(34, "COMRES_1.ico")
        Me.ImageList.Images.SetKeyName(35, "qa2.ico")
        Me.ImageList.Images.SetKeyName(36, "schedfolderclosed.ico")
        Me.ImageList.Images.SetKeyName(37, "schedfolderopen.ico")
        Me.ImageList.Images.SetKeyName(38, "newreportsclosed.ico")
        Me.ImageList.Images.SetKeyName(39, "newreportsopen.ico")
        Me.ImageList.Images.SetKeyName(40, "newfavsclosed.ico")
        Me.ImageList.Images.SetKeyName(41, "newfavsopen.ico")
        Me.ImageList.Images.SetKeyName(42, "distclosed.ico")
        Me.ImageList.Images.SetKeyName(43, "MSGraphs.ico")
        Me.ImageList.Images.SetKeyName(44, "CrystalReports32.ico")
        Me.ImageList.Images.SetKeyName(45, "MSExcel.ico")
        Me.ImageList.Images.SetKeyName(46, "HTML32.ico")
        Me.ImageList.Images.SetKeyName(47, "AcroRd32_2.ico")
        Me.ImageList.Images.SetKeyName(48, "MSPowerPoint32.ico")
        Me.ImageList.Images.SetKeyName(49, "report.ico")
        Me.ImageList.Images.SetKeyName(50, "MSWord32.ico")
        Me.ImageList.Images.SetKeyName(51, "amclosed.ico")

    End Sub
    Public WithEvents ImageList As System.Windows.Forms.ImageList

#End Region

    Public Overridable Sub BuildImageList()
        Dim ds As New DataSet
        BuildDataSet(gDatabaseConnection, sqlStr, "Images", ds)
        Dim imagedr As DataRow() = ds.Tables("Images").Select
        Dim ir As DataRow

        If myDR Is Nothing Then myDR = imagedr
        For Each ir In myDR
            ImageList.Images.Add(ir("ImageType"), Image.FromFile(ir("ImageFileLocation")))
        Next

        myDR = Nothing
        ds = Nothing
    End Sub

End Class
