using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using Shipyard.Modular.QuestModule;

namespace Shipyard.Modular.Test
{
	public class QuestView : MonoBehaviour
	{
		public string questId;

		public Text questTitle;
		public Text questSummary;
		public Text questObjectives;

		public void PopulateQuestView(string questId, string title, string summary, List<QuestObjective> objectives)
		{
			this.questId = questId;

			this.questTitle.text = title;
			this.questSummary.text = summary;
			this.questObjectives.text = "";

			UpdateQuestObjectives(objectives);
		}

		public void UpdateQuestObjectives(List<QuestObjective> objectives)
		{
			this.questObjectives.text = "";

			foreach (QuestObjective objective in objectives)
			{
				switch (objective.id)
				{
					case "travel":
						this.questObjectives.text += $"{objective.id}: distance/target\n";
						break;
					case "earn":
						this.questObjectives.text += $"{objective.id}: {objective.amountEarnFulfilled}/{objective.amountEarnRequested}\n";
						break;
					case "collect":
						this.questObjectives.text += $"{objective.id}: {objective.amountCollectFulfilled}/{objective.amountCollectRequested}\n";
						break;
					case "kill":
						this.questObjectives.text += $"{objective.id}: {objective.amountKillFulfilled}/{objective.amountKillRequested}\n";
						break;
				}


			}
		}
	}
}