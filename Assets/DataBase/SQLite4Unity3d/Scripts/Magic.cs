using SQLite4Unity3d;


public class Magic
{
	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string name {  get; set; }
	//説明
	public string desc { get; set; }
	//コスト
	public int cost { get; set; }
	//カテゴリー
	public string category { get; set; }
	//標的
	public string target { get; set; }
	//効果量
	public int value { get; set; }

	public override string ToString()
	{
		return string.Format("[Magic: Id={0}, Name={1},  Desc={2}, Cost={3}," +
			"Category={4},Target={5},value={6}]",
			id, name, desc, cost, category, target, value);
	}
}

