using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Grid
{

	//http://stackoverflow.com/questions/16950813/class-library-does-not-recognize-commandmanager-class/16951365
	//Go to the "References" part of your class library and select "Add Reference". Look for an assembly called "PresentationCore" and add it.

	public class Command : ICommand
	{
		Action<object> executeMethod;
		Func<object, bool> canExecuteMethod;

		public Command(Action<object> _executeMethod, Func<object, bool> _canExecuteMethod)
		{
			this.executeMethod = _executeMethod;
			this.canExecuteMethod = _canExecuteMethod;
		}
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}


		public bool CanExecute(object parameter)
		{
			return canExecuteMethod(parameter);
		}

		public void Execute(object parameter)
		{
			executeMethod(parameter);
		}
	}
}
