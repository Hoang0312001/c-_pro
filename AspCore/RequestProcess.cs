using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcore
{
    public class RequestProcess
    {
        public static async Task<String> ProcessForm(HttpRequest request)
        {
            string name = "";
            string address = "";
            string inform = "";
            if (request.Method == "POST")
            {
                IFormCollection _form = request.Form;
                name = _form["name"].FirstOrDefault() ?? "";
                address = _form["address"].FirstOrDefault() ?? "";
                inform = $"{name} : {address}";

                if (_form.Files.Count > 0)
                {
                    string informFile = "file da upload";
                    foreach (IFormFile formFile in _form.Files)
                    {
                        if (formFile.Length > 0)
                        {
                            var filePath = "wwwroot/upload/" + formFile.FileName;
                            if (!Directory.Exists("wwwroot/upload/")) Directory.CreateDirectory("wwwroot/upload/");
                            informFile += $"{filePath} {formFile.Length} bytes";
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            { // Mở stream để lưu file, lưu file ở thư mục wwwroot/upload/// Mở stream để lưu file, lưu file ở thư mục wwwroot/upload/
                                await formFile.CopyToAsync(stream);
                            }


                        }
                        inform += "<br>" + informFile;
                    }
                }


            }

            // submit file


            var format = File.ReadAllText("form.html");
            var html = string.Format(format, "name", "hoang dep trai", "no");

            return format + inform;
        }

        public static string Cookies(HttpRequest request, HttpResponse response)
        {

            string tb = "";
            switch (request.Path)
            {
                case "/Cookies/read":
                    var listcokie = request.Cookies.Select((header) => $"{header.Key}: {header.Value}".HtmlTag("li"));
                    tb = string.Join("", listcokie).HtmlTag("ul");
                    break;
                case "/Cookies/write":
                    // ghi cookie
                    response.Cookies.Append("masanpham", "12345",
                        new CookieOptions
                        {
                            Path = "/Cookies",
                            Expires = DateTime.Now.AddDays(1)
                        }
                    );
                    tb = "Đã lưu Cookie  -  masanpham - hết hạn 1 ngày".HtmlTag("div", "alert alert-danger");
                    break;
            }



            return tb;
        }

    }
}