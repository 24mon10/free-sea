using SQLite4Unity3d;

public class Items
{

	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string name { get; set; }
	//�A�C�e���̐���
	public string desc { get; set; }
	//�A�C�e���̎��
	public string category { get; set; }
	//���ʗ�
	public int value { get; set; }
	//�g�p��
	public int numberOfUse { get; set; }
	//�U���͂ւ̕␳�l
	public int strength { get; set; }
	//�h��͂ւ̕␳�l
	public int guard { get; set; }
	//�f�����ւ̕␳�l
	public int speed { get; set; }
	//�l�i
	public int price { get; set; }

	public override string ToString()
	{
		return string.Format("[Items: Id={0}, Name={1}, Desc={2}, Category={3}," +
			"Value={4}, NumberOfUse={5}, Strength={6}, Guard={7}, Speed={8}, Price={9}]",
			id, name, desc, category, value,numberOfUse,strength,guard,speed,price);
	}
}

