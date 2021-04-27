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
            //int supprimer = 0;
            // ajouter alter ??
            List<string> parties = new List<string>();
            string part = "<part id=\"";
            string part_end = "</part>";
            string part_name = "<part-name>";
            string part_name_end = "</part-name>";
            string mesure = "<measure number=\"";
            string mesure_end = "</measure>";
            string beats = "<beats>";
            string beats_end = "</beats>";
            string beatType = "<beat-type>";
            string beatType_end = "</beat-type>";
            string sign = "<sign>";
            string sign_end = "</sign>";
            string step = "<step>";
            string step_end = "</step>";
            string octave = "<octave>";
            string octave_end = "</octave>";
            string type = "<type>";
            string type_end = "</type>";
            string fin = "</score-partwise>";
            //Balises à rajouter : <divisions>, <line>, <alter>, <duration>, <voice> et <rest measure="yes"> 

            XmlDocument test = new XmlDocument();
            test.Load("digitalized.xml");
            string essaiBis = ""; //chaîne qui copiera bout par bout essai, et qui sera analysé
            string essai = GetXMLAsString(test);

            //récupération du nombre de parties et des noms des parties
            int nb_parties = 0;
            string essai_nomsparties = "";
            while (essai.Contains(part_name_end)) //chercher nb
            {
                essaiBis = "";
                int n = 0;
                while (!essaiBis.Contains(part_name_end))
                {
                    essaiBis += essai[n];
                    n++;
                }
                essai = essai.Remove(0, n - 1);

                if (essaiBis.Contains(part_name))
                {
                    nb_parties++;
                }
                essai_nomsparties += essaiBis;
            }
            Console.WriteLine("La partition présente {0} parties.",nb_parties);

            int cpt = 1;
            while (essai_nomsparties.Contains(part_name)) //chercher noms
            {
                essaiBis = "";
                int p = 0;
                while (!essaiBis.Contains(part_name_end))
                {
                    essaiBis += essai_nomsparties[p];
                    p++;
                }
                essai_nomsparties = essai_nomsparties.Remove(0, p - 1);
                if (essaiBis.Contains(part_name))
                {
                    Console.Write("La partie {0} est intitullée ",cpt);
                    int index = essaiBis.IndexOf(part_name) + 11;
                    string partie = "";
                    while (essaiBis[index] != '<')
                    {
                        Console.Write(essaiBis[index]);
                        partie += essaiBis[index];
                        index++;
                    }
                    parties.Add(partie);
                    Console.WriteLine(".");
                    cpt++;
                }
                
            }

            while (!essaiBis.Contains(fin))
            {
                essaiBis = "";
                int m = 0;
                //va enregistrer les éléments de essai jusqu'à tomber sur la fermeture d'une balise qui nous intéresse (ex </mesure>) ==> essaiBis ne contiendra donc jamais deux fois un même type de balise
                while (!essaiBis.Contains(fin) && !essaiBis.Contains(part_end) && !essaiBis.Contains(beats_end) && !essaiBis.Contains(beatType_end) && !essaiBis.Contains(sign_end) && !essaiBis.Contains(mesure_end) && !essaiBis.Contains(step_end) && !essaiBis.Contains(octave_end) && !essaiBis.Contains(type_end))
                {
                    essaiBis += essai[m];
                    m++; //m permet de supprimer de essai tout ce qui a été enregistré et qui va être analysé dans essaiBis, donc qui n'est plus utile de garder dans essai
                }

                essai = essai.Remove(0, m - 1);

                //verification de la présence d'une ou plusieurs balises de début qui nous intéressent (ex : <mesure ...>, <beats>, ...)

                if (essaiBis.Contains(part)) //lire le nom de partie
                {
                    int index = essaiBis.IndexOf(part);
                    Console.Write("Lecture de la Partie ");
                    int i = index + 10;
                    string numero_partie = "";
                    while (essaiBis[i] != '\"') //cherche le guillemet de fin de la balise <part>
                    {
                        numero_partie+=essaiBis[i];
                        i++;
                    }
                    for (int a = 0; a < parties.Count(); a++) //chercher le nom de la partie dans la liste en fonction de son numéro
                    {
                        if (numero_partie == "P" + (a+1))
                        {
                            Console.Write(parties[a]);
                        }
                    }
                    Console.WriteLine(".");
                }

                if (essaiBis.Contains(mesure))//lire le numéro de mesure
                {
                    int index = essaiBis.IndexOf(mesure);
                    Console.Write("Mesure numéro ");
                    int i = index + 17;
                    while (essaiBis[i] != '\"')
                    {
                        Console.Write(essaiBis[i]);
                        i++;
                    }
                    Console.WriteLine(".");
                }

                if (essaiBis.Contains(beats)) //lire le nombre de temps
                {
                    int index = essaiBis.IndexOf(beats);
                    Console.Write("Nombre de temps : ");
                    int i = index + 7;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        i++;
                    }
                    Console.WriteLine(",");
                }
                if (essaiBis.Contains(beatType)) //lire le type de temps
                {
                    int index = essaiBis.IndexOf(beatType);
                    Console.Write("Type de temps : ");
                    int i = index + 11;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        i++;
                    }
                    Console.WriteLine(".");
                }

                if (essaiBis.Contains(sign)) //lire la clé
                {
                    int index = essaiBis.IndexOf(sign);
                    Console.Write("La portée est en clé de ");
                    int i = index + 6;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        i++;
                    }
                    Console.WriteLine(".");
                }

                if (essaiBis.Contains(step)) //lire le nom de la note
                {
                    int index = essaiBis.IndexOf(step);
                    Console.Write("Note : ");
                    int i = index + 6;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        i++;
                    }
                    Console.Write(", ");
                }

                if (essaiBis.Contains(octave)) //lire l'octave de la note
                {
                    int index = essaiBis.IndexOf(octave);
                    Console.Write("Octave : ");
                    int i = index + 8;
                    while (essaiBis[i] != '<')
                    {
                        Console.Write(essaiBis[i]);
                        i++;
                    }
                    Console.Write(", ");
                }

                if (essaiBis.Contains(type)) //lire le rythme de la note
                {
                    int index = essaiBis.IndexOf(type);
                    Console.Write("Type de rythme : ");
                    int i = index + 6;
                    string rythme = "";
                    while (essaiBis[i] != '<')
                    {
                        rythme += essaiBis[i];
                        i++;
                    }
                    if (rythme == "eighth")
                    {
                        Console.Write("croche");
                    }
                    else if (rythme == "quarter")
                    {
                        Console.Write("noire");
                    }
                    else if (rythme == "half")
                    {
                        Console.Write("blanche");
                    }
                    else if (rythme == "whole")
                    {
                        Console.Write("ronde");
                    }
                    else if (rythme == "sixteenth")
                    {
                        Console.Write("double-croche");
                    }
                    else if (rythme == "demisemiquaver")
                    {
                        Console.Write("triple-croche");
                    }
                    else if (rythme == "hemidemisemiquaver")
                    {
                        Console.Write("quadruple-croche");
                    }
                    Console.WriteLine(".");
                }
            }
            Console.WriteLine("Fin de la partition.");
        }
    }
}
