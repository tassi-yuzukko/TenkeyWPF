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
	class TenkeyViewModel : ViewModel
	{
		IDictionary<TenkeyButtonType, ViewModelCommand> _tenkeyBtnTbl;
		public IDictionary<TenkeyButtonType, ViewModelCommand> TenkeyBtnTbl { get => _tenkeyBtnTbl; set => _tenkeyBtnTbl = value; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public TenkeyViewModel(Tenkey tenkey)
		{
			this.TekeyOrigin = tenkey;
			this.TenkeyCopy = (Tenkey)this.TekeyOrigin.Clone();

			this.TenkeyCopy.NumStr += "000";

			// テンキーボタンテーブル作成（左上から順番）
			_tenkeyBtnTbl = new Dictionary<TenkeyButtonType, ViewModelCommand>()
			{
				{ TenkeyButtonType.Btn_E, null},
				{ TenkeyButtonType.Btn_F, null},
				{ TenkeyButtonType.Btn_7, null},
				{ TenkeyButtonType.Btn_8, null},
				{ TenkeyButtonType.Btn_9, null},
				{ TenkeyButtonType.Btn_C, null},
				{ TenkeyButtonType.Btn_D, null},
				{ TenkeyButtonType.Btn_4, null},
				{ TenkeyButtonType.Btn_5, null},
				{ TenkeyButtonType.Btn_6, null},
				{ TenkeyButtonType.Btn_A, null},
				{ TenkeyButtonType.Btn_B, null},
				{ TenkeyButtonType.Btn_1, null},
				{ TenkeyButtonType.Btn_2, null},
				{ TenkeyButtonType.Btn_3, null},
				{ TenkeyButtonType.Btn_Clear, null},
				{ TenkeyButtonType.Btn_Backspace, null},
				{ TenkeyButtonType.Btn_Cancel, null},
				{ TenkeyButtonType.Btn_0, null},
				{ TenkeyButtonType.Btn_Enter, null},
			};
		}

		#region Tenkeyオブジェクト
		private Tenkey _tenkeyCopy;
		public Tenkey TenkeyCopy
		{
			get { return _tenkeyCopy; }
			set
			{
				if (_tenkeyCopy == value) return;
				_tenkeyCopy = value;
				RaisePropertyChanged(nameof(_tenkeyCopy));
			}
		}
		#endregion

		private Tenkey _tenkeyOrigin;
		public Tenkey TekeyOrigin { get; set; }
	}
}
