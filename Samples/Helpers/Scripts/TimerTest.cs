using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Shipyard.Modular.Helper;
using Shipyard.Modular.Internationalization;

public class TimerTest : MonoBehaviour
{
	private Timer gameTimer;

	public i18n converter;
	public Languages language;
	public Text gameTimeText;
	public Text resumeButtonText;
	public Text pauseButtonText;

	// Start is called before the first frame update
	void Start()
	{
		converter = new i18n(language, "helpers");
		gameTimer = new Timer();
	}

	// Update is called once per frame
	void Update()
	{
		converter.language = language;

		gameTimeText.text = converter.GetMessage("test.helpers.timer.gameTimeText", converter.secondsToTime(gameTimer.elapsed));
		resumeButtonText.text = converter.GetMessage("test.helpers.timer.resumeTimeButton");
		pauseButtonText.text = converter.GetMessage("test.helpers.timer.pauseTimeButton");
	}

	public void PauseTime()
	{
		gameTimer.Stop();
	}
	public void ResumeTime()
	{
		gameTimer.Resume();
	}
}
