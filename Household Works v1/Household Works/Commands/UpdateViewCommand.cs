using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Household_Works.ViewModel
{
    internal class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Parent")
            {
                viewModel.SelectedViewModel = new ParentViewModel();
            }
            else if (parameter.ToString() == "Child")
            {
                viewModel.SelectedViewModel = new ChildViewModel();
            }
        }
    }
}