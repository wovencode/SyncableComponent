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
	// Database
	// ===================================================================================
	public partial class Database
	{
	
		// -------------------------------------------------------------------------------
		// Init_Level
		// -------------------------------------------------------------------------------
		[DevExtMethods("Init")]
		public void Init_Level()
		{
			connection.CreateTable<TableLevel>();
        	connection.CreateIndex(nameof(TableLevel), new []{"owner", "name"});
		}
		
		// -------------------------------------------------------------------------------
		// LoadDataWithPriority_Level
		// We have to load levels first, because inventory size (etc.) could depend on them
		// -------------------------------------------------------------------------------
		[DevExtMethods("LoadDataWithPriority")]
		public void LoadDataWithPriority_Level(GameObject player)
		{
			
			Component[] components = player.GetComponents<UpgradableManager>();
			
	   		foreach (TableLevel row in connection.Query<TableLevel>("SELECT * FROM TableLevel WHERE owner=?", player.name))
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
		public void SaveData_Level(GameObject player)
		{

	   		connection.Execute("DELETE FROM TableLevel WHERE owner=?", player.name);
	   		
	   		Component[] components = player.GetComponents<UpgradableManager>();
	   		
	   		foreach (Component component in components)
	   		{
	   			if (component is UpgradableManager)
	   			{
	   			
	   				UpgradableManager manager = (UpgradableManager)component;
	   			
	   				connection.InsertOrReplace(new TableLevel{
                		owner 			= player.name,
                		name 			= manager.GetType().ToString(),
                		level 			= manager.level
            		});
            	
            	}
	   		}
		
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================