using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Character")]
public class GameCharacter : ScriptableObject
{
	public string characterId;
	public string characterName;
	public Sprite characterImage;

	public GameCharacter(string characterId, string characterName, Sprite characterImage)
	{
		this.characterId = characterId;
		this.characterName = characterName;
		this.characterImage = characterImage;
	}

	public GameCharacter(string characterName, Sprite characterImage)
	{
		this.characterId = System.Guid.NewGuid().ToString();
		this.characterName = characterName;
		this.characterImage = characterImage;
	}
}
