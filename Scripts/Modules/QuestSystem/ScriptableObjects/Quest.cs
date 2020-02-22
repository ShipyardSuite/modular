using System.Collections;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

using Shipyard.Modular.Helper;
using Shipyard.Modular.Inventory;

namespace Shipyard.Modular.QuestModule
{
	[CreateAssetMenu(menuName = "Game/Quest")]
	public class Quest : ScriptableObject
	{
		public List<bool> objectivesFinished = new List<bool>();

		[Header("Settings")]
		public string title;
		public string id;
		public QuestStatus questStatus;
		public Quest nextQuest;

		[Header("Objectives")]
		public List<QuestObjective> objectives = new List<QuestObjective>();

		[Header("Informations")]
		[TextArea(3, 10)]
		public string description;
		public string summary;

		[Header("Rewards")]
		public bool rewardExperience;
		public bool rewardCredits;

		[ConditionalField("rewardExperience")] public int experience;
		[ConditionalField("rewardCredits")] public int credits;
		public Item[] items;

		public void Init(string title, string id, QuestStatus questStatus, Quest nextQuest, List<QuestObjective> objectives, string description, string summary, bool rewardExperience, bool rewardCredits, int experience, int credits, Item[] items)
		{
			this.title = title;
			this.id = id;
			this.questStatus = questStatus;
			this.nextQuest = nextQuest;

			foreach (QuestObjective objective in objectives)
			{
				this.objectives.Add(QuestObjective.CreateInstance(objective));
			}
			this.description = description;
			this.summary = summary;
			this.rewardExperience = rewardExperience;
			this.rewardCredits = rewardCredits;
			this.experience = experience;
			this.credits = credits;
			this.items = items;

			UpdateObjectivesState();
		}

		public static Quest CreateInstance(string title, string id, QuestStatus questStatus, Quest nextQuest, List<QuestObjective> objectives, string description, string summary, bool rewardExperience, bool rewardCredits, int experience, int credits, Item[] items)
		{
			var data = ScriptableObject.CreateInstance<Quest>();
			data.Init(title, id, questStatus, nextQuest, objectives, description, summary, rewardExperience, rewardCredits, experience, credits, items);

			return data;
		}

		public static Quest CreateInstance(Quest quest)
		{
			var data = ScriptableObject.CreateInstance<Quest>();
			data.Init(quest.title, quest.id, quest.questStatus, quest.nextQuest, quest.objectives, quest.description, quest.summary, quest.rewardExperience, quest.rewardCredits, quest.experience, quest.credits, quest.items);

			return data;
		}

		public void UpdateObjectivesState()
		{
			objectivesFinished.Clear();
			foreach (QuestObjective obj in objectives)
			{
				objectivesFinished.Add(obj.isFinished);
			}
		}

		public bool GetIfAllObjectivesFinished
		{
			get
			{
				for (int i = 0; i < objectivesFinished.Count; i++)
				{
					if (!objectivesFinished[i])
					{
						return false;
					}
				}
				return true;
			}
		}
	}
}
