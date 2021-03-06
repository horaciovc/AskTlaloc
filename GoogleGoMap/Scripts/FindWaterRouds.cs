﻿using UnityEngine;
//using UnityEditor;
using System.Collections;

public class FindWaterRouds : MonoBehaviour {

	public GameObject NearestWaterGO;
	public GameObject Person;
	public Texture2D MapTexture;
	public Color Water = Color.black;
	public Color ActualC;
	public Vector3 NearWater = new Vector3(999f,999f,999f);
	private float startTime = 0;
	private bool Scan = true;

	//[Menu
	//[MenuItem("GameObject/Create Material")]

	// Use this for initialization
	void Start () {

		Water = GetComponent<GoogleStaticMap> ().waterColor;

		startTime = Time.time;




	
	}
	
	// Update is called once per frame
	void Update () {

		if ((Time.time - startTime) > 3f && Scan) {
			
			MapTexture = GetComponent<GoogleStaticMap> ().map2d;
			//Texture2D map = transform.GetComponent<Renderer> ().material.GetTexture ("_MainTex") as Texture2D;
			//Texture2D map = transform.GetComponent<Texture2D>();

//			Texture2D t2d = new Texture2D (1024, 1024);
//			t2d = MapTexture;
//
//			AssetDatabase.CreateAsset (t2d, "Assets/myTexture2d.png");
//			Debug.Log (AssetDatabase.GetAssetPath (t2d));
//
//			string path = AssetDatabase.GetAssetPath (t2d);
//			TextureImporter ti = TextureImporter.GetAtPath(path) as TextureImporter;
//			ti.isReadable = true;
//			AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate); 

			float dist = 9999f;
			float distA = 9999f;


			for (int i = 0; i < 1024; i++) {
				
				for (int j = 0; j < 1024; j++) {


					//ActualC = MapTexture.GetPixel (j, i);

						//ActualC [j] = MapTexture.GetPixel (j, i);
					if (MapTexture.GetPixel(j,i).b > 0.50f) {
							
						Debug.Log (i + " " + j);

						float localX = (j) / (transform.localScale.x*10f);
						float localY = (i) / (transform.localScale.y*10f);

						//Debug.Log (i);
						Vector3 worldPos = transform.TransformPoint (new Vector3 (localX, localY, 0f));

						NearestWaterGO.transform.position = worldPos;
						ActualC = MapTexture.GetPixel (j, i);
							dist = Vector3.Distance(NearestWaterGO.transform.position,Person.transform.position);
							if (dist < distA) {

								distA = dist;
								NearWater = NearestWaterGO.transform.position;

							}
							
						}

	

				}

			}

			NearestWaterGO.transform.position = NearWater;	
			//Debug.Log (MapTexture.texelSize);

			Scan = false;

		}



	
	}
}
