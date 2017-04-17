using Livet;
using Livet.Commands;
using Livet.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenkeyApp.Model;

namespace TenkeyViewModel.ViewModels
{
	class TenkeyViewModel : ViewModel
	{
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
		public TenkeyViewModel(Tenkey tenkey)
		{
			TenkeyObj = tenkey;
			TenkeyObj.NumStr += "000";
		}
	}
}
