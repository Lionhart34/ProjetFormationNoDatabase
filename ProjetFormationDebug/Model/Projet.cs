using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;

namespace ProjetFormationDebug.Model
{
    [MetadataType(typeof(ProjetMetaData))]
    [Description("Projet")]
    public partial class Projet : EntityObject, IDataErrorInfo
    {
        public enum Etats
        {
            [Description("EN DISCUSSION")]
            enDiscussion = 0,
            [Description("GAGNÉ")]
            gagne = 1,
            [Description("TERMINÉ")]
            termine = 2,
        }

        public Etats? Etat
        {
            get
            {
                if (CodeEtat == null)
                    return null;
                return (Etats)CodeEtat;
            }
            set
            {
                CodeEtat = (int)value;
            }

        }

        #region IDataErrorInfo
        public string Error
        {
            get
            {
                return Validateurs.Courant.GetErreurs(this);
            }
        }

        public string this[string columnName]
        {
            get
            {
                this.OnPropertyChanged("Error");
                return Validateurs.Courant.GetErreur(this, columnName);
            }
        }
        #endregion
    }

    public class ProjetMetaData
    {
        [Required(ErrorMessage = "Le nom de projet est requis")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Une date de début est requise")]
        public DateTime DateDebut { get; set; }

        [Required(ErrorMessage = "Une date de fin est requise")]
        public DateTime DateFin { get; set; }
    }
}
