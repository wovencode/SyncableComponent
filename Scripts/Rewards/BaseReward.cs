// =======================================================================================
// BaseReward
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using System;
using System.Text;
using UnityEngine;
using wovencode;

namespace wovencode {

	// ===================================================================================
	// BaseReward
	// ===================================================================================
	[System.Serializable]
	public abstract partial class BaseReward
	{
		
		[HideInInspector]public string title;
		[HideInInspector]public byte state = 0;
		[HideInInspector]public long timer = 0;
	
		/*
		public virtual void OnValidate()
		{
	
			if (String.IsNullOrWhiteSpace(name))
				title = name;
			
		}
		*/
	
	}
	
}

// =======================================================================================