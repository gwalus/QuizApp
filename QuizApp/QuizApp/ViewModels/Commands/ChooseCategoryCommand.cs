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
            return true;
        }

        public void Execute(object parameter)
        {
            var categoryId = parameter.ToString();

            _viewModel.GoToQuiz(categoryId);
        }
    }
}
