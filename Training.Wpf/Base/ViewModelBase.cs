using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Training.Wpf.Base
{
    /// <summary>
    /// Classe mère de toutes les classes ViewModel de l'application.
    /// Fournit une implementation par défaut de <c>INotifyPropertyChanged</c>
    /// et une propriété <c>DisplayName</c>. Cette classe est abstraite.
    /// </summary>
    public abstract class ViewModelBase : BasePropertyChanged, IDisposable, IViewModelBase, IDataErrorInfo
    {
        #region Constructor

        protected ViewModelBase()
        {
            ValidationRules = new Dictionary<string, Func<string>>();
            Errors = new Dictionary<string, string>();
            InitializeValidationRules();
        }

        #endregion // Constructor

        #region DisplayName

        /// <summary>
        /// Returns the user-friendly name of this object.
        /// Child classes can set this property to a new value,
        /// or override it to determine the value on-demand.
        /// </summary>
        public virtual string DisplayName { get; protected set; }

        #endregion // DisplayName

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            this.OnDispose();
        }

        /// <summary>
        /// Child classes can override this method to perform 
        /// clean-up logic, such as removing event handlers.
        /// </summary>
        protected virtual void OnDispose()
        {
        }

#if DEBUG
        /// <summary>
        /// Useful for ensuring that ViewModel objects are properly garbage collected.
        /// </summary>
        ~ViewModelBase()
        {
            string msg = string.Format("{0} ({1}) ({2}) Finalized", this.GetType().Name, this.DisplayName, this.GetHashCode());
            System.Diagnostics.Debug.WriteLine(msg);
        }
#endif

        #endregion // IDisposable Members

        #region IDataErrorInfo Members

        public bool HasError
        {
            get
            {
                return Error != null;
            }
        }

        public void CheckValidation()
        {
            OnPropertyChanged("Error");
            OnPropertyChanged("HasError");
            this.ValidateAll();
        }

        public virtual string Error
        {
            get
            {
                if (Errors.Count > 0)
                    return "(" + Errors.Count + " erreurs)";
                return null;
            }
            set
            {
            }
        }

        public virtual string this[string columnName]
        {
            get
            {
                Func<string> validationFunc;
                if (ValidationRules.TryGetValue(columnName, out validationFunc))
                {
                    Errors.Remove(columnName);
                    string errorMsg = validationFunc();
                    if (errorMsg != null)
                    {
                        Errors[columnName] = errorMsg;
                    }
                    OnPropertyChanged("Error");
                    OnPropertyChanged("HasError");
                    return errorMsg;
                }
                //Log.Debug("ViewModelBase", "Erreur de validation :  la propriété '" + columnName + "' n'a pas de règle associée");
                throw new ArgumentException("Pas de règle de validation pour la propriété", columnName);
            }
        }

        /// <summary>
        /// Enregistre une règle de validation sur le view-model pour la property <paramref name="propertyName"/>
        /// </summary>
        /// <param name="propertyName">Le nom de la property validée</param>
        /// <param name="rule">un fonction retournant un message d'erreur ou null si pas d'erreurs</param>
        public void RegisterRule(string propertyName, Func<string> rule)
        {
            Func<string> validationFunc;
            if (ValidationRules.TryGetValue(propertyName, out validationFunc))
            {
                throw new ArgumentException("Une règle de validation est déjà enregistrer", propertyName);
            }
            ValidationRules[propertyName] = rule;
        }

        public Dictionary<string, string> Errors { get; private set; }
        protected Dictionary<string, Func<string>> ValidationRules { get; set; }

        #endregion

        /// <summary>
        /// Initialisation des regles de validation.
        /// <see cref="RegisterRule"/>
        /// </summary>
        public virtual void InitializeValidationRules()
        {
            // do nothing
        }

        //Checks if viewmodel is in a valid state
        public bool IsValid()
        {
            foreach (var item in ValidationRules)
            {
                if (item.Value.Invoke() != null)
                    return false;
            }
            return true;
        }

        public virtual void ValidateAll()
        {
            RaiseAll();
        }
    }
}
