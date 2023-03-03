Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Threading
Imports Newtonsoft.Json

Module Module1


    Sub Main()

        Dim endpoint = $"https://ucvazservicebus.azurewebsites.net/api/SendPersonaForceSales?code=rwt-HCQIhG3j7oFs7Qd820-cS83WpDBnaiWSgGBQb0ZTAzFuKD1xaQ=="

        Dim client As HttpClient = New HttpClient
        client.BaseAddress = New Uri(endpoint)
        client.Timeout = TimeSpan.FromSeconds(60)

        Dim params = New Dictionary(Of String, String) From {
            {"numerodoc", "46791506"},
            {"codigo", "7002504289"},
            {"solicitud", "0"}
        }

        Dim resp = ""

        Dim payload = JsonConvert.SerializeObject(params)
        Dim buffer = Encoding.UTF8.GetBytes(payload)
        Dim bytes = New Net.Http.ByteArrayContent(buffer)
        bytes.Headers.ContentType = New Net.Http.Headers.MediaTypeHeaderValue("application/json")

        REM Dim request  = client.PostAsync(url, bytes)
        Dim response As HttpResponseMessage = client.PostAsync(endpoint, bytes).Result
        Dim responseString = response.Content.ReadAsStringAsync

        If response.IsSuccessStatusCode Then
            resp = responseString.Result
        End If

        Console.WriteLine(resp.ToString)
        Console.Read()


    End Sub


End Module
