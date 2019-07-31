using System;
using System.IO;

namespace CreateTestMessage
{
    class Program
    {

        static void Main(string[] args)
        {
            byte soh = 1;
            byte etx = 3;
            Console.WriteLine("Hello World!");
            for (int x = 0; x < 20; x++)
            {
                for (int error1 = 0; error1 < 2; error1++)
                {
                    for (int error2 = 0; error2 < 2; error2++)
                    {
                        for (int HeadNumber = 0; HeadNumber < 5; HeadNumber++)
                        {
                            for (int other = 0; other < 2; other++)
                            {
                                if (other == 0 && error1 == 0 && error2 == 0)
                                    MessageOut("" + (char)soh + (char)etx + (char)soh + "     {\"Machine\":\"HIL-XS-FIM\", \"Good\":\"1\", \"Bad\":\"0\",\"Empty\":\"0\",\"Attempt\":\"1\",\"Other\":\"" + other.ToString() + "\",\"HeadNumber\":\"" + HeadNumber.ToString() + "\" ,\"Error1\":\"" + error1.ToString() + "\",\"Error2\":\"" + error2.ToString() + "\"}");
                                else
                                    MessageOut("" + (char)soh + (char)etx + (char)soh + "     {\"Machine\":\"HIL-XS-FIM\", \"Good\":\"0\", \"Bad\":\"1\",\"Empty\":\"0\",\"Attempt\":\"1\",\"Other\":\"" + other.ToString() + "\",\"HeadNumber\":\"" + HeadNumber.ToString() + "\" ,\"Error1\":\"" + error1.ToString() + "\",\"Error2\":\"" + error2.ToString() + "\"}");
                            }
                        }
                    }
                }

                MessageOut("" + (char)soh + (char)soh + (char)soh + "     {\"Machine\": \"HIL-XS-AutoFocous\", \"Good\":\"32\" , \"Bad\":\"32\", \"Empty\":\"4\", \"Indexes\":\"68\", \"UOM\":\"EA\", \"NAED\":\"31474\"}");
                MessageOut("" + (char)soh + (char)soh + (char)soh + "     {\"Machine\": \"HIL-XS-FIM\", \"Good\":\"32\" , \"Bad\":\"32\", \"Empty\":\"4\", \"Indexes\":\"68\", \"UOM\":\"EA\", \"NAED\":\"31474\"}");
                if (x % 2 == 0)
                {
                    MessageOut("" + (char)etx + (char)etx + (char)soh + "     {\"Machine\": \"HIL-XS-AutoFocous\", \"StatusCode\":\"2\" , \"MReason\":\"Preventing Wrenching\", \"UReason\":\"oiling up wrench launcher\", \"NAED\":\"31474\",\"Code\": \"1300\"}");
                    MessageOut("" + (char)etx + (char)etx + (char)soh + "     {\"Machine\": \"HIL-XS-FIM\", \"StatusCode\":\"2\" , \"MReason\":\"Preventing Wrenching\", \"UReason\":\"oiling up wrench launcher\", \"NAED\":\"31474\",\"Code\": \"1300\"}");
                }
                else
                {
                    MessageOut("" + (char)etx + (char)etx + (char)soh + "     {\"Machine\": \"HIL-XS-AutoFocous\", \"StatusCode\":\"0\" , \"MReason\":\"Preventing Wrenching\", \"UReason\":\"oiling up wrench launcher\", \"NAED\":\"31474\",\"Code\": \"1300\"}");
                    MessageOut("" + (char)etx + (char)etx + (char)soh + "     {\"Machine\": \"HIL-XS-FIM\", \"StatusCode\":\"0\" , \"MReason\":\"Preventing Wrenching\", \"UReason\":\"oiling up wrench launcher\", \"NAED\":\"31474\",\"Code\": \"1300\"}");
                }
            }
        }
        public static void MessageOut(string message)
        {
            using (StreamWriter DiagnosticWriter = File.AppendText("C:\\Users\\d.paddock\\Desktop\\Messages.txt"))
            {
                DiagnosticWriter.WriteLine(message);                          //output it to file
            }
        }
    }
}
