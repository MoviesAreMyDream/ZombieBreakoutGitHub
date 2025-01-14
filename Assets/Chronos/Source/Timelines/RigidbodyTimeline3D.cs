using UnityEngine;

namespace Chronos
{
	public class RigidbodyTimeline3D : RigidbodyTimeline<Rigidbody, RigidbodyTimeline3D.Snapshot>
	{
		// Scale is disabled by default because it usually doesn't change and 
		// would otherwise take more memory. Feel free to uncomment the lines
		// below if you need to record it.

		public struct Snapshot
		{
			public Vector3 position;
			public Quaternion rotation;
			// public Vector3 scale;
			public Vector3 velocity;
			public Vector3 angularVelocity;
			public float lastPositiveTimeScale;

			public static Snapshot Lerp(Snapshot from, Snapshot to, float t)
			{
				return new Snapshot()
				{
					position = Vector3.Lerp(from.position, to.position, t),
					rotation = Quaternion.Lerp(from.rotation, to.rotation, t),
					// scale = Vector3.Lerp(from.scale, to.scale, t),
					velocity = Vector3.Lerp(from.velocity, to.velocity, t),
					angularVelocity = Vector3.Lerp(from.angularVelocity, to.angularVelocity, t),
					lastPositiveTimeScale = Mathf.Lerp(from.lastPositiveTimeScale, to.lastPositiveTimeScale, t),
				};
			}
		}

		public RigidbodyTimeline3D(Timeline timeline) : base(timeline) { }

		public override void CopyProperties(Rigidbody source)
		{
			isKinematic = source.isKinematic;
			useGravity = source.useGravity;
			source.useGravity = false;
		}

		public override void FixedUpdate()
		{
			if (useGravity && !component.isKinematic && timeline.timeScale > 0)
			{
				velocity += (Physics.gravity * timeline.fixedDeltaTime);
			}
		}

		public bool shouldSleep;

		#region Snapshots

		protected override Snapshot LerpSnapshots(Snapshot from, Snapshot to, float t)
		{
			return Snapshot.Lerp(from, to, t);
		}

		protected override Snapshot CopySnapshot()
		{
			return new Snapshot()
			{
				position = component.transform.position,
				rotation = component.transform.rotation,
				// scale = component.transform.localScale,
				velocity = component.velocity,
				angularVelocity = component.angularVelocity,
				lastPositiveTimeScale = lastPositiveTimeScale
			};
		}

		protected override void ApplySnapshot(Snapshot snapshot)
		{
			component.transform.position = snapshot.position;
			component.transform.rotation = snapshot.rotation;
			// component.transform.localScale = snapshot.scale;

			if (timeline.timeScale > 0)
			{
				component.velocity = snapshot.velocity;
				component.angularVelocity = snapshot.angularVelocity;
			}

			lastPositiveTimeScale = snapshot.lastPositiveTimeScale;
		}

		#endregion

		#region Components

		protected bool bodyUseGravity
		{
			get { return component.useGravity; }
			set { component.useGravity = value; }
		}

		protected override bool bodyIsKinematic
		{
			get { return component.isKinematic; }
			set { component.isKinematic = value; }
		}

		protected override float bodyMass
		{
			get { return component.mass; }
			set { component.mass = value; }
		}

		protected override Vector3 bodyVelocity
		{
			get { return component.velocity; }
			set { component.velocity = value; }
		}

		protected override Vector3 bodyAngularVelocity
		{
			get { return component.angularVelocity; }
			set { component.angularVelocity = value; }
		}

		protected override float bodyDrag
		{
			get { return component.drag; }
			set { component.drag = value; }
		}

		protected override float bodyAngularDrag
		{
			get { return component.angularDrag; }
			set { component.angularDrag = value; }
		}

		protected override void WakeUp()
		{
			component.WakeUp();
		}

		protected override bool IsSleeping()
		{
			return component.IsSleeping();
		}

		/// <summary>
		/// Determines whether the rigidbody uses gravity. Use this property instead of Rigidbody.useGravity, which will be overwritten by the physics timer at runtime. 
		/// </summary>
		public bool useGravity { get; set; }

		/// <summary>
		/// The velocity of the rigidbody before time effects. Use this property instead of Rigidbody.velocity, which will be overwritten by the physics timer at runtime. 
		/// </summary>
		public Vector3 velocity
		{
			get { return bodyVelocity / timeline.timeScale; }
			set { if (AssertForwardProperty("velocity", Severity.Ignore)) bodyVelocity = value * timeline.timeScale; }
		}

		/// <summary>
		/// The angular velocity of the rigidbody before time effects. Use this property instead of Rigidbody.angularVelocity, which will be overwritten by the physics timer at runtime. 
		/// </summary>
		public Vector3 angularVelocity
		{
			get { return bodyAngularVelocity / timeline.timeScale; }
			set { if (AssertForwardProperty("angularVelocity", Severity.Ignore)) bodyAngularVelocity = value * timeline.timeScale; }
		}

		/// <summary>
		/// The equivalent of Rigidbody.AddForce adjusted for time effects.
		/// </summary>
		public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force)
		{
			if (AssertForwardForce(Severity.Ignore))
				component.AddForce(AdjustForce(force), mode);
		}

		/// <summary>
		/// The equivalent of Rigidbody.AddRelativeForce adjusted for time effects.
		/// </summary>
		public void AddRelativeForce(Vector3 force, ForceMode mode = ForceMode.Force)
		{
			if (AssertForwardForce(Severity.Ignore))
				component.AddRelativeForce(AdjustForce(force), mode);
		}

		/// <summary>
		/// The equivalent of Rigidbody.AddForceAtPosition adjusted for time effects.
		/// </summary>
		public void AddForceAtPosition(Vector3 force, Vector3 position, ForceMode mode = ForceMode.Force)
		{
			if (AssertForwardForce(Severity.Ignore))
				component.AddForceAtPosition(AdjustForce(force), position, mode);
		}

		/// <summary>
		/// The equivalent of Rigidbody.AddRelativeForce adjusted for time effects.
		/// </summary>
		public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius,
			float upwardsModifier = 0, ForceMode mode = ForceMode.Force)
		{
			if (AssertForwardForce(Severity.Ignore))
				component.AddExplosionForce(AdjustForce(explosionForce), explosionPosition, explosionRadius, upwardsModifier, mode);
		}

		/// <summary>
		/// The equivalent of Rigidbody.AddTorque adjusted for time effects.
		/// </summary>
		public void AddTorque(Vector3 torque, ForceMode mode = ForceMode.Force)
		{
			if (AssertForwardForce(Severity.Ignore))
				component.AddTorque(AdjustForce(torque), mode);
		}

		/// <summary>
		/// The equivalent of Rigidbody.AddRelativeTorque adjusted for time effects.
		/// </summary>
		public void AddRelativeTorque(Vector3 torque, ForceMode mode = ForceMode.Force)
		{
			if (AssertForwardForce(Severity.Ignore))
				component.AddRelativeTorque(AdjustForce(torque), mode);
		}

		#endregion
	}
}
