Public Class Form1
    Dim Bped, Lped, B, H, ef, ew, Bpb, Lpb, epb, grout, Bllc, hllc, ellc, esi, np, dp, proy, nat, hat, eat, naty, haty, eaty, sepx, sepy
    Dim codigo, svgForm, svgPDF
    Dim daux = 100
    Dim diametros = {19, 22, 25, 32, 38, 44, 51, 64}
    Dim perforaciones = {1 + 5 / 16, 1 + 9 / 16, +1 + 13 / 16, 2 + 1 / 16, 2 + 5 / 16, 2 + 3 / 4, 3 + 1 / 4, 3 + 3 / 4}
    Dim defs = <defs>
                   <marker
                       id="arrow"
                       viewBox="0 0 10 10"
                       refX="1"
                       refY="5"
                       markerUnits="strokeWidth"
                       markerWidth="10"
                       markerHeight="10"
                       orient="auto">
                       <path d="M 0 0 L 10 5 L 0 10 z" fill="blue" stroke="blue"/>
                   </marker>
               </defs>

    Dim styles = <style>
                    .estil {
                        font: 18px arial;
                        fill: blue }
                 </style>

    Private Sub AbrirCodigo_Click(sender As Object, e As EventArgs) Handles AbrirCodigo.Click
        Dim infoCod = New Form2()
        infoCod.WebView22.Source = New Uri("https://github.com/pbaezr/Dibujo-Anclaje-Columnas/blob/main/Form1.vb")
        infoCod.ShowDialog()
    End Sub

    Private Sub dperno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dperno.SelectedIndexChanged
        TextBox16.Text = diametros(dperno.SelectedIndex)
    End Sub

    Private Sub dibpedes_CheckedChanged(sender As Object, e As EventArgs) Handles dibpedes.CheckedChanged
        Dim status = dibpedes.Checked
        TextBox10.Enabled = status
        TextBox9.Enabled = status
    End Sub

    Private Sub hay_atiex_CheckedChanged(sender As Object, e As EventArgs) Handles hay_atiex.CheckedChanged
        Dim status = hay_atiex.Checked
        TextBox21.Enabled = status
        TextBox17.Enabled = status
        TextBox15.Enabled = status
    End Sub
    Private Sub hay_atiey_CheckedChanged(sender As Object, e As EventArgs) Handles hay_atiey.CheckedChanged
        Dim status = hay_atiey.Checked
        TextBox22.Enabled = status
        TextBox24.Enabled = status
        TextBox23.Enabled = status
    End Sub

    Private Sub haysilla_CheckedChanged(sender As Object, e As EventArgs) Handles haysilla.CheckedChanged
        Dim status = haysilla.Checked
        TextBox11.Enabled = status
        RadioButton1.Enabled = status
        RadioButton2.Enabled = status
    End Sub

    Private Sub hayllave_CheckedChanged(sender As Object, e As EventArgs) Handles hayllave.CheckedChanged
        Dim status = hayllave.Checked
        TextBox14.Enabled = status
        TextBox13.Enabled = status
        TextBox12.Enabled = status
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dperno.SelectedIndex = 0
        TextBox18.Text = 330
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Double.TryParse(Val(TextBox1.Text), H)
        Double.TryParse(Val(TextBox2.Text), B)
        Double.TryParse(Val(TextBox3.Text), ef)
        Double.TryParse(Val(TextBox4.Text), ew)

        Double.TryParse(Val(TextBox8.Text), Bpb)
        Double.TryParse(Val(TextBox7.Text), Lpb)
        Double.TryParse(Val(TextBox6.Text), epb)
        Double.TryParse(Val(TextBox5.Text), grout)

        Double.TryParse(Val(TextBox10.Text), Bped)
        Double.TryParse(Val(TextBox9.Text), Lped)

        Double.TryParse(Val(TextBox14.Text), Bllc)
        Double.TryParse(Val(TextBox13.Text), hllc)
        Double.TryParse(Val(TextBox12.Text), ellc)

        Double.TryParse(Val(TextBox11.Text), esi)

        Double.TryParse(Val(TextBox20.Text), np)
        'Double.TryParse(Val(TextBox19.Text), dp)
        Double.TryParse(Val(TextBox18.Text), proy)

        Double.TryParse(Val(TextBox21.Text), nat)
        Double.TryParse(Val(TextBox17.Text), hat)
        Double.TryParse(Val(TextBox15.Text), eat)

        Double.TryParse(Val(TextBox22.Text), naty)
        Double.TryParse(Val(TextBox24.Text), haty)
        Double.TryParse(Val(TextBox23.Text), eaty)

        Double.TryParse(Val(TextBox27.Text), sepx)
        Double.TryParse(Val(TextBox26.Text), sepy)

        codigo = ""

        'vista en elevación
        If haysilla.Checked Then
            dibujarRectangulo(-H / 2 + ef, 0, H - 2 * ef, esi, "white") 'silla
            If RadioButton2.Checked = True Then
                dibujarRectangulo(-Lpb / 2, 0, (Lpb - H) / 2, esi, "white")
                dibujarRectangulo(H / 2, 0, (Lpb - H) / 2, esi, "white")
            End If
        Else
            esi = 22 'solo para tener una cota para empezar a didujar
        End If

        If hay_atiex.Checked Then
            dibujarRectangulo(-eat / 2, esi, eat, hat, "white") 'atiesador
        Else
            hat = 250 'solo para tener una cota para empezar a didujar
        End If

        If hay_atiey.Checked Then
            dibujarRectangulo(-Lpb / 2, esi, (Lpb - H) / 2, haty, "white") 'atiesador izq
            dibujarRectangulo(H / 2, esi, (Lpb - H) / 2, haty, "white") 'atiesador der
        End If

        If hayllave.Checked Then
            dibujarRectangulo(-Bllc / 2, hat + esi + epb, Bllc, hllc, "white") 'llave de corte
            dibujarRectangulo(-ellc / 2, hat + esi + epb, ellc, hllc, "white") 'llave de corte transversal
        Else
            hllc = 0
        End If

        'dibujarRectangulo(-H / 2 + ef, esi, H - 2 * ef, hat, "white") 'alma
        dibujarRectangulo(-H / 2, -daux, ef, hat + esi + daux, "white") 'ala izquierda
        dibujarRectangulo(H / 2 - ef, -daux, ef, hat + esi + daux, "white") 'ala derecha
        dibujarRectangulo(-Lpb / 2, hat + esi, Lpb, epb, "white") 'placa base

        'corte superior en perfil
        Dim daux2 = daux / 4
        Dim x0(6), y0(6)
        x0(0) = -H / 2 - daux2 : y0(0) = -daux
        x0(1) = -daux2 / 4 : y0(1) = -daux
        x0(2) = 0 : y0(2) = y0(1) + daux2 / 2
        x0(3) = 0 : y0(3) = y0(1) - daux2 / 2
        x0(4) = -x0(1) : y0(4) = y0(1)
        x0(5) = -x0(0) : y0(5) = y0(0)
        dibujarlinea(x0, y0, "black")

        'grout
        Dim xi(12), yi(12)
        xi(0) = -Lpb / 2 : yi(0) = hat + esi + epb
        xi(1) = xi(0) - grout : yi(1) = yi(0) + grout
        xi(2) = -Bllc / 2 - grout : yi(2) = yi(1)
        xi(3) = xi(2) : yi(3) = yi(0) + hllc + grout
        xi(4) = -xi(3) : yi(4) = yi(3)
        xi(5) = xi(4) : yi(5) = yi(2)
        xi(6) = -xi(1) : yi(6) = yi(1)
        xi(7) = -xi(0) : yi(7) = yi(0)
        xi(8) = Bllc / 2 : yi(8) = yi(7)
        xi(9) = xi(8) : yi(9) = yi(8) + hllc
        xi(10) = -xi(9) : yi(10) = yi(9)
        xi(11) = xi(10) : yi(11) = yi(10) - hllc
        dibujarPoligono(xi, yi, "gray", 0.15)

        'vista en planta
        Dim daux3 = hat + esi + epb + grout + 3 * daux

        If dibpedes.Checked Then
            Dim xped(12), yped(12)
            xped(0) = -Lped / 2 : yped(0) = hat + esi + epb + grout
            xped(1) = xped(0) : yped(1) = yped(0) + 2 * daux
            xped(2) = -daux2 / 4 : yped(2) = yped(1)
            xped(3) = 0 : yped(3) = yped(2) + daux2 / 2
            xped(4) = 0 : yped(4) = yped(2) - daux2 / 2
            xped(5) = -xped(2) : yped(5) = yped(2)
            xped(6) = -xped(1) : yped(6) = yped(1)
            xped(7) = -xped(0) : yped(7) = yped(0)
            Dim j = 0
            For i = 8 To 11
                xped(i) = xi(5 - j) : yped(i) = yi(5 - j)
                j = j + 1
            Next
            dibujarPoligono(xped, yped, "gray", 0.3)
            codigo = codigo + "<line x1=" + (-Lped / 2 - daux2).ToString + " y1=" + yped(1).ToString + " x2=" + (-Lped / 2).ToString + " y2=" + yped(1).ToString + " stroke=black />" + "<line x1=" + (Lped / 2).ToString + " y1=" + yped(1).ToString + " x2=" + (Lped / 2 + daux2).ToString + " y2=" + yped(1).ToString + " stroke=black />"
            dibujarPoligono({-Lped / 2, -Lped / 2, Lped / 2, Lped / 2, -Lped / 2}, {daux3, daux3 + Bped, daux3 + Bped, daux3, daux3}, "gray", 0.3)
        Else
            Bped = Bpb
        End If

        dibujarRectangulo(-Lpb / 2, daux3 + (Bped - Bpb) / 2, Lpb, Bpb, "white") 'placa base
        dibujarRectangulo(-H / 2, daux3 + (Bped - B) / 2, ef, B, "white") 'ala izquierda
        dibujarRectangulo(H / 2 - ef, daux3 + (Bped - B) / 2, ef, B, "white") 'ala derecha
        dibujarRectangulo(-H / 2 + ef, daux3 + (Bped - ew) / 2, H - 2 * ef, ew, "white") 'alma

        If hay_atiex.Checked Then 'atiesador
            dibujarRectangulo(-eat / 2, daux3 + (Bped - B) / 2, eat, (B - ew) / 2, "white") 'atiesador arriba
            dibujarRectangulo(-eat / 2, daux3 + (Bped + ew) / 2, eat, (B - ew) / 2, "white") 'atiesador abajo
        End If

        If hay_atiey.Checked Then
            dibujarRectangulo(-Lpb / 2, daux3 + (Bped - eaty) / 2, (Lpb - H) / 2, eaty, "white") 'atiesador izq
            dibujarRectangulo(H / 2, daux3 + (Bped - eaty) / 2, (Lpb - H) / 2, eaty, "white") 'atiesador der
        End If

        'pernos
        Dim xp, yp
        For i = 0 To np / 2 - 1
            xp = sepx * (i - (np / 2 - 1) / 2)
            yp = daux3 + Bped / 2 - sepy / 2
            codigo = codigo + "<circle style=""fill:gray; fill-opacity:0.3; stroke:black"" cx=" + xp.ToString + " cy=" + yp.ToString + " r=" + (0.5 * 25.4 * perforaciones(dperno.SelectedIndex)).ToString + " />" +
                "<circle style=""fill:gray; fill-opacity:0.3; stroke:black"" cx=" + xp.ToString + " cy=" + (yp + sepy).ToString + " r=" + (0.5 * 25.4 * perforaciones(dperno.SelectedIndex)).ToString + " />"
            dibujarlinea({xp, xp, xp}, {yp + sepy, daux3 + (Bped - Bpb) / 2 - 50, daux3 + (Bped - Bpb) / 2 - 50}, "blue")
        Next
        dibujarlinea({-sepx * (np / 2 - 1) / 2, xp + 160, xp + 160}, {daux3 + (Bped - Bpb) / 2 - 50, daux3 + (Bped - Bpb) / 2 - 50, daux3 + (Bped - Bpb) / 2 - 50}, "blue")
        codigo = codigo + "<text x=" + (xp + 30).ToString + " y=" + (daux3 + (Bped - Bpb) / 2 - 60).ToString + " class=estil >" + np.ToString + " pernos ϕ " + dperno.SelectedItem.ToString + """</text>" +
            "<text x=" + (xp + 30).ToString + " y=" + (daux3 + (Bped - Bpb) / 2 - 30).ToString + " class=estil >perf = " + Format(25.4 * perforaciones(dperno.SelectedIndex), "###0.0") + " mm </text>"

        'cotas
        Dim xmin = -Lpb / 2 - grout - 25, xmax = -xmin, ymax = esi + hat + epb + hllc + grout + 30, ymax2 = daux3 + (Bped + Bpb) / 2 + grout + 25
        Dim auxx = 15
        trazarCotaEspesor(xmin, 0, xmin, esi, {xmin - auxx, -H / 2 - auxx}, {xmin - auxx, -H / 2 - auxx}, "izq", "arriba", True) 'espesor silla
        trazarCotaEspesor(xmin, esi + hat, xmin, esi + hat + epb, {xmin - auxx, xmin + auxx}, {xmin - auxx, xmin + auxx}, "izq", "arriba", True) 'espesor placa base
        trazarCotaEspesor(xmin, esi + hat + epb, xmin, esi + hat + epb + grout, {xmin - auxx, xmin + auxx}, {xmin - auxx, xmin + auxx}, "izq", "abajo", True) 'espesor grout
        trazarCota(xmax, esi, xmax, esi + hat, {H / 2 + auxx, xmax + auxx}, {xmax - auxx, xmax + auxx}, "der") 'altura atiesador
        trazarCotaEspesor(-eat / 2, esi + hat / 2, eat / 2, esi + hat / 2, {0, 0}, {0, 0}, "der", "arriba", False) 'espesor atiesador
        trazarCota(xmax, esi + hat + epb, xmax, esi + hat + epb + hllc, {xmax - auxx, xmax + auxx}, {Bllc / 2 + grout + auxx, xmax + auxx}, "der") 'altura llave de corte
        trazarCota(-Bllc / 2, ymax, Bllc / 2, ymax, {ymax - auxx, ymax + auxx}, {ymax - auxx, ymax + auxx}, "abajo") 'ancho llave de corte
        trazarCotaEspesor(-ellc / 2, esi + hat + epb + hllc / 2, ellc / 2, esi + hat + epb + hllc / 2, {0, 0}, {0, 0}, "der", "arriba", False) 'espesor llave de corte
        trazarCota(-Lpb / 2, ymax2, Lpb / 2, ymax2, {ymax2 - auxx, ymax2 + auxx}, {ymax2 - auxx, ymax2 + auxx}, "abajo") 'largo placa base
        trazarCota(xmin, daux3 + (Bped - Bpb) / 2, xmin, daux3 + (Bped + Bpb) / 2, {xmin - auxx, xmin + auxx}, {xmin - auxx, xmin + auxx}, "izq") 'ancho placa base

        svgForm = "<head><meta http-equiv=x-ua-compatible content=IE=EDGE><svg viewBox=""-" + (H / 2 + 2 * grout).ToString + " -150 200 200"" preserveAspectRatio=""xMidYMid meet"" ""xmlns=http://www.w3.org/2000/svg>" + defs.ToString + styles.ToString + codigo

        'svgPDF = "<head><meta http-equiv=x-ua-compatible content=IE=EDGE></head><svg viewBox=""-" + (Bped / 2).ToString + " -" + (H / 2).ToString + " " + (3 * Lped).ToString + " " + (H / 2 + esi + hat + epb + hllc + H / 2).ToString + """ preserveAspectRatio=""xMidYMid meet"" xmlns=http://www.w3.org/2000/svg>" + defs.ToString + codigo
        'IO.File.WriteAllText("info.html", svgPDF)

        WebBrowser1.DocumentText = svgForm
    End Sub

    Private Sub dibujarPoligono(xi, yi, color, opacidad)
        Dim poli = "<polygon style=""fill:" + color + ";fill-opacity:" + opacidad.ToString + ";stroke:black"" points="""
        For i = 0 To UBound(xi) - 1
            poli = poli + xi(i).ToString + "," + yi(i).ToString + " "
        Next
        poli = poli + """/>"
        codigo = codigo + poli
    End Sub

    Private Sub dibujarRectangulo(x0, y0, lx, ly, color)
        dibujarPoligono({x0, x0, x0 + lx, x0 + lx, x0}, {y0, y0 + ly, y0 + ly, y0, y0}, color, 1)
    End Sub

    Private Sub dibujarlinea(xi, yi, color)
        Dim poli = "<polyline fill=none" + " stroke=" + color + " points="""
        For i = 0 To UBound(xi) - 1
            poli = poli + xi(i).ToString + "," + yi(i).ToString + " "
        Next
        poli = poli + """/>"
        codigo = codigo + poli
    End Sub

    Private Sub trazarCota(x1, y1, x2, y2, de1, de2, pos_tex)
        Dim angulo '= Math.Atan2(y1 - y2, x1 - x2) * 180 / Math.PI
        Dim medida = ((x1 - x2) ^ 2 + (y1 - y2) ^ 2) ^ 0.5
        Dim lineas, texto, posx, posy
        If x1 - x2 = 0 Then
            Dim minY = Math.Min(y1, y2), maxY = Math.Max(y1, y2)
            angulo = -90
            lineas = "<line x1=" + x1.ToString + " y1=" + (y1 / 2 + y2 / 2).ToString + " x2=" + x2.ToString + " y2=" + (minY + 10).ToString + " stroke=blue marker-end=url(#arrow) />" +
                    "<line x1=" + x1.ToString + " y1=" + (y1 / 2 + y2 / 2).ToString + " x2=" + x2.ToString + " y2=" + (maxY - 10).ToString + " stroke=blue marker-end=url(#arrow) />" +
                    "<line x1=" + de1(0).ToString + " y1=" + y1.ToString + " x2=" + de1(1).ToString + " y2=" + y1.ToString + " stroke=blue />" +
                    "<line x1=" + de2(0).ToString + " y1=" + y2.ToString + " x2=" + de2(1).ToString + " y2=" + y2.ToString + " stroke=blue />"
            If pos_tex = "izq" Then
                posx = x1 - 10
            ElseIf pos_tex = "der" Then
                posx = x1 + 20
            End If
            texto = "<text transform=""translate(" + posx.ToString + "," + (y1 / 2 + y2 / 2 + 3 * (((y1 / 2 + y2 / 2).ToString).Length)).ToString + ") rotate(" + angulo.ToString + ")"" class=estil >" + medida.ToString + "</text>"
        Else 'If y1 - y2 = 0 Then
            Dim minX = Math.Min(x1, x2), maxX = Math.Max(x1, x2)
            angulo = 0
            lineas = "<line x1=" + (x1 / 2 + x2 / 2).ToString + " y1=" + y1.ToString + " x2=" + (minX + 10).ToString + " y2=" + y2.ToString + " stroke=blue marker-end=url(#arrow) />" +
                    "<line x1=" + (x1 / 2 + x2 / 2).ToString + " y1=" + y1.ToString + " x2=" + (maxX - 10).ToString + " y2=" + y2.ToString + " stroke=blue marker-end=url(#arrow) />" +
                    "<line y1=" + de1(0).ToString + " x1=" + x1.ToString + " y2=" + de1(1).ToString + " x2=" + x1.ToString + " stroke=blue />" +
                    "<line y1=" + de2(0).ToString + " x1=" + x2.ToString + " y2=" + de2(1).ToString + " x2=" + x2.ToString + " stroke=blue />"
            If pos_tex = "arriba" Then
                posy = y1 - 10
            ElseIf pos_tex = "abajo" Then
                posy = y1 + 20
            End If
            texto = "<text transform=""translate(" + (x1 / 2 + x2 / 2 - 6 * (medida.ToString).Length).ToString + "," + posy.ToString + ") rotate(" + angulo.ToString + ")"" class=estil >" + medida.ToString + "</text>"
        End If

        codigo = codigo + lineas + texto
    End Sub

    Private Sub trazarCotaEspesor(x1, y1, x2, y2, de1, de2, pos_tex_x, pos_tex_y, conLineaCentral)
        Dim angulo '= Math.Atan2(y1 - y2, x1 - x2) * 180 / Math.PI
        Dim medida = (((x1 - x2) ^ 2 + (y1 - y2) ^ 2) ^ 0.5)
        Dim lineas = "", texto, posx, posy
        If conLineaCentral = True Then lineas = "<line x1=" + x1.ToString + " y1=" + y1.ToString + " x2=" + x2.ToString + " y2=" + y2.ToString + " stroke=blue />"

        Dim Lflecha = 50
        If hayllave.Checked = True Then Lflecha = Math.Min(Lflecha, Bllc / 2 - ellc / 2 - 5)
        If x1 - x2 = 0 Then
            Dim minY = Math.Min(y1, y2), maxY = Math.Max(y1, y2)
            angulo = -90
            lineas = lineas + "<line x1=" + x1.ToString + " y1=" + (minY - Lflecha).ToString + " x2=" + x2.ToString + " y2=" + (minY - 10).ToString + " stroke=blue marker-end=url(#arrow) />" +
                "<line x1=" + x1.ToString + " y1=" + (maxY + Lflecha).ToString + " x2=" + x2.ToString + " y2=" + (maxY + 10).ToString + " stroke=blue marker-end=url(#arrow) />" +
                "<line x1=" + de1(0).ToString + " y1=" + y1.ToString + " x2=" + de1(1).ToString + " y2=" + y1.ToString + " stroke=blue />" +
                "<line x1=" + de2(0).ToString + " y1=" + y2.ToString + " x2=" + de2(1).ToString + " y2=" + y2.ToString + " stroke=blue />"
            If pos_tex_x = "izq" Then
                posx = x1 - 10
            ElseIf pos_tex_x = "der" Then
                posx = x1 + 20
            End If

            posy = 3 * (((y1 / 2 + y2 / 2).ToString).Length)
            If pos_tex_y = "arriba" Then
                posy = posy + minY - Lflecha / 2
            ElseIf pos_tex_y = "abajo" Then
                posy = posy + maxY + Lflecha / 2
            ElseIf pos_tex_y = "centro" Then
                posy = posy + 0.5 * (y1 + y2)
            End If
        Else 'If y1 - y2 = 0 Then
            Dim minX = Math.Min(x1, x2), maxX = Math.Max(x1, x2)
            angulo = 0
            lineas = lineas + "<line y1=" + y1.ToString + " x1=" + (minX - Lflecha).ToString + " y2=" + y2.ToString + " x2=" + (minX - 10).ToString + " stroke=blue marker-end=url(#arrow) />" +
                "<line y1=" + y1.ToString + " x1=" + (maxX + Lflecha).ToString + " y2=" + y2.ToString + " x2=" + (maxX + 10).ToString + " stroke=blue marker-end=url(#arrow) />" +
                "<line y1=" + de1(0).ToString + " x1=" + x1.ToString + " y2=" + de1(1).ToString + " x2=" + x1.ToString + " stroke=blue />" +
                "<line y1=" + de2(0).ToString + " x1=" + x2.ToString + " y2=" + de2(1).ToString + " x2=" + x2.ToString + " stroke=blue />"
            If pos_tex_y = "arriba" Then
                posy = y1 - 10
            ElseIf pos_tex_y = "abajo" Then
                posy = y1 + 10
            End If

            posx = -3 * (medida.ToString).Length
            If pos_tex_x = "izq" Then
                posx = posx + minX - Lflecha / 2
            ElseIf pos_tex_x = "der" Then
                posx = posx + maxX + Lflecha / 2
            ElseIf pos_tex_x = "centro" Then
                posx = posx + 0.5 * (x1 + x2)
            End If
        End If
        texto = "<text transform=""translate(" + posx.ToString + "," + posy.ToString + ") rotate(" + angulo.ToString + ")"" class=estil >" + medida.ToString + "</text>"
        codigo = codigo + lineas + texto
    End Sub

End Class
