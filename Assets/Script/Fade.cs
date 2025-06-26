using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour 
{
	[SerializeField] private Image m_image;
	public float fadeDuration = 1.0f;
	public void CallCoroutine()
	{
		StartCoroutine(StartFadeOut());
	}

	private IEnumerator StartFadeOut()
	{
		m_image.enabled = true;
		float elapsedTime = 0.0f;
		Color StartColor = m_image.color;
		Color endColor = new Color(StartColor.r, StartColor.g, StartColor.b, 1.0f);

		while (elapsedTime < fadeDuration)
		{
			elapsedTime += Time.deltaTime;
			float t = Mathf.Clamp01(elapsedTime / fadeDuration);
			m_image.color = Color.Lerp(StartColor, endColor, t);
			yield return null;
		}

		m_image.color = endColor;
	}
	
}
