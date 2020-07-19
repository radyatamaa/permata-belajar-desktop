Module Module1
    Sub BorderColor(ByVal Ctl As Control, ByVal cColor As Color, Optional ByVal wWidth As Integer = 1)

        Ctl.Region = New Region(New Rectangle(wWidth, wWidth, Ctl.Width - (wWidth * 2), Ctl.Height - (wWidth * 2)))

        Windows.Forms.ControlPaint.DrawBorder(Ctl.Parent.CreateGraphics,
         Ctl.Bounds, cColor, wWidth, 3, cColor, wWidth, 3, cColor, wWidth, 3,
        cColor, wWidth, 3)

        Ctl.Refresh()

    End Sub

End Module
