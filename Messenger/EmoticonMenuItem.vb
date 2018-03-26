Imports System
Imports System.Drawing
Imports System.Windows.Forms


Namespace Messager.Controls
    Public Class EmoticonMenuItem
        Inherits System.Windows.Forms.MenuItem

        Private Const ICON_WIDTH As Integer = 18
        Private Const ICON_HEIGHT As Integer = 18
        Private Const ICON_MARGIN As Integer = 4
        Private backgroundColor As Color, selectionColor As Color, selectionBorderColor As Color
        Public image As Image

        Public Property Images() As Image
            Get
                Return image
            End Get
            Set(ByVal value As Image)
                image = value
            End Set
        End Property

        Public Sub New()
            Me.OwnerDraw = True
            backgroundColor = SystemColors.ControlLightLight
            selectionColor = Color.FromArgb(50, 0, 0, 150)
            selectionBorderColor = SystemColors.Highlight
        End Sub

        Public Sub New(ByVal _image As Image)
            Me.New()
            image = _image
        End Sub

        Protected Overrides Sub OnMeasureItem(ByVal _args As MeasureItemEventArgs)
            _args.ItemWidth = ICON_WIDTH + ICON_MARGIN
            _args.ItemHeight = ICON_HEIGHT + 2 * ICON_MARGIN
        End Sub

        Protected Overrides Sub OnDrawItem(ByVal _args As DrawItemEventArgs)
            Dim _graphics As Graphics = _args.Graphics
            Dim _bounds As Rectangle = _args.Bounds

            DrawBackground(_graphics, _bounds, ((_args.State And DrawItemState.Selected) <> 0))

            _graphics.DrawImage(image, CType(_bounds.X + ((_bounds.Width - ICON_WIDTH) / 2), Int32), CType(_bounds.Y + ((_bounds.Height - ICON_HEIGHT) / 2), Int32))
        End Sub

        Private Sub DrawBackground(ByVal _graphics As Graphics, ByVal _bounds As Rectangle, ByVal _selected As Boolean)
            If _selected Then
                _graphics.FillRectangle(New SolidBrush(selectionColor), _bounds)
                _graphics.DrawRectangle(New Pen(selectionBorderColor), _bounds.X, _bounds.Y, _bounds.Width - 1, _bounds.Height - 1)
            Else
                _graphics.FillRectangle(New SolidBrush(backgroundColor), _bounds)
            End If
        End Sub
    End Class

End Namespace

