// =======================================================================================
// SyncableManager
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
	// SyncableManager
	// ===================================================================================
	[System.Serializable]
	public abstract partial class SyncableManager : NetworkBehaviour
	{
	
		[Header("Caching")]
		[Range(0.01f, 99)]
		public float refreshInterval = 1f;
		float _cacheTimer = 0;
		
		public static GameObject localPlayer => ClientScene.localPlayer != null ? ClientScene.localPlayer.gameObject : null;
		
		// -------------------------------------------------------------------------------
		// Start
		// -------------------------------------------------------------------------------
		protected virtual void Start() {}
		
		// -------------------------------------------------------------------------------
		// Check
		// Used to throttle calls to "Update" (similar to how we do it in "Wovencore UI")
		// -------------------------------------------------------------------------------
		protected bool Check => Time.time > _cacheTimer;
		
		// -------------------------------------------------------------------------------
		// Refresh
		// updates the cache timer interval
		// -------------------------------------------------------------------------------
		void Refresh()
		{
			_cacheTimer = Time.time + refreshInterval;
		}
		
		// -------------------------------------------------------------------------------
		// Update
		// updated every frame, private to enforce the use of UpdateServer/UpdateClient
		// -------------------------------------------------------------------------------
		void Update()
		{
			if (Check)
			{
				if (isClient)
					UpdateClient();
				if (isServer)
					UpdateServer();
				
				Refresh();
			}
		}
		
		// -------------------------------------------------------------------------------
		// UpdateServer
		// @Server
		// -------------------------------------------------------------------------------
		[Server]
		protected abstract void UpdateServer();
		
		// -------------------------------------------------------------------------------
		// UpdateClient
		// @Client
		// -------------------------------------------------------------------------------
		[Client]
		protected abstract void UpdateClient();
		
		// -------------------------------------------------------------------------------
			
	}

}

// =======================================================================================