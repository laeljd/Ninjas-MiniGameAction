using UnityEngine;
using System.Collections;
/// <summary>
/// Grab drag mouse.
/// Can drag the target by holding the mouse button.
/// </summary>
public class GrabDragMouse : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public Transform  targetTransform;
	
	private bool grab;
	private float posX;
	private float posY;

	void Start () {
		this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		this.targetTransform = this.gameObject.GetComponent<Transform>();
	}
	
	void Update () {
		var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var width = spriteRenderer.sprite.rect.width/spriteRenderer.sprite.pixelsPerUnit * targetTransform.localScale.x;
		var height = spriteRenderer.sprite.rect.height/spriteRenderer.sprite.pixelsPerUnit * targetTransform.localScale.y;

		if(Input.GetMouseButtonDown(0)){
			if(mouse.x > targetTransform.position.x - width/2  && mouse.x  < targetTransform.position.x + width/2 &&
			   mouse.y > targetTransform.position.y - height/2 && mouse.y  < targetTransform.position.y + height/2 ){
					grab = true;
					posX = mouse.x - targetTransform.position.x;
					posY = mouse.y - targetTransform.position.y;
			}
		}
		if(Input.GetMouseButtonUp(0)){
			grab = false;
		}

		if(grab){
			targetTransform.position = new Vector3(mouse.x - posX, mouse.y - posY,targetTransform.position.z);
		}

	}
}
