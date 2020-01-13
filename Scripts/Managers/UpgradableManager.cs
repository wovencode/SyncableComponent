// =======================================================================================
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
#if WOCO_CURRENCY
		public LevelCurrencyCost[] upgradeCost;
#endif
		
		// -------------------------------------------------------------------------------
		public int GetCapacity => capacity.Get(level);
		
		// -------------------------------------------------------------------------------
		// Start
		// @Server
		// -------------------------------------------------------------------------------
		[ServerCallback]
		protected override void Start() {
			base.Start();
		}
		
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
#if WOCO_CURRENCY
					&& GetComponentInParent<PlayerCurrencyManager>().CanPayCost(upgradeCost, level)
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
#if WOCO_CURRENCY
			GetComponentInParent<PlayerCurrencyManager>().PayCost(upgradeCost, level);
#endif
			level++;
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================