using UnityEngine;

namespace Shipyard.Modular.Helper
{
	public class Timer : MonoBehaviour
	{
		public float life { get { return _life; } private set { _life = value; } }
		public float elapsed { get { return _curTime; } }
		public float normalized { get { return _curTime / life; } } // returns timer as a range between 0 and 1
		public float remaining { get { return life - elapsed; } }
		public bool isFinished { get { return elapsed >= life; } }
		public bool isPaused { get { return _isPaused; } private set { _isPaused = value; } }

		protected bool _fixedTime;
		protected bool _isPaused;
		protected float _life;
		protected float _startTime;
		protected float _pauseTime;
		protected float _curTime { get { return (isPaused ? _pauseTime : _getTime) - _startTime; } set { _pauseTime = value; } }
		protected float _getTime { get { return _fixedTime ? Time.fixedTime : Time.time; } }


		public Timer() { }

		public Timer(float lifeSpan, bool useFixedTime = false)
		{
			life = lifeSpan;
			_fixedTime = useFixedTime;
			_startTime = _getTime;
		}

		public void Resume()
		{
			_startTime = (isPaused ? _getTime - elapsed : _getTime);
			isPaused = false;
		}

		public void Stop()
		{
			if (!isPaused)
			{
				_curTime = _getTime;
				isPaused = true;
			}
		}

		public void AddTime(float amt) => _life += amt;
	}
}