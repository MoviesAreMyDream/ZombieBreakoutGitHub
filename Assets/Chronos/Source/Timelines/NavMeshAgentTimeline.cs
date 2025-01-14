using UnityEngine;

namespace Chronos
{
	public class NavMeshAgentTimeline : ComponentTimeline<NavMeshAgent>
	{
		private float _speed;

		/// <summary>
		/// The speed that is applied to the agent before time effects. Use this property instead of NavMeshAgent.speed, which will be overwritten by the timeline at runtime. 
		/// </summary>
		public float speed
		{
			get { return _speed; }
			set
			{
				_speed = value;
				AdjustProperties();
			}
		}

		private float _angularSpeed;

		/// <summary>
		/// The angular speed that is applied to the agent before time effects. Use this property instead of NavMeshAgent.angularSpeed, which will be overwritten by the timeline at runtime. 
		/// </summary>
//		public float angularSpeed
//		{
//			get { return _angularSpeed; }
//			set
//			{
//				_angularSpeed = value;
//				AdjustProperties();
//			}
//		}

		public NavMeshAgentTimeline(Timeline timeline) : base(timeline) { }

		public override void CopyProperties(NavMeshAgent source)
		{
			speed = source.speed;
//			angularSpeed = source.angularSpeed;
		}

		public override void AdjustProperties(float timeScale)
		{
			component.speed = speed * timeScale;
//			component.angularSpeed = angularSpeed * timeScale;
		}
	}
}
