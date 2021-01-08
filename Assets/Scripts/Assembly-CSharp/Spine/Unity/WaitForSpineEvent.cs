using System.Collections;

namespace Spine.Unity
{
    public class WaitForSpineEvent : IEnumerator
	{
		public WaitForSpineEvent(AnimationState state, EventData eventDataReference, bool unsubscribeAfterFiring = true)
		{
			this.Subscribe(state, eventDataReference, unsubscribeAfterFiring);
		}

		public WaitForSpineEvent(SkeletonAnimation skeletonAnimation, EventData eventDataReference, bool unsubscribeAfterFiring = true)
		{
			this.Subscribe(skeletonAnimation.state, eventDataReference, unsubscribeAfterFiring);
		}

		public WaitForSpineEvent(AnimationState state, string eventName, bool unsubscribeAfterFiring = true)
		{
			this.SubscribeByName(state, eventName, unsubscribeAfterFiring);
		}

		public WaitForSpineEvent(SkeletonAnimation skeletonAnimation, string eventName, bool unsubscribeAfterFiring = true)
		{
			this.SubscribeByName(skeletonAnimation.state, eventName, unsubscribeAfterFiring);
		}

		private void Subscribe(AnimationState state, EventData eventDataReference, bool unsubscribe)
		{
			if (state == null)
			{
				this.m_WasFired = true;
				return;
			}
			if (eventDataReference == null)
			{
				this.m_WasFired = true;
				return;
			}
			this.m_AnimationState = state;
			this.m_TargetEvent = eventDataReference;
			state.Event += this.HandleAnimationStateEvent;
			this.m_unsubscribeAfterFiring = unsubscribe;
		}

		private void SubscribeByName(AnimationState state, string eventName, bool unsubscribe)
		{
			if (state == null)
			{
				this.m_WasFired = true;
				return;
			}
			if (string.IsNullOrEmpty(eventName))
			{
				this.m_WasFired = true;
				return;
			}
			this.m_AnimationState = state;
			this.m_EventName = eventName;
			state.Event += this.HandleAnimationStateEventByName;
			this.m_unsubscribeAfterFiring = unsubscribe;
		}

		private void HandleAnimationStateEventByName(AnimationState state, int trackIndex, Event e)
		{
			if (state != this.m_AnimationState)
			{
				return;
			}
			this.m_WasFired |= (e.Data.Name == this.m_EventName);
			if (this.m_WasFired && this.m_unsubscribeAfterFiring)
			{
				state.Event -= this.HandleAnimationStateEventByName;
			}
		}

		private void HandleAnimationStateEvent(AnimationState state, int trackIndex, Event e)
		{
			if (state != this.m_AnimationState)
			{
				return;
			}
			this.m_WasFired |= (e.Data == this.m_TargetEvent);
			if (this.m_WasFired && this.m_unsubscribeAfterFiring)
			{
				state.Event -= this.HandleAnimationStateEvent;
			}
		}

		public bool WillUnsubscribeAfterFiring
		{
			get
			{
				return this.m_unsubscribeAfterFiring;
			}
			set
			{
				this.m_unsubscribeAfterFiring = value;
			}
		}

		public WaitForSpineEvent NowWaitFor(AnimationState state, EventData eventDataReference, bool unsubscribeAfterFiring = true)
		{
			((IEnumerator)this).Reset();
			this.Clear(state);
			this.Subscribe(state, eventDataReference, unsubscribeAfterFiring);
			return this;
		}

		public WaitForSpineEvent NowWaitFor(AnimationState state, string eventName, bool unsubscribeAfterFiring = true)
		{
			((IEnumerator)this).Reset();
			this.Clear(state);
			this.SubscribeByName(state, eventName, unsubscribeAfterFiring);
			return this;
		}

		private void Clear(AnimationState state)
		{
			state.Event -= this.HandleAnimationStateEvent;
			state.Event -= this.HandleAnimationStateEventByName;
		}

		bool IEnumerator.MoveNext()
		{
			if (this.m_WasFired)
			{
				((IEnumerator)this).Reset();
				return false;
			}
			return true;
		}

		void IEnumerator.Reset()
		{
			this.m_WasFired = false;
		}

		object IEnumerator.Current
		{
			get
			{
				return null;
			}
		}

		private EventData m_TargetEvent;

		private string m_EventName;

		private AnimationState m_AnimationState;

		private bool m_WasFired;

		private bool m_unsubscribeAfterFiring;
	}
}
