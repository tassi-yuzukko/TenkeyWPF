using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenkeyTestLib.Model
{
	/// <summary>
	/// テンキーボタン識別子
	/// </summary>
	public enum TenkeyButtonType
	{
		Btn_0,
		Btn_1,
		Btn_2,
		Btn_3,
		Btn_4,
		Btn_5,
		Btn_6,
		Btn_7,
		Btn_8,
		Btn_9,
		Btn_A,
		Btn_B,
		Btn_C,
		Btn_D,
		Btn_E,
		Btn_F,
		Btn_Enter,
		Btn_Cancel,
		Btn_Clear,
		Btn_Backspace,
	}

	public static class TenkeyButtonName
	{
		/// <summary>
		/// ボタンの表示名テーブル
		/// </summary>
		static private IDictionary<TenkeyButtonType, string> _tenkeyContentsTbl = new Dictionary<TenkeyButtonType, string>()
		{
			{ TenkeyButtonType.Btn_0, "0"},
			{ TenkeyButtonType.Btn_1, "1"},
			{ TenkeyButtonType.Btn_2, "2"},
			{ TenkeyButtonType.Btn_3, "3"},
			{ TenkeyButtonType.Btn_4, "4"},
			{ TenkeyButtonType.Btn_5, "5"},
			{ TenkeyButtonType.Btn_6, "6"},
			{ TenkeyButtonType.Btn_7, "7"},
			{ TenkeyButtonType.Btn_8, "8"},
			{ TenkeyButtonType.Btn_9, "9"},
			{ TenkeyButtonType.Btn_A, "A"},
			{ TenkeyButtonType.Btn_B, "B"},
			{ TenkeyButtonType.Btn_C, "C"},
			{ TenkeyButtonType.Btn_D, "D"},
			{ TenkeyButtonType.Btn_E, "E"},
			{ TenkeyButtonType.Btn_F, "F"},
			{ TenkeyButtonType.Btn_Clear, "Clr"},
			{ TenkeyButtonType.Btn_Backspace, "BS"},
			{ TenkeyButtonType.Btn_Cancel, "戻る"},
			{ TenkeyButtonType.Btn_Enter, "OK"},
		};

		/// <summary>
		/// Enumに割り当てられた名前を返す
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static string GetTenkeyButtonTypeName(TenkeyButtonType type)
		{
			return _tenkeyContentsTbl[type];
		}

		public static int GetTenkeyButtonTypeSize()
		{
			return _tenkeyContentsTbl.Count;
		}
	}
}
