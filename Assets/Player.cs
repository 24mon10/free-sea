using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
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

	private Transform _transform;
	private CharacterController _characterController;

	private Vector2 _inputMove;
	private float _verticalVelocity;
	private float _turnVelocity;
	private bool _isGroundedPrev;

	Animator animator; // �A�j���[�V����
	public void OnMove(InputAction.CallbackContext context)
	{
		// ���͒l��ێ����Ă���
		_inputMove = context.ReadValue<Vector2>();
		animator.SetBool("Move", true);
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		// Performed�t�F�[�Y�̔�����s��
		if (context.phase == InputActionPhase.Performed)
		{
			// �{�^���������ꂽ�u�Ԃ����n���Ă��鎞��������
			if (!context.performed || !_characterController.isGrounded) return;
			animator.SetTrigger("Jump");

			// ����������ɑ��x��^����
			_verticalVelocity = _jumpSpeed;
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


	private void Update()
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
			animator.SetBool("Move", true);
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
	}


	private void Landing()
	{
		
	}
}
