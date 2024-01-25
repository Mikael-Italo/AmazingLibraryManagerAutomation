namespace AmazingLibraryManagerAutomation.Utils
{
    public class ResultGenerator
    {
        private readonly string date = DateTime.Now.ToString("dd_MM_yyyy");

        StreamWriter _sw;
        public ResultGenerator(string nomeCT)
        {
            _sw = new StreamWriter($"Results\\{nomeCT}_{date}.html", true, Encoding.UTF8);

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
            "<h1 style=\"margin-left: 30%;\">__________Evidência de teste___________</h1>\n    <hr>\n   " +
            "<div>\n      " +
            $"<h2 style=\"color: red;\">Data e hora do teste: {DateTime.Now.ToString()}</h2>\n<hr>\n" +
            $"<h4 style=\"margin-left: 45%;\">{nomeCT}</h4>\n            <hr>\n       "
            );
            _sw.Close();
        }
        public ResultGenerator(string nomeCT, string bdd)
        {
            //_sw = new StreamWriter($"Results\\{nomeCT}_{date}.html", true, Encoding.UTF8);
            using var file = File.AppendText($"Results\\{nomeCT}_{date}.html");

            file.WriteLine
            ("<p style=\"color: green;\">\n         " +
            $" {bdd} \n       " +
            "</p>\n        <hr>\n   " +
            "</div>\n    <div>\n       " +
     //     $"<h2 style=\"color: green;\">response.StatusCode: {response.StatusCode} <br>\n" +
     //     $"response.StatusCode: {(int)response.StatusCode} <br>\n" +
     //     $"response.content: {response.Content} <br>\n" +
            "</h2>\n        <hr>\n <hr>\n   " +
            "</div>\n" +
            "</body>\n" +
            "</html>"
            );
            //_sw.Close();
            file.Close();
        }
    }
}
