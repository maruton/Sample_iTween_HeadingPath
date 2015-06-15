/*
 *	@file	csMoveHeadingToPath.cs
 *	@note		None 
 *	@attention	
 *				[csMoveHeadingToPath.cs]
 *				Copyright (c) [2015] [Maruton]
 *				This software is released under the MIT License.
 *				http://opensource.org/licenses/mit-license.php
 */
using UnityEngine;
using System.Collections;

public class csMoveHeadingToPath : MonoBehaviour {
	string pathName = "MyPath";
	float pathTime = 18.0f;//5.0f
	Hashtable table = new Hashtable();
	void SetupPath(){
		table.Add( "path", iTweenPath.GetPath(pathName) );//ITween path hash data
		table.Add( "time", pathTime );
		table.Add( "easetype", iTween.EaseType.easeInOutSine );
		table.Add( "onstart", "cb_iTweenStart" );  //Handler func when iTween start
		table.Add( "onstartparams", "Start" );   //parameter of Handler func when iTween start
		table.Add( "oncomplete", "cb_iTweenComplete" ); //Handler func when iTween end
		table.Add( "oncompleteparams", "Complete" ); //parameter of Handler func when iTween end
		
		table.Add( "orienttopath", true ); //Head to forwarding vector (*Important*)
		table.Add( "lookTime", 1.0f ); //Time value for heading nose (*Important*)
		
		iTween.MoveTo(gameObject, table);
	}
	void cb_iTweenStart(string param){
		Debug.Log("[iTween] cb_iTweenStart: "+param);
	}
	void cb_iTweenComplete(string param){
		Debug.Log("[iTween] cb_iTweenComplete: "+param);
		iTween.MoveTo(gameObject, table);//Restart iTween.
	}

	void Start () {
		SetupPath();
	}
	void Update () {
	}
}
