using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	public Queue<DialogSentence> sentences;

	public Text nameText;
	public Text dialogText;
	public Image characterSpot;

	private Dialog currentDialog;

	public GameObject dialogBox;

	void Awake()
	{
		sentences = new Queue<DialogSentence>();
	}

	public void StartDialog(Dialog dialog)
	{

		currentDialog = dialog;

		dialogBox.SetActive(true);

		sentences.Clear();

		foreach (DialogSentence sentence in dialog.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialog();
			return;
		}

		DialogSentence sentence = sentences.Dequeue();

		if (sentence.speaker.characterImage)
		{
			characterSpot.gameObject.SetActive(true);
			characterSpot.sprite = sentence.speaker.characterImage;
		}
		else
		{
			characterSpot.gameObject.SetActive(false);
		}


		nameText.text = sentence.speaker.characterName;

		StartCoroutine(TypeSentence(sentence.sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogText.text = "";

		foreach (char letter in sentence.ToCharArray())
		{
			dialogText.text += letter;
			yield return new WaitForSeconds(0.05f);
		}
	}

	public void EndDialog()
	{
		Debug.Log("End of conversation.");
		dialogBox.SetActive(false);

		currentDialog.DialogCallback();
	}
}