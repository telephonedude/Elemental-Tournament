/*
 * Created by SharpDevelop.
 * User: telephonedude
 * Date: 08/15/2018
 * Time: 23:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace RPS_game
{
	/// <summary>
	/// Description of player.
	/// </summary>
	
	public class DataStorage
	{
		static DataStorage _dataStorage;
		public static DataStorage Current
		{
			get
			{
				if (_dataStorage == null)
				{
					_dataStorage = new DataStorage();
				}
				return _dataStorage;
			}
		}
		
		public DataStorage()
		{
			users = new List<player1>();
		}
		    
		public List<player1> users;		
	}
	
	public class player1
	{
			public string name_{get; set;}
			public int single_mode_{get; set;}
			public int multi_mode_{get; set;}
			public int highest_score_{get; set;}
			public int number_of_wins_{get; set;}
			public int number_of_losses_{get; set;}
			public int games_played_{get; set;}
			public player1()
			{
				name_ ="";
				single_mode_ = 0;
				multi_mode_ = 0;
				highest_score_ =0;
				number_of_losses_ =0;
				number_of_wins_ =0;
				games_played_ =0;
			}
			public player1 Copy()
		{
				return new player1() {name_=name_ , multi_mode_=multi_mode_ , single_mode_ = single_mode_ , highest_score_ = highest_score_ , number_of_losses_ = number_of_losses_ , number_of_wins_ = number_of_wins_ ,games_played_ = games_played_};
		}
			
	}
	
}

