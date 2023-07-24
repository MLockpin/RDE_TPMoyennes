﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMoyennes
{
    public class Classe
    {
        public string nomClasse { get; private set; }
        public Classe(string s)
        {
            nomClasse = s;
        }

        public List<Eleve>eleves = new List<Eleve> ();
        public List<string>matieres = new List<string> ();
        

        public void ajouterEleve(string firstname, string lastname)
        {
            if (eleves.Count == 30)
            {
                Console.Write("error, trop d'élèves");
                return;
            }
            eleves.Add(new Eleve(firstname, lastname));
        }

        public void ajouterMatiere(string matiere)
        {
            if (matieres.Count == 10)
            {
                Console.Write("error, trop de matières");
                return;
            }
            matieres.Add(matiere);
        }

        public float moyenneMatiere(int i)
        {
            float _moyenne = 0;
            int _counter = 0;
            foreach (Eleve eleve in eleves)
            {
                foreach (Note note in eleve.notes)
                {
                    if (note.matiere == i)
                    {
                        _moyenne += note.note;
                        _counter++;
                    }
                }
            }
            if (_counter == 0)
            {
                //Dislay error
                return 0;
            }

            _moyenne = _moyenne / _counter;

            return (float)Math.Round(_moyenne, 2);
        }

        public float moyenneGeneral()
        {
            float _moyenne = 0;
            int _counter = 0;
            foreach (Eleve eleve in eleves)
            {
                foreach (Note note in eleve.notes)
                {
                    _moyenne += note.note;
                    _counter++; 
                }
            }
            if (_counter == 0)
            {
                //Dislay error
                return 0;
            }

            _moyenne = _moyenne / _counter;

            return (float)Math.Round(_moyenne, 2);
        }
    }
}
