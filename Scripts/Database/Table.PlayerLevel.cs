// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using Wovencode;
using Wovencode.Database;
using System;
using SQLite;

namespace Wovencode.Database
{

	// ===================================================================================
	// DatabaseManager
	// ===================================================================================
	public partial class DatabaseManager
	{
	
		// -------------------------------------------------------------------------------
		// TablePlayerLevel
		// -------------------------------------------------------------------------------
		partial class TablePlayerLevel
		{
			public string 	owner 		{ get; set; }
			public string 	name 		{ get; set; }
			public int 		level 		{ get; set; }
		}
	
	}
	
	// -------------------------------------------------------------------------------
	
}