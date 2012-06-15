using UnityEngine;
using System.Collections;

public class Texture2DTouchListener : MonoBehaviour {

	private static ArrayList arrObject;
	private static bool bBegan;
	private GameObject gObjectTouchOne; 
	private Vector2 vecTemp;

	// Update is called once per frame
	void Update () {
		if(Texture2DTouchListener.arrObject.Count <= 0)
			return;
		if(Input.touchCount == 1){
			foreach(GameObject gObject in Texture2DTouchListener.arrObject){
				if(gObject.guiTexture.HitTest(Input.GetTouch(0).position)){
					if(Input.touches[0].phase == TouchPhase.Began && !bBegan){
						bBegan = !bBegan;
						gObjectTouchOne = gObject;
						vecTemp = Input.GetTouch(0).position;
						gObject.SendMessage("OnMouseDown");
						return;
					}

					if(Input.touches[0].phase == TouchPhase.Ended && gObject.guiTexture == gObjectTouchOne){
						gObject.SendMessage("OnMouseUp");
						return;
					}
				}
			}
		} else if(Input.touchCount == 0 && bBegan){
			if(gObjectTouchOne.guiTexture.HitTest(vecTemp)){
				gObjectTouchOne.SendMessage("OnMouseUp");
			}
			bBegan = false;
			gObjectTouchOne.SendMessage("OnMouseExit");
		}	
	}

	public static bool AddGameObject(GameObject gObject){
		if(Texture2DTouchListener.arrObject == null){
			Texture2DTouchListener.arrObject = new ArrayList();
		}
		if(gObject != null){
			Texture2DTouchListener.arrObject.Add(gObject);
			return true;
		} else {
			return false;
		}
	}

	public static bool RemoveGameObject(GameObject gObject){
		if(arrObject != null && gObject != null){
			Texture2DTouchListener.arrObject.Remove(gObject);
			return true;
		} else {
			return false;
		}
	}
}
