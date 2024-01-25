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
            _sw = new StreamWriter($"Results\\{nameCTContext}.html", true, Encoding.UTF8);

            _sw!.WriteLine
            ("<!DOCTYPE html>" +
            "\n<html>" +
            "\n<head>\n " +
            "<meta charset='utf-8'>\n " +
            "<meta http-equiv='X-UA-Compatible' content='IE=edge'>\n" +
            "<title>Evidência</title>\n  " +
            "<meta name='viewport' content='width=device-width, initial-scale=1'>\n" +
            "</head>\n" +
            "<body>\n  " +
            "<h1 style=\"margin-left: 30%;\">__________ Evidência de teste ___________</h1>\n    <hr>\n   " +
            "<div>\n      " +
            $"<h2 style=\"color: red;\">Data e hora do teste: {DateTime.Now.ToString()}</h2>\n<hr>\n" +
            $"<h4 style=\"margin-left: 45%;\">{nameCTContext}</h4>\n            <hr>\n       " +
            $"</div>" +
            $"<div>"
            );
            _sw.Close();
        }

        public void WriteBDD(string bdd)
        {
            using var file = File.AppendText($"Results\\{nameCTContext}.html");

            file.WriteLine
            ("<p style=\"color: green;\">\n         " +
            $" {bdd} \n       " +
            "</p>\n           \n   "
            );
        }

        public void WriteResponseResults(RestResponse response)
        {
            using var file = File.AppendText($"Results\\{nameCTContext}.html");

            file.WriteLine
            ("</div>" +
            "<div>\n       " +
            $"<h2 style=\"color: green;\">response.StatusCode: {response.StatusCode} <br>\n" +
            $"response.StatusCode: {(int)response.StatusCode} <br>\n" +
            $"response.content: {response.Content} <br>\n" +
            "</h2>\n        <hr>\n <hr>\n   "
            );
            file.Close();
        }

        public void FinishBaseResult()
        {
            using var file = File.AppendText($"Results\\{nameCTContext}.html");

            file.WriteLine
            ("</div>\n" +
            "</body>\n" +
            "</html>");
        }
    }
}
