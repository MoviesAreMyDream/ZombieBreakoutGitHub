using UnityEngine;
using System.Collections;

public class EndGameResults : MonoBehaviour {

    public CustomText ZombieKillNum;
    public CustomText DynamiteNum;
    public CustomText RankNum;

    private GameObject ScrManagerGO;
    private ScoreManager ScrManager;
    private float ZombieKill;
    private float DynCount;
    public string Rank; 

	void Start () {
        ScrManagerGO = GameObject.Find("GameManager");
        ScrManager = ScrManagerGO.GetComponent<ScoreManager>();
        ZombieKill = ScrManager.CurrentScore;
		DynCount = ScrManager.DynamiteCount;

        ZombieKillNum.text = ZombieKill.ToString();
        DynamiteNum.text = DynCount.ToString();
        

        
    }
	
	void Update () {

        RankNum.text = Rank.ToString();

        if (ZombieKill <= 150)
            Rank = "F";
        if ((ZombieKill >= 151) && (ZombieKill <= 200))
            Rank = "D";
        if ((ZombieKill >= 201) && (ZombieKill <= 250))
            Rank = "C";
        if ((ZombieKill >= 251) && (ZombieKill <= 300))
            Rank = "B";
        if ((ZombieKill >= 301) && (ZombieKill <= 350))
            Rank = "A";
        if (ZombieKill >= 351)
            Rank = "S";
    }
}
