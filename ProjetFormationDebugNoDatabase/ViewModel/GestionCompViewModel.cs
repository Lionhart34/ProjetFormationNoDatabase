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
                            MessageBox.Show(p.Competence.Libelle);
                        }); 
                return _ThisOne;
            }
        }
    }

}
