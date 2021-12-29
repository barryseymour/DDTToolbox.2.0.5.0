Imports System.ComponentModel

Public Class DDT_BaseControl
    Inherits System.Windows.Forms.UserControl

#Region "Declared Variables"
    'ArrayList Notes:
    'Capacity = 6 is the number of elements that the ArrayList is capable of storing. 
    'If more than six elements are added, then the arraylist will be doubled in size.
    'Count is the number of elements that are actually in the ArrayList.
    Public myParents As New ArrayList(6)
    Public myChildren As New ArrayList(6)
    Private myComparer As New DDT_ComparableClass
    Private _ReportID As Integer
    Private _ControlID As Integer
    Private _ReportControlID As Integer
    Private _IndexOrder As Integer
    Private _TabName As String
    Private _Tab_Index As Integer
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'DDT_BaseControl
        '
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DDT_BaseControl"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Declared Properties"
    <Browsable(True), Category("Data"), Description("The report ID.")> _
    Public Property ReportID() As Integer
        Get
            Return _ReportID
        End Get
        Set(ByVal value As Integer)
            _ReportID = value
        End Set
    End Property

    <Browsable(True), Category("Data"), Description("The control ID.")> _
    Public Property ControlID() As Integer
        Get
            Return _ControlID
        End Get
        Set(ByVal value As Integer)
            _ControlID = value
        End Set
    End Property

    <Browsable(True), Category("Data"), Description("The unique report control ID.")> _
    Public Property ReportControlID() As Integer
        Get
            Return _ReportControlID
        End Get
        Set(ByVal value As Integer)
            _ReportControlID = value
        End Set
    End Property

    <Browsable(True), Category("Controls"), DefaultValue(-1), Description("Sets and gets the index order. This value is used by child controls.")> _
    Public Property IndexOrder() As Integer
        Get
            Return _IndexOrder
        End Get
        Set(ByVal value As Integer)
            _IndexOrder = value
        End Set
    End Property

    <Browsable(True), Category("Controls"), Description("The tab name, if any.")> _
    Public Property TabName() As String
        Get
            Return _TabName
        End Get
        Set(ByVal value As String)
            _TabName = value
        End Set
    End Property

    <Browsable(True), Category("Controls"), DefaultValue(-1), Description("The tab index, if any.")> _
    Public Property Tab_Index() As Integer
        Get
            Return _Tab_Index
        End Get
        Set(ByVal value As Integer)
            _Tab_Index = value
        End Set
    End Property
#End Region

#Region "Data Gathering"
    Public Overridable Sub GetData()
        'Leave these method as a stub.
        'The inheriting class will override this method
    End Sub

    Public Overridable Function GetUserSelectedData() As String
        'Leave these method as a stub.
        'The inheriting class will override this method
        Return ""
    End Function

    Public Overridable Sub GetChildData(ByVal ParentID As String, ByVal DataSetName As String, ByVal conn As SqlClient.SqlConnection)
        'Leave these method as a stub.
        'The inheriting class will override this method
    End Sub

    Public Overridable Function IsDataValid(Optional ByVal DispayMessageBoxWhenInvalid As Boolean = True) As Boolean
        'This method is used to determine if the data is valid.
        'This method should be checked before saving the data to the database.
        'Controls like DDT_ListBox and DDT_DateRange should override this method.
        'Example:
        'If a DDT_ListBox has a limit of 25 items to be selected and the user 
        'selects more than the max, then this flag will/should be set to false.
        'Therefore the data should not be written to the database
        Return True 'default value
    End Function
#End Region

#Region "Updates and Sorting"
    Public Sub UpdateMyChildren()
        Try
            If myChildren.Count = 0 Then
                Exit Sub
            End If

            Dim myEnumerator As System.Collections.IEnumerator = myChildren.GetEnumerator()
            Dim currentChild As DDT_BaseControl
            While myEnumerator.MoveNext()
                currentChild = myEnumerator.Current()
                currentChild.GetData()
                If currentChild.myChildren.Count > 0 Then currentChild.UpdateMyChildren()
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message + "; Method Name: " + Reflection.MethodBase.GetCurrentMethod.Name, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Sort_MyChildren()
        myChildren.Sort(myComparer)
    End Sub

    Public Sub Sort_MyParents()
        myParents.Sort(myComparer)
    End Sub
#End Region
End Class
