using System;
using System.Windows.Input;

namespace QuizApp.ViewModels.Commands
{
    public class CheckAnswerCommand : ICommand
    {
        QuizPageVM _viewModel;

        public CheckAnswerCommand(QuizPageVM viewModel)
        {
            _viewModel = viewModel;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter != null)
            _viewModel.CheckAnswer(parameter.ToString());
        }
    }
}
