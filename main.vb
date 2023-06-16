Imports System.Text.RegularExpressions
Imports System.IO

Module Module1
    Class regX
        Public open_tag As Regex = New Regex("(<\w*>)")
        Public close_tag As Regex = New Regex("(</\w*>)")
        Public valid As Regex = New Regex("[^\W]\w*")
    End Class

    Sub file_creator(code)
        Dim file_path = "D:\mycode.html"
        Dim writer As New IO.StreamWriter(file_path, True)
        writer.WriteLine(code)
        writer.WriteLine("")
        writer.Close()
    End Sub


    Sub file_opener(code)
        Dim file_path As String = "D:\mycode.html"
        If System.IO.File.Exists(file_path) = True Then
            Dim Reader As New System.IO.StreamReader(file_path)
            Dim txt As String = Reader.ReadToEnd()
            Console.Clear()
            Console.WriteLine(txt)
            Process.Start("D:\mycode.html")
            Console.WriteLine("#######press any key to exit########")
            Console.ReadKey()
            Reader.Close()
        Else
            Console.WriteLine("File Does Not Exist")
        End If
    End Sub

    Sub setup()
        Dim file_path As String = "D:\mycode.html"
        If System.IO.File.Exists(file_path) = True Then
            System.IO.File.WriteAllText(file_path, "")
            Console.WriteLine("HTML COMPILER V0.85 [Still haven't added the heriarchy logic so please start with <HTML> @_@] ~KD")
            Console.WriteLine("         You can use following commands for different pre-defined functions such as")
            Console.WriteLine("    [run] --> To compile your code                 [exit] --> To close and reset the compiler")
            Console.WriteLine("                             Current lines of code = 169")
            Console.WriteLine("")
        Else
            Console.WriteLine("HTML COMPILER V0.85 [Still haven't added the heriarchy logic so please start with <HTML> @_@] ~KD")
            Console.WriteLine("         You can use following commands for different pre-defined functions such as")
            Console.WriteLine("    [run] --> To compile your code                 [exit] --> To close and reset the compiler")
            Console.WriteLine("                             Current lines of code = 169")
            Console.WriteLine("")
        End If
    End Sub

    Sub end_code()
        For counter As Integer = 0 To 4 Step 1
            Console.Write("Exiting in 5secs T-{0}", counter)
            Threading.Thread.Sleep(1000)
            Console.Clear()
        Next

    End Sub


    Sub Main()
        setup()
        Dim Text, temp As String
        Dim code As String = ""
        Dim tags() As String = {"html", "head", "title", "body", "p"}
        Dim i As Integer = 1

        Dim RegObj As New regX

        Dim O_match As Match
        Dim C_match As Match
        Dim T_match As Match

        Do
            Console.Write("|{0}|. ", i)
            i += 1
            code = Console.ReadLine()
            code = code.ToLower()

            O_match = RegObj.open_tag.Match(code)
            C_match = RegObj.close_tag.Match(code)
            T_match = RegObj.valid.Match(code)



            Text = T_match.ToString
            ''Console.WriteLine(Text)
            ''Console.ReadKey()


            If O_match.Success And C_match.Success And T_match.Success Then

                ''Console.WriteLine("<inline tags registeration successful>")
                i = i.ToString

                If tags.Contains(Text) Then

                    file_creator(code)
                Else
                    temp = "  <----{ Un-Indentified tag"
                    code = code + temp
                    file_creator(code)

                End If
            ElseIf C_match.Success And T_match.Success Then

                ''Console.WriteLine("<closing tag registeration successful>")

                If tags.Contains(Text) Then

                    file_creator(code)
                Else

                    temp = "  <----{ Un-Indentified tag"
                    code = code + temp
                    file_creator(code)

                End If
            ElseIf O_match.Success And T_match.Success Then

                ''Console.WriteLine("<opening tag registeration successful>")

                If tags.Contains(Text) Then

                    file_creator(code)
                Else
                    temp = "  <----{ Un-Indentified tag "
                    code = code + temp
                    file_creator(code)
                End If
            ElseIf code = "run" Then

                Console.WriteLine("program complied")
                Console.WriteLine("press any key to run code :D")
                Console.ReadKey()
                file_opener(code)

            ElseIf code = "exit" Then
                code = "run"

            ElseIf code <> "exit" And code <> "run" Then
                temp = code
                Console.Clear()
                Console.WriteLine("Un-Identified command")
                Console.WriteLine("press any key and restart program")
                Console.ReadKey()
                Console.Clear()
                Console.WriteLine("Well Hello Genuis (w).... what were you trying to do with that mess you just typed in #_#")
                Console.WriteLine("like seriously what is ''{0}''", temp)
                Console.WriteLine("anyway (^_^)  try again!! #happy_coding :D")
                Console.WriteLine("")
                Console.ReadKey()
                Main()
            Else
                temp = "  <----{ Syntax error / Un-Identified tag"
                code = code + temp
                file_creator(code)

            End If

        Loop Until code = "run"
        end_code()
    End Sub


End Module
