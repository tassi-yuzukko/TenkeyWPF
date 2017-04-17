using Livet;
using System;
using System.Collections.ObjectModel;

namespace TenkeyApp.Model
{
	class Tenkey : NotificationObject, ICloneable
	{
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

		/// <summary>
		/// ICloneable
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			return new Tenkey()
			{
				NumStr = this.NumStr,
			};
		}
	}
}
