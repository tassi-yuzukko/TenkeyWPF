using Livet;
using Livet.Commands;
using Livet.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenkeyViewModel.ViewModels
{
	class MainWindowViewModel : ViewModel
	{
		#region DoButton
		private ViewModelCommand _doButton;
		public ViewModelCommand DoButton => (_doButton = _doButton ?? new ViewModelCommand(ExecuteDoButton));

		private  void ExecuteDoButton()
		{
			using (var vm = new TenkeyViewModel())
			{
				Messenger.Raise(new TransitionMessage(vm, "DoButton"));
			}
		}
		#endregion
	}
}
