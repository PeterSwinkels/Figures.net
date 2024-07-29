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
      Try
         InitializeComponent()

         My.Computer.FileSystem.CurrentDirectory = My.Application.Info.DirectoryPath

         Me.Text = My.Application.Info.Title

         With My.Computer.Screen.WorkingArea
            Me.Size = New Size(CInt(.Width / 1.1), CInt(.Height / 1.1))
         End With

         Me.Controls.Add(Canvas)
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure toggles the animator on/off.
   Private Sub AnimateFiguresMenu_Click(sender As Object, e As EventArgs) Handles AnimateFiguresMenu.Click
      Try
         Animator.Enabled = Not Animator.Enabled
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure gives the toggles drawing radii on/off.
   Private Sub DrawRadiiMenu_Click(sender As Object, e As EventArgs) Handles DrawRadiiMenu.Click
      Try
         For FigureDrawingProperty As Integer = FigureDrawingProperties.GetLowerBound(0) To FigureDrawingProperties.GetUpperBound(0)
            With FigureDrawingProperties(FigureDrawingProperty)
               .DrawRadii = Not .DrawRadii
            End With
         Next FigureDrawingProperty

         Canvas.Invalidate()
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure displays information about this program.
   Private Sub InformationMainMenu_Click(sender As Object, e As EventArgs) Handles InformationMainMenu.Click
      Try
         MessageBox.Show(My.Application.Info.Description, ProgramInformation(), MessageBoxButtons.OK, MessageBoxIcon.Information)
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub


   'This procedure closes this program when this window is closed.
   Private Sub InterfaceWindow_FormClosed(sender As Object, e As EventArgs) Handles Me.FormClosed
      Try
         Application.Exit()
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub
End Class
