using SQLite4Unity3d;
using UnityEngine;

public class Enemies
{
	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string name { get; set; }
	public int hp { get; set; }
	public int mp { get; set; }
	public int strength { get; set; }
	public int guard { get; set; }
	public int speed { get; set; }
	public int expg { get; set; }
	public int gold { get; set; }
	

	public override string ToString()
	{
		return string.Format("[Items: Id={0}, Name={1}, Hp={2}, Mp={3},Strength={4}," +
			" Guard={5}, Speed={6}, Expg={7},gold[8]]",
			id, name, hp, mp, strength, guard, speed, expg, gold);
	}
}
