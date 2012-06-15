using UnityEngine;
using System.Collections;

public class Texture2DTouch: MonoBehaviour {

	public bool percentage;
	public float x;
	public float y;
	public Texture textureDown,textureUP,textureEnter,textureExit;

	private float width;
	private float height;
	private float px;
	private float py;
	private Texture2DTouchImp tti;

	void Start(){
		if(!Texture2DTouchListener.AddGameObject(gameObject)){
			Debug.Log("Texture2DTouchListener.AddGameObject Error");
		}
		if(textureEnter != null && textureExit == null)
			textureExit = guiTexture.texture;
	}

	private void init(){
		if(percentage){
			px = (1 / 100f) * x;
			py = (1 / 100f) * y;
		} else {
			width = Screen.width;
			height = Screen.height;
			px = (1 / width) * x;
			py = (1 / height) * y;
		}

	}

	public void SetX(float x){
		this.x = x;
	}

	public void SetY(float y){
		this.y = y;
	}

	public void Reload(){
		init();
		transform.position = new Vector2(px,py);
	}
	
//    this is mouse event.
	void OnMouseDown(){
		if(transform == null){
			Debug.Log("Transform is null");
		}
		if(this.tti != null){
			textureUP = guiTexture.texture;
			guiTexture.texture = textureDown;
			this.tti.OnEvent(gameObject.name,GUIEvent.DOWN,transform);
		}
	}

	void OnMouseUp(){
		if(this.tti != null){
			guiTexture.texture = textureUP;
			this.tti.OnEvent(gameObject.name,GUIEvent.UP,transform);
		}
	}

	void OnMouseEnter(){
		if(this.tti != null && textureEnter != null){
			guiTexture.texture = textureEnter;
			this.tti.OnEvent(gameObject.name,GUIEvent.ENTER,transform);
		}
	}

	void OnMouseExit(){
		if(this.tti != null && textureExit != null){
			guiTexture.texture = textureExit;//Resources.Load("",typeof(Texture2D)) as Texture;
			this.tti.OnEvent(gameObject.name,GUIEvent.EXIT,transform);
		}
	}

	public void SetCoorTransformImp(Texture2DTouchImp tti){
		this.tti = tti;
	}
}
