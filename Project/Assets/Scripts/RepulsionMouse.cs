using UnityEngine;
using System.Collections;

public class RepulsionMouse : MonoBehaviour {
	
	public SpriteRenderer spriteRenderer;
	public Transform  targetTransform;
	
	private float directionX;
	private float directionY;
	private float ray;
	private float force;
	
	void Start () {
		this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		this.targetTransform = this.gameObject.GetComponent<Transform>();
		this.ray = 3f;
	}
	
	void Update () {
		var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var width = spriteRenderer.sprite.rect.width /spriteRenderer.sprite.pixelsPerUnit * targetTransform.localScale.x;
		var height = spriteRenderer.sprite.rect.height /spriteRenderer.sprite.pixelsPerUnit * targetTransform.localScale.y;

		if(mouse.x > targetTransform.position.x - width/2 - ray &&
		   mouse.x < targetTransform.position.x + width/2 + ray &&
		   mouse.y > targetTransform.position.y - height/2 - ray &&
		   mouse.y < targetTransform.position.y + height/2 + ray ){


			//var mod = Mathf.Sqrt(Mathf.Pow((targetTransform.position.x - mouse.x),2)+ Mathf.Pow((targetTransform.position.y - mouse.y),2));
			var mod2 = Mathf.Pow((targetTransform.position.x - mouse.x),2) + Mathf.Pow((targetTransform.position.y - mouse.y),2);

			directionX = ((targetTransform.position.x - mouse.x) / mod2);
			directionY = ((targetTransform.position.y - mouse.y) / mod2);

			this.force = 20;
			//Debug.Log("dentro");	
		}else{
			//Debug.Log("fora");
		}
		
		if(targetTransform.position.x - width/2 <= -Camera.main.orthographicSize * Screen.width/Screen.height){
			directionX = Mathf.Abs(directionX);
		}
		if(targetTransform.position.x + width/2 >= Camera.main.orthographicSize * Screen.width/Screen.height){
			directionX = -Mathf.Abs(directionX);
		}
		if(targetTransform.position.y - height/2 <= -Camera.main.orthographicSize){
			directionY = Mathf.Abs(directionY);
		}
		if(targetTransform.position.y + height/2 >= Camera.main.orthographicSize){
			directionY = -Mathf.Abs(directionY);
		}

		transform.Translate(directionX * force * Time.deltaTime ,directionY * force * Time.deltaTime ,0);
		if(this.force > 0){
			//this.force -=  this.force* Time.deltaTime;
			//this.force -=  Time.deltaTime;
		}else{
			this.force = 0;
		}
	}
}