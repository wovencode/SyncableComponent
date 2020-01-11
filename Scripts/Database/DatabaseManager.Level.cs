// =======================================================================================
// Database
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using UnityEngine;
using Mirror;
using System;
using System.IO;
using System.Collections.Generic;
using SQLite;
using UnityEngine.AI;
using wovencode;

namespace wovencode
{

	// ===================================================================================
	// DatabaseManager
	// ===================================================================================
	public partial class DatabaseManager
	{
	
		// -------------------------------------------------------------------------------
		// Init_Level
		// -------------------------------------------------------------------------------
		[DevExtMethods("Init")]
		void Init_Level()
		{
			CreateTable<TableLevel>();
        	CreateIndex(nameof(TableLevel), new []{"owner", "name"});
		}
		
		// -------------------------------------------------------------------------------
		// LoadDataWithPriority_Level
		// We have to load levels first, because inventory size (etc.) could depend on them
		// -------------------------------------------------------------------------------
		[DevExtMethods("LoadDataWithPriority")]
		void LoadDataWithPriority_Level(GameObject player)
		{
			
			Component[] components = player.GetComponents<UpgradableManager>();
			
	   		foreach (TableLevel row in Query<TableLevel>("SELECT * FROM TableLevel WHERE owner=?", player.name))
			{
				foreach (Component component in components)
	   			{
	   				if (component is UpgradableManager)
	   				{
	   				
	   					UpgradableManager manager = (UpgradableManager)component;
	   				
	   					if (manager.GetType().ToString() == row.name)
	   						manager.level = row.level;
	   					
	   				}
	   			}
			}
		}
		
		// -------------------------------------------------------------------------------
		// SaveData_Level
		// -------------------------------------------------------------------------------
		[DevExtMethods("SaveData")]
		void SaveData_Level(GameObject player)
		{
		
			// you should delete all data of this player first, to prevent duplicates
	   		DeleteData_Level(player.name);
	   		
	   		Component[] components = player.GetComponents<UpgradableManager>();
	   		
	   		foreach (Component component in components)
	   		{
	   			if (component is UpgradableManager)
	   			{
	   			
	   				UpgradableManager manager = (UpgradableManager)component;
	   			
	   				InsertOrReplace(new TableLevel{
                		owner 			= player.name,
                		name 			= manager.GetType().ToString(),
                		level 			= manager.level
            		});
            	
            	}
	   		}
		
		}
		
		// -------------------------------------------------------------------------------
	   	// DeleteData_Level
	   	// -------------------------------------------------------------------------------
	   	[DevExtMethods("DeleteData")]
	   	void DeleteData_Level(string _name)
	   	{
	   		Execute("DELETE FROM TableLevel WHERE owner=?", _name);
	   	}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================