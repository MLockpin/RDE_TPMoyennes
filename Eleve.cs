﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMoyennes
{
    public class Eleve
    {
        public string prenom { get; private set; }

        public string nom { get; private set; }
        public Eleve(string f, string l)
        {
            prenom = f;
            nom = l;
        }

        internal List<Note> notes = new List<Note>();

        public Classe classe;

        internal void ajouterNote(Note note)
        {
            if(notes.Count ==200)
            {
                Console.Write("error, trop de notes");
                return;
            }
            notes.Add(note);
        }

        public float moyenneMatiere(int i)
        {
            float _moyenne = 0;
            int _counter = 0;

            foreach (Note note in notes) 
            {
                if(note.matiere == i)
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

        public float moyenneGeneral()
        {
            float _moyenne = 0;
            float _moyenneTotal = 0;
            int _counter = 0;

            for (int i = 0; i < classe.matieres.Count(); i++)
            {
                _moyenne = 0;
                _counter = 0;

                foreach (Note note in notes)
                {
                    if (note.matiere == i)
                    {
                        _moyenne += note.note;
                        _counter++;
                    }
                }
                _moyenne = _moyenne / _counter;
                _moyenneTotal += _moyenne;
            }

            _moyenneTotal = _moyenneTotal / classe.matieres.Count;

            return (float)Math.Round(_moyenneTotal, 2);
        }
    }
}
