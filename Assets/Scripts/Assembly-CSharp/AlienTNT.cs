using System;
using System.Collections;
using UnityEngine;

public class AlienTNT : TNT
{
	public override void Explode()
	{
		if (this.m_triggered)
		{
			return;
		}
		this.m_triggered = true;
		Collider[] array = Physics.OverlapSphere(base.transform.position, this.m_explosionRadius);
		foreach (Collider collider in array)
		{
			GameObject gameObject = base.FindParentWithRigidBody(collider.gameObject);
			if (gameObject != null)
			{
				int num = base.CountChildColliders(gameObject, 0);
				base.AddExplosionForce(gameObject, 1f / (float)num);
			}
			TNT component = collider.GetComponent<TNT>();
			if (component && !(component is AlienTNT))
			{
				component.Explode();
			}
		}
		Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.tntExplosion, base.transform.position);
		WPFMonoBehaviour.effectManager.CreateParticles(this.smokeCloud, base.transform.position - Vector3.forward * 5f, true);
		if (this.extraEffect)
		{
			WPFMonoBehaviour.effectManager.CreateParticles(this.extraEffect, base.transform.position - Vector3.forward * 4f, true);
		}
		base.CheckForTNTAchievement();
		base.StartCoroutine(this.ShineLight());
	}

	public override void OnCollisionEnter(Collision c)
	{
	}

	protected new virtual void LateUpdate()
	{
		this.m_triggered = false;
	}

	protected override IEnumerator ShineLight()
	{
		PointLightSource pls = base.GetComponentInChildren<PointLightSource>();
		if (pls)
		{
			MeshRenderer renderer = base.transform.GetComponentInChildren<MeshRenderer>();
			if (renderer)
			{
				renderer.enabled = false;
			}
			PointLightSource pointLightSource = pls;
			pointLightSource.onLightTurnOff = (Action)Delegate.Combine(pointLightSource.onLightTurnOff, new Action(delegate()
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}));
			pls.isEnabled = true;
			yield return new WaitForSeconds(pls.turnOnCurve[pls.turnOnCurve.length - 1].time);
			pls.isEnabled = false;
		}
		yield break;
	}
}
