using UnityEngine;
using System.Collections;

public class Rank : MonoBehaviour {

	public float ZombieAScore = 10.0f;
	public float ZombieBScore = 25.0f;
	public float ZombieCScore = 35.0f;
	public float DynamiteScore = 30.0f;
	
	public float CurrentScore;
	public float DynamiteCount;
	private string RankScore;
	
	private GameObject ScoreNumGO;
	private CustomText ScoreNum;
	private Animation ScoreAnim;
	
	private GameObject ScorePlusGO;
	private CustomText ScorePlus;
	private Animation ScorePlusAnim;
	
	private GameObject DynamiteNumGO;
	private CustomText PortalNum;
	private Animation DynamiteAnim;
	
	private GameObject DynamitPlusGO;
	private CustomText DynamitePlus;
	private Animation DynamitePlusAnim;
	
	private GameObject RankNumGO;
	private CustomText RankNum;


	// Use this for initialization
	void Start () {

		RankNumGO = GameObject.Find("RankNum");
		RankNum = RankNumGO.GetComponent<CustomText>();

		ScorePlus.text = "";
		DynamitePlus.text = "";
		
		CurrentScore = 0;
		DynamiteCount = 0;
		RankScore = "";
	}
	
	// Update is called once per frame
	void Update () {
	
		ScoreNum.text = CurrentScore.ToString();
		PortalNum.text = DynamiteCount.ToString();
		RankNum.text = RankScore;

		
		if (CurrentScore <= 40)
			RankScore = "F";
		if ((CurrentScore >= 41) && (CurrentScore <= 80))
			RankScore = "D";
		if ((CurrentScore >= 81) && (CurrentScore <= 100))
			RankScore = "C";
		if ((CurrentScore >= 101) && (CurrentScore <= 120))
			RankScore = "B";
		if ((CurrentScore >= 121) && (CurrentScore <= 140))
			RankScore = "A";
		if (CurrentScore >= 141) 
			RankScore = "S";

	}
}
