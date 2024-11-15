using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleControler : MonoBehaviour
{
	public float speed = 5f;

    private string Verticais;

    public Vector2 limits = new Vector2(-4.5f, 4.5f);

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        Verticais = isPlayer ? "VerticalArrows" : "VerticalWS";

        if (isPlayer)
            spriteRenderer.color = SaveController.Instance.colorPlayer;
        else
            spriteRenderer.color = SaveController.Instance.colorEnemy;
    }

    void Update()
	{
		float moveInput = Input.GetAxis(Verticais);
		Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
		newPosition.y = Mathf.Clamp(newPosition.y, limits.x, limits.y);
		transform.position = newPosition;
	}
}
