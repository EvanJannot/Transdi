using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace XML_Partition
{
    class Program
    {
        public static string GetXMLAsString(XmlDocument myxml)
        {
            return myxml.OuterXml;
        }
        static void Main(string[] args)
        {
            int supprimer = 0;
            string part = "<part id=";
            string mesure = "<measure number=\"";
            string beats = "<beats>";
            string beatType = "<beat-type>";
            string sign = "<sign>";
            string step = "<step>";
            string octave = "<octave>";
            string type = "<type>";
            XmlDocument test = new XmlDocument();
            test.Load("digitalized.xml");
            string essai = "";
            essai = GetXMLAsString(test);
            
                bool a = essai.Contains(part);
                bool b = essai.Contains(mesure);
                bool c = essai.Contains(beats);
                bool d = essai.Contains(beatType);
                bool e = essai.Contains(sign);
                bool f = essai.Contains(step);
                bool g = essai.Contains(octave);
                bool h = essai.Contains(type);

                if (a)
                {
                    int index = essai.IndexOf(part);
                    Console.Write("Partie : ");
                    for (int i = (index + 10); i < (index + 12); i++)
                    {
                        Console.Write(essai[i]);
                    }
                    Console.WriteLine();
                }
                if (b)
                {
                    int index = essai.IndexOf(mesure);
                    Console.Write("Nombre de mesure : ");
                    for (int i = (index + 17); i < (index + 18); i++)
                    {

                        Console.Write(essai[i]);
                    }
                    supprimer = essai.IndexOf(mesure);
                    essai = essai.Remove(supprimer, supprimer + 20);
                    Console.WriteLine();
                }
                if (c)
                {
                    int index = essai.IndexOf(beats);
                    Console.Write("Nombre de temps : ");
                    for (int i = (index + 7); i < (index + 8); i++)
                    {
                        Console.Write(essai[i]);
                    }
                    Console.WriteLine();
                }
                if (d)
                {
                    int index = essai.IndexOf(beatType);
                    Console.Write("Type de temps : ");
                    for (int i = (index + 11); i < (index + 12); i++)
                    {
                        Console.Write(essai[i]);
                    }
                    Console.WriteLine();
                }
                if (e)
                {
                    int index = essai.IndexOf(sign);
                    Console.Write("Clef de : ");
                    for (int i = (index + 6); i < (index + 7); i++)
                    {
                        Console.Write(essai[i]);
                    }
                    Console.WriteLine();
                }
            Console.WriteLine();
            while (essai.Contains("<type>half</type>"))
            {
                if (f)
                {
                    int index = essai.IndexOf(step);
                    Console.Write("Note ");
                    for (int i = (index + 6); i < (index + 7); i++)
                    {
                        Console.Write(essai[i]);
                    }
                }
                if (g)
                {
                    int index = essai.IndexOf(octave);
                    Console.Write(" à l'octave ");
                    for (int i = (index + 8); i < (index + 9); i++)
                    {
                        Console.Write(essai[i]);
                    }
                    Console.WriteLine();
                }
                if (h)
                {
                    int index = essai.IndexOf(type);
                    Console.Write("Durée : ");
                    for (int i = (index + 6); i < (index + 12); i++)
                    {
                        Console.Write(essai[i]);
                    }
                    Console.WriteLine();
                    supprimer = essai.IndexOf(type);
                    essai = essai.Remove(0, supprimer + 15);
                    Console.WriteLine();
                    if (a)
                    {
                        index = essai.IndexOf(part);
                        Console.Write("Partie : ");
                        for (int i = (index + 10); i < (index + 12); i++)
                        {
                            Console.Write(essai[i]);
                        }
                        Console.WriteLine();
                    }
                    if (b)
                    {
                        index = essai.IndexOf(mesure);
                        Console.Write("Nombre de mesure : ");
                        for (int i = (index + 17); i < (index + 18); i++)
                        {

                            Console.Write(essai[i]);
                        }
                        supprimer = essai.IndexOf(mesure);
                        essai = essai.Remove(supprimer, supprimer + 20);
                        Console.WriteLine();
                    }
                    if (c)
                    {
                        index = essai.IndexOf(beats);
                        Console.Write("Nombre de temps : ");
                        for (int i = (index + 7); i < (index + 8); i++)
                        {
                            Console.Write(essai[i]);
                        }
                        Console.WriteLine();
                    }
                    if (d)
                    {
                        index = essai.IndexOf(beatType);
                        Console.Write("Type de temps : ");
                        for (int i = (index + 11); i < (index + 12); i++)
                        {
                            Console.Write(essai[i]);
                        }
                        Console.WriteLine();
                    }
                    if (e)
                    {
                        index = essai.IndexOf(sign);
                        Console.Write("Clef de : ");
                        for (int i = (index + 6); i < (index + 7); i++)
                        {
                            Console.Write(essai[i]);
                        }
                        Console.WriteLine();
                    }
                }
                
            }

        }
    }
}
