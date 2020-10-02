/*
 * Created by SharpDevelop.
 * User: telephonedude
 * Date: 08/18/2018
 * Time: 01:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace RPS_game
{
	/// <summary>
	/// Interaction logic for show_stats.xaml
	/// </summary>
	public partial class show_stats : Window
	{
		public show_stats()
		{
			InitializeComponent();
			DataContext = DataStorage.Current.users[0].Copy();
			namebox.Text = ((player1)DataContext).name_;
			singlebox.Text = ((player1)DataContext).single_mode_.ToString();
			multibox.Text = ((player1)DataContext).multi_mode_.ToString();
			scorebox.Text = ((player1)DataContext).highest_score_.ToString();
			winbox.Text = ((player1)DataContext).number_of_wins_.ToString();
			lossbox.Text = ((player1)DataContext).number_of_losses_.ToString();
			gamesbox.Text = ((player1)DataContext).games_played_.ToString();
		}
		void closebutton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}