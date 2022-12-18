using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeaks.ViewModel
{
    /// <summary>
    /// DependencyProperty를 Binding 하는 경우 CLR 내부에서 'INotifyPropertyChanged'를 이용한 강력한 참조를 생성
    /// https://stackoverflow.com/questions/18542940/can-bindings-create-memory-leaks-in-wpf/18543350#18543350
    /// </summary>
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; } 
            set { 
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowViewModel()
        {
            _name = string.Empty;
        }

    }
}
