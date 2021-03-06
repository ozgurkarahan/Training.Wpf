﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Wpf.Base;
using System.Resources;
using System.Collections.ObjectModel;

namespace Training.Wpf.UserControls
{
    public class PersonModel : ViewModelBase
    {
        public PersonModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            _nameLabel = Properties.Resources.LabelName;
            _surNameLabel = Properties.Resources.LabelSurName;
            _titlesLabel = Properties.Resources.LabelTitle;
            RegisterRule("Name", ValidateName);
            RegisterRule("SelectedTitle", ValidateSelectedTitle);
            RegisterRule("PhoneNumber", ValidatePhoneNumber);
        }

        #region Binded Properties
        
        private string _nameLabel;
        public string NameLabel
        {
            get { return _nameLabel; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
        private string ValidateName()
        {
            return string.IsNullOrWhiteSpace(Name) ? Properties.Resources.ErrName : null;
        }

        private string _surNameLabel;
        public string SurNameLabel
        {
            get { return _surNameLabel; }
        }

        private string _surName;
        public string SurName
        {
            get { return _surName; }
            set
            {
                _surName = value;
                RaisePropertyChanged("SurName");
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                RaisePropertyChanged("PhoneNumber");
            }
        }
        private string ValidatePhoneNumber()
        {
            double number;
            if (!Double.TryParse((PhoneNumber as string), out number))
                return Properties.Resources.ErrNonValidePhoneNumberMessage;
            return null;
        }

        private string _titlesLabel;
        public string TitlesLabel
        {
            get { return _titlesLabel; }
        }

        private ObservableCollection<string> _titles;
        public ObservableCollection<string> Titles
        {
            get
            {
                if (_titles == null)
                {
                    _titles = new ObservableCollection<string>();
                    _titles.Add(Properties.Resources.TitleMr);
                    _titles.Add(Properties.Resources.TitleMme);
                    _titles.Add(Properties.Resources.TitleMlle);
                }
                return _titles;
            }
            set { _titles = value; }
        }

        private string _selectedTitle;
        public string SelectedTitle
        {
            get { return _selectedTitle; }
            set
            {
                _selectedTitle = value;
                RaisePropertyChanged("SelectedTitle");
            }
        }
        private string ValidateSelectedTitle()
        {
            return string.IsNullOrWhiteSpace(SelectedTitle) ? Properties.Resources.ErrMsgSelectedTitle : null;
        }
        
        #endregion
    }
}
