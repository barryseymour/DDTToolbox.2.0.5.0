Public Class ExtTreeView
    Inherits TreeView

    Protected Friend Overridable Function CreateNode() As ExtTreeNode

        Return New ExtTreeNode

    End Function

End Class
