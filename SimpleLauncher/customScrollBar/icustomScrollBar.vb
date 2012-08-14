Imports System
Imports System.Collections.Generic
Imports System.Text

Public Delegate Sub ScrollValueChangedDelegate(ByVal sender As IcustomScrollBar, ByVal newValue As Integer)

Public Interface IcustomScrollBar
    Event ValueChanged As ScrollValueChangedDelegate

    Property LargeChange() As Integer
    Property SmallChange() As Integer
    Property Maximum() As Integer
    Property Minimum() As Integer
    Property Value() As Integer
    ReadOnly Property CanScroll() As Boolean
End Interface