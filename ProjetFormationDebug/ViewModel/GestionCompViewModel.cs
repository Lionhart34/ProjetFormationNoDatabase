using ProjetFormationDebug.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ProjetFormationDebug.ViewModel
{
    public class GestionCompViewModel : BaseViewModel
    {

        public GestionCompViewModel()
        {


        }

        private ObservableCollection<Personne> _personnes = null;
        public ObservableCollection<Personne> Personnes
        {
            get
            {
                    _personnes = new ObservableCollection<Personne>(
                        from Pers in Context.Personnes
                        select Pers);
                return _personnes;
            }
            set
            {
                _personnes = value;
                RaisePropertyChanged("Personnes");
            }
        }

        private ObservableCollection<Competence> _competences = null;
        public ObservableCollection<Competence> Competences
        {
            get
            {
              
                    _competences = new ObservableCollection<Competence>(
                        from Comp in Context.Competences
                        select Comp);
               
                return _competences;
            }
            set
            {
                _competences = value;
                RaisePropertyChanged("Competences");
            }
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
                            MessageBox.Show(p.Competence.Libelle);
                        }); 
                return _ThisOne;
            }
        }
    }

}
