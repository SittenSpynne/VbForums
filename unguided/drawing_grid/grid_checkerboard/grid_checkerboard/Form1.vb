Public Class Form1

    ' Using constants for information like this makes it easier to change
    ' things later.
    Private Const COLUMNS As Integer = 3
    Private Const ROWS As Integer = 3

    Private Const CELL_WIDTH As Integer = 64
    Private Const CELL_HEIGHT As Integer = 64

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim currentX As Integer = 0
        Dim currentY As Integer = 0

        Dim isBlack As Boolean = False

        For currentRow As Integer = 0 To ROWS - 1
            ' At the start of each row, make sure to reset CurrentX.
            currentX = 0
            For currentColumn As Integer = 0 To COLUMNS - 1
                Dim bounds As New Rectangle(currentX, currentY, CELL_WIDTH, CELL_HEIGHT)
                Dim brush As Brush = If(isBlack, Brushes.Black, Brushes.White)
                e.Graphics.FillRectangle(brush, bounds)

                ' After drawing each column, move over by the cell width.
                currentX += CELL_WIDTH

                ' Change colors every cell.
                isBlack = Not isBlack
            Next

            ' After finishing a row, move down by the cell height.
            currentY += CELL_HEIGHT
        Next
    End Sub

End Class
