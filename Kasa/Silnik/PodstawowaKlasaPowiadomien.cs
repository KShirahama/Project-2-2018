using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Engine
{
    [Serializable]
    public class PodstawowaKlasaPowiadomien : INotifyPropertyChanged
    {
        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}