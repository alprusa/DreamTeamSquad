using UnityEngine;

public class SpriteText : MonoBehaviour
{
	void Start()
	{		
		GetComponent<MeshRenderer> ().sortingLayerName = "Fruits";
		GetComponent<MeshRenderer> ().sortingOrder = 0;
	}
}