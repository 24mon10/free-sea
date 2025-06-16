using SQLite4Unity3d;
using System.Linq;
using UnityEngine;

public class PlayerData
{
	[PrimaryKey, AutoIncrement]
	//�v���C���[�̃��x��
	public int level { get; set; }
	//�K�v�Ȍo���l
	public int n_exp { get; set; }
	public int hp { get; set; }
	public int mp { get; set; }
	public int strength { get; set;}
	public int guard { get; set; }
	public int speed { get; set; }

	public override string ToString()
	{
		return string.Format("[Magic: Level={0}, N_Exp={1},  Hp={2}, mp={3}, Strength={4}," +
		"Guard={5},Speed={6}]",
			level,n_exp,hp,mp,strength,guard,speed);
	}
}
