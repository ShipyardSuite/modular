using System.Collections;
using UnityEngine;

using Shipyard.Modular.Helper;
using Shipyard.Modular.Inventory;

namespace Shipyard.Modular.QuestModule
{
	public class QuestObjective : ScriptableObject
	{
		public string id;
		[HideInInspector] public bool collect;
		[HideInInspector] public bool travel;
		[HideInInspector] public bool kill;
		[HideInInspector] public bool earn;

		[ConditionalField("collect")] public int amountCollectRequested;
		[ConditionalField("collect")] public int amountCollectFulfilled;
		[ConditionalField("collect")] public Item item;

		[ConditionalField("travel")] public string destination;
		[ConditionalField("travel")] public string position;

		[ConditionalField("kill")] public int amountKillRequested;
		[ConditionalField("kill")] public int amountKillFulfilled;

		[ConditionalField("earn")] public int amountEarnRequested;
		[ConditionalField("earn")] public int amountEarnFulfilled;

		public bool isFinished;

		public void Init(
						string id,
						bool collect,
						bool travel,
						bool kill,
						bool earn,
						int amountCollectRequested,
						int amountCollectFulfilled,
						Item item,
						string destination,
						string position,
						int amountKillRequested,
						int amountKillFulfilled,
						int amountEarnRequested,
						int amountEarnFulfilled,
						bool isFinished
		)
		{
			this.id = id;
			this.collect = collect;
			this.travel = travel;
			this.kill = kill;
			this.earn = earn;
			this.amountCollectRequested = amountCollectRequested;
			this.amountCollectFulfilled = amountCollectFulfilled;
			this.item = item;
			this.destination = destination;
			this.position = position;
			this.amountKillRequested = amountKillRequested;
			this.amountKillFulfilled = amountKillFulfilled;
			this.amountEarnRequested = amountEarnRequested;
			this.amountEarnFulfilled = amountEarnFulfilled;
			this.isFinished = isFinished;
		}

		public static QuestObjective CreateInstance(QuestObjective questObjective)
		{
			var data = ScriptableObject.CreateInstance<QuestObjective>();
			data.Init(
				questObjective.id,
				questObjective.collect,
				questObjective.travel,
				questObjective.kill,
				questObjective.earn,
				questObjective.amountCollectRequested,
				questObjective.amountCollectFulfilled,
				questObjective.item,
				questObjective.destination,
				questObjective.position,
				questObjective.amountKillRequested,
				questObjective.amountKillFulfilled,
				questObjective.amountEarnRequested,
				questObjective.amountEarnFulfilled,
				questObjective.isFinished
			);

			return data;
		}
	}
}
