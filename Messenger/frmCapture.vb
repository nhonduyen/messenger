
Imports System.Math
Imports System.Environment
Imports System.IO
Imports System.Drawing.Imaging


Public Class frmCapture
    Inherits System.Windows.Forms.Form

    Public ipSend_ As String
    Public nameSend_ As String
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents picDesktop As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.picDesktop = New System.Windows.Forms.PictureBox()
        CType(Me.picDesktop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picDesktop
        '
        Me.picDesktop.BackColor = System.Drawing.Color.Transparent
        Me.picDesktop.Cursor = System.Windows.Forms.Cursors.Cross
        Me.picDesktop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picDesktop.Location = New System.Drawing.Point(0, 0)
        Me.picDesktop.Name = "picDesktop"
        Me.picDesktop.Size = New System.Drawing.Size(1165, 608)
        Me.picDesktop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDesktop.TabIndex = 0
        Me.picDesktop.TabStop = False
        '
        'frmCapture
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1165, 608)
        Me.ControlBox = False
        Me.Controls.Add(Me.picDesktop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCapture"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.picDesktop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Rubberband rectangle coordinates.
    Private m_Drawing As Boolean = False
    Private m_X1 As Integer
    Private m_Y1 As Integer
    Private m_X2 As Integer
    Private m_Y2 As Integer

    ' A saved image of the desktop.
    Private m_bmDesktop As Bitmap

    ' Drawing variables.
    Private m_grDesktop As Graphics

    Private Sub frmScreenCapture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()   
        Threading.Thread.Sleep(100)
        Application.DoEvents()

        ' Get the desktop image.
        m_bmDesktop = DesktopImage()

        ' Display the image.
        picDesktop.Image = DirectCast(m_bmDesktop.Clone(), Bitmap)

        Me.Show()
        'Me.TopMost = True
    End Sub

    ' Start dragging to select an area.
    Private Sub picDesktop_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picDesktop.MouseDown
        m_Drawing = True

        ' Save the point's coordinates.
        m_X1 = e.X
        m_X2 = e.X
        m_Y1 = e.Y
        m_Y2 = e.Y

        ' Make a Graphics object to draw on.
        m_grDesktop = picDesktop.CreateGraphics()
    End Sub

    ' Continue drawing.
    Private Sub picDesktop_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picDesktop.MouseMove
        If Not m_Drawing Then Exit Sub

        ' Save the new point.
        m_X2 = e.X
        m_Y2 = e.Y

        ' Redraw the desktop image.
        m_grDesktop.DrawImage(m_bmDesktop, 0, 0)

        ' Draw the rubberband rectangle.
        Dim rect As New Rectangle( _
            Min(m_X1, m_X2), Min(m_Y1, m_Y2), _
            Abs(m_X1 - m_X2), Abs(m_Y1 - m_Y2))
        m_grDesktop.DrawRectangle(Pens.Blue, rect)
    End Sub

    ' Stop drawing.
    Private Sub picDesktop_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picDesktop.MouseUp
        Try
            If Not m_Drawing Then Exit Sub
            m_Drawing = False

            ' Hide the form.
            Me.Hide()

            ' Get the name of a file on the desktop.

            Dim file_name As String
            file_name = Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & Now.Millisecond & ".jpg"

            ' Grab the selected piece of the image.
            Dim rect As New Rectangle( _
                Min(m_X1, m_X2), Min(m_Y1, m_Y2), _
                Abs(m_X1 - m_X2), Abs(m_Y1 - m_Y2))
            Dim bm As Bitmap = DirectCast( _
                m_bmDesktop.Clone(rect, m_bmDesktop.PixelFormat), Bitmap)

            ' Save the image into the file.
            bm.Save("temp\" + file_name, ImageFormat.Jpeg)
            bm.Dispose()
            Dim img As Image = Image.FromFile("temp\" + file_name)

            'Dim frm As New frmDisplayImage
            'Dim height As Integer
            'Dim width As Integer
            'frm.Location = New System.Drawing.Point((Screen.PrimaryScreen.WorkingArea.Width - img.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - img.Height) / 2)
            'If img.Height < Screen.PrimaryScreen.WorkingArea.Height - 82 Then
            '    height = img.Height + 82
            'Else
            '    height = Screen.PrimaryScreen.WorkingArea.Height - 82
            'End If

            ''If img.Width < Screen.PrimaryScreen.WorkingArea.Width Then
            'width = img.Width + 16
            ''Else
            ''    width = Screen.PrimaryScreen.WorkingArea.Width
            ''End If


            'frm.Size = New System.Drawing.Size(width, height)
            'frm.ptbImage.Size = New System.Drawing.Size(img.Width, img.Height)
            'frm.ptbImage.Location = New System.Drawing.Point(0, 0)
            ''frm.ptbImage.Image = img
            'frm.ptbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            'frm.btnSend.Location = New System.Drawing.Point(width - 218, height - 76)
            'frm.btnCancel.Location = New System.Drawing.Point(width - 120, height - 76)
            'frm.ipSend = ipSend_
            'frm.imagePath = "temp\" + file_name
            'frm.nameSend = nameSend_
            'frm.Text = "Send To : " + nameSend_ + " / " + ipSend_
            'frm.Show()
            'img.Dispose()
            'Me.Close()

            Dim frm As New frmDisplayImage
            Dim height As Integer
            Dim width As Integer

            height = Screen.PrimaryScreen.WorkingArea.Height
            width = Screen.PrimaryScreen.WorkingArea.Width


            frm.Size = New System.Drawing.Size(width, height)
            frm.ptbImage.Size = New System.Drawing.Size(width, height - 90)
            frm.ptbImage.Location = New System.Drawing.Point(0, 0)
            ''frm.ptbImage.Image = img
            frm.ptbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            frm.btnSend.Location = New System.Drawing.Point(width / 2 - 80, height - 80)
            frm.btnCancel.Location = New System.Drawing.Point(width / 2 + 30, height - 80)
            frm.ipSend = ipSend_
            frm.imagePath = "temp\" + file_name
            frm.nameSend = nameSend_
            frm.Text = "Send Image To : " + nameSend_ + " / " + ipSend_
            frm.Show()
            img.Dispose()
            frm.Location = New System.Drawing.Point(0, 0)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Your Image Size Incorect!( Need > 1 pixel )", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

#Region "Desktop Capture Routines"
    Private Declare Function GetDesktopWindow Lib "user32" () As Int32
    Private Declare Function GetDC Lib "user32" (ByVal hwnd As Int32) As Int32
    Private Declare Function StretchBlt Lib "gdi32" (ByVal hdc As IntPtr, ByVal x As Int32, ByVal y As Int32, _
                                                     ByVal nWidth As Int32, ByVal nHeight As Int32, ByVal hSrcDC As Int32, _
                                                     ByVal xSrc As Int32, ByVal ySrc As Int32, ByVal nSrcWidth As Int32, _
                                                     ByVal nSrcHeight As Int32, ByVal dwRop As Int32) As Int32
    Private Declare Function ReleaseDC Lib "user32" (ByVal hwnd As Int32, ByVal hdc As Int32) As Int32
    Private Structure RECT
        Dim Left As Int32
        Dim Top As Int32
        Dim Right As Int32
        Dim Bottom As Int32
    End Structure
    Private Const SRCCOPY As Int32 = &HCC0020

    ' Return an image of the desktop.
    Private Function DesktopImage() As Bitmap
        ' Get the desktop size in pixels.
        Dim desktop_win As Int32 = GetDesktopWindow()
        Dim desktop_dc As Int32 = GetDC(desktop_win)
        Dim desktop_bounds As Rectangle = Screen.GetBounds(New Point(1, 1))
        Dim desktop_wid As Int32 = desktop_bounds.Width
        Dim desktop_hgt As Int32 = desktop_bounds.Height

        ' Make a Bitmap to hold the image.
        Dim bm As New Bitmap(desktop_wid, desktop_hgt)
        Dim bm_gr As Graphics = Graphics.FromImage(bm)
        Dim bm_hdc As IntPtr = bm_gr.GetHdc

        ' Copy the desktop's image.
        StretchBlt( _
            bm_hdc, 0, 0, desktop_wid, desktop_hgt, _
            desktop_dc, 0, 0, desktop_wid, desktop_hgt, _
            SRCCOPY)

        ' Release the bitmap's  and desktop's DCs.
        bm_gr.ReleaseHdc(bm_hdc)
        ReleaseDC(desktop_win, desktop_dc)

        ' Return the result.
        Return bm
    End Function

#End Region ' Desktop Capture Routines

    Sub frmScreenCapture_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(27) Then
            Me.Close()
        End If
    End Sub
End Class
