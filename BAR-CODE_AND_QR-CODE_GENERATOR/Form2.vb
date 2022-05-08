Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim generate As New MessagingToolkit.Barcode.BarcodeEncoder
        generate.BackColor = Color.White
        generate.LabelFont = New Font("Arial", 7, FontStyle.Regular)
        generate.IncludeLabel = True
        generate.CustomLabel = T4.Text

        Try
            PictureBox1.Image = New Bitmap(generate.Encode(MessagingToolkit.Barcode.BarcodeFormat.QRCode, "BEGIN:VCARD" & vbCrLf +
           "VERSION:2.1" & vbCrLf +
            "N:" + T1.Text & vbCrLf +
                                                           "ORG:" + T2.Text & vbCrLf +
                                                           "EMAIL:" + T3.Text & vbCrLf +
                                                           "TEL:" + T4.Text & vbCrLf +
                                                           "END:VCARD"
                                                           ))
        Catch ex As Exception
            PictureBox1.Image = Nothing
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim SD As New SaveFileDialog
        SD.Filter = "PNG File|*.png"
        If SD.ShowDialog() = DialogResult.OK Then
            Try
                PictureBox1.Image.Save(SD.FileName, Imaging.ImageFormat.Png)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim Scanner As New MessagingToolkit.Barcode.BarcodeDecoder
        Dim result As MessagingToolkit.Barcode.Result
        Try
            result = Scanner.Decode(New Bitmap(PictureBox1.Image))
            T1.Text = result.Text
            MsgBox("Succesfully Decoded-Code : " + result.Text)

        Catch ex As Exception

        End Try
    End Sub
End Class