namespace AmazingLibraryManagerAutomation.Utils
{
    public class ResultGenerator
    {
        private readonly string nameCTContext; 
        private StreamWriter _sw;

        public ResultGenerator(string ContextCT)
        {
            this.nameCTContext = ContextCT;
        }

        public void CreateBaseResult()
        {
            string baseResult =
                "<!doctype html>\r\n" +
                 "<html lang=\"pt-br\">\r\n  " +
                 "  <head>\r\n    " +
                 "      <meta charset=\"utf-8\">\r\n    " +
                 "      <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    " +
                 "      <title>Evidência</title>\r\n    " +
                 "      <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN\" crossorigin=\"anonymous\">\r\n" +
                 "  </head>\r\n  " +
                 "  <body>\r\n    " +
                 "      <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL\" crossorigin=\"anonymous\"></script>  \r\n\r\n    " +
                 "  <header>\r\n        " +
                 $"     <span style=\"width: 100%; font-size: 35px;\" class=\"badge rounded-pill text-bg-dark\">{nameCTContext}</span>\r\n        " +
                 $"     <span style=\"width: 100%; font-size: 12px;\" class=\"badge rounded-pill text-bg-secondary\">{DateTime.Now.ToString()}</span>\r\n    " +
                 "  </header>" +
                 "  <div style=\"margin-top: 4%; width: 100%;\">\r\n        " +
                 "      <span style=\"width: 100%; font-size: 20px;\" class=\"badge text-bg-info\">BDD</span>\r\n        " +
                 "      <div style=\" display: flex; align-items: center; justify-content: center; width: 100%;\">\r\n            " +
                 "          <ul style=\"text-align: center; margin-top: 1%; width: 60%;\" class=\"list-group list-group-flush\">\r\n ";

            if (File.Exists($"Results\\{nameCTContext}.html"))
            {
                File.WriteAllText($"Results\\{nameCTContext}.html", baseResult);
            }
            else
            {
                _sw = new StreamWriter($"Results\\{nameCTContext}.html", true, Encoding.UTF8);

                _sw!.WriteLine(baseResult);

                _sw.Close();
            }
        }

        public void WriteBDD(string bdd)
        {
            using var file = File.AppendText($"Results\\{nameCTContext}.html");

            file.WriteLine
            (
            $"<li class=\"list-group-item\">{bdd}</li> \r\n"
            );
        }

        public void WriteResponseResults(RestResponse response)
        {
            using var file = File.AppendText($"Results\\{nameCTContext}.html");

            file.WriteLine
            (
            "</ul>\r\n        " +
                "</div>    \r\n    " +
                "</div>\r\n    " +
                    "<div style=\"margin-top: 4%;\">\r\n        " +
                    "<span style=\"width: 100%; font-size: 20px;\" class=\"badge text-bg-info\">Dados da resposta</span>\r\n\r\n        " +
                   $"<div style=\"display: flex; align-items: center; justify-content: center;\" class=\"alert alert-dark\" role=\"alert\">\r\n {(int)response.StatusCode} {response.StatusCode}  \r\n" +
                   $"<div style=\"display: flex; align-items: center; justify-content: center; margin-left: 10px;\" class=\"alert alert-dark\" role=\"alert\">\r\n Response: {response.Content}  \r\n" +
                "</div>\r\n    " +
                "</div>"
            );
            file.Close();
        }

        public void FinishBaseResult()
        {
            using var file = File.AppendText($"Results\\{nameCTContext}.html");

            file.WriteLine
            (
            "</body>\r\n" +
            "</html>"
            );
        }

        public void ClassifyResult(string TestResult)
        {
            string evidenciaSucesso;
            string evidenciaFalha;
            string evidenciaCompleta = File.ReadAllText($"Results\\{nameCTContext}.html");

            if (TestResult == "Passed")
            {
                evidenciaSucesso = evidenciaCompleta.Replace("dark", "success");
                File.WriteAllText($"Results\\{nameCTContext}.html", evidenciaSucesso);
            }
            else if (TestResult == "Failed")
            {
                evidenciaFalha = evidenciaCompleta.Replace("dark", "danger");
                File.WriteAllText($"Results\\{nameCTContext}.html", evidenciaFalha);
            }
        }
    }
}