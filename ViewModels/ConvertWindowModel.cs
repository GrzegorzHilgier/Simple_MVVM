using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Simple_MVVM.Models;

namespace Simple_MVVM.ViewModels
{
    public class ConvertWindowModel : ObservableObject
    {
        private readonly TextConverter _textConverter = new TextConverter(s => s.ToUpper());
        private string _inputText;
        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();

        public string InputText
        {
            get { return _inputText; }
            set
            {
                _inputText = value;
                RaisePropertyChangedEvent("InputText");
            }
        }

        public IEnumerable<string> History
        {
            get { return _history; }
        }

        public ICommand ConvertTextCommand
        {
            get { return new SimpleCommand(ConvertText); }
        }

        private void ConvertText()
        {
            if (string.IsNullOrWhiteSpace(InputText)) return;
            AddToHistory(_textConverter.ConvertText(InputText));
            InputText = string.Empty;
        }

        private void AddToHistory(string item)
        {
            if (!_history.Contains(item))
                _history.Add(item);
        }
    }
}
