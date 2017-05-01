using Livet;
using System;
using System.Collections.ObjectModel;

namespace TenkeyTestLib.Model
{
	public enum TenkeyMode
	{
		Dec,	// 10進数モード
		Hex,	// 16進数モード
	};

	public class Tenkey : NotificationObject, ICloneable
	{
		const int MinStrLength = 1;
		const int MaxStrLength = 9;

		/// <summary>
		/// テンキー入力された文字列
		/// </summary>
		#region NumStr
		private string _numStr;
		public string NumStr
		{
			get { return _numStr; }
			set
			{
				if(_numStr == value) return;
				_numStr = value;
				RaisePropertyChanged(nameof(NumStr));
			}
		}
		#endregion

		#region MaxLength
		private uint _maxLength;
		public uint MaxLength
		{
			get { return _maxLength; }
			set
			{
				if (_maxLength == value) return;
				if ((value < MinStrLength) || (MaxStrLength < value)) return;
				_maxLength = value;
				RaisePropertyChanged(nameof(MaxLength));
			}
		}
		#endregion

		#region Mode
		private TenkeyMode _mode;
		public TenkeyMode Mode
	{
			get { return _mode; }
			set
			{
				if (_mode == value) return;
				_mode = value;
				RaisePropertyChanged(nameof(Mode));
			}
		}
		#endregion

		public Tenkey()
		{
			NumStr = "";
			Mode = TenkeyMode.Dec;
			MaxLength = 4;
		}

		/// <summary>
		/// ICloneable
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			return new Tenkey()
			{
				NumStr = this.NumStr,
				MaxLength = this.MaxLength,
				Mode = this.Mode,
			};
		}

		/// <summary>
		/// １０進数モードか１６進数モードかで値入力チェックする
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public bool CheckHexOrDec(TenkeyButtonType type)
		{
			if (this.Mode == TenkeyMode.Dec)
			{
				if ((TenkeyButtonType.Btn_A <= type) && (type <= TenkeyButtonType.Btn_F))
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// 値を追加する
		/// </summary>
		/// <param name="type"></param>
		public void AddStr(TenkeyButtonType type)
		{
			string btnStr = TenkeyButtonName.GetTenkeyButtonTypeName(type);

			if (this.NumStr.Length < this.MaxLength)
			{
				this.NumStr += btnStr;
			}
		}

		/// <summary>
		/// 値を削除する
		/// </summary>
		/// <param name="type"></param>
		public void DelStr()
		{
			if (this.NumStr.Length > 0)
			{
				this.NumStr = this.NumStr.Remove(this.NumStr.Length - 1);
			}
		}

		/// <summary>
		/// 値をクリアする
		/// </summary>
		public void ClrStr()
		{
			this.NumStr = "";
		}
	}
}
