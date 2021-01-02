using System;
using UnityEngine;

[RequireComponent(typeof(Sprite))]
[Serializable]
public class LocalizationEntry : IComparable<LocalizationEntry>
{
	public LocalizationEntry(string locale, string sprite)
	{
		this.locale = locale;
		this.sprite = sprite;
	}

	public int CompareTo(LocalizationEntry other)
	{
		return this.locale.CompareTo(other.locale);
	}

	public string locale;

	public string sprite;
}
