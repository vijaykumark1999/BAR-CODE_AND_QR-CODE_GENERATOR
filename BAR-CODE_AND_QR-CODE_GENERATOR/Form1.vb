Public Class Form1
    Dim QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Generator As New MessagingToolkit.Barcode.BarcodeEncoder
        Generator.IncludeLabel = True
        Generator.CustomLabel = TextQrcode.Text
        Try
            PictureBox1.Image = New Bitmap(Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.Code128C, TextQrcode.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Scanner As New MessagingToolkit.Barcode.BarcodeDecoder
        Dim result As MessagingToolkit.Barcode.Result
        Try
            result = Scanner.Decode(New Bitmap(PictureBox1.Image))
            TextQrcode.Text = result.Text
            MsgBox("Succesfully Decoded-Code : " + result.Text)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim SD As New SaveFileDialog
        SD.Filter = "PNG File|*.png"
        If SD.ShowDialog() = DialogResult.OK Then
            Try
                PictureBox1.Image.Save(SD.FileName, Imaging.ImageFormat.Png)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim OD As New OpenFileDialog
        OD.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        If OD.ShowDialog() = DialogResult.OK Then
            Try
                PictureBox1.Load(OD.FileName)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextQrcode.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim generate As New MessagingToolkit.Barcode.BarcodeEncoder
        generate.BackColor = Color.White
        generate.LabelFont = New Font("Arial", 7, FontStyle.Regular)
        generate.IncludeLabel = True
        generate.CustomLabel = TextQrcode.Text

        Try
            PictureBox1.Image = New Bitmap(generate.Encode(MessagingToolkit.Barcode.BarcodeFormat.QRCode, TextQrcode.Text))
        Catch ex As Exception
            PictureBox1.Image = Nothing
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form2.Show()
        Me.Hide()
    End Sub
End Class
