using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Engine
{
    public class PodstawowaKlasaPowiadomien : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}