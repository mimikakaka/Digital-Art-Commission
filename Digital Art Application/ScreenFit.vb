Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

Module ScreenFit

    ' Call ONCE, after the form is on screen (use the form's Shown event).
    ' Shrinks every control and font so the whole design fits the window.
    ' Returns the scale used (1.0 = nothing was changed).
    Public Function FitFormToScreen(frm As Form) As Single

        ' Remove scrollbars and go back to the top-left corner
        frm.AutoScrollPosition = New Point(0, 0)
        frm.AutoScrollMinSize = New Size(0, 0)
        frm.AutoScroll = False

        ' How big is the design? (farthest right and bottom edges)
        Dim designWidth As Integer = 0
        Dim designHeight As Integer = 0

        For Each c As Control In frm.Controls
            If c.Visible Then
                designWidth = Math.Max(designWidth, c.Right)
                designHeight = Math.Max(designHeight, c.Bottom)
            End If
        Next

        If designWidth <= 0 OrElse designHeight <= 0 Then Return 1.0F

        ' How much shrinking is needed?
        Dim factor As Single = Math.Min(
            frm.ClientSize.Width / CSng(designWidth),
            frm.ClientSize.Height / CSng(designHeight))

        ' Only shrink, never enlarge. Ignore tiny differences.
        If factor >= 0.98F Then Return 1.0F
        If factor < 0.3F Then factor = 0.3F

        ' Work out the new fonts first, then scale
        Dim fonts As New List(Of KeyValuePair(Of Control, Font))
        CollectFonts(frm, factor, fonts)

        frm.SuspendLayout()
        For Each c As Control In frm.Controls
            c.Scale(New SizeF(factor, factor))
        Next
        For Each pair As KeyValuePair(Of Control, Font) In fonts
            pair.Key.Font = pair.Value
        Next
        frm.ResumeLayout(True)

        Return factor
    End Function

    ' Shrinks ONE control (and everything inside it).
    ' Used for artwork cards that are created after the form has opened.
    Public Sub ScaleTree(target As Control, factor As Single)
        If factor >= 0.999F Then Return

        Dim fonts As New List(Of KeyValuePair(Of Control, Font))
        fonts.Add(New KeyValuePair(Of Control, Font)(target, ScaledFont(target.Font, factor)))
        CollectFonts(target, factor, fonts)

        target.Scale(New SizeF(factor, factor))

        For Each pair As KeyValuePair(Of Control, Font) In fonts
            pair.Key.Font = pair.Value
        Next
    End Sub

    Private Sub CollectFonts(parent As Control, factor As Single,
                             result As List(Of KeyValuePair(Of Control, Font)))
        For Each c As Control In parent.Controls
            result.Add(New KeyValuePair(Of Control, Font)(c, ScaledFont(c.Font, factor)))
            CollectFonts(c, factor, result)
        Next
    End Sub

    Private Function ScaledFont(f As Font, factor As Single) As Font
        Dim newSize As Single = Math.Max(6.0F, f.Size * factor)
        Return New Font(f.FontFamily, newSize, f.Style, f.Unit)
    End Function
    ' Like FitFormToScreen, but it only makes the page fit the WIDTH.
    ' If the page is taller than the window, a scrollbar appears on the
    ' right side only (never at the bottom).
    Public Function FitFormToWidth(frm As Form) As Single

        frm.AutoScrollPosition = New Point(0, 0)
        frm.AutoScrollMinSize = New Size(0, 0)
        frm.AutoScroll = False

        ' How wide is the design?
        Dim designWidth As Integer = 0
        For Each c As Control In frm.Controls
            If c.Visible Then designWidth = Math.Max(designWidth, c.Right)
        Next

        ' Leave room for the vertical scrollbar
        Dim usableWidth As Integer = frm.ClientSize.Width - SystemInformation.VerticalScrollBarWidth

        Dim factor As Single = 1.0F
        If designWidth > 0 Then factor = usableWidth / CSng(designWidth)

        If factor < 0.98F Then
            If factor < 0.3F Then factor = 0.3F

            Dim fonts As New List(Of KeyValuePair(Of Control, Font))
            CollectFonts(frm, factor, fonts)

            frm.SuspendLayout()
            For Each c As Control In frm.Controls
                c.Scale(New SizeF(factor, factor))
            Next
            For Each pair As KeyValuePair(Of Control, Font) In fonts
                pair.Key.Font = pair.Value
            Next
            frm.ResumeLayout(True)
        Else
            factor = 1.0F
        End If

        ' How tall is the page now?
        Dim contentHeight As Integer = 0
        For Each c As Control In frm.Controls
            If c.Visible Then contentHeight = Math.Max(contentHeight, c.Bottom)
        Next

        ' Vertical scrollbar only
        frm.HorizontalScroll.Enabled = False
        frm.HorizontalScroll.Visible = False
        frm.HorizontalScroll.Maximum = 0
        frm.AutoScroll = True
        frm.AutoScrollMinSize = New Size(0, contentHeight + 20)

        Return factor
    End Function
End Module