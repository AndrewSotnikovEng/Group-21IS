using Group_IS_21zp.Model;
using Group_IS_21zp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_IS_21zp.ViewModel
{
    class SearchWinViewModel : ViewModelBase
    {
        public SearchWinViewModel()
        {
            MessengerStatic.SearchElementsResponded += UpdateSearchResults;
            Results.Add(new SearchResult(0, "Bill Gates", SearchType.StudentElementType));
        }

        public ObservableCollection<SearchResult> _results { get; set; }  = new ObservableCollection<SearchResult>();
        public ObservableCollection<SearchResult> Results
        {
            get => _results; set
            {
                _results = value;
                OnPropertyChanged("Results");
            }
        }

        private void UpdateSearchResults(object obj)
        {
            List<SearchResult> searchResults = (List <SearchResult>) obj;
            Results.Clear();
            foreach(SearchResult r in searchResults)
            {
                Results.Add(r);
            }
        }
    }
}
