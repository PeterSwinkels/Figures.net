'This module's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Drawing
Imports System.Windows.Forms

'This module contains this program's main interface window.
Public Class InterfaceWindow
   'This procedure initializes this window.
   Public Sub New()
      InitializeComponent()

      My.Computer.FileSystem.CurrentDirectory = My.Application.Info.DirectoryPath

      With My.Application.Info
         Me.Text = $"{ .Title} v{ .Version} - by: { .CompanyName}"
      End With

      With My.Computer.Screen.WorkingArea
         Me.Size = New Size(CInt(.Width / 1.1), CInt(.Height / 1.1))
      End With

      Me.Controls.Add(Canvas)
   End Sub

   'This procedure closes this program when this window is closed.
   Private Sub InterfaceWindow_FormClosed(sender As Object, e As EventArgs) Handles Me.FormClosed
      Application.Exit()
   End Sub

   'This procedure handles the user's key strokes.3
   Private Sub InterfaceWindow_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      For FigureDrawingProperty As Integer = FigureDrawingProperties.GetLowerBound(0) To FigureDrawingProperties.GetUpperBound(0)
         With FigureDrawingProperties(FigureDrawingProperty)
            .DrawRadii = Not .DrawRadii
         End With
      Next FigureDrawingProperty

      Canvas.Invalidate()
   End Sub
End Class
