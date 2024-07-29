﻿'This module's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Environment
Imports System.Linq
Imports System.Math
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

'This module contains this program's core procedures.
Public Module CoreModule
   'The constants used by this program.
   Private Const DEGREES_PER_RADIAN As Double = 180 / PI   'Defines the number of degrees per radian.

   'This structure defines a polygon's drawing properties.
   Public Structure FigureDrawingPropertiesStr
      Public Angle As Double        'Defines the angle at which the polygon will be displayed.
      Public DrawRadii As Boolean   'Indicates whether the polygon's radii will be displayed.
   End Structure

   'This structure defines a polygon and the way it will be drawn.
   Private Structure FigureStr
      Public Center As Point        'Defines the polygon's center.
      Public EdgeColor As Color     'Defines the polygon's edge color.
      Public LineWidth As Integer   'Defines the polygon's line width.
      Public Radii() As Integer     'Defines the polygon's radii.
   End Structure

   'The objects used by this program.
   Public WithEvents Animator As New Timer With {.Enabled = False, .Interval = 125}                                                                                                                  'Contains the timer that controls the animation.
   Public WithEvents Canvas As New PictureBox With {.BackColor = Color.Black, .Height = My.Computer.Screen.WorkingArea.Height, .Left = 0, .Top = 0, .Width = My.Computer.Screen.WorkingArea.Width}   'Contains the canvas on which the polygons are drawn.

   'The variables used by this module.
   Public ReadOnly FigureDrawingProperties() As FigureDrawingPropertiesStr = Enumerable.Repeat(New FigureDrawingPropertiesStr With {.Angle = 0, .DrawRadii = False}, 10).ToArray()   'Contains the polygons' drawing properties.
   Private ReadOnly FigureSet As New List(Of FigureStr) From {
   New FigureStr With {.Center = New Point(110, 130), .EdgeColor = Color.Green, .LineWidth = 2, .Radii = GenerateRadii(SeedRadii:={100}, Repeat:=360)},
   New FigureStr With {.Center = New Point(320, 130), .EdgeColor = Color.Green, .LineWidth = 2, .Radii = GenerateRadii(SeedRadii:={100}, Repeat:=8)},
   New FigureStr With {.Center = New Point(530, 130), .EdgeColor = Color.Green, .LineWidth = 2, .Radii = GenerateRadii(SeedRadii:={100}, Repeat:=6)},
   New FigureStr With {.Center = New Point(740, 130), .EdgeColor = Color.Green, .LineWidth = 2, .Radii = GenerateRadii(SeedRadii:={100}, Repeat:=4)},
   New FigureStr With {.Center = New Point(950, 130), .EdgeColor = Color.Green, .LineWidth = 2, .Radii = GenerateRadii(SeedRadii:={100}, Repeat:=3)},
   New FigureStr With {.Center = New Point(110, 340), .EdgeColor = Color.Green, .LineWidth = 2, .Radii = GenerateRadii(SeedRadii:={100}, Repeat:=2)},
   New FigureStr With {.Center = New Point(320, 340), .EdgeColor = Color.Red, .LineWidth = 2, .Radii = GenerateRadii(SeedRadii:={50, 100}, Repeat:=5)},
   New FigureStr With {.Center = New Point(520, 340), .EdgeColor = Color.Red, .LineWidth = 2, .Radii = GenerateRadii(SeedRadii:={100, 100, 80, 80}, Repeat:=15)},
   New FigureStr With {.Center = New Point(850, 450), .EdgeColor = Color.Blue, .LineWidth = 3, .Radii = ExtendFigure(GenerateRadii(SeedRadii:={100}, Repeat:=3), GenerateRadii(SeedRadii:={200}, Repeat:=1))}
   }   'Contains the polygons' data.

   'This procedure animates the various polygons by changing their angle.
   Private Sub Animator_Tick(sender As Object, e As EventArgs) Handles Animator.Tick
      Try
         For FigureDrawingProperty As Integer = FigureDrawingProperties.GetLowerBound(0) To FigureDrawingProperties.GetUpperBound(0)
            With FigureDrawingProperties(FigureDrawingProperty)
               If .Angle >= 360 Then .Angle = 0 Else .Angle += 8
            End With
         Next FigureDrawingProperty

         Canvas.Invalidate()
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure refreshes the canvas when it's added to another control.
   Private Sub Canvas_ControlAdded(sender As Object, e As EventArgs) Handles Canvas.ControlAdded
      Try
         Canvas.Invalidate()
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to draw the polygon's.
   Private Sub Canvas_Paint(sender As Object, e As PaintEventArgs) Handles Canvas.Paint
      Try
         e.Graphics.Clear(Color.Black)

         For Figure As Integer = 0 To FigureSet.Count - 1
            DrawFigure(e.Graphics, FigureSet(Figure), FigureDrawingProperties(Figure))
         Next Figure
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure displays any errors that occur.
   Public Sub DisplayError(ExceptionO As Exception)
      Try
         MessageBox.Show(ExceptionO.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch
         [Exit](0)
      End Try
   End Sub

   'This procedure draws the specified polygon at the specified angle and position.
   Private Sub DrawFigure(CanvasGraphics As Graphics, Figure As FigureStr, FigureDrawingProperties As FigureDrawingPropertiesStr)
      Try
         Dim Increment As Double = 360 / Figure.Radii.Count
         Dim NextRadiusTipX As New Integer
         Dim NextRadiusTipY As New Integer
         Dim RadiusTipX As New Integer
         Dim RadiusTipY As New Integer

         With Figure
            For Radius As Integer = .Radii.GetLowerBound(0) To .Radii.GetUpperBound(0)
               RadiusTipX = CInt((Cos(FigureDrawingProperties.Angle.ToRadians()) * .Radii(Radius)) + .Center.X)
               RadiusTipY = CInt((Sin(FigureDrawingProperties.Angle.ToRadians()) * .Radii(Radius)) + .Center.Y)
               If Radius = .Radii.Count - 1 Then
                  NextRadiusTipX = CInt((Cos((FigureDrawingProperties.Angle + Increment).ToRadians()) * .Radii(0)) + .Center.X)
                  NextRadiusTipY = CInt((Sin((FigureDrawingProperties.Angle + Increment).ToRadians()) * .Radii(0)) + .Center.Y)
               Else
                  NextRadiusTipX = CInt((Cos((FigureDrawingProperties.Angle + Increment).ToRadians()) * .Radii(Radius + 1)) + .Center.X)
                  NextRadiusTipY = CInt((Sin((FigureDrawingProperties.Angle + Increment).ToRadians()) * .Radii(Radius + 1)) + .Center.Y)
               End If

               If FigureDrawingProperties.DrawRadii Then CanvasGraphics.DrawLine(Pens.White, .Center.X, .Center.Y, NextRadiusTipX, NextRadiusTipY)
               CanvasGraphics.DrawLine(New Pen(New SolidBrush(.EdgeColor), .LineWidth), RadiusTipX, RadiusTipY, NextRadiusTipX, NextRadiusTipY)

               FigureDrawingProperties.Angle += Increment
            Next Radius
         End With
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure extends one polygon by extending it with another polygon and returns the result.
   Private Function ExtendFigure(Figure() As Integer, Extension() As Integer) As Integer()
      Try
         Dim Extended As New List(Of Integer)(Figure)

         Extended.AddRange(Extension)

         Return Extended.ToArray()
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure generates a set of radii using the specified seed radii.
   Private Function GenerateRadii(SeedRadii() As Integer, Optional Repeat As Integer = 1) As Integer()
      Try
         Dim Radii As New List(Of Integer)

         For Repetition As Integer = 1 To Repeat
            Radii.AddRange(SeedRadii)
         Next Repetition

         Return Radii.ToArray()
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure returns information about this program.
   Public Function ProgramInformation() As String
      Try
         Dim Information As String = Nothing

         With My.Application.Info
            Information = $"{ .Title} v{ .Version} - by: { .CompanyName}"
         End With

         Return Information
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure converts the specified value measured in degrees to radians.
   <Extension>
   Private Function ToRadians(Degrees As Double) As Double
      Try
         Return Degrees / DEGREES_PER_RADIAN
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try

      Return Nothing
   End Function
End Module
