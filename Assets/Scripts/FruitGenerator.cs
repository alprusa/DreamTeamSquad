using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FruitGenerator : MonoBehaviour {
	public Transform FruitParent;
	public FruitCharacter FruitPrefab;
	public LevelLimits Limits;
	
	private List<FruitModel> FruitModels = new List<FruitModel>();
	private List<FruitCharacter> Fruits = new List<FruitCharacter>();
	private List<string> names;
	private bool hasFinishedGenerating = false;
	private float elapsedTime = 0f;

	// Use this for initialization
	void Start () {
		names = new List<string>() {
			"Hurley",
			"Sayid",
			"Sawyer",
			"Desmond",
			"Kate",
			"Jack",
			"Walt",
			"John",
			"Boone",
			"Alisa",
			"Jonathan",
			"Kory",
			"Kevin",
			"Max",
			"Alison",
			"David",
			"Arnold",
			"Jason",
			"Freddy",
			"Chad",
			"James",
			"Ron",
			"Harry",
			"Hermione",
			"Severus",
			"Alan",
			"Dumbledore",
			"Elrond",
			"Shephard",
			"Luke",
			"Darth",
			"Alice",
			"Tiffany",
			"Scarlet"
		};
		
		for(int i = 0; i < 32; i++) {
			string randomString = names[ i ];
			
			FruitModel fruitModel = new FruitModel();
			fruitModel.Name = randomString;
			fruitModel.Hours = Random.Range(0f, 11f);
			fruitModel.CheckedIn = (Random.value <= 0.75);
			FruitModels.Add(fruitModel);
		}
		
		StartCoroutine(SpawnFruits());
	}
	public List<FruitCharacter> GetFruits() {
		return Fruits;
	}
	
	public FruitCharacter ChoosePlayerFruit() {
		int randIndex = Random.Range (0, Fruits.Count);
		FruitCharacter fruit = Fruits[randIndex];
		fruit.Freeze(false);
		return fruit;
	}
	
	private IEnumerator SpawnFruits() {
		float safeDistance = 8;
		foreach(FruitModel model in FruitModels) {
			float randomX = Random.Range (Limits.LeftLimit + 15, Limits.RightLimit - 15);
			float randomY = Random.Range (Limits.BottomLimit + 15, Limits.TopLimit - 15);
			Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
			bool foundValidLocation = false;
			int attempts = 0;
			while(!foundValidLocation && attempts < 100) {
				foundValidLocation = true;
				foreach(FruitCharacter character in Fruits) {
					float dist = Vector2.Distance(character.transform.position, spawnPosition);
					if(dist <= safeDistance) {
						randomX = Random.Range (Limits.LeftLimit + 15, Limits.RightLimit - 15);
						randomY = Random.Range (Limits.BottomLimit + 15, Limits.TopLimit - 15);
						spawnPosition = new Vector3(randomX, randomY, 0);
						foundValidLocation = false;
						break;
					}
				}
				
				attempts++;
				
				yield return null;
			}
			
			FruitCharacter fruitCharacter = (FruitCharacter) Instantiate(FruitPrefab, spawnPosition, Quaternion.identity);
			fruitCharacter.Freeze(true);
			fruitCharacter.InitWithModel(model);
			fruitCharacter.transform.SetParent(FruitParent);
			Fruits.Add(fruitCharacter);
			
			yield return null;
		}
		
		this.hasFinishedGenerating = true;
	}
	
	public bool HasFinishedGenerating() {
		return this.hasFinishedGenerating;
	}
}