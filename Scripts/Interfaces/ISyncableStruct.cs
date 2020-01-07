// =======================================================================================
// NetworkAuthenticator
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

// A simple interface shared by all SyncStructs

using UnityEngine;
using wovencode;

namespace wovencode
{
	
	public interface ISyncableStruct<T>
	{
		T template { get; }
	}
	
}