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

	[Header("�ړ��̑���"), SerializeField]
	private float _speed = 3;

	[Header("�W�����v����u�Ԃ̑���"), SerializeField]
	private float _jumpSpeed = 7;

	[Header("�d�͉����x"), SerializeField]
	private float _gravity = 15;

	[Header("�������̑��������iInfinity�Ŗ������j"), SerializeField]
	private float _fallSpeed = 10;

	[Header("�����̏���"), SerializeField]
	private float _initFallSpeed = 2;

	[Header("�J����"), SerializeField]
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
	

	//�v���C���[�̏��
	private State state;

	//�v���C���[�̉�b�����X�N���v�g
	private PlayerTalkScript playerTalkScript;

	Animator animator; // �A�j���[�V����

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
			// ���͒l��ێ����Ă���
			_inputMove = context.ReadValue<Vector2>();
			animator.SetBool("Move", true);
		}
		
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		// Performed�t�F�[�Y�̔�����s��
		if (context.phase == InputActionPhase.Performed && state == State.Normal)
		{
			// �{�^���������ꂽ�u�Ԃ����n���Ă��鎞��������
			if (!context.performed || !_characterController.isGrounded) return;
			animator.SetTrigger("Jump");

			// ����������ɑ��x��^����
			_verticalVelocity = _jumpSpeed;
		}
	}
	public void OnDecision(InputAction.CallbackContext context)
	{
		// performed�R�[���o�b�N�����󂯎��
		if (context.performed)
		{
			decision = true;
			Debug.Log(decision);
			
		}
	}

	public void Release(InputAction.CallbackContext context)
	{
		// performed�R�[���o�b�N�����󂯎��
		if (context.performed)
		{
			decision = false;
			Debug.Log(decision);

		}
	}

	//���j���[���
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
				// ���n����u�Ԃɗ����̏������w�肵�Ă���
				_verticalVelocity = -_initFallSpeed;
			}
			else if (!isGrounded)
			{
				// �󒆂ɂ���Ƃ��́A�������ɏd�͉����x��^���ė���������
				_verticalVelocity -= _gravity * Time.deltaTime;

				// �������鑬���ȏ�ɂȂ�Ȃ��悤�ɕ␳
				if (_verticalVelocity < -_fallSpeed)
					_verticalVelocity = -_fallSpeed;
			}

			_isGroundedPrev = isGrounded;

			// �J�����̌���(�p�x[deg])�擾
			var cameraAngleY = m_targetCamera.transform.eulerAngles.y;


			// ������͂Ɖ����������x����A���ݑ��x���v�Z
			var moveVelocity = new Vector3(
				_inputMove.x * _speed,
				_verticalVelocity,
				_inputMove.y * _speed
			);

			// �J�����̊p�x�������ړ��ʂ���]
			moveVelocity = Quaternion.Euler(0, cameraAngleY, 0) * moveVelocity;

			// ���݃t���[���̈ړ��ʂ��ړ����x����v�Z
			var moveDelta = moveVelocity * Time.deltaTime;

			// CharacterController�Ɉړ��ʂ��w�肵�A�I�u�W�F�N�g�𓮂���
			_characterController.Move(moveDelta);

			if (_inputMove != Vector2.zero)
			{
				//animator.SetBool("Move", true);
				// �ړ����͂�����ꍇ�́A�U�����������s��
				/*
				// ������͂���y������̖ڕW�p�x[deg]���v�Z
				var targetAngleY = -Mathf.Atan2(moveVelocity.z, moveVelocity.x)
					* Mathf.Rad2Deg + 90;

				// �C�[�W���O���Ȃ��玟�̉�]�p�x[deg]���v�Z
				var angleY = Mathf.SmoothDampAngle(
					_transform.eulerAngles.y,
					targetAngleY,
					ref _turnVelocity,
					0.1f
				);

				// �I�u�W�F�N�g�̉�]���X�V
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
			Debug.Log("�����ɓ�����");
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


	//State�ύX�Ə����ݒ�
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
