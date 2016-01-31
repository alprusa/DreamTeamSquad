using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopSlotController : Controller {
	public Image SlotImage;
	public ShopController ShopController;
	
	public Sprite Sprite;
	public int Cost;
	
	protected override void Start() {
		SlotImage.sprite = Sprite;
	}
	
	public void Purchase() {
		DecorationModel model = new DecorationModel();
		model.Sprite = Sprite;
		model.cost = Cost;
		ShopController.ChooseDecoration(model);
	}
}