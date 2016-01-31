using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildSlotController : Controller {
	public Sprite DefaultSprite;
	public Image SlotImage;
	public BuildSlotsController BuildSlotsController;
	
	private DecorationModel decorationModel;
	
	public int slotId { get; private set; }
	
	public void InitWithIndex(int index) {
		slotId = index;
	}
	
	public void InitWithModel (DecorationModel model) {
		decorationModel = model;
		
		if(model == null)
			SlotImage.sprite = DefaultSprite;
		else
			SlotImage.sprite = model.Sprite;
	}
	
	public void SetInteraction(bool flag) {
		CanvasGroup.interactable = flag;
	}
	
	public void PrepareForPlacement() {
		Show (true);
	}
	
	public void PrepareForRemoval() {
		Show(true);
	}
	
	public void StopPlacement() {
		if(decorationModel == null) {
			Show (false);
		}
	}
	
	public void PlaceDecoration() {
		if(BuildSlotsController.GetSavedModel() != null) {
			BuildSlotsController.PlaceDecoration(this.slotId);
		} else {
			
		}
	}
	
	public void Remove() {
		BuildSlotsController.RemoveDecoration(this.slotId);
	}
}