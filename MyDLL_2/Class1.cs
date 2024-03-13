using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Text;

namespace MyDLL_2
{
    public class MyClass
    {
        public ReturnClass GetHello(DataTable dt, string st)
        {
            return new ReturnClass()
            {
                Data = dt.Rows[0][0] + " Test",
                Count = st.Length
            };
        }

        public string GetPdf(string fileName)
        {
            unsafe
            {
                using (PdfReader reader = new PdfReader(fileName))
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        sb.AppendLine(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                    return sb.ToString();
                }
            }
        }
    }

    public class ReturnClass
    {
        public string Data { get; set; }
        public int Count { get; set; }
    }
}
