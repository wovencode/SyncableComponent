// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using System;
using System.Collections.Generic;
using UnityEngine;
using wovencode;

namespace wovencode {
	
	// ===================================================================================
	// DataCacheEntry
	// ===================================================================================
	public partial class DataCacheEntry : BaseCacheEntry
	{
		
#if WOCO_CURRENCY
		public long 	autoGenerateCurrencyCapacity 	= 0;
		public long 	autoGenerateCurrencyProduction 	= 0;
		public float 	autoGenerateCurrencyDuration 	= 0f;
#endif
		
	}

}

// =======================================================================================