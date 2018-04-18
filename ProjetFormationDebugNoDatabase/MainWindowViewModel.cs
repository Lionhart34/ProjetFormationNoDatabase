using ProjetFormationDebugNoDatabase.Model;
using ProjetFormationDebugNoDatabase.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationDebugNoDatabase
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            #region Initialisation du catalogue avec des valeurs
            if (Competences.Count() == 0)
            {
                Competences.Add(new Competence() { Couleur = "#4f6228", Libelle = "Archi Analog", LibelleCourt = "AA" });
                Competences.Add(new Competence() { Couleur = "#75923c", Libelle = "Design Analog", LibelleCourt = "DA" });
                Competences.Add(new Competence() { Couleur = "#9bbb59", Libelle = "Layout Analog", LibelleCourt = "LA" });
                Competences.Add(new Competence() { Couleur = "#17375d", Libelle = "", LibelleCourt = "AD" });
                Competences.Add(new Competence() { Couleur = "#1f497d", Libelle = "Design Digital", LibelleCourt = "DN" });
                Competences.Add(new Competence() { Couleur = "#4f81bd", Libelle = "Verif. Fonct.", LibelleCourt = "VF" });
                Competences.Add(new Competence() { Couleur = "#4bacc6", Libelle = "Design For Test", LibelleCourt = "DFT" });
                Competences.Add(new Competence() { Couleur = "#b2a1c7", Libelle = "Middle End (Synthèse, TA)", LibelleCourt = "ME" });
                Competences.Add(new Competence() { Couleur = "#8064a2", Libelle = "Implémentation Physique", LibelleCourt = "P&R" });
                Competences.Add(new Competence() { Couleur = "#953735", Libelle = "", LibelleCourt = "SV" });
                Competences.Add(new Competence() { Couleur = "#953735", Libelle = "Caractérisation", LibelleCourt = "Ca" });
                Competences.Add(new Competence() { Couleur = "#8064a2", Libelle = "INDUS", LibelleCourt = "Ind" });
                Competences.Add(new Competence() { Couleur = "#00b050", Libelle = "Hw (Carte)", LibelleCourt = "Hw" });
                Competences.Add(new Competence() { Couleur = "#00b050", Libelle = "Software", LibelleCourt = "Sw" });
                Competences.Add(new Competence() { Couleur = "#00b050", Libelle = "Banc de Test", LibelleCourt = "BT" });
                Competences.Add(new Competence() { Couleur = "#00b050", Libelle = "", LibelleCourt = "VA" });
            }

            if (Personnes.Count() == 0)
            {
                 Personnes.Add(new Personne() { Nom = "Geoffrey", Competence =  Competences.First(C => C.Libelle == "Software") });
                 Personnes.Add(new Personne() { Nom = "Nicola", Competence =  Competences.First(C => C.Libelle == "Hw (Carte)") });
                 Personnes.Add(new Personne() { Nom = "Guillaume", Competence =  Competences.First(C => C.Libelle == "INDUS") });
            }
            #endregion
        }
    }
}
