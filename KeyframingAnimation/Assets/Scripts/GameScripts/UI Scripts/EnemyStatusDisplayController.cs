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
	private Text t_name;
	public Image background;

	private Enemy enemy;

	private float timer;
	#endregion

	#region Accessors
	public Enemy Enemy{
		get {return enemy;}
		set {
			this.portrait.sprite = value.Portrait;
			this.health.value = value.HP / value.MaxHP;
			this.t_name.text = value.e_name;

			this.timer = 10.0f;
			this.ShowUI();
		}
	}
	#endregion

	#region Monobehaviour
	void Start() {
		this.portrait = transform.GetChild(0).GetComponent<Image>();
		this.health = transform.GetChild(1).GetComponent<Slider>();
		this.t_name = transform.GetChild(2).GetComponent<Text>();

		this.timer = 10.0f;
		this.background = this.GetComponent<Image>();

		this.HideUI();
	}

	void Update() {
		this.timer -= Time.deltaTime;

		if (this.timer < 0) {
			this.HideUI();
		}
	}
	#endregion

	#region Helpers
	void HideUI() {
		this.portrait.enabled = false;
		this.health.gameObject.SetActive(false);
		this.t_name.enabled = false;

		this.background.enabled = false;
	}

	void ShowUI() {
		this.portrait.enabled = true;
		this.health.gameObject.SetActive(true);
		this.t_name.enabled = true;

		this.background.enabled = true;
	}
	#endregion
}
