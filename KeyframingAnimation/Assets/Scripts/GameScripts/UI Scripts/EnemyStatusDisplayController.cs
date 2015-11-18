using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Enemy status display controller.
/// </summary>
public class EnemyStatusDisplayController : MonoBehaviour {

	#region Private Members
	private Image portrait;
	private Slider health;
	private Text name;

	private Enemy enemy;
	#endregion

	#region Accessors
	public Enemy Enemy{
		get {return enemy;}
		set {
			this.portrait.sprite = value.Portrait;
			this.health.value = value.HP / value.MaxHP;
			this.name.text = value.name;
		}
	}
	#endregion
}
