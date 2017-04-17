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

			// ボタンの作成
			foreach(var cmd in vm.TenkeyBtnTbl)
			{
				var button = new Button() { Content = TenkeyButtonName.GetTenkeyButtonTypeName(cmd.Key), FontSize = 20 };
				var binding = new Binding(cmd.Value);
				button.SetBinding(Button.CommandProperty, binding);
				this.ButtonGrid.Children.Add(button);
			}
		}
	}
}
