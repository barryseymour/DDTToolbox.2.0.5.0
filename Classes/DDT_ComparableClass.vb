Imports System

Public Class DDT_ComparableClass
    Implements IComparer

    ' By: Sylvester Maya
    ' 10/10/2005
    ' This method implements the IComparer interface, which is used (passed)
    ' to the ArrayList (myParents and myChildren). 
    ' This method compare two objects based on the IndexOrder.
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
        Implements IComparer.Compare

        Return CType(x, DDT_BaseControl).IndexOrder.CompareTo(CType(x, DDT_BaseControl).IndexOrder)
    End Function
End Class