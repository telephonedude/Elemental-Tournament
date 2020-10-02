/*
 * Created by SharpDevelop.
 * User: telephonedude
 * Date: 15/08/2018
 * Time: 11:17 AM
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
using System.Text.RegularExpressions;
using System.Windows.Threading;
using Microsoft.Win32;

namespace RPS_game
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		
		public MediaPlayer backgroundMusicPlayer = new MediaPlayer ();

		public Window1()
		{
			playsong();
       		 backgroundMusicPlayer.MediaEnded += new EventHandler (Media_Ended);

			InitializeComponent();
			
		}
		void submit_Click(object sender, RoutedEventArgs e)
		{
			int datacheck=0;
			if(namebox.Text == "")
			{
				MessageBox.Show("Error, please input a name","Error",MessageBoxButton.OK,MessageBoxImage.Error);
				return;
			}
			var choice = MessageBox.Show("Are you sure about this name, oh great warrior?","Confirmation",MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation);
					switch(choice)
					{
					case MessageBoxResult.Yes:
						break;
					case MessageBoxResult.No:
						return;
					default:
						return;
					}
			submitbutton.IsEnabled = false;
			storybutton.IsEnabled = true;
			pvpbutton.IsEnabled = true;
			statsbutton.IsEnabled = true;
			changebutton.IsEnabled = true;
			namebox.IsEnabled = false;
			if(datacheck==0)
			{
				DataContext = new player1();
			}
			((player1)DataContext).name_ = namebox.Text;
			MessageBox.Show("Welcome to the arena, "+((player1)DataContext).name_,"Welcome", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			if(datacheck==0)
			{
				DataStorage.Current.users.Add((player1)DataContext);
				datacheck++;
			}
			DataStorage.Current.users[0]=(player1)DataContext;
		}
		void story_Click(object sender, RoutedEventArgs e)
		{
			story_play storyplay = new story_play();
			storyplay.ShowDialog();
			((player1)DataContext).single_mode_++;
			((player1)DataContext).games_played_++;
			((player1)DataContext).number_of_wins_ = ((player1)DataContext).number_of_wins_ + storyplay.wins;
			((player1)DataContext).number_of_losses_ = ((player1)DataContext).number_of_losses_ + storyplay.losses;
			DataStorage.Current.users[0]=(player1)DataContext;
			
		}
		void pvp_Click(object sender, RoutedEventArgs e)
		{
			pvp_play playpvp = new pvp_play();
			playpvp.ShowDialog();
			((player1)DataContext).number_of_wins_ = ((player1)DataContext).number_of_wins_ + playpvp.wins;
			((player1)DataContext).number_of_losses_ = ((player1)DataContext).number_of_wins_ + playpvp.losses;
			((player1)DataContext).multi_mode_++;
			((player1)DataContext).games_played_++;
			DataStorage.Current.users[0]=(player1)DataContext;
		}
		void stats_Click(object sender, RoutedEventArgs e)
		{
			show_stats showstats = new show_stats();
			showstats.ShowDialog();
		}
		void changebutton_Click(object sender, RoutedEventArgs e)
		{
			var choice = MessageBox.Show("Are you sure that you would like to change profiles?\nThis will delete all the stats of the previous profile!!","Confirmation",MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation);
					switch(choice)
					{
					case MessageBoxResult.Yes:
						break;
					case MessageBoxResult.No:
						return;
					default:
						return;
					}
					namebox.IsEnabled = true;
					submitbutton.IsEnabled = true;
					storybutton.IsEnabled = false;
					pvpbutton.IsEnabled = false;
					statsbutton.IsEnabled = false;
					changebutton.IsEnabled = false;
		}
		void namebox1_previewtext(object sender, TextCompositionEventArgs e)
		{
			e.Handled = new Regex("^[0-9]+$").IsMatch(e.Text);
		}
		public void playsong()
		{
			backgroundMusicPlayer.Open (new Uri ("Pictures/Arena.mp3",UriKind.Relative));
       		backgroundMusicPlayer.Play ();
		}
		public void stopsong()
		{
			backgroundMusicPlayer.Stop();
		}
		void Media_Ended(object sender, EventArgs e)
		{
    		backgroundMusicPlayer.Position = TimeSpan.Zero;
    		backgroundMusicPlayer.Play();
		}
		void turnon_Click(object sender, RoutedEventArgs e)
		{
			playsong();
			turnoff.Visibility = Visibility.Visible;
			turnon.Visibility = Visibility.Hidden;
		}
		void turnoff_Click(object sender, RoutedEventArgs e)
		{
			stopsong();
			turnoff.Visibility = Visibility.Hidden;
			turnon.Visibility = Visibility.Visible;
		}

	}

	}
