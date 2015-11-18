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

	#region Monobehaviour
	void Start() {
		this.portrait = transform.GetChild(0).GetComponent<Image>();
		this.health = transform.GetChild(1).GetComponent<Slider>();
		this.name = transform.GetChild(2).GetComponent<Text>();
	}
	#endregion
}
