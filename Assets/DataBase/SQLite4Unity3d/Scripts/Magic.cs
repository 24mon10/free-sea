using SQLite4Unity3d;


public class Magic
{
	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string name {  get; set; }
	//����
	public string desc { get; set; }
	//�R�X�g
	public int cost { get; set; }
	//�J�e�S���[
	public string category { get; set; }
	//�W�I
	public string target { get; set; }
	//���ʗ�
	public int value { get; set; }

	public override string ToString()
	{
		return string.Format("[Magic: Id={0}, Name={1},  Desc={2}, Cost={3}," +
			"Category={4},Target={5},value={6}]",
			id, name, desc, cost, category, target, value);
	}
}

