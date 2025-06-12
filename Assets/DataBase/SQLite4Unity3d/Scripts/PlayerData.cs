using SQLite4Unity3d;
using System.Xml.Linq;
using UnityEngine;

public class PlayerData
{
	[PrimaryKey, AutoIncrement]
	//プレイヤーのレベル
	public int level { get; set; }
	//必要な経験値
	public int n_exp { get; set; }
	public int hp { get; set; }
	public int strength { get; set;}
	public int guard { get; set; }
	public int speed { get; set; }

	public override string ToString()
	{
		return string.Format("[Magic: Level={0}, N_Exp={1},  Hp={2}, Strength={3}," +
		"Guard={4},Speed={5}]",
			level,n_exp,hp,strength,guard,speed);
	}
}
