Imports MySql.Data.MySqlClient

Module connection
   
    Public sqlcon As MySqlConnection

    Public Function EnsureDBOpen() As Boolean
        Dim is_ok As Boolean = False
        Dim is_force As Boolean = True
        For n As Integer = 1 To 3
            is_ok = True
            If sqlcon Is Nothing Then
                ServerStatus("Connecting...")
                Dim con_str As String = "server=" & DBHost() & ";Port=" & srv_port & ";Database=" & srv_db & ";User ID=" & srv_root & ";Password=" & srv_dbpass & ";"
                sqlcon = New MySqlConnection(con_str)
            End If
            If sqlcon.State <> ConnectionState.Open Then
                Try
                    sqlcon.Open()
                    is_force = False
                Catch
                End Try
            End If
            If sqlcon.State = ConnectionState.Open Then
                If is_force Then
                    Try
                        Dim cmd As New MySqlCommand("SELECT 1", sqlcon)
                        cmd.ExecuteScalar()
                    Catch
                        is_ok = False
                    End Try
                End If
                If is_ok Then
                    Exit For
                End If
            End If
            is_force = False '/ no need to force again
            Try
                sqlcon.Dispose()
            Catch
            Finally
                sqlcon = Nothing
            End Try
            is_ok = False
            ForceDBPause()
        Next
        Offline(Not is_ok)
        Return is_ok
    End Function

    Public Sub ForceDBClose(Optional ByVal is_dispose As Boolean = False)
        Try
            If sqlcon Is Nothing Then
                Return
            End If
            If sqlcon.State = True Then
                sqlcon.Close()
            End If
            If (is_dispose) Then
                sqlcon.Dispose()
                sqlcon = Nothing
            End If
        Catch
            sqlcon = Nothing
        End Try
    End Sub

End Module
