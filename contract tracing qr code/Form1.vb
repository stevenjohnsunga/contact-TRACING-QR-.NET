Imports ZXing.Common
Imports ZXing
Imports ZXing.QrCode
Imports System.Net.Mime.MediaTypeNames
Imports System.Text.RegularExpressions

Public Class Form1
    Dim pic As Bitmap = New Bitmap(190, 190)
    Dim gfx As Graphics = Graphics.FromImage(pic)

    Public Function CountWords(ByVal value As String) As Integer
        ' Count matches.
        Dim collection As MatchCollection = Regex.Matches(value, "\S+")
        Return collection.Count
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Reader As New BarcodeReader()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Reader As New BarcodeReader()
        Dim mystr As String = ""
        Dim cnt As Integer
        PictureBox2.Image = pic

        Dim result As Result = Reader.Decode(pic)
        Try
            Dim decoded As String = result.ToString().Trim()
            TextBox1.Text = decoded
            mystr = decoded
            cnt = CountWords(decoded)
        Catch ex As Exception

        End Try
        Dim strarray(cnt - 1) As String
        Dim words As String() = mystr.Split(New Char() {" "c})
        For i As Integer = 0 To 4

        Next
        MessageBox.Show(cnt)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        gfx.CopyFromScreen(New Point(Me.Location.X + PictureBox1.Location.X + 4, Me.Location.Y + PictureBox1.Location.Y + 30), New Point(0, 0), pic.Size)
        PictureBox1.Image = pic
        PictureBox1.Image = Nothing
    End Sub
End Class
