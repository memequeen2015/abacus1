using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Controller2D target;
	public Vector2 focusAreaSize;

	FocusArea focusArea;

	void Start()
	{
		focusArea = new FocusArea (target.collider.bounds, focusAreaSize);
	}

	void LateUpdate()
	{
		focusArea.Update (target.collider.bounds);
	}

	void OnDrawGizmos() {
		Gizmos.color = new Color (1, 0, 0, 0.5f);
		Gizmos.DrawCube (focusArea.center, focusAreaSize);
	}

	struct FocusArea
	{
		public Vector2 center;
		public Vector2 velocity;
		float left, right;
		float top, bot;

		public FocusArea(Bounds targetBounds, Vector2 size)
		{
			left = targetBounds.center.x - size.x/2;
			right = targetBounds.center.x + size.x/2;
			bot = targetBounds.min.y;
			top = targetBounds.min.y + size.y;

			AudioVelocityUpdateMode = Vector2.zero;
			center = new Vector2((left + right) / 2, (top + bot) / 2);
		}

		public void Update(Bounds targetBounds)
		{
			float shiftX = 0;
			if (targetBounds.min.x < left) {
				shiftX = targetBounds.min.x - left;
			} else if (targetBounds.max.x > right) {
				shiftX = targetBounds.max.x - right;
			}
			left += shiftX;
			right += shiftX;

			float shiftY = 0;
			if (targetBounds.min.y < bot) {
				shiftY = targetBounds.min.y - bot;
			} else if (targetBounds.max.y < top) {
				shiftY = targetBounds.max.y - top;
			}
			bot += shiftY;
			top += shiftY;

			center = new Vector2 ((left + right) / 2, (top + bottom) / 2);
			velocity = new Vector2 (shiftX, shiftY);
		}
	}
}
