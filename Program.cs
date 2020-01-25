using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SSIM
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<double> list = new List<double>();
            double number;
            string line;
            string regexStrStart = ".*All:";
            string regexStrEnd = " .*";

            // 1: open file
            // 2: Foreach line in file
            // 2.1: Remove everything before All: AND after (and including) the space, leaving only 1.000 and 0.9xxx numbers
            /*
            0.999
            0.999
            0.998
            0.999
            1.000
                */
            // 2.2: Move the number into a list
            // 3: Take the average of the list: double average = list.Average();
            // 4: wite the average in the console.


            if (args.Length==0)
            {
                // STEP 2:
                // When running SSIM.exe, 
                // 1: gather all the .log files in the current directory
                // 2: Do the average calculation for each file
                // 3: Create one file with each source filename and average SSIM to put into a spreadsheet

                //1
                string[] arr = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.log");

                StreamWriter Resultfile = new StreamWriter("SSIM_Result.txt");

                //2
                foreach (string fileIndir in arr)
                {
                    StreamReader ActFile = new StreamReader(fileIndir);
                    while ((line = ActFile.ReadLine()) != null)
                    {
                        //n:1 Y:0.999831 U:0.999362 V:0.999708 All:0.999732 (35.726670)
                        //2.1
                        string actual_number = Regex.Replace(line, regexStrStart, "");
                        actual_number = Regex.Replace(actual_number, regexStrEnd, "");
                        //0.999732

                        number = double.Parse(actual_number, CultureInfo.InvariantCulture); // Might be wrong, but works in denmark
                       
                        list.Add(number);

                    }
                    double average = list.Average();
                    Resultfile.WriteLine(fileIndir + ";" + average);
                }
                Resultfile.Close();



            }
            else
            {
                //1
                StreamReader file = new StreamReader(args[0]);
                //2
                while ((line = file.ReadLine()) != null)
                {
                    //n:1 Y:0.999831 U:0.999362 V:0.999708 All:0.999732 (35.726670)
                   //2.1
                    string actual_number = Regex.Replace(line, regexStrStart, "");
                    actual_number = Regex.Replace(actual_number, regexStrEnd,"");
                    //0.999732

                    number = double.Parse(actual_number, CultureInfo.InvariantCulture); // Might be wrong, but works in denmark
                    //2.2
                    list.Add(number);

                }
                //3
                double average = list.Average();
                //4

                Console.WriteLine(average);
                
                
                file.Close();

            }




            

            
            

        }
    }
}
