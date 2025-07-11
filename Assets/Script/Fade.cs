using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour 
{
	[SerializeField] private Image m_image;
	private IEnumerator FadeAlphaValue(
	float duration,
	Action on_completed,
	bool is_reversing = false
	)
	{
		if (!is_reversing) m_image.enabled = true;

		var elapsed_time = 0.0f;
		var color = m_image.color;

		while (elapsed_time < duration)
		{
			var elapsed_rate = Mathf.Min(elapsed_time / duration, 1.0f);
			color.a = is_reversing ? 1.0f - elapsed_rate : elapsed_rate;
			m_image.color = color;

			yield return null;
			elapsed_time += Time.deltaTime;
		}

		if (is_reversing) m_image.enabled = false;
		if (on_completed != null) on_completed();
	}

	private void Reset()
	{
		m_image = GetComponent<Image>();
	}

	public void FadeIn(float duration, Action on_completed = null)
	{
		StartCoroutine(FadeAlphaValue(duration, on_completed, true));
	}

	public void FadeOut(float duration, Action on_completed = null)
	{
		StartCoroutine(FadeAlphaValue(duration, on_completed));
	}
}
