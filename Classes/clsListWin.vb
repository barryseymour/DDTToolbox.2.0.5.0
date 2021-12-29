Option Explicit On
Imports System.Collections

Public Class clsListWin
    Private WinName_value As String
    Private FormName_value As String
    Private FormText_value As String
    Private mIndex_value As Integer
    Private formIndex_value As Integer
    Private ToolTipText_value As String
    Private FormObject_value As Form

    Public Sub New(ByVal WinName As String, ByVal FormName As String, ByVal FormText As String, ByVal mIndex As Integer, ByVal FormIndex As Integer, ByVal ToolTipText As String, ByVal FormObject As Form)
        WinName_value = WinName
        FormName_value = FormName
        FormText_value = FormText
        mIndex_value = mIndex
        formIndex_value = FormIndex
        ToolTipText_value = ToolTipText
        FormObject_value = FormObject
    End Sub

    Public Property WinName() As String
        Get
            Return WinName_value
        End Get
        Set(ByVal value As String)
            WinName_value = value
        End Set
    End Property

    Public Property FormName() As String
        Get
            Return FormName_value
        End Get
        Set(ByVal value As String)
            FormName_value = value
        End Set
    End Property

    Public Property FormText() As String
        Get
            Return FormText_value
        End Get
        Set(ByVal value As String)
            FormText_value = value
        End Set
    End Property

    Public Property ToolTipText() As String
        Get
            Return ToolTipText_value
        End Get
        Set(ByVal value As String)
            ToolTipText_value = value
        End Set
    End Property

    Public Property mIndex() As Integer
        Get
            Return mIndex_value
        End Get
        Set(ByVal value As Integer)
            mIndex_value = value
        End Set
    End Property

    Public Property FormIndex() As Integer
        Get
            Return formIndex_value
        End Get
        Set(ByVal value As Integer)
            formIndex_value = value
        End Set
    End Property

    Public Property FormObject() As Form
        Get
            Return FormObject_value
        End Get
        Set(ByVal value As Form)
            FormObject_value = value
        End Set
    End Property
End Class
