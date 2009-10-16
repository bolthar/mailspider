using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using MailSpider.Engine;
using Microsoft.Practices.Composite.Wpf.Commands;

namespace MailSpider.UI
{
    public class MainPresentationModel : INotifyPropertyChanged
    {
        public Main View { get; private set; }
        public DelegateCommand<object> GoCommand { get; private set; }
        private Spider _spider;

        public ObservableCollection<string> CurrentResults { get; set; }

        public MainPresentationModel(Main view)
        {
            View = view;
            CurrentResults = new ObservableCollection<string>();
            _spider = new Spider();
            _spider.ResultsFound += _spider_ResultsFound;
            GoCommand = new DelegateCommand<object>(Search, delegate { return true; });
            View.Model = this;
        }

        void _spider_ResultsFound(object sender, ResultsFoundEventArgs e)
        {
            foreach(string s in e.Results)
            {
                if (!CurrentResults.Contains(s))
                {
                    CurrentResults.Add(s.Replace("<em>",string.Empty).Replace("</em>",string.Empty));
                }
            }
            CurrentResults = new ObservableCollection<string>(CurrentResults.Distinct());
            FirePropertyChanged("CurrentResults");
        }


        public void Search(object parameter)
        {
            CurrentResults.Clear();
            string searchString = parameter.ToString();
            _spider.DoSearch(searchString);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
