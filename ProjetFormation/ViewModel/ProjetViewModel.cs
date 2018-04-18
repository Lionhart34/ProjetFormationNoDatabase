using ProjetFormation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjetFormation.ViewModel
{
    public class ProjetViewModel : BaseViewModel
    {
        private ObservableCollection<Competence> _competences = null;
        public ObservableCollection<Competence> Competences
        {
            get
            {
                if (_competences == null)
                {
                    _competences = new ObservableCollection<Competence>(
                        (from Comp in Context.Competences
                        select Comp).ToList());
                }
                return _competences;
            }
            set
            {
                _competences = value;
                RaisePropertyChanged("Competences");
            }
        }

        public ProjetViewModel()
        {
          
        }


        
    }
}
