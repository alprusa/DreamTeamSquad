using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class BuildSlotsController : Controller {
	public BuildSlotController[] BuildSlots;
	
	private DecorationModel savedModel;
	
	protected override void Start() {
		BuildSlots = GetComponentsInChildren<BuildSlotController>();
		
		int count = 0;
		foreach(BuildSlotController buildSlot in BuildSlots) {
			buildSlot.InitWithIndex(count);
			count++;
		}
	}
	
	public void PrepareSlotsForPlacement(DecorationModel model) {
		savedModel = model;
		for (int i = 0; i < BuildSlots.Length; i++) {
			BuildSlots[i].PrepareForPlacement();
		}
	}
	
	public void PrepareSlotsForRemoval() {
		for (int i = 0; i < BuildSlots.Length; i++) {
			BuildSlots[i].PrepareForRemoval();
		}
	}
	
	public void StopSlotsPlacement() {
		savedModel = null;
		
		for (int i = 0; i < BuildSlots.Length; i++) {
			BuildSlots[i].StopPlacement();
		}
	}
	
	public void PlaceDecoration(int slotIndex) {
		BuildSlots[slotIndex].InitWithModel(savedModel);
		
		StopSlotsPlacement();
	}
	
	public void RemoveDecoration(int slotIndex) {
		Debug.Log (slotIndex);
		BuildSlots[slotIndex].InitWithModel(null);
		
		StopSlotsPlacement();
	}
	
	public DecorationModel GetSavedModel() {
		return savedModel;
	}
}
