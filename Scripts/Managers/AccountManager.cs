﻿// =======================================================================================
// AccountManager
// by Weaver (Fhiz)
// MIT licensed
//
// =======================================================================================

using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using wovencode;

namespace wovencode {
	
	// ===================================================================================
	// AccountManager
	// ===================================================================================
	[DisallowMultipleComponent]
	[System.Serializable]
	public partial class AccountManager : UpgradableManager
	{
	
		public static GameObject localPlayer;
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		protected override void Start()
    	{
        	base.Start();
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public override void OnStartLocalPlayer()
    	{
        	localPlayer = this.gameObject;
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		void OnDestroy()
    	{
    		if (isLocalPlayer)
            	localPlayer = null;
        }
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		[Server]
		protected override void UpdateServer()
		{
			
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		[Client]
		protected override void UpdateClient()
		{
			
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================