using ProjetFormation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ProjetFormation.ViewModel
{
    public class GestionCompViewModel : BaseViewModel
    {

        public GestionCompViewModel()
        {


        }

        private ObservableCollection<Personne> _personnes=null;
        public ObservableCollection<Personne> Personnes
        {
            get
            {
                if (_personnes == null)
                {
                    _personnes = new ObservableCollection<Personne>(
                        from Pers in Context.Personnes
                        select Pers);

                }

                return _personnes;
            }
            set
            {
                _personnes = value;
                RaisePropertyChanged("Personnes");
            }
        }

        private ObservableCollection<Competence> _competences=null;
        public ObservableCollection<Competence> Competences
        {
            get
            {
                if (_competences == null)
                {
                    _competences = new ObservableCollection<Competence>(
                        from Comp in Context.Competences
                        select Comp);
                }
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
                            MessageBox.Show(p.CompetencePrincipale.Libelle);
                        });
                return _ThisOne;
            }
        }


        private ObservableCollection<TestDebug> _debug = null;
        public ObservableCollection<TestDebug> Debug
        {
            get
            {
                if (_debug == null)
                {
                    _debug = new ObservableCollection<TestDebug>();
                    _debug.Add(new TestDebug() { Nom = "T1", Comp = Context.Competences.First(C => C.Libelle == "Software") });
                    _debug.Add(new TestDebug() { Nom = "T2", Comp = Context.Competences.First(C => C.Libelle == "Software") });
                    _debug.Add(new TestDebug() { Nom = "T3", Comp = Context.Competences.First(C => C.Libelle == "Software") });
                }
                return _debug;
            }
            set
            {
                _debug = value;
                RaisePropertyChanged("Debug");
            }
        }
    }


    public class TestDebug:BaseViewModel
    {

        private Competence _comp;
        public Competence Comp
        {
            get
            {
                return _comp;
            }
            set
            {
                _comp = value;
                RaisePropertyChanged("Comp");
            }
        }

        public string Nom { get; set; }
    }
    //public partial class Personne
    //{
    //    private Competence _test = null;
    //    public Competence test
    //    {
    //        get
    //        {
    //            return _test;
    //        }
    //        set
    //        {
    //            _test = value;
    //        }

    //    }

    //}

   
}
