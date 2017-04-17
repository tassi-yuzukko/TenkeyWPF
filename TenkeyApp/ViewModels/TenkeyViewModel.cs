using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using TenkeyApp.Model;

namespace TenkeyApp.ViewModels
{
	class TenkeyViewModel : ViewModel
	{
		IDictionary<TenkeyButtonType, string> _tenkeyBtnTbl;
		public IDictionary<TenkeyButtonType, string> TenkeyBtnTbl { get => _tenkeyBtnTbl; set => _tenkeyBtnTbl = value; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public TenkeyViewModel(Tenkey tenkey)
		{
			this.TenkeyOrigin = tenkey;
			this.TenkeyCopy = (Tenkey)this.TenkeyOrigin.Clone();

			// テンキー関連の実行処理を作成
			_tenkeyButton = new Dictionary<string, ViewModelCommand>();
			for (TenkeyButtonType type = TenkeyButtonType.Btn_0; type <= TenkeyButtonType.Btn_F; type++)
			{
				string btnStr = TenkeyButtonName.GetTenkeyButtonTypeName(type);
				_tenkeyButton.Add(btnStr, new ViewModelCommand(() => { TenkeyCopy.NumStr += btnStr; }, () => { return TenkeyCopy.NumStr.Length < TenkeyCopy.MaxLength; }));
			}

			// テンキーボタンテーブル作成（左上から順番）
			// ※順番をいつでも変えられるように、あえてここで列挙しています
			// 　ここの列挙順がバインディング順になります
			_tenkeyBtnTbl = new Dictionary<TenkeyButtonType, string>()
			{
				{ TenkeyButtonType.Btn_E, "TenkeyButton[E]"},
				{ TenkeyButtonType.Btn_F, "TenkeyButton[F]"},
				{ TenkeyButtonType.Btn_7, "TenkeyButton[7]"},
				{ TenkeyButtonType.Btn_8, "TenkeyButton[8]"},
				{ TenkeyButtonType.Btn_9, "TenkeyButton[9]"},
				{ TenkeyButtonType.Btn_C, "TenkeyButton[C]"},
				{ TenkeyButtonType.Btn_D, "TenkeyButton[D]"},
				{ TenkeyButtonType.Btn_4, "TenkeyButton[4]"},
				{ TenkeyButtonType.Btn_5, "TenkeyButton[5]"},
				{ TenkeyButtonType.Btn_6, "TenkeyButton[6]"},
				{ TenkeyButtonType.Btn_A, "TenkeyButton[A]"},
				{ TenkeyButtonType.Btn_B, "TenkeyButton[B]"},
				{ TenkeyButtonType.Btn_1, "TenkeyButton[1]"},
				{ TenkeyButtonType.Btn_2, "TenkeyButton[2]"},
				{ TenkeyButtonType.Btn_3, "TenkeyButton[3]"},
				{ TenkeyButtonType.Btn_Clear, "ClearButton"},
				{ TenkeyButtonType.Btn_Backspace, "BsButton"},
				{ TenkeyButtonType.Btn_Cancel, "CancelButton"},
				{ TenkeyButtonType.Btn_0, "TenkeyButton[0]"},
				{ TenkeyButtonType.Btn_Enter, "EnterButton"},
			};
		}

		#region TenkeyCopy
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

		#region TenkeyOrigin
		private Tenkey _tenkeyOrigin;
		public Tenkey TenkeyOrigin { get => _tenkeyOrigin; set => _tenkeyOrigin = value; }
		#endregion

		#region EnterButton
		private ViewModelCommand _enterButton;
		public ViewModelCommand EnterButton => (_enterButton = _enterButton ?? new ViewModelCommand(ExecuteEnterButton));

		private void ExecuteEnterButton()
		{
			// テンキー情報を更新する
			// ※インスタンスそのものに代入すると、コンストラクタで与えられた参照が上書きされるので
			// 　要素のみを更新する
			TenkeyOrigin.NumStr = TenkeyCopy.NumStr;
			Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Close"));
		}
		#endregion

		#region CancelButton
		private ViewModelCommand _cancelButton;
		public ViewModelCommand CancelButton => (_cancelButton = _cancelButton ?? new ViewModelCommand(ExecuteCancelButton));

		private void ExecuteCancelButton()
		{
			// テンキー情報を更新せずウィンドウを閉じる
			Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Close"));
		}
		#endregion

		#region tenkeyButton
		private IDictionary<string, ViewModelCommand> _tenkeyButton;
		public IDictionary<string, ViewModelCommand> TenkeyButton
		{
			get
			{
				return _tenkeyButton;
			}
		}
		#endregion

		#region CancelButton
		private ViewModelCommand _bsButton;
		public ViewModelCommand BsButton => (_bsButton = _bsButton ?? new ViewModelCommand(() => { TenkeyCopy.NumStr = TenkeyCopy.NumStr.Remove(TenkeyCopy.NumStr.Length - 1); }));
		#endregion

		#region ClearButton
		private ViewModelCommand _clearButton;
		public ViewModelCommand ClearButton => (_clearButton = _clearButton ?? new ViewModelCommand(() => { TenkeyCopy.NumStr = ""; }));
		#endregion
	}
}
