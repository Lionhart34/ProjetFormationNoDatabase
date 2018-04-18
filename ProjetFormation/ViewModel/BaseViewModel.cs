using ProjetFormation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjetFormation.ViewModel
{
    public class BaseViewModel:INotifyPropertyChanged
    {

        private static ModelContainer _Context = null;
        public static ModelContainer Context
        {
            get
            {
                if (_Context == null)
                {
                    try
                    {
                        _Context = new ModelContainer();
                        _Context.Configuration.LazyLoadingEnabled = true;
                        #region Initialisation du catalogue avec des valeurs
                        if (_Context.Competences.Count() == 0)
                        {
                            _Context.Competences.Add(new Competence() { Couleur = "#4f6228", Libelle = "Archi Analog", LibelleCourt = "AA" });
                            _Context.Competences.Add(new Competence() { Couleur = "#75923c", Libelle = "Design Analog", LibelleCourt = "DA" });
                            _Context.Competences.Add(new Competence() { Couleur = "#9bbb59", Libelle = "Layout Analog", LibelleCourt = "LA" });
                            _Context.Competences.Add(new Competence() { Couleur = "#17375d", Libelle = "", LibelleCourt = "AD" });
                            _Context.Competences.Add(new Competence() { Couleur = "#1f497d", Libelle = "Design Digital", LibelleCourt = "DN" });
                            _Context.Competences.Add(new Competence() { Couleur = "#4f81bd", Libelle = "Verif. Fonct.", LibelleCourt = "VF" });
                            _Context.Competences.Add(new Competence() { Couleur = "#4bacc6", Libelle = "Design For Test", LibelleCourt = "DFT" });
                            _Context.Competences.Add(new Competence() { Couleur = "#b2a1c7", Libelle = "Middle End (Synthèse, TA)", LibelleCourt = "ME" });
                            _Context.Competences.Add(new Competence() { Couleur = "#8064a2", Libelle = "Implémentation Physique", LibelleCourt = "P&R" });
                            _Context.Competences.Add(new Competence() { Couleur = "#953735", Libelle = "", LibelleCourt = "SV" });
                            _Context.Competences.Add(new Competence() { Couleur = "#953735", Libelle = "Caractérisation", LibelleCourt = "Ca" });
                            _Context.Competences.Add(new Competence() { Couleur = "#8064a2", Libelle = "INDUS", LibelleCourt = "Ind" });
                            _Context.Competences.Add(new Competence() { Couleur = "#00b050", Libelle = "Hw (Carte)", LibelleCourt = "Hw" });
                            _Context.Competences.Add(new Competence() { Couleur = "#00b050", Libelle = "Software", LibelleCourt = "Sw" });
                            _Context.Competences.Add(new Competence() { Couleur = "#00b050", Libelle = "Banc de Test", LibelleCourt = "BT" });
                            _Context.Competences.Add(new Competence() { Couleur = "#00b050", Libelle = "", LibelleCourt = "VA" });
                            _Context.SaveChanges();
                        }

                        if (_Context.Personnes.Count() == 0)
                        {
                            _Context.Personnes.Add(new Personne() { Nom = "Geoffrey", CompetencePrincipale = _Context.Competences.First(C => C.Libelle == "Software") });
                            _Context.Personnes.Add(new Personne() { Nom = "Nicola", CompetencePrincipale = _Context.Competences.First(C => C.Libelle == "Hw (Carte)") });
                            _Context.Personnes.Add(new Personne() { Nom = "Guillaume", CompetencePrincipale = _Context.Competences.First(C => C.Libelle == "INDUS") });
                            _Context.SaveChanges();
                        }
                        #endregion
                    }
                    catch
                    {
                        throw;
                    }
                }
                return _Context;
            }
            set
            {
                _Context = value;
            }
        }

        private BaseViewModel _CurrentViewModel = null;
        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _CurrentViewModel;
            }
            set
            {
                _CurrentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }

        }

        #region Command

        public ICommand Enregistrer
        {
            get
            {
                return new RelayCommand(() => Context.SaveChanges());
            }

        }

        private ICommand _GoTo = null;
        public ICommand GoTo
        {
            get
            {
                if (_GoTo == null)
                    _GoTo = new RelayCommand<string>((t)=>NavigateTo(t));
                return _GoTo;
            }
        }
        public void NavigateTo(string targetViewModel)
        {
            switch (targetViewModel)
            {
                case "1":
                    CurrentViewModel = new ProjetViewModel(); 
                    break;
                case "2":
                    CurrentViewModel = new GestionCompViewModel(); 
                    break;
                default:
                    CurrentViewModel = null;
                    break;
            }
                

        }
        #endregion

        #region INotifyPropertyChanged

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

    public class RelayCommand : ICommand
    {
        #region Constructors

        /// <summary>
        ///     Constructor
        /// </summary>
        public RelayCommand(Action executeMethod)
            : this(executeMethod, null, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
            : this(executeMethod, canExecuteMethod, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod, bool isAutomaticRequeryDisabled)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod");
            }

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
            _isAutomaticRequeryDisabled = isAutomaticRequeryDisabled;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute()
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod();
            }
            return true;
        }

        /// <summary>
        ///     Execution of the command
        /// </summary>
        public void Execute()
        {
            if (_executeMethod != null)
            {
                try
                {
                    _executeMethod();
                }
                catch (Exception E)
                {
                    System.Windows.MessageBox.Show(E.ToDisplay(), "Exception non gérée !", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Exclamation);
                }
            }
        }

        /// <summary>
        ///     Property to enable or disable CommandManager's automatic requery on this command
        /// </summary>
        public bool IsAutomaticRequeryDisabled
        {
            get
            {
                return _isAutomaticRequeryDisabled;
            }
            set
            {
                if (_isAutomaticRequeryDisabled != value)
                {
                    if (value)
                    {
                        CommandManagerHelper.RemoveHandlersFromRequerySuggested(_canExecuteChangedHandlers);
                    }
                    else
                    {
                        CommandManagerHelper.AddHandlersToRequerySuggested(_canExecuteChangedHandlers);
                    }
                    _isAutomaticRequeryDisabled = value;
                }
            }
        }

        /// <summary>
        ///     Raises the CanExecuteChaged event
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        /// <summary>
        ///     Protected virtual method to raise CanExecuteChanged event
        /// </summary>
        protected virtual void OnCanExecuteChanged()
        {
            CommandManagerHelper.CallWeakReferenceHandlers(_canExecuteChangedHandlers);
        }

        #endregion

        #region ICommand Members

        /// <summary>
        ///     ICommand.CanExecuteChanged implementation
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested += value;
                }
                CommandManagerHelper.AddWeakReferenceHandler(ref _canExecuteChangedHandlers, value, 2);
            }
            remove
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested -= value;
                }
                CommandManagerHelper.RemoveWeakReferenceHandler(_canExecuteChangedHandlers, value);
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            Execute();
        }

        #endregion

        #region Data

        private readonly Action _executeMethod = null;
        private readonly Func<bool> _canExecuteMethod = null;
        private bool _isAutomaticRequeryDisabled = false;
        private List<WeakReference> _canExecuteChangedHandlers;

        #endregion
    }

    public class RelayCommand<T> : ICommand
    {
        #region Constructors

        /// <summary>
        ///     Constructor
        /// </summary>
        public RelayCommand(Action<T> executeMethod)
            : this(executeMethod, null, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
            : this(executeMethod, canExecuteMethod, false)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod, bool isAutomaticRequeryDisabled)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod");
            }

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
            _isAutomaticRequeryDisabled = isAutomaticRequeryDisabled;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute(T parameter)
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod(parameter);
            }
            return true;
        }

        /// <summary>
        ///     Execution of the command
        /// </summary>
        public void Execute(T parameter)
        {
            if (_executeMethod != null)
            {
                try
                {
                    _executeMethod(parameter);

                }
                catch (Exception E)
                {
                    System.Windows.MessageBox.Show(E.ToDisplay(), "Exception non gérée !", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Exclamation);
                }
            }
        }

        /// <summary>
        ///     Raises the CanExecuteChaged event
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        /// <summary>
        ///     Protected virtual method to raise CanExecuteChanged event
        /// </summary>
        protected virtual void OnCanExecuteChanged()
        {
            CommandManagerHelper.CallWeakReferenceHandlers(_canExecuteChangedHandlers);
        }

        /// <summary>
        ///     Property to enable or disable CommandManager's automatic requery on this command
        /// </summary>
        public bool IsAutomaticRequeryDisabled
        {
            get
            {
                return _isAutomaticRequeryDisabled;
            }
            set
            {
                if (_isAutomaticRequeryDisabled != value)
                {
                    if (value)
                    {
                        CommandManagerHelper.RemoveHandlersFromRequerySuggested(_canExecuteChangedHandlers);
                    }
                    else
                    {
                        CommandManagerHelper.AddHandlersToRequerySuggested(_canExecuteChangedHandlers);
                    }
                    _isAutomaticRequeryDisabled = value;
                }
            }
        }

        #endregion

        #region ICommand Members

        /// <summary>
        ///     ICommand.CanExecuteChanged implementation
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested += value;
                }
                CommandManagerHelper.AddWeakReferenceHandler(ref _canExecuteChangedHandlers, value, 2);
            }
            remove
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested -= value;
                }
                CommandManagerHelper.RemoveWeakReferenceHandler(_canExecuteChangedHandlers, value);
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            // if T is of value type and the parameter is not
            // set yet, then return false if CanExecute delegate
            // exists, else return true
            if (parameter == null &&
                typeof(T).IsValueType)
            {
                return (_canExecuteMethod == null);
            }


            // l'object parameter est en cours de destruction
            if (parameter != null)
                if (parameter.GetType().Name == "NamedObject") //MS.Internal.NamedObject
                    return false;

            return CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            Execute((T)parameter);
        }

        #endregion

        #region Data

        private readonly Action<T> _executeMethod = null;
        private readonly Func<T, bool> _canExecuteMethod = null;
        private bool _isAutomaticRequeryDisabled = false;
        private List<WeakReference> _canExecuteChangedHandlers;

        #endregion
    }

    internal class CommandManagerHelper
    {
        internal static void CallWeakReferenceHandlers(List<WeakReference> handlers)
        {
            if (handlers != null)
            {
                // Take a snapshot of the handlers before we call out to them since the handlers
                // could cause the array to me modified while we are reading it.

                EventHandler[] callees = new EventHandler[handlers.Count];
                int count = 0;

                for (int i = handlers.Count - 1; i >= 0; i--)
                {
                    WeakReference reference = handlers[i];
                    EventHandler handler = reference.Target as EventHandler;
                    if (handler == null)
                    {
                        // Clean up old handlers that have been collected
                        handlers.RemoveAt(i);
                    }
                    else
                    {
                        callees[count] = handler;
                        count++;
                    }
                }

                // Call the handlers that we snapshotted
                for (int i = 0; i < count; i++)
                {
                    EventHandler handler = callees[i];
                    handler(null, EventArgs.Empty);
                }
            }
        }

        internal static void AddHandlersToRequerySuggested(List<WeakReference> handlers)
        {
            if (handlers != null)
            {
                foreach (WeakReference handlerRef in handlers)
                {
                    EventHandler handler = handlerRef.Target as EventHandler;
                    if (handler != null)
                    {
                        CommandManager.RequerySuggested += handler;
                    }
                }
            }
        }

        internal static void RemoveHandlersFromRequerySuggested(List<WeakReference> handlers)
        {
            if (handlers != null)
            {
                foreach (WeakReference handlerRef in handlers)
                {
                    EventHandler handler = handlerRef.Target as EventHandler;
                    if (handler != null)
                    {
                        CommandManager.RequerySuggested -= handler;
                    }
                }
            }
        }

        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler)
        {
            AddWeakReferenceHandler(ref handlers, handler, -1);
        }

        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler, int defaultListSize)
        {
            if (handlers == null)
            {
                handlers = (defaultListSize > 0 ? new List<WeakReference>(defaultListSize) : new List<WeakReference>());
            }

            handlers.Add(new WeakReference(handler));
        }

        internal static void RemoveWeakReferenceHandler(List<WeakReference> handlers, EventHandler handler)
        {
            if (handlers != null)
            {
                for (int i = handlers.Count - 1; i >= 0; i--)
                {
                    WeakReference reference = handlers[i];
                    EventHandler existingHandler = reference.Target as EventHandler;
                    if ((existingHandler == null) || (existingHandler == handler))
                    {
                        // Clean up old handlers that have been collected
                        // in addition to the handler that is to be removed.
                        handlers.RemoveAt(i);
                    }
                }
            }
        }
    }

    public static class ExceptionExtension
    {

        public static string ToDisplay(this Exception E)
        {
            string Message = "";

            Message += "EXCEPTION : \n" + E.Message + "\n";

            if (E.InnerException != null)
            {
                Message += "INNEREXCEPTION : \n" + E.InnerException.Message + "\n";
            }

            Message += "STACKTRACE : \n" + E.StackTrace;

            return Message;
        }



    }
}
