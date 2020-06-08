﻿Imports System.IO


''' <summary>
''' This is the Main Communications Center
''' </summary>
Public Class Form_Chat_UI

    Public Newpoint As New Point

    'Methods for form positioning
    Public x, y As Integer

    Private mInputText As String = ""

    Private mloaded As Boolean = False

    Public Event TEXTRECIEVED(ByVal Text As String)

    Public ReadOnly Property Loaded As Boolean
        Get
            Return mloaded
        End Get
    End Property

    Public ReadOnly Property RecievedText As String
        Get
            Return mInputText
        End Get

    End Property

    Public Sub DISPLAYOUTPUT(ByRef NewText As String)
        TextOut.Text += "User: " & mInputText & vbNewLine & "AI: " & NewText & vbNewLine
    End Sub

    Private Sub Button_Enter_Click(sender As Object, e As EventArgs) Handles Button_Enter.Click
        mInputText = TextIn.Text
        TextIn.Text = ""
        RaiseEvent TEXTRECIEVED(mInputText)
    End Sub

    Private Sub Form_Chat_UI_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        mloaded = False
    End Sub

    Private Sub Form_Chat_UI_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        Me.Close()
    End Sub

    Private Sub Form_Chat_UI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox2.Height = 50
        mloaded = True
        Me.Height = 383
        Me.Width = 907
    End Sub

    Private Sub FrmMain_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        ' Form movement set integers
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub FrmMain_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        ' Form movement movement
        If e.Button = MouseButtons.Left Then
            Newpoint = Control.MousePosition
            Newpoint.X -= (x)
            Newpoint.Y -= (y)
            Me.Location = Newpoint
        End If
    End Sub

    Private Sub GroupBox2_DoubleClick(sender As Object, e As EventArgs) Handles GroupBox2.DoubleClick
        GroupBox2.Height = If(GroupBox2.Height <> 20, 20, 50)
    End Sub

End Class