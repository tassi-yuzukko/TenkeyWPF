using Livet;
using System;
using System.Collections.ObjectModel;

namespace TenkeyApp.Model
{
	public enum TenkeyMode
	{
		Dec,	// 10進数モード
		Hex,	// 16進数モード
	};

	class Tenkey : NotificationObject, ICloneable
	{
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
				if ((value < 1) || (6 < value)) return;
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
	}
}
