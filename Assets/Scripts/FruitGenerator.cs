﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FruitGenerator : MonoBehaviour {
	public Transform FruitParent;
	public FruitCharacter FruitPrefab;
	public LevelLimits Limits;
	
	private List<FruitModel> FruitModels = new List<FruitModel>();
	private List<FruitCharacter> Fruits = new List<FruitCharacter>();

	// Use this for initialization
	void Start () {
		List<string> names = new List<string>() {
			"Hurley",
			"Sayid",
			"Sawyer",
			"Desmond",
			"Kate",
			"Jack",
			"Walt",
			"John",
			"Boone"
		};
		
		for(int i = 0; i < 32; i++) {
			int randIndex = Random.Range(0, names.Count);
			string randomString = names[ randIndex ];
			
			FruitModel fruitModel = new FruitModel();
			fruitModel.Name = randomString;
			fruitModel.Hours = Random.Range(5, 15);
			FruitModels.Add(fruitModel);
		}
		
		StartCoroutine(SpawnFruits());
	}
	
	private IEnumerator SpawnFruits() {
		float safeDistance = 6;
		foreach(FruitModel model in FruitModels) {
			float randomX = Random.Range (Limits.LeftLimit + 20, Limits.RightLimit - 20);
			float randomY = Random.Range (Limits.BottomLimit + 30, Limits.TopLimit - 30);
			Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
			bool foundValidLocation = false;
			int attempts = 0;
			while(!foundValidLocation && attempts < 100) {
				foundValidLocation = true;
				foreach(FruitCharacter character in Fruits) {
					float dist = Vector2.Distance(character.transform.position, spawnPosition);
					if(dist <= safeDistance) {
						randomX = Random.Range (Limits.LeftLimit, Limits.RightLimit);
						randomY = Random.Range (Limits.BottomLimit, Limits.TopLimit);
						spawnPosition = new Vector3(randomX, randomY, 0);
						foundValidLocation = false;
						break;
					}
				}
				
				attempts++;
				
				yield return null;
			}
			
			FruitCharacter fruitCharacter = (FruitCharacter) Instantiate(FruitPrefab, spawnPosition, Quaternion.identity);
			fruitCharacter.InitWithModel(model);
			fruitCharacter.transform.SetParent(FruitParent);
			Fruits.Add(fruitCharacter);
			
			yield return null;
		}
	}
}