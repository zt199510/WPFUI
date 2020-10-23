using GalaSoft.MvvmLight;

namespace Test.ViewModel
{
  
    public class MainViewModel : ViewModelBase
    {

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { 
                _Id = value;
                RaisePropertyChanged(); }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
    }
}