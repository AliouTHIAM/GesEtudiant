using System;
using System.Collections;

namespace UsageCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList lstÉtudiant = new SortedList();
            Console.Write("Combien d'étudiants voulez-vous enregistrer ? ");
            int nombreEtudiants = int.Parse(Console.ReadLine());

            double sommeMoyennes = 0;

            for (int i = 0; i < nombreEtudiants; i++)
            {
                Console.WriteLine($"\nSaisie des informations pour l'étudiant {i + 1} :");

                Console.Write("Numéro d'ordre (NO) : ");
                string NO = Console.ReadLine();

                Console.Write("Prénom : ");
                string prénom = Console.ReadLine();

                Console.Write("Nom : ");
                string nom = Console.ReadLine();

                Console.Write("Note CC : ");
                double noteCC = double.Parse(Console.ReadLine());

                Console.Write("Note Devoir : ");
                double noteDevoir = double.Parse(Console.ReadLine());

                // Création de l'objet Étudiant
                Étudiant nouvelÉtudiant = new Étudiant()
                {
                    NO = NO,
                    Prénom = prénom,
                    Nom = nom,
                    NoteCC = noteCC,
                    NoteDevoir = noteDevoir
                };

                // Ajouter à la liste triée
                lstÉtudiant.Add(nouvelÉtudiant.NO, nouvelÉtudiant);

                // Ajouter la moyenne à la somme totale
                sommeMoyennes += nouvelÉtudiant.Moyenne;
            }

            // Demander à l'utilisateur le nombre de lignes par page
            int lignesParPage;
            do
            {
                Console.Write("\nChoisissez le nombre de lignes par page (entre 1 et 15) : ");
                lignesParPage = int.Parse(Console.ReadLine());
            } while (lignesParPage < 1 || lignesParPage > 15);

            Console.WriteLine("\nListe des étudiants enregistrés avec leurs moyennes :");
            Console.WriteLine("------------------------------------------------------");

            int totalPages = (int)Math.Ceiling((double)nombreEtudiants / lignesParPage);
            int page = 1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Page {page}/{totalPages}");
                Console.WriteLine("NO\tNom\tPrénom\tNoteCC\tNoteDevoir\tMoyenne");
                Console.WriteLine("------------------------------------------------------");

                int startIndex = (page - 1) * lignesParPage;
                int endIndex = Math.Min(startIndex + lignesParPage, nombreEtudiants);

                for (int i = startIndex; i < endIndex; i++)
                {
                    Étudiant étudiant = (Étudiant)lstÉtudiant.GetByIndex(i);
                    Console.WriteLine($"{étudiant.NO}\t{étudiant.Nom}\t{étudiant.Prénom}\t{étudiant.NoteCC:F2}\t{étudiant.NoteDevoir:F2}\t\t{étudiant.Moyenne:F2}");
                }

                Console.WriteLine("\nN = Page suivante | P = Page précédente | Q = Quitter");
                string input = Console.ReadLine().ToUpper();

                if (input == "N" && page < totalPages)
                {
                    page++;
                }
                else if (input == "P" && page > 1)
                {
                    page--;
                }
                else if (input == "Q")
                {
                    break;
                }
            }

            // Calcul de la moyenne de la classe
            double moyenneClasse = sommeMoyennes / nombreEtudiants;
            Console.WriteLine("\n-------------------");
            Console.WriteLine($"Moyenne de la classe : {moyenneClasse:F2}");
            Console.WriteLine("-------------------");
        }
    }
}
