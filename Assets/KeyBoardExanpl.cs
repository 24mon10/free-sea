using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyBoardExanpl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// 現在のキーボード情報
		var current = Keyboard.current;

		// キーボード接続チェック
		if (current == null)
		{
			// キーボードが接続されていないと
			// Keyboard.currentがnullになる
			return;
		}

		// Aキーの入力状態取得
		var aKey = current.aKey;

		// Aキーが押された瞬間かどうか
		if (aKey.wasPressedThisFrame)
		{
			Debug.Log("Aキーが押された！");
		}

		// Aキーが離された瞬間かどうか
		if (aKey.wasReleasedThisFrame)
		{
			Debug.Log("Aキーが離された！");
		}

		// Aキーが押されているかどうか
		if (aKey.isPressed)
		{
			Debug.Log("Aキーが押されている！");
		}
	}
}
