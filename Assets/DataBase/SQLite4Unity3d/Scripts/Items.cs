using SQLite4Unity3d;

public class Items
{

	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string name { get; set; }
	//アイテムの説明
	public string desc { get; set; }
	//アイテムの種類
	public string category { get; set; }
	//効果量
	public int value { get; set; }
	//使用回数
	public int numberOfUse { get; set; }
	//攻撃力への補正値
	public int strength { get; set; }
	//防御力への補正値
	public int guard { get; set; }
	//素早さへの補正値
	public int speed { get; set; }
	//値段
	public int price { get; set; }

	public override string ToString()
	{
		return string.Format("[Items: Id={0}, Name={1}, Desc={2}, Category={3}," +
			"Value={4}, NumberOfUse={5}, Strength={6}, Guard={7}, Speed={8}, Price={9}]",
			id, name, desc, category, value,numberOfUse,strength,guard,speed,price);
	}
}

