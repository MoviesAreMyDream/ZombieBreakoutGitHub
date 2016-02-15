using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AntidoteUI : MonoBehaviour {
	
	private GameObject AntidoteNumGO;
	private Text AntidoteNum;
	
	private GameObject PlayerGO;
	private PlayerHealthNewChar PHealth;
	[ReadOnlyAttribute]
	public float AntidoteAmount;
	
	void Start ()
	{
		AntidoteNumGO = GameObject.Find("AntidoteNum");
		AntidoteNum = AntidoteNumGO.GetComponent<Text>();
		
		PlayerGO = GameObject.FindGameObjectWithTag("Player");
		PHealth = PlayerGO.GetComponent<PlayerHealthNewChar>();
	}
	
	void Update ()
	{
		AntidoteNum.text = PHealth.AntidoteAmount.ToString();
		AntidoteAmount = PHealth.AntidoteAmount;
	}
}
