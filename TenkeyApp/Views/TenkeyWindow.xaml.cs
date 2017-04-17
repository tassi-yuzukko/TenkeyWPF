using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TenkeyApp.Model;
using TenkeyApp.ViewModels;

namespace TenkeyApp.Views
{
	/// <summary>
	/// TenkeyApp.xaml の相互作用ロジック
	/// </summary>
	public partial class TenkeyWindow : Window
	{
		public TenkeyWindow()
		{
			InitializeComponent();

			// ここに何も追加しなくても
			// MainWindow.xaml のDataTemplateによって
			// View と ViewModel がバインドされる

		}

		/// <summary>
		/// 動的コントロール定義
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			var vm = (TenkeyViewModel)this.DataContext;

			// テキストについて手動パインディング
			Binding bi = new Binding("TenkeyCopy.NumStr");
			this.NumStr.SetBinding(TextBox.TextProperty, bi);

			// ボタンの作成
			foreach(var cmd in vm.TenkeyBtnTbl)
			{
				this.ButtonGrid.Children.Add(new Button() { Content = tenkeyContentsTbl[cmd.Key], Command = cmd.Value, FontSize = 20});
			}
		}

		/// <summary>
		/// ボタンの表示名テーブル
		/// </summary>
		private IDictionary<TenkeyButtonType, string> tenkeyContentsTbl = new Dictionary<TenkeyButtonType, string>()
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
	}
}
