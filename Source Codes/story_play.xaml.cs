/*
 * Created by SharpDevelop.
 * User: telephonedude
 * Date: 22/08/2018
 * Time: 10:50 PM
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
	/// Interaction logic for story_play.xaml
	/// </summary>
	public partial class story_play : Window
	{
		int dialognum=0;
		int p1_lives=3;
		int p2_lives=3;
		int p1_choice=0;
		int p2_choice=0;
		int ending_choice = 0;
		int health_potion = 4;
		int vision_stone = 4;
		public int wins = 0;
		public int losses = 0;
		public story_play()
		{
			InitializeComponent();
			DataContext = DataStorage.Current.users[0].Copy();
			dialogbox.Text = ((player1)DataContext).name_+", you live in a world of magic, of men bending the elements to their will";
		
		}
		void gamestart()
		{
			if(dialognum == 1)
			{
				dialogbox.Text = "Where only the strongest benders can rule";
			}
			if(dialognum == 2)
			{
				dialogbox.Text = "Only the Avatar has been able to bend all the 4 elements\nFire, Earth, Water and Electricity";
			}
			if(dialognum == 3)
			{
				dialogbox.Text = "Until you came";
			}
			if(dialognum == 4)
			{
				dialogbox.Text = ((player1)DataContext).name_+", since you were a child, your parents have done their best to raise you\nBut alas poverty got the better of them and they died when you were on the cusp of manhood\nbut not before teaching you";
			}
			if(dialognum == 5)
			{
				dialogbox.Text = "How to use the 4 elements to your advantage";
			}
			if(dialognum == 6)
			{
				dialogbox.Text = "and now, you plan to put it to good use";
			}
			if(dialognum == 7)
			{
				dialogbox.Text = "The king is dead and as tradition, a tournament for elementalists will be held yet again in the capital";
			}
			if(dialognum == 8)
			{
				dialogbox.Text = "A tournament to the death\nWhere only the best benders can survive\nWhere the victor will be crowned as the ruler of the kingdom";
			}
			if(dialognum == 9)
			{
				this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/Colliseum.jpg",UriKind.Relative)));
				dialogbox.Text = "Now you have made yourself there to the arena, "+((player1)DataContext).name_;
			}
			if(dialognum == 10)
			{
				dialogpic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/narrator2.png"));
				dialogbox.Text = "Will you waste your gift and die in mediocrity?\n Or will you rise up to the occasion and prove yourself and be crowned ruler?";
			}
			if(dialognum == 11)
			{
				dialogbox.Text = "Make it or break it, your choice,"+((player1)DataContext).name_;
			}
			if(dialognum == 12)
			{
				dialogpic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/narrator1.png"));
				this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/Dungeon.png",UriKind.Relative)));
				dialogbox.Text = "Well whatever your choice was, you seem to have gotten yourself into the dungeon\nSomething about stealing a loaf of bread or some other crime\nYou're going to have to put glory on hold";
			}
			if(dialognum == 13)
			{
				dialogpic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/soldier1.png"));
				dialogname.Text = "Soldier";
				dialogbox.Text = "So, you're the troublemaker eh? I have no idea what you did but you're here so it doesn't really matter now";
			}
			if(dialognum == 14)
			{
				dialogbox.Text = "*checks your records*\nso, " +((player1)DataContext).name_+", you here for the Elemental Arena Tournament then?";
			}
			if(dialognum == 15)
			{
				dialogbox.Text = "I pity you elementalist types, usin' your gifts like that, what a waste,\nWell the law dictates that we can't keep competitors here, so off you go to the Arena then";
			}
			if(dialognum == 16)
			{
				hide_dialog();
				this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/coliseum1.jpg",UriKind.Relative)));
				dialogbox.Text = "*you tread near the great gladitorium, from outside you hear cheers already*\n*You were told to go to the registration booth down below*";
			}
			if(dialognum == 17)
			{
				this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/Dungeon1.png",UriKind.Relative)));
				dialogbox.Text = "*you go to another place that looks like a dungeon yet again\nyou seem to be attracting alot of dungeons lately\nyou see a woman on a table nearby, you go near her*";
			}
			if(dialognum == 18)
			{
				dialogname.Visibility = Visibility.Visible;
				dialogpic.Visibility = Visibility.Visible;
				dialogpic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/receptionist1.png"));
				dialogname.Text = "Receptionist";
				dialogbox.Text = "Hail! You here for the Arena? We were about to close up but we could take in another contender\n*You give her your papers*\n";
			}
			if(dialognum == 19)
			{
				dialogbox.Text = ((player1)DataContext).name_+", you'll need to sign a waiver that waives your death and considers us blameless during whatever will happen in the arena";
			}
			if(dialognum == 20)
			{
				dialogpic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/receptionist2.png"));
				dialogbox.Text = "Thanks for understanding! I wish you the best of luck";
			}
			if(dialognum == 21)
			{
				hide_dialog();
				view.Visibility = Visibility.Visible;
				view.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse.png"));
				dialogbox.Text = "*In the distance, you see a beautiful girl with a medic's insignia on her chest\nShe sees you and smiles, she then stands up and walks to your direction";
			}
			if(dialognum == 22)
			{
				view.Visibility = Visibility.Hidden;
				show_dialog();
				dialogname.Text = "Taoru";
				dialogpic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse_happy3.png"));
				dialogbox.Text = "Hello there! I'm Taoru, I'll be your nurse for the entiriety of the event, I'll heal your wounds and keep you in fighting shape";
			}
			if(dialognum == 23)
			{
				dialogbox.Text = "Now I'll be helping you as much as I can, your next opponent is the famed Hitoma, He always uses fire on his first hit, so you might be better off using water for your first attack\nHe also knows how to bend Earth and control Electricity, so be careful alright?!";
			}
			if(dialognum == 24)
			{
				nextbutton.Visibility = Visibility.Visible;
				hidebuttons();
				hide_dialog();
				rules.Visibility = Visibility.Visible;
				dialogbox.Text = "((Here are the elemental rules, please study them and then press next once you're finished))";	
			}
			if(dialognum == 25)
			{
				show_dialog();
				showbuttons();
				nextbutton.Visibility = Visibility.Hidden;
				dialogbox.Text = "You can use health potions to restore your health\nYou can also use vision stones to see your opponent's future attacks\nNow, are you sure you're ready?";
			}
			if(dialognum == 26)
			{
				hidebuttons();
				nextbutton.Visibility = Visibility.Visible;
				rules.Visibility = Visibility.Hidden;
				dialogpic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse_happy.png"));
				dialogbox.Text = "Alright, good luck out there!!";
				skip_story.Visibility = Visibility.Hidden;
			}
			if(dialognum == 27)
			{
				hide_dialog();
				this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/coliseum.jpg",UriKind.Relative)));
				view.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/guard1.png"));
				view.Visibility = Visibility.Visible;
				dialogbox.Text = "*You walk onto the arena, the ground is stained with blood, in the distance, you see a well dressed man\nHis face unimpressed with you";
			}
			if(dialognum == 28)
			{
				show_dialog();
				view.Visibility = Visibility.Hidden;
				dialogname.Text = "Hitoma";
				dialogpic.Source =new BitmapImage (new Uri("pack://application:,,,/RPS_game;component/Pictures/p2surprised.png"));
				dialogbox.Text = "You're my opponent? HAHAHAHA\nLooks like the first round will be a breeze";
			}
			if(dialognum == 29)
			{
				nextbutton.Visibility = Visibility.Hidden;
				hide_dialog();
				checklives();
				show_elements();
				p1avatar.Visibility = Visibility.Visible;
				enemypic.Visibility = Visibility.Visible;
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/p2cocky.png"));
				dialogbox.Text = ((player1)DataContext).name_+" please choose an element";
				p2_choice = 1;
			}
			if(dialognum == 30)
			{
				if(p1_lives == 0)
				{
					losegame();
					return;
				}
				if(p2_lives ==0)
				{
					winmatch();
					return;
				}
				checklives();
				show_elementpic();
				p1_element.Visibility = Visibility.Visible;
				p2_element.Visibility = Visibility.Visible;
				Random num = new Random();
				p2_choice = num.Next(1,4);
				dialogbox.Text = ((player1)DataContext).name_+" please choose an element";
			}
			if(dialognum == 31)
			{
				nextbutton.Visibility = Visibility.Visible;
				dialogbox.Text = "You won!! "+dialogname.Text+" lays dead on your feet and the crowds are all cheering for you";
			}
			if(dialognum == 32)
			{
				show_dialog();
				dialogname.Text = "Taoru";
				this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/Dungeon1.png",UriKind.Relative)));
				dialogpic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse_happy.png"));
				dialogbox.Text = "*You walk back to the waiting dungeon, to be greeted by the beautiful Taoru*";
			}
			if(dialognum == 33)
			{
				dialogbox.Text = "Congratulations! "+((player1)DataContext).name_+ " I am going to heal you up!";
			}
			if(dialognum == 34)
			{
				MessageBox.Show("You have been healed back to full HP");
				p1_lives=3;
				p2_lives=3;
				dialogbox.Text = "Now, on to your next opponent\nA dark elf by the name of Elko\nBe careful of her, she can use the elements of Earth, Electricity and Water";
			}
			if(dialognum == 35)
			{
				dialogpic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse_happy1.png"));
				dialogbox.Text = "I wish you the best, adventurer, make sure you dont die!";
			}
			if(dialognum == 36)
			{
				hide_dialog();
				this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/coliseum.jpg",UriKind.Relative)));
				view.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/elko.png"));
				view.Visibility = Visibility.Visible;
				dialogbox.Text = "*You strut onto the arena, everything looks the same as yesterday\nIn the distance, you see a young girl, smiling at you*";
			}
			if(dialognum == 37)
			{
				view.Visibility = Visibility.Hidden;
				show_dialog();
				dialogpic.Visibility = Visibility.Hidden;
				p1avatar.Visibility = Visibility.Visible;
				enemypic.Visibility = Visibility.Visible;
				dialogname.Text = "Elko";
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/elko_happy.png"));
				dialogbox.Text = "Hello mister! You look ready..";
			}
			if(dialognum == 38)
			{
				dialogbox.Text = "ready to die, that is";
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/elko_indifferent.png"));
			}
			if(dialognum == 39)
			{
				Random num = new Random();
				p2_choice = num.Next(2,5);
				if(p1_lives == 0)
				{
					losegame();
					return;
				}
				if(p2_lives ==0)
				{
					winmatch();
					return;
				}
				nextbutton.Visibility = Visibility.Hidden;
				hide_dialog();
				checklives();
				show_elements();
				dialogbox.Text = ((player1)DataContext).name_+" please choose an element";
			}
			if(dialognum == 40)
			{
				nextbutton.Visibility = Visibility.Visible;
				dialogbox.Text = "Congratulations!! You have won! "+dialogname.Text+" lays down on the ground all bloodied";
			}
			if(dialognum == 41)
			{
				show_dialog();
				dialogname.Text = "Taoru";
				this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/Dungeon1.png",UriKind.Relative)));
				dialogpic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse_happy1.png"));
				dialogbox.Text = "*you limp back to the dungeon, out of breath*";
			}
			if(dialognum == 42)
			{
				dialogbox.Text = ((player1)DataContext).name_+" congratulations! I am impressed you've reached this far, you might actually have a chance\nAnyways, come rest and let me heal your wounds";
			}
			if(dialognum == 43)
			{
				MessageBox.Show("You have been healed back to full HP", "Fully healed");
				p1_lives=3;
				p2_lives=3;
				dialogbox.Text = "Now, your next opponent will be difficult, Sir Benz of Gretelwood, a nobleman, so he will have had access to tactics and such";
			}
			if(dialognum == 44)
			{
				dialogpic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse_annoyed.png"));
				dialogbox.Text = "Don't die, alright?..";
			}
			if(dialognum == 45)
			{
				hide_dialog();
				this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/coliseum.jpg",UriKind.Relative)));
				view.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/benz.png"));
				view.Visibility = Visibility.Visible;
				dialogbox.Text = "*You walk, into the arena, for the first time, feeling fear as you see your opponenet heavily clad in heavy armor*";
			}
			if(dialognum == 46)
			{
				view.Visibility = Visibility.Hidden;
				show_dialog();
				dialogpic.Visibility = Visibility.Hidden;
				p1avatar.Visibility = Visibility.Visible;
				enemypic.Visibility = Visibility.Visible;
				dialogname.Text = "Benz";
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/benz_happy.png"));
				dialogbox.Text = "Good day sir, I have been looking forward to exchange blows with you, before I finish you off though, I want you to know,";
			}
			if(dialognum == 47)
			{
				dialogbox.Text = "it's nothing personal";
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/benz_cocky.png"));
			}
			if(dialognum == 48)
			{
				
				Random num = new Random();
				p2_choice = num.Next(1,4);
				if(p1_lives == 0)
				{
					losegame();
					return;
				}
				if(p2_lives ==0)
				{
					winmatch();
					return;
				}
				nextbutton.Visibility = Visibility.Hidden;
				hide_dialog();
				checklives();
				show_elements();
				dialogbox.Text = ((player1)DataContext).name_+" please choose an element";
			}
			if(dialognum == 49)
			{
				nextbutton.Visibility = Visibility.Visible;
				dialogbox.Text = "and the crowd goes wild!! You have reached the finals! One more battle and you will win the title of strongest elementalist!";
			}
			if(dialognum == 50)
			{
				this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/Dungeon1.png",UriKind.Relative)));
				dialogbox.Text = "*You go back to the dungeon, hoping to see Taoru's amazing smile*";
			}
			if(dialognum == 51)
			{
				dialogbox.Text = "*But alas, she is nowhere to be found, you searched the surroundings, hoping to see her again\nBut to no avail*";
			}
			if(dialognum == 52)
			{
				dialogbox.Text = "*Tired and demoralized, you go to lie down on your bed, anxious not only for the battle ahead, but for Taoru as well*";
			}
			if(dialognum == 53)
			{
				MessageBox.Show("You have been healed back to full HP","Healed");
				p1_lives=3;
				p2_lives=3;
				dialogbox.Text = "You are woken up by a servant, telling you that the battle is near, so you wake up and do your morning routine*";
			}
			if(dialognum == 54)
			{
				hide_dialog();
				this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/coliseum.jpg",UriKind.Relative)));
				dialogbox.Text = "*You don your armor as you walk on that arena once again, feeling sluggish and tired*";
			}
			if(dialognum == 55)
			{
				dialogbox.Text = "*In the distance you see a figure that seems familiar, you walk closer to see*";
			}
			if(dialognum == 56)
			{
				view.Visibility = Visibility.Visible;
				view.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse.png"));
				dialogbox.Text= "*It's Taoru! She smiles as she walks toward you*";
			}
			if(dialognum == 57)
			{
				view.Visibility = Visibility.Hidden;
				show_dialog();
				dialogpic.Visibility = Visibility.Hidden;
				p1avatar.Visibility = Visibility.Visible;
				enemypic.Visibility = Visibility.Visible;
				dialogname.Text = "Taoru";
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse_happy3.png"));
				dialogbox.Text = "Hello, "+((player1)DataContext).name_+" you have come far, I congratulate you on that\nI'd appreciate it if you forgave me for all the deception";
			}
			if(dialognum == 58)
			{
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse_happy1.png"));
				dialogbox.Text = "You see, I like seeing the competition before fighting, I am the strongest after all\nI have to say, I am impressed with your skill\nIt seems that I am not the only one who can bend the 4 elements";
			}
			if(dialognum == 59)
			{
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse_happy.png"));
				dialogbox.Text = "But I have a reputation to uphold, and I do not plan on dying anytime soon";
			}
			if(dialognum == 60)
			{
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse_annoyed.png"));
				dialogbox.Text = "So I'm sorry, but your journey ends here\nIt's sad, I'm sure that in another life, we could've been friends";
			}
			if(dialognum == 61)
			{
				dialogbox.Text = "Unfortunately, this isn't one of those lives\nIt's a shame, really";
			}
			if(dialognum == 62)
			{
				Random num = new Random();
				p2_choice = num.Next(1,5);	
				if(p1_lives == 0)
				{
					losegame();
					return;
				}
				if(p2_lives ==0)
				{
					winmatch();
					return;
				}
				nextbutton.Visibility = Visibility.Hidden;
				hide_dialog();
				checklives();
				show_elements();
				dialogbox.Text = ((player1)DataContext).name_+" please choose an element";
			}
			if(dialognum == 63)
			{
				hide_elements();
				hide_elementpic();
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse_shocked.png"));
				enemypic.Visibility = Visibility.Visible;
				p1avatar.Visibility = Visibility.Visible;
				nextbutton.Visibility = Visibility.Visible;
				dialogname.Visibility = Visibility.Visible;
				dialogbox.Text = "Well, well, this is a surprise, you seem to have bested me, I applaud you";
			}
			if(dialognum == 64)
			{
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse_annoyed.png"));
				dialogbox.Text = "Well I guess there's no better time to shed this physical form than now";
			}
			if(dialognum == 65)
			{
				enemypic.Visibility = Visibility.Hidden;
				p1avatar.Visibility = Visibility.Hidden;
				view.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse.png"));
				view.Visibility = Visibility.Visible;
				dialogname.Visibility = Visibility.Hidden;
				dialogbox.Text = "*Taoru starts changing into a different creature, her hair turning into snakes and her eyes turning red*";
			}
			if(dialognum == 66)
			{
				view.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/medusa.png"));
				dialogname.Visibility = Visibility.Visible;
				dialogname.Text = "Taoru?";
				dialogbox.Text = "Ah that feels better, how about we start over, "+((player1)DataContext).name_ +"\nI look forward to not holding back";
			}
			if(dialognum == 67)
			{
				p2_lives = 3;
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/medusa_happy1.png"));
				view.Visibility = Visibility.Hidden;
				enemypic.Visibility = Visibility.Visible;
				p1avatar.Visibility = Visibility.Visible;
				dialogbox.Text ="Don't go easy, alright? I expect only the best from you, great warrior";
			}
			if(dialognum == 68)
			{
				Random num = new Random();
				p2_choice = num.Next(1,5);
				if(p1_lives == 0)
				{
					losegame();
					return;
				}
				if(p2_lives ==0)
				{
					winmatch();
					return;
				}
				nextbutton.Visibility = Visibility.Hidden;
				hide_dialog();
				checklives();
				show_elements();
				dialogbox.Text = ((player1)DataContext).name_+" please choose an element";
			}
			if(dialognum == 69)
			{
				hide_elements();
				hide_elementpic();
				enemypic.Visibility = Visibility.Visible;
				p1avatar.Visibility = Visibility.Visible;
				nextbutton.Visibility = Visibility.Visible;
				dialogname.Visibility = Visibility.Visible;
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/medusa_sad.png"));
				dialogbox.Text = "I guess this is it, the day I die\nI am just glad that I died fighting";
			}
			if(dialognum == 70)
			{
				nextbutton.Visibility = Visibility.Hidden;
				goodend_button.Visibility= Visibility.Visible;
				badend_button.Visibility= Visibility.Visible;
				dialogbox.Text = "Now finish me off, all I ask is that you kill me swiftly";
			}
			
		}
		
		
		
		void skip_story_Click(object sender, RoutedEventArgs e)
			{
				skip_story.Visibility = Visibility.Hidden;
				dialognum = 26;
				gamestart();
			}	
		
		void show_elements()
		{
			firebutton.Visibility = Visibility.Visible;
			earthbutton.Visibility = Visibility.Visible;
			thunderbutton.Visibility = Visibility.Visible;
			waterbutton.Visibility = Visibility.Visible;
			health_powerup.Visibility = Visibility.Visible;
			vision_powerup.Visibility = Visibility.Visible;
		}
		
		void hide_elements()
		{
			firebutton.Visibility = Visibility.Hidden;
			earthbutton.Visibility = Visibility.Hidden;
			thunderbutton.Visibility = Visibility.Hidden;
			waterbutton.Visibility = Visibility.Hidden;
			health_powerup.Visibility = Visibility.Hidden;
			vision_powerup.Visibility = Visibility.Hidden;
		}
		
		void nextbutton_Click(object sender, RoutedEventArgs e)
		{
			if(dialognum>69)
			{
				if(ending_choice == 1)
				{
					dialognum++;
					badend();
					return;
				}
				if(ending_choice == 2)
				{
					dialognum++;
					goodend();
					return;
				}
			}
			if(dialognum>=500)
			{
				dialognum++;
				losegame();
			}
			dialognum++;
			gamestart();
		}

		void hide_dialog()
		{
			dialogpic.Visibility = Visibility.Hidden;
			dialogname.Visibility = Visibility.Hidden;
		}
		
		void show_dialog()
		{
			dialogpic.Visibility = Visibility.Visible;
			dialogname.Visibility = Visibility.Visible;
		}
		
		void yesbutton_Click(object sender, RoutedEventArgs e)
		{
			if(dialognum == 25)
			{
				dialognum++;
				gamestart();
			}
		}
		
		void nobutton_Click(object sender, RoutedEventArgs e)
		{
			if(dialognum == 25)
			{
				dialognum--;
				gamestart();
			}
		}
		
		void showbuttons()
		{
			nobutton.Visibility = Visibility.Visible;
			yesbutton.Visibility = Visibility.Visible;
		}
		
		void hidebuttons()
		{
			nobutton.Visibility = Visibility.Hidden;
			yesbutton.Visibility = Visibility.Hidden;
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
					if(p1_lives == 1)
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
		
		void earthbutton_Click(object sender, RoutedEventArgs e)
		{
				future.Visibility = Visibility.Hidden;
				p1_choice = 2;
				checkwin();
		}
		
		void firebutton_Click(object sender, RoutedEventArgs e)
		{
				future.Visibility = Visibility.Hidden;
				p1_choice = 1;
				checkwin();
		}
		
		void thunderbutton_Click(object sender, RoutedEventArgs e)
		{
				future.Visibility = Visibility.Hidden;
				p1_choice = 3;
				checkwin();
		}
		
		void waterbutton_Click(object sender, RoutedEventArgs e)
		{
				future.Visibility = Visibility.Hidden;
				p1_choice = 4;
				checkwin();
		}
		
		void checkwin()
		{
			show_elementpic();
			if(dialognum==29)
			{
				p2_choice = 1;
				dialognum++;
			}
			if(p1_choice == 1 && p2_choice == 2 || p1_choice == 2 && p2_choice == 3 || p1_choice == 3 && p2_choice == 4 || p1_choice == 4 && p2_choice == 1)
			{
				p2_lives--;
				MessageBox.Show(dialogname.Text+" got damaged!!");
				checklives();
				if(dialognum > 20 && dialognum < 33)
				{
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/p2surprised.png"));
				}
				if(dialognum >33 && dialognum < 43)
				{
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/elko_angry.png"));	
				}
				if(dialognum >45 && dialognum < 50)
				{
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/benz_surprised.png"));	
				}
				if(dialognum > 60 && dialognum <65)
				{
					enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse_shocked.png"));
				}
				if(dialognum > 66 && dialognum <70)
				{
					enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/medusa_shocked.png"));
				}
				gamestart();
			}
			else if(p2_choice == 1 && p1_choice == 2 || p2_choice == 2 && p1_choice == 3 || p2_choice == 3 && p1_choice == 4 || p2_choice == 4 && p1_choice == 1)
			{
				p1_lives--;
				MessageBox.Show(dialogbox.Text = ((player1)DataContext).name_+" got damaged!!");
				checklives();
				if(dialognum > 20 && dialognum < 33)
				{
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/p2cocky.png"));
				}
				if(dialognum >33 && dialognum < 43)
				{
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/elko_happy.png"));	
				}
				if(dialognum >45 && dialognum < 50)
				{
				enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/benz_cocky.png"));	
				}
				if(dialognum > 60 && dialognum <65)
				{
					enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/nurse_happy1.png"));
				}
				if(dialognum > 66 && dialognum <70)
				{
					enemypic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/medusa_happy2.png"));
				}
				gamestart();
			}
			
			else
			{
				MessageBox.Show("You blocked each other's attacks!!");
				gamestart();
			}
		}
		
		void losegame()
		{
			hideall();
			nextbutton.Visibility = Visibility.Visible;
			if(dialognum > 500)
			{
				losses++;
				Close();
			}
			this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/Graveyard.jpg",UriKind.Relative)));
			rules.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/youdied.jpg"));
			rules.Visibility = Visibility.Visible;
			dialogbox.Text = "You have died, your existence forgotten and your body withered away\nYou had one chance, and you blew it\nClick next to go back to the main menu";
			dialognum = 500;
		}
		
		void winmatch()
		{
			wins++;
			if(dialognum > 55 && dialognum < 65)
			{
				hideall();
				dialognum++;
				gamestart();
				return;
			}
			hideall();
			this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/Winner.jpg",UriKind.Relative)));
			dialognum++;
			gamestart();
		}
		
		void hideall()
		{
			hidebuttons();
			hide_dialog();
			hide_enemy();
			hide_player();
			hide_elements();
			hide_elementpic();
		}
		
		void hide_enemy()
		{
			enemypic.Visibility = Visibility.Hidden;
			p1avatar.Visibility = Visibility.Hidden;
			p2_hp1.Visibility = Visibility.Hidden;
			p2_hp2.Visibility = Visibility.Hidden;
			p2_hp3.Visibility = Visibility.Hidden;
		}
		
		void hide_player()
		{
			p1avatar.Visibility = Visibility.Hidden;
			p1_hp1.Visibility = Visibility.Hidden;
			p1_hp2.Visibility = Visibility.Hidden;
			p1_hp3.Visibility = Visibility.Hidden;
		}
		
		void hide_elementpic()
		{
			p1_element.Visibility = Visibility.Hidden;
			p2_element.Visibility = Visibility.Hidden;
		}
		
		void show_elementpic()
		{
			p1_element.Visibility = Visibility.Visible;
			p2_element.Visibility = Visibility.Visible;
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
		
		void badend_button_Click(object sender, RoutedEventArgs e)
		{
			dialognum++;
				ending_choice = 1;
				badend();
		}
		
		void goodend_button_Click(object sender, RoutedEventArgs e)
		{
			dialognum++;
				ending_choice = 2;
				goodend();
		}
		
		void badend()
		{
				hidebuttons();
				hide_enemy();
				hide_player();
				hide_elements();
				hide_elementpic();
				goodend_button.Visibility= Visibility.Hidden;
				badend_button.Visibility= Visibility.Hidden;
				nextbutton.Visibility = Visibility.Visible;
				
				if(dialognum == 71)
				{
					this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/Winner.jpg",UriKind.Relative)));
					dialogbox.Text = "You slice her head off and it rolls on the ground, turning the sands red";
				}
				if(dialognum == 72)
				{
					dialogbox.Text = "The whole stadium applauds for you, the knights bow as the monarchs come to you";
				}
				if(dialognum == 73)
				{
					this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/throneroom1.jpg",UriKind.Relative)));
					dialogbox.Text = "and after a few days, you have been crowned as the Ruler of the kingdom";
				}
				if(dialognum == 74)
				{
					dialogbox.Text = "Your rule was strict and just\nThere was peace across the land under your rule";
				}
				if(dialognum == 75)
				{
					dialogbox.Text = "You have won!! Press next to go back to the main menu";
				}
				if(dialognum == 76)
				{
					Close();
				}
		}
		
		void goodend()
		{
			
				hidebuttons();
				hide_enemy();
				hide_player();
				hide_elements();
				hide_elementpic();
				goodend_button.Visibility= Visibility.Hidden;
				badend_button.Visibility= Visibility.Hidden;
				nextbutton.Visibility = Visibility.Visible;
				if(dialognum == 71)
				{
					this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/Winner.jpg",UriKind.Relative)));
					dialogpic.Visibility = Visibility.Visible;
					dialogpic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/medusa_shocked.png"));
					dialogbox.Text = "You're.. you're not going to kill me?";
				}	
				if(dialognum == 72)
				{
					dialogpic.Visibility = Visibility.Visible;
					dialogpic.Source = new BitmapImage(new Uri("pack://application:,,,/RPS_game;component/Pictures/medusa_happy1.png"));
					dialogbox.Text = "I thank you for your mercy\nand for that, I shall serve you for all my life, master";
				}
				if(dialognum == 73)
				{
					dialogpic.Visibility = Visibility.Hidden;
					dialogname.Visibility = Visibility.Hidden;
					this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/throneroom1.jpg",UriKind.Relative)));
					dialogbox.Text = "After a few days, you have been crowned king";
				}
				if(dialognum == 74)
				{
					this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/wedding.png",UriKind.Relative)));
					dialogbox.Text = "You and Taoru fall in love with each other and you were married a year later";
				}
				if(dialognum == 75)
				{
					dialogbox.Text = "She bore you 2 sons, years after the tournament, your life is kept busy with the duties of the king\nBut you are happy nontheless, with your wife and children";
				}
				if(dialognum == 76)
				{
					this.Background = new ImageBrush(new BitmapImage(new Uri("Pictures/throneroom2.jpg",UriKind.Relative)));
					dialogbox.Text = "Your rule was recorded as the best by historians\nJust and fair, making you loved by the people of the kingdom";
				}
				if(dialognum == 77)
				{
					dialogbox.Text = "You have won!! Press next to go back to the main menu";
				}
				if(dialognum == 78)
				{
					Close();
				}
		}
		void health_powerup_Click(object sender, RoutedEventArgs e)
		{
			if(p1_lives == 3)
			{
				MessageBox.Show("You are at full hp!");
				return;
			}
			health_potion--;
			p1_lives = 3;
			MessageBox.Show("You have used a health potion! You only have "+health_potion+" more potions left!");
			if(health_potion == 0)
			{
				MessageBox.Show("You have ran out of health potions!!");
				health_powerup.IsEnabled = false;
				return;
			}
			checklives();
		}
		void vision_powerup_Click(object sender, RoutedEventArgs e)
		{
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
			vision_stone--;
			p2_element.Visibility=Visibility.Visible;
			future.Visibility = Visibility.Visible;
			MessageBox.Show("You have used a vision stone! You only have "+vision_stone+" more vision stones left!");
			if(vision_stone == 0)
			{
				MessageBox.Show("You have ran out of vision stones!!");
				vision_powerup.IsEnabled = false;
				return;
			}
		}
	}
}