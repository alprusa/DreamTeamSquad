using UnityEngine;

public class SpriteText : MonoBehaviour
{
	void Start()
	{		
		GetComponent<MeshRenderer> ().sortingLayerName = "Default";
		GetComponent<MeshRenderer> ().sortingOrder = 0;
	}
}