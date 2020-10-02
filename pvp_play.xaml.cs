/*
 * Created by SharpDevelop.
 * User: telephonedude
 * Date: 08/19/2018
 * Time: 14:24
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace RPS_game
{
	/// <summary>
	/// Interaction logic for pvp_play.xaml
	/// </summary>
	/// 
	
	public partial class pvp_play : Window
	{
		public int wins = 0;
		public int losses = 0;
		public int winner = 0;
		int rounds=0;
		int instructionsnum=0;
		int p1_lives=3;
		int p2_lives=3;
		int p1_wins=0;
		int p2_wins=0;
		int p1_choice=0;
		int p2_choice=0;
		int p1avatar_choice=0;
		int p2avatar_choice=0;
		int avatar_choice=0;
		int runs = 0;
		public Button targetbutton;
		public pvp_play()
		{
			InitializeComponent();
			avatarchoice.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar1.png"));
			p1_happy.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar1_happy.png"));
			p1_cocky.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar1_cocky.png"));
			p1_surprised.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar1_shocked.png"));
			DataContext = DataStorage.Current.users[0].Copy();
			player1box.Text = ((player1)DataContext).name_;
			instructions.Text = ((player1)DataContext).name_+" please choose an avatar";
		}
		void oneround_Click(object sender, RoutedEventArgs e)
		{
			var result = MessageBox.Show("The tournament will have a single round, are you sure about this?","Confirmation",MessageBoxButton.YesNo, MessageBoxImage.Hand);
					switch(result)
					{
						case MessageBoxResult.Yes:
							MessageBox.Show("The tournament will have only 1 round","Confirmed!",MessageBoxButton.OK, MessageBoxImage.Information);
							break;
						case MessageBoxResult.No:
							return;
					}
			rounds = 1;
			gamestart();
		}
		void threerounds_Click(object sender, RoutedEventArgs e)
		{
			var result = MessageBox.Show("The tournament will have three rounds, are you sure about this?","Confirmation",MessageBoxButton.YesNo, MessageBoxImage.Hand);
					switch(result)
					{
						case MessageBoxResult.Yes:
							MessageBox.Show("The tournament will have 3 rounds","Confirmed!",MessageBoxButton.OK, MessageBoxImage.Information);
							break;
						case MessageBoxResult.No:
							return;
					}
			rounds = 3;
			gamestart();
		}
		void fiverounds_Click(object sender, RoutedEventArgs e)
		{
			var result = MessageBox.Show("The tournament will have five rounds, are you sure about this?","Confirmation",MessageBoxButton.YesNo, MessageBoxImage.Hand);
					switch(result)
					{
						case MessageBoxResult.Yes:
							MessageBox.Show("The tournament will have 5 rounds","Confirmed!",MessageBoxButton.OK, MessageBoxImage.Information);
							break;
						case MessageBoxResult.No:
							return;
					}
			rounds = 5;
			gamestart();
		}
		void gamestart()
		{
			if(p1_lives == 0)
			{
				checklives();
				((player1)DataContext).number_of_losses_++;
				DataStorage.Current.users[0]=(player1)DataContext;
				instructions.Text = "The Challenger has won a round!!"+((player1)DataContext).name_+" has been taken to the infirmary!";
				instructionsnum = 7;
				p2_wins++;
				runs = 0;
			}
			if(p2_lives == 0)
			{
				checklives();
				((player1)DataContext).number_of_wins_++;
				DataStorage.Current.users[0]=(player1)DataContext;
				instructions.Text = ((player1)DataContext).name_+" has won a round!! The Challenger has been taken to the infirmary!";
				instructionsnum = 7;
				p1_wins++;
				runs = 0;
			}
			onebutton.Visibility = Visibility.Hidden;
			onebutton.IsEnabled = false;
			triplebutton.Visibility = Visibility.Hidden;
			triplebutton.IsEnabled = false;
			fivebutton.Visibility = Visibility.Hidden;
			fivebutton.IsEnabled = false;
			nextbutton.Visibility = Visibility.Visible;
			if(instructionsnum == 4 || instructionsnum == 5 || instructionsnum == 6)
			{
				nextbutton.Visibility = Visibility.Hidden;
			}
			if(instructionsnum==0)
			{
				rulespic.Visibility = Visibility.Visible;
				instructions.Text = "Here is how each element reacts with each other\nWater is strong against Fire\nFire is strong against Earth\nEarth is strong against Electricity\nand Electricity is strong against Water";
			}
			if(instructionsnum == 1)
			{
				instructions.Text = "Fire and Electricity cancels out each other\nWater and Earth also cancels out each other";
			}
			if(instructionsnum == 2)
			{
				instructions.Text = "You will be given "+rounds+" round(s) to fight\nEach of you will start off with 3 hearts\nThe player who drops to O hearts will lose the round";
				rulespic.Visibility = Visibility.Hidden;
			}
			if(instructionsnum == 3)
			{
				if(rounds==1)
				{
					instructions.Text = "The player who wins the first round, will win the tournament, is that understood?";
					yesbutton.Visibility = Visibility.Visible;
					nobutton.Visibility = Visibility.Visible;
					nextbutton.Visibility = Visibility.Hidden;
				}
				if(rounds==3)
				{
					instructions.Text = "The player who wins 2 rounds first, will win the tournament, is that understood?";
					yesbutton.Visibility = Visibility.Visible;
					nobutton.Visibility = Visibility.Visible;
					nextbutton.Visibility = Visibility.Hidden;
				}
				if(rounds==5)
				{
					instructions.Text = "The player who wins 3 rounds first, will win the tournament, is that understood?";
					yesbutton.Visibility = Visibility.Visible;
					nobutton.Visibility = Visibility.Visible;
					nextbutton.Visibility = Visibility.Hidden;
				}
			}
				if(instructionsnum == 4)
				{
					if(runs == 0)
					{
						p1_happy.Visibility = Visibility.Visible;
						p2_happy.Visibility = Visibility.Visible;
						runs++;
					}
						show_elementpic();
						checklives();
						this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/coliseum.jpg",UriKind.Relative)));
						instructions.Text = ((player1)DataContext).name_+", please choose an element";
						player1box.Visibility = Visibility.Visible;
						player2box.Visibility = Visibility.Visible;
						nextbutton.Visibility = Visibility.Hidden;
						firebutton.Visibility = Visibility.Visible;
						earthbutton.Visibility = Visibility.Visible;
						thunderbutton.Visibility = Visibility.Visible;
						waterbutton.Visibility = Visibility.Visible;
				}
				if(instructionsnum == 5)
				{
					instructions.Text = "Challenger, please choose an element";
				}
				if(instructionsnum == 6)
				{
					checkwin();
				}
				if(instructionsnum == 7)
				{
					this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/Winner.jpg",UriKind.Relative)));
					if(rounds == 1 && p1_wins ==1)
					{
						instructions.Text = ((player1)DataContext).name_+" has won the tournament!! Press next to go back to the main menu";
						winner = 1;
						endgame();
					}
					else if(rounds == 1 && p2_wins ==1)
					{
						instructions.Text = "The Challenger has won the tournament!! Press next to go back to the main menu";
						winner = 2;
						endgame();
					}
					else if(rounds == 3 && p1_wins ==2)
					{
						instructions.Text = ((player1)DataContext).name_+" has won the tournament!! Press next to go back to the main menu";
						winner = 1;
						endgame();
					}
					else if(rounds == 3 && p2_wins ==2)
					{
						instructions.Text = "The Challenger has won the tournament!! Press next to go back to the main menu";
						winner = 2;
						endgame();
					}
					else if(rounds == 5 && p1_wins ==3)
					{
						instructions.Text = ((player1)DataContext).name_+" has won the tournament!! Press next to go back to the main menu";
						winner = 1;
						endgame();
					}
					else if(rounds == 5 && p2_wins ==3)
					{
						instructions.Text = "The Challenger has won the tournament!! Press next to go back to the main menu";
						winner = 2;
						endgame();
					}
					else
					{
						this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/Rest.png",UriKind.Relative)));
						instructions.Text = "Both competitors are healing up, press next to go to the next round";
						nextbutton.Visibility = Visibility.Visible;
						firebutton.Visibility = Visibility.Hidden;
						earthbutton.Visibility = Visibility.Hidden;
						thunderbutton.Visibility = Visibility.Hidden;
						waterbutton.Visibility = Visibility.Hidden;
						instructionsnum = 3;
						p1_lives = 3;
						p2_lives = 3;
					}
				}
			
		}
		void nextbutton_Click(object sender, RoutedEventArgs e)
		{
			if(winner == 1 || winner == 2)
			{
				Close();
			}
			else
			{
			instructionsnum++;
			gamestart();
			}
		}
		void nobutton_Click(object sender, RoutedEventArgs e)
		{
			instructionsnum = 0;
			yesbutton.Visibility = Visibility.Hidden;
			nobutton.Visibility = Visibility.Hidden;
			gamestart();
		}
		void yesbutton_Click(object sender, RoutedEventArgs e)
		{
			instructionsnum++;
			yesbutton.Visibility = Visibility.Hidden;
			nobutton.Visibility = Visibility.Hidden;
			gamestart();
		}
		void earthbutton_Click(object sender, RoutedEventArgs e)
		{
			if(instructionsnum == 5)
			{
				p2_choice = 2;
				instructionsnum++;
			}
			if(instructionsnum == 4)
			{
				p1_choice = 2;
				instructionsnum++;
			}
			
			gamestart();
		}
		void firebutton_Click(object sender, RoutedEventArgs e)
		{
			if(instructionsnum == 5)
			{
				p2_choice = 1;
				instructionsnum++;
			}
			if(instructionsnum == 4)
			{
				p1_choice = 1;
				instructionsnum++;
			}
			gamestart();
		}
		
		void thunderbutton_Click(object sender, RoutedEventArgs e)
		{
			if(instructionsnum == 5)
			{
				p2_choice = 3;
				instructionsnum++;
			}
			if(instructionsnum == 4)
			{
				p1_choice = 3;
				instructionsnum++;
			}
			gamestart();
		}
		
		void waterbutton_Click(object sender, RoutedEventArgs e)
		{
			if(instructionsnum == 5)
			{
				p2_choice = 4;
				instructionsnum++;
			}
			if(instructionsnum == 4)
			{
				p1_choice = 4;
				instructionsnum++;
			}
			gamestart();
		}
		
		void checkwin()
		{
			if(p1_choice == 1 && p2_choice == 2 || p1_choice == 2 && p2_choice == 3 || p1_choice == 3 && p2_choice == 4 || p1_choice == 4 && p2_choice == 1)
			{
				p1_cocky.Visibility = Visibility.Hidden;
				p1_happy.Visibility = Visibility.Hidden;
				p1_surprised.Visibility = Visibility.Hidden;
				p2_cocky.Visibility = Visibility.Hidden;
				p2_happy.Visibility = Visibility.Hidden;
				p2_surprised.Visibility = Visibility.Hidden;
				p2_lives--;
				instructionsnum = 4;
				p1_cocky.Visibility = Visibility.Visible;
				p2_surprised.Visibility = Visibility.Visible;
				MessageBox.Show("The Challenger got damaged!!");
				gamestart();
			}
			else if(p2_choice == 1 && p1_choice == 2 || p2_choice == 2 && p1_choice == 3 || p2_choice == 3 && p1_choice == 4 || p2_choice == 4 && p1_choice == 1)
			{
				p2_cocky.Visibility = Visibility.Hidden;
				p2_happy.Visibility = Visibility.Hidden;
				p2_surprised.Visibility = Visibility.Hidden;
				p1_cocky.Visibility = Visibility.Hidden;
				p1_happy.Visibility = Visibility.Hidden;
				p1_surprised.Visibility = Visibility.Hidden;
				p1_lives--;
				instructionsnum = 4;
				p2_cocky.Visibility = Visibility.Visible;
				p1_surprised.Visibility = Visibility.Visible;
				MessageBox.Show(instructions.Text = ((player1)DataContext).name_+" got damaged!!");
				gamestart();
			}
			
			else
			{
				MessageBox.Show("You blocked each other's attacks!!");
				instructionsnum =4;
				gamestart();
			}
		}
		
		void checklives()
		{
					if(p1_lives == 3)
					{
						p1_hp1.Visibility = Visibility.Visible;
						p1_hp2.Visibility = Visibility.Visible;
						p1_hp3.Visibility = Visibility.Visible;
					}
					if(p2_lives == 3)
					{
						p2_hp1.Visibility = Visibility.Visible;
						p2_hp2.Visibility = Visibility.Visible;
						p2_hp3.Visibility = Visibility.Visible;
					}
					if(p1_lives == 2)
					{
						p1_hp1.Visibility = Visibility.Visible;
						p1_hp2.Visibility = Visibility.Visible;
						p1_hp3.Visibility = Visibility.Hidden;
					}
					if(p2_lives == 2)
					{
						p2_hp1.Visibility = Visibility.Visible;
						p2_hp2.Visibility = Visibility.Visible;
						p2_hp3.Visibility = Visibility.Hidden;
					}
					else if(p1_lives == 1)
					{
						p1_hp1.Visibility = Visibility.Visible;
						p1_hp2.Visibility = Visibility.Hidden;
						p1_hp3.Visibility = Visibility.Hidden;
					}
					if(p2_lives == 1)
					{
						p2_hp1.Visibility = Visibility.Visible;
						p2_hp2.Visibility = Visibility.Hidden;
						p2_hp3.Visibility = Visibility.Hidden;
					}
					if(p1_lives == 0)
					{
						p1_hp1.Visibility = Visibility.Hidden;
						p1_hp2.Visibility = Visibility.Hidden;
						p1_hp3.Visibility = Visibility.Hidden;
					}
					if(p2_lives == 0)
					{
						p2_hp1.Visibility = Visibility.Hidden;
						p2_hp2.Visibility = Visibility.Hidden;
						p2_hp3.Visibility = Visibility.Hidden;
					}			
		}
		void endgame()
		{
			p1_element.Visibility = Visibility.Hidden;
			p2_element.Visibility = Visibility.Hidden;
			player1box.Visibility = Visibility.Hidden;
			player2box.Visibility = Visibility.Hidden;
			p2_cocky.Visibility = Visibility.Hidden;
			p2_happy.Visibility = Visibility.Hidden;
			p2_surprised.Visibility = Visibility.Hidden;
			p1_cocky.Visibility = Visibility.Hidden;
			p1_happy.Visibility = Visibility.Hidden;
			p1_surprised.Visibility = Visibility.Hidden;
			nextbutton.Visibility = Visibility.Visible;
			firebutton.Visibility = Visibility.Hidden;
			earthbutton.Visibility = Visibility.Hidden;
			thunderbutton.Visibility = Visibility.Hidden;
			waterbutton.Visibility = Visibility.Hidden;
			if(winner == 1)
			{
						player1box.Visibility = Visibility.Visible;
						p2_happy.Visibility = Visibility.Hidden;
						p1_happy.Visibility = Visibility.Visible;
						wins++;
			}
			if(winner == 2)
			{
						player2box.Visibility = Visibility.Visible;
						p1_happy.Visibility = Visibility.Hidden;
						p2_happy.Visibility = Visibility.Visible;
						losses++;
			}
		}
		
		void show_elementpic()
		{
			if(p1_choice == 1)
			{
				p1_element.Source = new BitmapImage(new Uri(@"/Pictures/fire.png", UriKind.Relative));
			}
			if(p1_choice == 2)
			{
				p1_element.Source = new BitmapImage(new Uri(@"/Pictures/earth.png", UriKind.Relative));
			}
			if(p1_choice == 3)
			{
				p1_element.Source = new BitmapImage(new Uri(@"/Pictures/electricity.png", UriKind.Relative));
			}
			if(p1_choice == 4)
			{
				p1_element.Source = new BitmapImage(new Uri(@"/Pictures/water.png", UriKind.Relative));
			}
			if(p2_choice == 1)
			{
				p2_element.Source = new BitmapImage(new Uri(@"/Pictures/fire.png", UriKind.Relative));
			}
			if(p2_choice == 2)
			{
				p2_element.Source = new BitmapImage(new Uri(@"/Pictures/earth.png", UriKind.Relative));
			}
			if(p2_choice == 3)
			{
				p2_element.Source = new BitmapImage(new Uri(@"/Pictures/electricity.png", UriKind.Relative));
			}
			if(p2_choice == 4)
			{
				p2_element.Source = new BitmapImage(new Uri(@"/Pictures/water.png", UriKind.Relative));
			}
		}
		void next1_Click(object sender, RoutedEventArgs e)
		{
			if(avatar_choice == 0)
			{
				p1avatar_choice++;
				previous.IsEnabled = true;
				if(p1avatar_choice == 5)
				{
					next1.IsEnabled = false;
				}
				checkavatarp1();
			}
			if(avatar_choice == 1)
			{
				p2avatar_choice++;
				next1.IsEnabled = true;
				if(p2avatar_choice == 5)
				{
					next1.IsEnabled = false;
				}
				checkavatarp2();
			}
		}
		void choose_Click(object sender, RoutedEventArgs e)
		{
			if(avatar_choice == 1)
			{
				instructions.Text = "Please choose how many rounds to play";
				avatarchoice.Visibility = Visibility.Hidden;
				next1.Visibility = Visibility.Hidden;
				previous.Visibility = Visibility.Hidden;
				choose.Visibility = Visibility.Hidden;
				onebutton.Visibility = Visibility.Visible;
				triplebutton.Visibility = Visibility.Visible;
				fivebutton.Visibility=Visibility.Visible;
			}
			if(avatar_choice == 0)
			{
				next1.IsEnabled = true;
				previous.IsEnabled = false;
				instructions.Text = "Challenger, please choose an avatar";
				avatar_choice++;
				checkavatarp2();
			}
		}
		void previous_Click(object sender, RoutedEventArgs e)
		{
			if(avatar_choice == 0)
			{
				p1avatar_choice--;
				next1.IsEnabled = true;
				if(p1avatar_choice == 0)
				{
					previous.IsEnabled = false;
				}
				checkavatarp1();
			}
			if(avatar_choice == 1)
				{
				p2avatar_choice--;
				next1.IsEnabled = true;
				previous.IsEnabled = true;
				if(p2avatar_choice == 0)
				{
					previous.IsEnabled = false;
				}
				checkavatarp2();
			}
		}
		void checkavatarp1()
		{
			if(p1avatar_choice == 0)
			{
			avatarchoice.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar1.png"));
			p1_happy.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar1_happy.png"));
			p1_cocky.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar1_cocky.png"));
			p1_surprised.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar1_shocked.png"));
			}
			if(p1avatar_choice == 1)
			{
				avatarchoice.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar2.png"));
				p1_happy.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar2_happy.png"));
				p1_cocky.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar2_cocky.png"));
				p1_surprised.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar2_shocked.png"));
			}
			if(p1avatar_choice == 2)
			{
				avatarchoice.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar3.png"));
				p1_happy.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar3_happy.png"));
				p1_cocky.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar3_cocky.png"));
				p1_surprised.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar3_shocked.png"));
			}
			if(p1avatar_choice == 3)
			{
				avatarchoice.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar4.png"));
				p1_happy.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar4_happy.png"));
				p1_cocky.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar4_cocky.png"));
				p1_surprised.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar4_shocked.png"));
			}
			if(p1avatar_choice == 4)
			{
				avatarchoice.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar5.png"));
				p1_happy.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar5_happy.png"));
				p1_cocky.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar5_cocky.png"));
				p1_surprised.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar5_shocked.png"));
			}
			if(p1avatar_choice == 5)
			{
				avatarchoice.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar6.png"));
				p1_happy.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar6_happy.png"));
				p1_cocky.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar6_cocky.png"));
				p1_surprised.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p1/avatar6_shocked.png"));
			}
		}
		
		void checkavatarp2()
		{
			if(p2avatar_choice == 0)
			{
			avatarchoice.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar1.png"));
			p2_happy.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar1_happy.png"));
			p2_cocky.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar1_cocky.png"));
			p2_surprised.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar1_shocked.png"));
			}
			if(p2avatar_choice == 1)
			{
				previous.IsEnabled = true;
				avatarchoice.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar2.png"));
				p2_happy.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar2_happy.png"));
				p2_cocky.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar2_cocky.png"));
				p2_surprised.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar2_shocked.png"));
			}
			if(p2avatar_choice == 2)
			{
				previous.IsEnabled = true;
				avatarchoice.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar3.png"));
				p2_happy.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar3_happy.png"));
				p2_cocky.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar3_cocky.png"));
				p2_surprised.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar3_shocked.png"));
			}
			if(p2avatar_choice == 3)
			{
				previous.IsEnabled = true;
				avatarchoice.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar4.png"));
				p2_happy.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar4_happy.png"));
				p2_cocky.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar4_cocky.png"));
				p2_surprised.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar4_shocked.png"));
			}
			if(p2avatar_choice == 4)
			{
				previous.IsEnabled = true;
				avatarchoice.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar5.png"));
				p2_happy.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar5_happy.png"));
				p2_cocky.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar5_cocky.png"));
				p2_surprised.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar5_shocked.png"));
			}
			if(p2avatar_choice == 5)
			{
				previous.IsEnabled = true;
				avatarchoice.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar6.png"));
				p2_happy.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar6_happy.png"));
				p2_cocky.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar6_cocky.png"));
				p2_surprised.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Avatars_p2/avatar6_shocked.png"));
			}
		}
		
		
	}
}