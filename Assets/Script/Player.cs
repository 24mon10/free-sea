using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	public enum State
	{
		Normal,
		Talk,
		Menu,
		Battle,
	}

	[Header("移動の速さ"), SerializeField]
	private float _speed = 3;

	[Header("ジャンプする瞬間の速さ"), SerializeField]
	private float _jumpSpeed = 7;

	[Header("重力加速度"), SerializeField]
	private float _gravity = 15;

	[Header("落下時の速さ制限（Infinityで無制限）"), SerializeField]
	private float _fallSpeed = 10;

	[Header("落下の初速"), SerializeField]
	private float _initFallSpeed = 2;

	[Header("カメラ"), SerializeField]
	private Camera m_targetCamera;

	[SerializeField] GameObject player;
	[SerializeField] GameObject menu;
	[SerializeField] EventSystem eventsystem;

	private Transform _transform;
	private CharacterController _characterController;

	public Vector2 _inputMove;
	private float _verticalVelocity;
	private float _turnVelocity;
	private bool _isGroundedPrev;

	[SerializeField] StateDrow stateDrow;

	[SerializeField] int level;
	[SerializeField] int n_exp;
	[SerializeField] int hp;
	[SerializeField] int mp;
	[SerializeField] int strength;
	[SerializeField] int guard;
	[SerializeField] int speed;
	private int h_Exp = 0;
	public int pLevel = 1;
	public int g_Exp;
	

	//プレイヤーの状態
	private State state;

	//プレイヤーの会話処理スクリプト
	private PlayerTalkScript playerTalkScript;

	Animator animator; // アニメーション

	//Decition decision = new Decition();

	bool decision;

	public bool Decision
	{
		get { return decision; }
		set { decision = value; }
	}



	private void Start()
	{
		state = State.Normal;
		playerTalkScript = GetComponent<PlayerTalkScript>();
		this.animator = player.GetComponent<Animator>();
		DataService ds = new DataService("RPG.db");
		PlayerData playerData = ds.GetPlayerData(pLevel);
		level = playerData.level;
		n_exp = playerData.n_exp;
		hp = playerData.hp;
		mp = playerData.mp;
		strength = playerData.strength;
		guard = playerData.guard;
		speed = playerData.speed;

		g_Exp = playerData.n_exp;
	}
	public void OnMove(InputAction.CallbackContext context)
	{
		if (state == State.Normal)
		{
			// 入力値を保持しておく
			_inputMove = context.ReadValue<Vector2>();
			animator.SetBool("Move", true);
		}
		
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		// Performedフェーズの判定を行う
		if (context.phase == InputActionPhase.Performed && state == State.Normal)
		{
			// ボタンが押された瞬間かつ着地している時だけ処理
			if (!context.performed || !_characterController.isGrounded) return;
			animator.SetTrigger("Jump");

			// 鉛直上向きに速度を与える
			_verticalVelocity = _jumpSpeed;
		}
	}
	public void OnDecision(InputAction.CallbackContext context)
	{
		// performedコールバックだけ受け取る
		if (context.performed)
		{
			decision = true;
			Debug.Log(decision);
			
		}
	}

	public void Release(InputAction.CallbackContext context)
	{
		// performedコールバックだけ受け取る
		if (context.performed)
		{
			decision = false;
			Debug.Log(decision);

		}
	}

	//メニュー画面
	public void OnMenu(InputAction.CallbackContext context)
	{
		if(context.performed && state == State.Normal)
		{
			menu.SetActive(true);
			Time.timeScale = 0;
			SetState(State.Menu);
		}
	}
	public void OnCancel(InputAction.CallbackContext context)
	{
		if(menu.activeSelf)
		{
			if(context.performed)
			{
				menu.SetActive(false);
				Time.timeScale = 1.0f;
				SetState(State.Normal);
			}
		}
	}
	private void Awake()
	{
		_transform = transform;
		_characterController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		if (m_targetCamera == null)
		{
			m_targetCamera = Camera.main;
		}

	}


	private void FixedUpdate()
	{
		Debug.Log(state);
		if(state == State.Normal)
		{
			var isGrounded = _characterController.isGrounded;

			if (isGrounded && !_isGroundedPrev)
			{
				// 着地する瞬間に落下の初速を指定しておく
				_verticalVelocity = -_initFallSpeed;
			}
			else if (!isGrounded)
			{
				// 空中にいるときは、下向きに重力加速度を与えて落下させる
				_verticalVelocity -= _gravity * Time.deltaTime;

				// 落下する速さ以上にならないように補正
				if (_verticalVelocity < -_fallSpeed)
					_verticalVelocity = -_fallSpeed;
			}

			_isGroundedPrev = isGrounded;

			// カメラの向き(角度[deg])取得
			var cameraAngleY = m_targetCamera.transform.eulerAngles.y;


			// 操作入力と鉛直方向速度から、現在速度を計算
			var moveVelocity = new Vector3(
				_inputMove.x * _speed,
				_verticalVelocity,
				_inputMove.y * _speed
			);

			// カメラの角度分だけ移動量を回転
			moveVelocity = Quaternion.Euler(0, cameraAngleY, 0) * moveVelocity;

			// 現在フレームの移動量を移動速度から計算
			var moveDelta = moveVelocity * Time.deltaTime;

			// CharacterControllerに移動量を指定し、オブジェクトを動かす
			_characterController.Move(moveDelta);

			if (_inputMove != Vector2.zero)
			{
				//animator.SetBool("Move", true);
				// 移動入力がある場合は、振り向き動作も行う
				/*
				// 操作入力からy軸周りの目標角度[deg]を計算
				var targetAngleY = -Mathf.Atan2(moveVelocity.z, moveVelocity.x)
					* Mathf.Rad2Deg + 90;

				// イージングしながら次の回転角度[deg]を計算
				var angleY = Mathf.SmoothDampAngle(
					_transform.eulerAngles.y,
					targetAngleY,
					ref _turnVelocity,
					0.1f
				);

				// オブジェクトの回転を更新
				_transform.rotation = Quaternion.Euler(0, angleY, 0);
				*/

				_transform.rotation = Quaternion.Lerp(
					_transform.rotation,
					Quaternion.LookRotation(Vector3.Scale(moveVelocity, new Vector3(1, 0, 1))),
					0.1f);

				
			}
			else
			{
				animator.SetBool("Move", false);
			}
		if (playerTalkScript.GetConversationPartner() != null
				&& decision == true)
		{
			Debug.Log("ここに入った");
			SetState(State.Talk);
		}
		}
		else if(state == State.Talk)
		{
			animator.SetBool("Move", false);
		}

		if (Input.GetKeyDown(KeyCode.T))
		{
			if (pLevel == 5) return;
			h_Exp = 5;
			g_Exp -= h_Exp;
			stateDrow.ExpDraw();
			if (g_Exp == 0)
			{
				pLevel++;
				DataService ds = new DataService("RPG.db");
				PlayerData playerData = ds.GetPlayerData(pLevel);
				level = playerData.level;
				n_exp = playerData.n_exp;
				hp = playerData.hp;
				mp = playerData.mp;
				strength = playerData.strength;
				guard = playerData.guard;
				speed = playerData.speed;

				g_Exp = playerData.n_exp;
				h_Exp = 0;
				stateDrow.NextLevelDraw();
			}
			
		}
	}


	//State変更と初期設定
	public void SetState(State state)
	{
		this.state = state;

		if (state == State.Talk)
		{
			var isGrounded = _characterController.isGrounded;
			animator.SetBool("Move", false);
			playerTalkScript.StartTalking();
			decision = false;
		}
	}

	public State GetState()
	{
		return state;
	}

	//public void GetExp()
	//{
	//	if (Input.GetKeyDown(KeyCode.F2))
	//	{
	//		h_Exp += 1;
	//		n_exp -= h_Exp;
	//		if (n_exp == 0)
	//		{
	//			DataService ds = new DataService("RPG.db");
	//			PlayerData playerData = ds.GetPlayerData(2);
	//			level = playerData.level;
	//			n_exp = playerData.n_exp;
	//			hp = playerData.hp;
	//			mp = playerData.mp;
	//			strength = playerData.strength;
	//			guard = playerData.guard;
	//			speed = playerData.speed;
	//		}
	//	}
	//}
}
