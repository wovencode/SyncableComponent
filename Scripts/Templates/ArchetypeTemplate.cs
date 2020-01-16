// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using wovencode;

namespace wovencode {
	
	// ===================================================================================
	// ArchetypeTemplate
	// ===================================================================================
	[CreateAssetMenu(fileName = "New Archetype", menuName = "Templates/New Archetype", order = 999)]
	public partial class ArchetypeTemplate : IterateableTemplate
	{
    	
    	/*
    		Reserved for future functionality
    	*/

    	// -------------------------------------------------------------------------------
    	
		public static string _folderName = "";
		
		static ArchetypeTemplateDictionary _data;
		
		// -------------------------------------------------------------------------------
        // data
        // -------------------------------------------------------------------------------
		public static ReadOnlyDictionary<int, ArchetypeTemplate> data
		{
			get {
				ArchetypeTemplate.BuildCache();
				return _data.data;
			}
		}
		
		// -------------------------------------------------------------------------------
        // BuildCache
        // -------------------------------------------------------------------------------
		public static void BuildCache()
		{
			if (_data == null)
				_data = new ArchetypeTemplateDictionary(ArchetypeTemplate._folderName);
		}
		
		// -------------------------------------------------------------------------------
        // OnEnable
        // -------------------------------------------------------------------------------
		public void OnEnable()
		{
			if (_folderName != folderName)
				_folderName = folderName;
		}
		
		// -------------------------------------------------------------------------------
        // OnValidate
        // You can add custom validation checks here
        // -------------------------------------------------------------------------------
		public override void OnValidate()
		{
			base.OnValidate();
		}
		
		// -------------------------------------------------------------------------------

	}

}

// =======================================================================================