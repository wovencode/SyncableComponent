﻿// =======================================================================================
// UpgradableManager
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using System;
using System.Text;
using UnityEngine;
using Mirror;
using wovencode;

namespace wovencode {

	// ===================================================================================
	// UpgradableManager
	// ===================================================================================
	[System.Serializable]
	public abstract partial class UpgradableManager : SyncableManager
	{
	
		[Header("Level")]
		[SyncVar]
		public int level = 1;
		public int maxLevel = 3;
		public LinearGrowthInt capacity = new LinearGrowthInt{baseValue=99, bonusPerLevel=0};
		public LevelCurrencyCost[] upgradeCost;
		
		public int GetCapacity => capacity.Get(level);
		
		// -------------------------------------------------------------------------------
		protected override void Start() {}
		
		// -------------------------------------------------------------------------------
		[Server]
		protected override void UpdateServer() {}
		
		// -------------------------------------------------------------------------------
		[Client]
		protected override void UpdateClient() {}
		
		// -------------------------------------------------------------------------------
		public bool CanUpgradeLevel()
		{
			return (level < maxLevel
#if WOCO_VCURRENCY
					&& GetComponentInParent<VirtualCurrencyManager>().CanPayCost(upgradeCost, level)
#endif
					);
		}
		
		// -------------------------------------------------------------------------------
		[Command]
		public void CmdUpgradeLevel()
		{
			if (CanUpgradeLevel())
				UpgradeLevel();
		}
		
		// -------------------------------------------------------------------------------
		[Server]
		protected virtual void UpgradeLevel()
		{
#if WOCO_VCURRENCY
			GetComponentInParent<VirtualCurrencyManager>().PayCost(upgradeCost, level);
#endif
			level++;
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================