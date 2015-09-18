using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Fievel.Wpf.Models.Observable;

namespace Fievel.Wpf.Commands
{
    public class ApplyHighlightingCommand : ICommand
    {
        private readonly TailFile _vm;

        public ApplyHighlightingCommand(TailFile vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await ClearHighlights();
            await SetHighlights(_vm.SearchPhrase);
         
            Trace.WriteLine($"Found {_vm.LogLines.Count(line => line.Highlight.Category == LogHighlight.HighlightCategory.Find)} results!");
        }

        private async Task ClearHighlights()
        {
            await Task.Run(() =>
            {
                foreach (var item in _vm.LogLines)
                {
                    item.Highlight = LogHighlight.None;
                }
            });
        }

        private async Task SetHighlights(string phrase)
        {
            if (string.IsNullOrEmpty(phrase)) return;

            await Task.Run(() =>
            {
                // verified this is twice as fast as using AsParallel
                foreach (var line in _vm.LogLines
                    .Where(line => line.Content.IndexOf(phrase, StringComparison.OrdinalIgnoreCase) != -1)) // TODO: make case sensitivity optional
                {
                    line.Highlight = LogHighlight.Find;
                }
            });
        }

        public event EventHandler CanExecuteChanged;
    }
}