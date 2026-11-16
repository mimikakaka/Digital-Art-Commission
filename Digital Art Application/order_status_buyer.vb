
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class order_status

    Private db As New CommissionRepository()

    Private Sub order_status_buyer_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        FadeIn(Me)
        Me.WindowState = FormWindowState.Maximized

        ' LOAD BOTH COMMISSION ORDERS
        LoadOrder001("001")
        LoadOrder002("002")

    End Sub

    ' ==========================================
    ' ORDER #001 - THYNN
    ' ==========================================

    Private Sub LoadOrder001(orderNo As String)

        Try
            Dim dt As DataTable = db.GetCommission(orderNo)

            If dt.Rows.Count > 0 Then

                Dim row As DataRow = dt.Rows(0)

                Dim status As String =
                    row("commission_status").ToString()

                ' UPDATE PROGRESS COLORS
                UpdateProgressColors(
                    status,
                    ordered_comms_status_thynn_panel,
                   sketch_comms_status_thynn_panel,
                    rendering_comms_status_thynn_panel,
                    final_comms_status_thynn_panel
                )

                ' UPDATE LAST UPDATED DATE
                If Not IsDBNull(row("last_updated")) Then
                    lastupdate_status_date_thynn.Value =
                        Convert.ToDateTime(row("last_updated"))
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Order #001 Error: " & ex.Message)
        End Try

    End Sub

    ' ==========================================
    ' ORDER #002 - SOAPPY
    ' ==========================================

    Private Sub LoadOrder002(orderNo As String)

        Try
            Dim dt As DataTable = db.GetCommission(orderNo)

            If dt.Rows.Count > 0 Then

                Dim row As DataRow = dt.Rows(0)

                Dim status As String =
                    row("commission_status").ToString()

                ' UPDATE PROGRESS COLORS
                UpdateProgressColors(
                    status,
                    ordered_comms_status_soapy_panel,
                    sketch_comms_sketch_soapy_panel,
                    rendering_comms_status_soapy_panel,
                    final_comms_status_soapy_panel
                )

                ' UPDATE LAST UPDATED DATE
                If Not IsDBNull(row("last_updated")) Then
                    lastupdate_status_date_soapy.Value =
                        Convert.ToDateTime(row("last_updated"))
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Order #002 Error: " & ex.Message)
        End Try

    End Sub

    ' ==========================================
    ' AUTOMATIC PROGRESS COLOR SYSTEM
    ' ==========================================

    Private Sub UpdateProgressColors(
        status As String,
        orderedPanel As Panel,
        sketchPanel As Panel,
        renderingPanel As Panel,
        finalPanel As Panel
    )

        ' GRAY FOR INACTIVE STAGES
        Dim inactiveColor As Color =
            Color.FromArgb(210, 210, 210)

        ' YOUR ORIGINAL PASTEL COLORS
        Dim orderedColor As Color =
            Color.FromArgb(193, 140, 204)

        Dim sketchColor As Color =
            Color.FromArgb(239, 240, 223)

        Dim renderingColor As Color =
            Color.FromArgb(201, 174, 225)

        Dim finalColor As Color =
            Color.FromArgb(184, 217, 224)

        ' RESET ALL FOUR PANELS
        orderedPanel.BackColor = inactiveColor
        sketchPanel.BackColor = inactiveColor
        renderingPanel.BackColor = inactiveColor
        finalPanel.BackColor = inactiveColor

        ' COLOR ONLY THE CURRENT STATUS
        Select Case status.Trim().ToLower()

            Case "ordered"
                orderedPanel.BackColor = orderedColor

            Case "sketch"
                sketchPanel.BackColor = sketchColor

            Case "rendering"
                renderingPanel.BackColor = renderingColor

            Case "final"
                finalPanel.BackColor = finalColor

        End Select

    End Sub

    ' ==========================================
    ' MANUAL REFRESH
    ' ==========================================

    Public Sub RefreshCommissionStatus()

        LoadOrder001("001")
        LoadOrder002("002")

    End Sub
    Private Sub back_button_Click(sender As Object, e As EventArgs) Handles back_button.Click
        Dim portfolio As New home_buyer()
        portfolio.Show()
        Me.Hide()
    End Sub
End Class
