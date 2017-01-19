using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{		
			InitializeComponent();
		}
		

		private void btn_open_Click(object sender, RoutedEventArgs e)
		{
			string[] lines = System.IO.File.ReadAllLines(txt_file.Text);
			AddRows(lines.Length);
			if (lines.Length > 0)
				AddColumns(lines[0].Length);
			AddGridContent(lines);
		}

		private void AddGridContent(string[] lines)
		{
			for(int i = 0; i < lines.Length; i++)
			{
				for(int j = 0; j < lines[i].Length; j++)
				{
					var TextBlock = new TextBlock();
					if (lines[i][j] == '*')
					{
						TextBlock.Background = Brushes.Black;
						TextBlock.Text = "";
					}
					else
						TextBlock.Text = lines[i][j].ToString();
					
					Grid.SetRow(TextBlock, i);
					Grid.SetColumn(TextBlock, j);
					TextBlock.TextAlignment = TextAlignment.Center;
					crossword_field.Children.Add(TextBlock);
				}
			}
		}

		private void AddRows(int length)
		{
			for(int i = 0; i < length; i++)
				crossword_field.RowDefinitions.Add(new RowDefinition());
		}

		private void AddColumns(int length)
		{
			for (int i = 0; i < length; i++)
				crossword_field.ColumnDefinitions.Add(new ColumnDefinition());
		}
	}
}
