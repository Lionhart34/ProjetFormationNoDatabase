using ProjetFormationDebugNoDatabase.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ProjetFormationDebugNoDatabase.ViewModel
{
    public class GestionCompViewModel : BaseViewModel
    {

        public GestionCompViewModel()
        {


        }

        private ICommand _ThisOne = null;
        public ICommand ThisOne
        {
            get
            {
                if (_ThisOne == null)
                    _ThisOne = new RelayCommand<Personne>(
                        (p) =>
                        {
                            MessageBox.Show(p.CompetencePrincipale.Libelle);
                        }); 
                return _ThisOne;
            }
        }
    }

    public class Wrapper:BaseViewModel
    {
        public Wrapper()
        { }
        public Wrapper(Personne pers)
        {
            P = pers;
        }

        
        private Personne _P = null;
        public Personne P
        {
            get
            {
                return _P;
            }
            set
            {
                _P = value;
            }
        }

        private Competence _SelectedItem = null;
        public Competence SelectedItem
        {
            get
            {
                if (_SelectedItem == null)
                    _SelectedItem = P.CompetencePrincipale;
                return _SelectedItem;
            }
            set
            {
                P.CompetencePrincipale = value;
                _SelectedItem = value;

                if (P.CompetencePrincipale != null)
                { 
                }
                RaisePropertyChanged("SelectedItem"); RaisePropertyChanged("P");
            }
        }

        private ObservableCollection<Competence> _Listcompetences = null;
        public ObservableCollection<Competence> Listcompetences 
        {
            get
            {
                if (_Listcompetences  == null)
                    _Listcompetences  = new ObservableCollection<Competence>(
                        from Comps in Competences
                         select Comps);
                return _Listcompetences ;
            }
            set
            {
                _Listcompetences = value;
                RaisePropertyChanged("Competences");
            }
        }

        private ICommand _ThisOne = null;
        public ICommand ThisOne
        {
            get
            {
                if (_ThisOne == null)
                    _ThisOne = new RelayCommand(
                        () =>
                        {
                            MessageBox.Show(SelectedItem.Libelle);
                        });
                return _ThisOne;
            }
        }

    }

}
