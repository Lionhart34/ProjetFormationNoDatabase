using ProjetFormationDebug.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;


namespace ProjetFormationDebug.ViewModel
{
    public class ProjetViewModel : BaseViewModel
    {
     

        public ProjetViewModel()
        {

        }

        #region Liste affichage
        private List<Personne> _personnesSource = null;
        public List<Personne> PersonnesSource
        {
            get
            {
                if (_personnesSource == null)
                    _personnesSource = new List<Personne>(
                        from p in Context.Personnes
                        select p
                        );
                return _personnesSource;
            }
            set
            {
                _personnesSource = value;
            }
        }


        private ICollectionView _personnesView;
        public ICollectionView PersonnesView
        {
            get
            {
                if (_personnesView == null)
                {
                    _personnesView = CollectionViewSource.GetDefaultView(PersonnesSource);
                }
                return _personnesView;
            }
        }

        #endregion


    }
}
