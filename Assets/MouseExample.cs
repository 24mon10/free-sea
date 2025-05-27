using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// ���݂̃}�E�X���
		var current = Mouse.current;

		// �}�E�X�ڑ��`�F�b�N
		if (current == null)
		{
			// �}�E�X���ڑ�����Ă��Ȃ���
			// Mouse.current��null�ɂȂ�
			return;
		}

		// �}�E�X�J�[�\���ʒu�擾
		var cursorPosition = current.position.ReadValue();

		// ���{�^���̓��͏�Ԏ擾
		var leftButton = current.leftButton;

		// ���{�^���������ꂽ�u�Ԃ��ǂ���
		if (leftButton.wasPressedThisFrame)
		{
			Debug.Log($"���{�^���������ꂽ�I {cursorPosition}");
		}

		// ���{�^���������ꂽ�u�Ԃ��ǂ���
		if (leftButton.wasReleasedThisFrame)
		{
			Debug.Log($"���{�^���������ꂽ�I{cursorPosition}");
		}

		// ���{�^����������Ă��邩�ǂ���
		if (leftButton.isPressed)
		{
			Debug.Log($"���{�^����������Ă���I{cursorPosition}");
		}
	}
}
