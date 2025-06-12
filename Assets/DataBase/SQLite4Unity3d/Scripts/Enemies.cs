using SQLite4Unity3d;
using UnityEngine;

public class Enemies
{
	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string name { get; set; }
	public int hp { get; set; }
	public int strength { get; set; }
	public int guard { get; set; }
	public int speed { get; set; }
	public int expg { get; set; }
	public int gold { get; set; }

	public override string ToString()
	{
		return string.Format("[Items: Id={0}, Name={1}, Hp={2}, Strength={3}," +
			" Guard={4}, Speed={5}, Expg={6},gold[7] ]",
			id, name, hp, strength, guard, speed, expg, gold);
	}
}
