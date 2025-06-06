﻿using System;
using RoR2;
using SS2;
using UnityEngine;
namespace EntityStates.Barrel
{
	public class OpeningSlow : EntityState
	{
		public override void OnEnter()
		{
			base.OnEnter();

			duration = CurseManager.GetChestTimer();

			base.PlayAnimation("Body", "Opening", "Opening.playbackRate", duration);
			if (base.sfxLocator)
			{
				Util.PlaySound(base.sfxLocator.openSound, base.gameObject);
			}

			GameObject prefab = SS2Assets.LoadAsset<GameObject>("ChestTimerEffect", SS2Bundle.Interactables);
			if(prefab)
            {
				EffectManager.SpawnEffect(prefab, new EffectData { origin = base.transform.position }, false);
			}
			
		}
		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (base.fixedAge >= duration)
			{
				this.outer.SetNextState(new Opened());
				return;
			}
		}
		private float duration = 1f;
	}
}
