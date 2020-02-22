using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

using Shipyard.Modular.QuestModule;
using Shipyard.Modular.Inventory;

namespace Shipyard.Modular.Test
{
	public class QuestModuleTester : MonoBehaviour
	{
		public Quest currentQuest;
		public GameObject questPanel;
		public GameObject questViewPrefab;

		public Item testItem;

		public List<QuestView> questViews = new List<QuestView>();

		public Button collectCreditsButton;
		public Button collectItemButton;
		public Button finishCompletedQuestsButton;

		private void Awake()
		{
			QuestManager.Instance.SetCurrentQuest("testQuest1");
		}

		private void Update()
		{
			collectCreditsButton.interactable = currentQuest;
			collectItemButton.interactable = currentQuest;
			finishCompletedQuestsButton.interactable = currentQuest && currentQuest.questStatus == QuestStatus.COMPLETED;


		}

		public void PupulateTestPanel()
		{
			if (currentQuest)
			{
				if (currentQuest.questStatus == QuestStatus.ACCEPTED)
				{
					GameObject questView = Instantiate(questViewPrefab, questPanel.transform);
					questView.GetComponent<QuestView>().PopulateQuestView(currentQuest.id, currentQuest.title, currentQuest.summary, currentQuest.objectives);

					questViews.Add(questView.GetComponent<QuestView>());
				}
			}
		}

		public void CallNewQuest()
		{
			QuestManager.Instance.AcceptCurrentQuest();
			currentQuest = QuestManager.Instance.GetCurrentQuest();

			PupulateTestPanel();
		}

		public void collectCredits()
		{
			QuestManager.Instance.UpdateObjective("earn", 20);

			foreach (QuestView questView in questViews)
			{
				if (currentQuest.id == questView.questId)
				{
					questView.UpdateQuestObjectives(currentQuest.objectives);
				}
			}
		}

		public void collectItem()
		{
			QuestManager.Instance.UpdateObjective("collect", testItem);

			foreach (QuestView questView in questViews)
			{
				if (currentQuest.id == questView.questId)
				{
					questView.UpdateQuestObjectives(currentQuest.objectives);
				}
			}
		}

		public void FinishCompletedQuest()
		{
			QuestManager.Instance.FinishCurrentQuest();

			foreach (QuestView questView in questViews)
			{
				if (currentQuest.id == questView.questId)
				{

					GameObject.Destroy(questView.gameObject);
				}
			}
		}
	}
}