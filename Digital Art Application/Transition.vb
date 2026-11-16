Imports System.Windows.Forms

Module Transition

    Public Sub FadeIn(f As Form)

        f.Opacity = 0

        Dim t As New Windows.Forms.Timer()
        t.Interval = 15

        AddHandler t.Tick,
            Sub(sender, e)
                If f.IsDisposed Then
                    t.Stop()
                    t.Dispose()
                    Return
                End If

                f.Opacity += 0.1

                If f.Opacity >= 1 Then
                    f.Opacity = 1
                    t.Stop()
                    t.Dispose()
                End If
            End Sub

        t.Start()

    End Sub
    Public Sub SmoothDraw(f As Form)
        EnableDoubleBuffer(f)
    End Sub

    Private Sub EnableDoubleBuffer(c As Control)

        Dim prop As System.Reflection.PropertyInfo =
            GetType(Control).GetProperty(
                "DoubleBuffered",
                System.Reflection.BindingFlags.Instance Or
                System.Reflection.BindingFlags.NonPublic)

        If prop IsNot Nothing Then
            prop.SetValue(c, True, Nothing)
        End If

        For Each child As Control In c.Controls
            EnableDoubleBuffer(child)
        Next

    End Sub
End Module