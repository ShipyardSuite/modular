using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class DialogSentence
{
	public GameCharacter speaker;

	[TextArea(3, 10)]
	public string sentence;

	public DialogSentence(GameCharacter speaker, string sentence)
	{
		this.speaker = speaker;
		this.sentence = sentence;
	}
}