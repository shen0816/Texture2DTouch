using UnityEngine;
using System.Collections;
//using Texture2DTouch;
public class example : MonoBehaviour , Texture2DTouchImp {
	
	private Texture2DTouch[] tt;
	// Use this for initialization
	void Start () {
		int size = transform.childCount;
		tt = new Texture2DTouch[size];
		for(int i = 0 ;i < size ;i++){
			tt[i] = transform.Find("button_" + (i + 1)).GetComponent<Texture2DTouch>();
			tt[i].SetX(100f);
			tt[i].SetY(50f + 80f * i);
			tt[i].Reload();
			tt[i].SetCoorTransformImp(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label(new Rect(0,20,100,20),str1);
		GUI.Label(new Rect(0,40,100,20),str2);
		GUI.Label(new Rect(0,60,200,20),str3);
	}
	
	private string str1,str2,str3;
	public void OnEvent(string name,int e,Transform t){
		str1 = "name = " + name ;
		Debug.Log("name = " + name);
		str2 = "Event = " + e;
		Debug.Log("Event = " + e);
		str3 = "Transform = " + (t != null);
		Debug.Log("Transform = " + (t != null));	
	}
}
