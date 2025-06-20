using SQLite4Unity3d;
using UnityEngine;
using System.Linq;

#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService{

	private SQLiteConnection _connection;

	public DataService(string DatabaseName){

#if UNITY_EDITOR
            var dbPath = string.Format(@"Assets/Database/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
            _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);     

	}

	public void CreateItemDB(){
		_connection.DropTable<Items>();
		_connection.CreateTable<Items>();

		_connection.InsertAll(new[]{
			new Items{
				id = 1,
				name = "薬草",
				desc = "HPを回復できる草",
				category = "Consumable Item",
				value = 20,
				numberOfUse = 1,
				strength = 0,
				guard = 0,
				speed = 0,
				price = 5,
			},
		});
	}

	public void CreateMagicDB()
	{
		_connection.DropTable<Magic>();
		_connection.CreateTable<Magic>();

		_connection.InsertAll(new[]{
			new Magic{
				id = 1,
				name = "ヒール",
				desc = "HPを回復する魔法",
				cost = 3,
				category = "Recover",
				target = "Own",
				value = 30
			},
		});
	}

	public void CreatePlayerDB()
	{
		_connection.DropTable<PlayerData>();
		_connection.CreateTable<PlayerData>();

		_connection.InsertAll(new[] {
			new PlayerData {
				level = 1,
				n_exp = 10,
				hp = 15,
				mp = 3,
				strength = 5,
				guard = 3,
				speed = 7
			},
			new PlayerData {
				level = 2,
				n_exp = 25,
				hp = 20,
				mp = 6,
				strength = 8,
				guard = 6,
				speed = 10
			},
			new PlayerData {
				level = 3,
				n_exp = 45,
				hp = 25,
				mp = 9,
				strength = 11,
				guard = 9,
				speed = 13
			},
			new PlayerData {
				level = 4,
				n_exp = 70,
				hp = 30,
				mp = 12,
				strength = 14,
				guard = 12,
				speed = 16
			},
			new PlayerData {
				level = 5,
				n_exp = 0,
				hp = 35,
				mp = 15,
				strength = 17,
				guard = 15,
				speed = 19
			},
		});
	}

	public void CreateEnemiesDB() 
	{
		_connection.DropTable<Enemies>();
		_connection.CreateTable<Enemies>();

		_connection.InsertAll(new[] {
			new Enemies
			{
				id = 1,
				name = "スライム",
				hp = 10,
				mp = 0,
				strength = 4,
				guard = 2,
				speed = 6,
				expg = 4,
				gold = 10,
			},
			new Enemies
			{
				id = 2,
				name = "インセクト",
				hp = 7,
				mp = 6,
				strength = 3,
				guard = 4,
				speed = 10,
				expg = 7,
				gold = 13,
			},
			new Enemies 
			{
				id = 3,
				name = "怪物サボテン",
				hp = 15,
				mp = 0,
				strength = 8,
				guard = 4,
				speed = 3,
				expg = 10,
				gold = 15,
			},
			
		});
	}
	public IEnumerable<Items> GetItems(){
		return _connection.Table<Items>();
	}
	public IEnumerable<Magic> GetMagic()
	{
		return _connection.Table<Magic>();
	}
	//プレイヤーデータの全ての要素を指す
	public List<PlayerData> GetAllPlayerData()
	{
		return _connection.Table<PlayerData>().ToList();
	}
	//プレイヤーの決められた要素のみを指す
	public PlayerData GetPlayerData(int lv)
	{
		return _connection.Table<PlayerData>().Where(pd => pd.level == lv).ElementAt(0);
	}

	public Enemies GetEnemiesData(int en)
	{
		return _connection.Table<Enemies>().Where(ed => ed.id == en).ElementAt(0);
	}
}
