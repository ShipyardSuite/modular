using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using Shipyard.Modular.Base;
using Shipyard.Modular.Helper;
using Shipyard.Modular.FSM;
using Shipyard.Modular.FSM.State;
using Shipyard.Modular.Inventory;

namespace Shipyard.Modular.QuestModule
{
	public class QuestManager : SingletonPersistent<QuestManager>
	{
		private Quest[] questList;

		public Quest currentQuest;
		public List<Quest> quests = new List<Quest>();

		private void Awake()
		{
			questList = (Quest[])Resources.FindObjectsOfTypeAll(typeof(Quest));

			foreach (Quest quest in questList)
			{
				quests.Add(Quest.CreateInstance(quest));
			}
		}

		private void Update()
		{
			if (currentQuest)
			{

				if (currentQuest.GetIfAllObjectivesFinished)
				{
					CompleteCurrentQuest();
				}

				foreach (QuestObjective objective in currentQuest.objectives)
				{
					if (objective.amountEarnFulfilled >= objective.amountEarnRequested)
					{
						objective.amountEarnFulfilled = objective.amountEarnRequested;
						objective.isFinished = true;
					}
					else if (objective.amountCollectFulfilled >= objective.amountCollectRequested)
					{
						objective.amountCollectFulfilled = objective.amountCollectRequested;
						objective.isFinished = true;
					}
				}

				currentQuest.UpdateObjectivesState();
			}
		}

		/*
			Sets the state of the current quest to accepted
			- Means that it is not active, and all its objectives need to be fulfilled to change its state again.
		*/
		public void AcceptCurrentQuest()
		{
			if (currentQuest)
			{
				currentQuest.questStatus = QuestStatus.ACCEPTED;
			}
		}

		/*
			Set the state of the current quest to completed
			- Means that all its objectives have been fulfilled.
		*/
		public void CompleteCurrentQuest()
		{
			if (currentQuest)
			{
				currentQuest.questStatus = QuestStatus.COMPLETED;
			}
		}

		/*
			Set the state of the current quest to finished/done
			- Means that all its objectives have been fulfilled and it has also been set to finished.
		*/
		public void FinishCurrentQuest()
		{
			currentQuest.questStatus = QuestStatus.DONE;

			if (currentQuest.nextQuest)
			{
				SetCurrentQuest(currentQuest.nextQuest.id);
			}
			else
			{
				currentQuest = null;
			}
		}

		/*
			Update the current quests objective state(Type: Earn)
		*/
		public void UpdateObjective(string id, int amount)
		{
			foreach (QuestObjective objective in currentQuest.objectives)
			{
				if (objective.id == id)
				{
					if (objective.amountEarnFulfilled < objective.amountEarnRequested)
					{
						objective.amountEarnFulfilled += amount;
					}
				}
			}

			if (currentQuest)
			{
				currentQuest.UpdateObjectivesState();
			}
		}

		/*
			Update the current quests objective state(Type: Collect)
		*/
		public void UpdateObjective(string id, Item item)
		{
			foreach (QuestObjective objective in currentQuest.objectives)
			{
				if (objective.id == id && objective.item == item)
				{
					Debug.Log(id + " -> " + item);
					if (objective.amountCollectFulfilled < objective.amountCollectRequested)
					{
						objective.amountCollectFulfilled++;
					}
				}
			}

			if (currentQuest)
			{
				currentQuest.UpdateObjectivesState();
			}
		}

		/*
			Set the current quest by id
		*/
		public void SetCurrentQuest(string id)
		{
			foreach (Quest quest in quests)
			{
				if (quest.id == id)
				{
					quest.UpdateObjectivesState();

					if (quest.questStatus == QuestStatus.AVAILIBLE)
					{
						currentQuest = quest;
					}
					else
					{
						currentQuest = null;
					}
				}
			}
		}

		/*
			Get the current quest
		*/
		public Quest GetCurrentQuest()
		{
			if (currentQuest)
			{
				return currentQuest;
			}

			return null;
		}

		/*
			Get the current Quest by id
		*/
		public Quest GetQuest(string id)
		{
			foreach (Quest quest in quests)
			{
				if (quest.id == id)
				{
					return quest;
				}
			}

			Debug.Log($"No Quest found with id { id }");
			return null;
		}

		/*
			Get a list of all objectives of current quest
		*/
		public List<QuestObjective> GetCurrentQuestObjectives()
		{
			return currentQuest.objectives;
		}

		public bool GetIfCurrentQuestFinished()
		{
			return currentQuest.GetIfAllObjectivesFinished;
		}
	}
}