using System;
using System.Windows.Input;

namespace QuizApp.ViewModels.Commands
{
    public class ChooseCategoryCommand : ICommand
    {
        ChooseDetailQuizPageVM _viewModel;

        public ChooseCategoryCommand(ChooseDetailQuizPageVM viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                var categoryId = parameter.ToString();

                _viewModel.GoToQuiz(categoryId);
            }
        }
    }
}
