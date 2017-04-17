using Livet;
using Livet.Commands;
using Livet.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenkeyApp.Model;

namespace TenkeyApp.ViewModels
{
	class MainWindowViewModel : ViewModel
	{
		#region DoButton
		private ViewModelCommand _doButton;
		public ViewModelCommand DoButton => (_doButton = _doButton ?? new ViewModelCommand(ExecuteDoButton));

		private  void ExecuteDoButton()
		{
			using (var vm = new TenkeyViewModel(this.TenkeyObj))
			{
				Messenger.Raise(new TransitionMessage(vm, "DoButton"));
			}
		}
		#endregion

		private Tenkey _tenkeyObj;
		public Tenkey TenkeyObj
		{
			get { return _tenkeyObj; }
			set
			{
				if (_tenkeyObj == value) return;
				_tenkeyObj = value;
				RaisePropertyChanged(nameof(TenkeyObj));
			}
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainWindowViewModel()
		{
			_tenkeyObj = new Tenkey();
		}
	}
}
