using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private GameObject PanelPrafab;
    [SerializeField] private Transform _root;
    [SerializeField] private GameObject ScoreText;
    [SerializeField] private GameObject TitleButton;
    [SerializeField] private GameObject ContinueButton;
    [SerializeField] private GameObject BackPanel;
    bool bPushButton;
    int nMaginTime;
    int Player1Score, Player2Score, Player1ScoreSPE, Player2ScoreSPE;//スコア保持用（セーブでもらってくる）
    int nStagePanelNUM;//ステージのパネルの総数
    float fPlayer1Percent, fPlayer2Percent;
    Vector2 Player1PanelPos;//パネルを落とす場所の指定（P1）
    Vector2 Player2PanelPos;//パネルを落とす場所の指定（P2）
    bool bSetText;
    bool bStartProduction;//演出フラグ
    GameObject ResultPanel, ResultPanel2;//オブジェクト生成用
    GameObject TitleButtonObj, ContinueButtonObj;
    float ResultMarginX, ResultMarginY;//スコア設置のマージン
    int nPercentPlayer1, nPercentPlayer2;//パネルを並べるための変数
    int nCntPanel1, nCntPanel2;
    const float fFirstPanelPosY = -155.0f;//スコア設置の基準Y
    bool bProductionP1, bProductionP2;
    int nStageSpecialPanelNUM;
    int nCntTime;
    bool bSetButton;

	AudioSource _audioSource;
	AudioClip _audioClip;

    // Use this for initialization
    void Start()
    {
        //ClearConsole();
        nCntPanel1 = 0;
        nCntPanel2 = 0;
        ResultMarginY = 30.0f;
        ResultMarginX = 35.0f;
        Player1PanelPos.x = 385.0f;
        Player1PanelPos.y = -155.0f;
        Player2PanelPos.x = -385.0f;
        Player2PanelPos.y = -155.0f;
        bSetText = false;
        bProductionP1 = false;
        bProductionP2 = false;
        bPushButton = false;
        TitleButtonObj = GameObject.Find("/Canvas/TitleButton");
        ContinueButtonObj = GameObject.Find("/Canvas/ContinueButton");
        TitleButtonObj.SetActive(false);
        ContinueButtonObj.SetActive(false);
        nMaginTime = 2 * 60;
        nCntTime = 0;
        bSetButton = false;

        //データをひっぱってくる
        Player1Score = PlayerPrefs.GetInt("NP_P1");
        Player2Score = PlayerPrefs.GetInt("NP_P2");
        Player1ScoreSPE = PlayerPrefs.GetInt("SP_P1");
        Player2ScoreSPE = PlayerPrefs.GetInt("SP_P2");
        nStagePanelNUM = Player1Score + Player2Score + (Player1ScoreSPE * 2) + (Player2ScoreSPE * 2);

        //割合の計算
        fPlayer1Percent = ((float)Player1Score + ((float)Player1ScoreSPE) * 2) / (float)nStagePanelNUM;
        fPlayer2Percent = (float)(Player2Score + (Player2ScoreSPE * 2)) / (float)nStagePanelNUM;
        nPercentPlayer1 = Mathf.RoundToInt(fPlayer1Percent * 100);
        nPercentPlayer2 = Mathf.RoundToInt(fPlayer2Percent * 100);

		_audioSource = GetComponent<AudioSource> ();
		_audioClip = Resources.Load<AudioClip>("Audio/ResultPro");
    }

    // Update is called once per frame
    void Update()
    {
		
        //プレイヤー1のボタンが押されたら演出スタートのフラグを立てる
        if ((Input.GetButton("Joycon1AButton") || Input.GetButton("Submit") ) && bPushButton != true)
        {

            bPushButton = true;
            if (bStartProduction != true)
            {
                bStartProduction = true;
            }
        }

        //演出
        if (bStartProduction != false)
        {
            if (nPercentPlayer1 > 0)
            {
                nCntPanel1++;
                ResultPanel = Instantiate(PanelPrafab, _root);
                ResultPanel.transform.localPosition = Player1PanelPos;
                ResultPanel.GetComponent<Image>().color = new Color(0.0f, 255f/255f, 100f/255f);
				_audioSource.PlayOneShot (_audioClip);
                if (nCntPanel1 < 10)
                {
                    Player1PanelPos.y += ResultMarginY;
                }
                else
                {
                    nCntPanel1 = 0;
                    Player1PanelPos.x -= ResultMarginX;
                    Player1PanelPos.y = fFirstPanelPosY;
                }

                nPercentPlayer1--;
            }
            else
            {
                
                bProductionP1 = true;
            }

            if (nPercentPlayer2 > 0 && bProductionP2 != true)
            {
                nCntPanel2++;
                ResultPanel2 = Instantiate(PanelPrafab, _root);
                ResultPanel2.transform.localPosition = Player2PanelPos;
                ResultPanel2.GetComponent<Image>().color = new Color(255/255f, 255f/255f, 0.0f);
                if (nCntPanel2 < 10)
                {
                    Player2PanelPos.y += ResultMarginY;
                }
                else
                {
                    nCntPanel2 = 0;
                    Player2PanelPos.x += ResultMarginX;
                    Player2PanelPos.y = fFirstPanelPosY;
                }

                nPercentPlayer2--;
            }
            else
            {
                bProductionP2 = true;
                
            }
        }

        //演出が終わったら文字を出す
        if(bProductionP1 == true && bProductionP2 == true && bSetText != true)
        {
        	int nScore;
            int nScore2;
            string str,str2;
            bSetText = true;
            ResultPanel = Instantiate(BackPanel, _root);
            ResultPanel.transform.localPosition = new Vector2(200, -15);

            ResultPanel = Instantiate(ScoreText, _root);
            ResultPanel.transform.localPosition = new Vector2(200,0);

            nScore = Mathf.RoundToInt(fPlayer1Percent * 100);
            str = nScore.ToString();
            str += "%";
            ResultPanel.GetComponent<Text>().text = str;
            ResultPanel.GetComponent<Text>().color = new Color(0.0f, 255f / 255f, 100f / 255f); ;


            ResultPanel2 = Instantiate(BackPanel, _root);
            ResultPanel2.transform.localPosition = new Vector2(-200, -15);

            ResultPanel2 = Instantiate(ScoreText, _root);
            ResultPanel2.transform.localPosition = new Vector2(-200, 0);
            nScore2 = Mathf.RoundToInt(fPlayer2Percent * 100);
            str2 = nScore2.ToString();
            str2 += "%";
            ResultPanel2.GetComponent<Text>().text = str2;
            ResultPanel2.GetComponent<Text>().color = new Color(255 / 255f, 255f / 255f, 0.0f);
            if(nScore > nScore2)
            {
                str = "WIN!!";
                str2 = "LOSE";
            }
            else if(nScore == nScore2)
            {
                str = "DRAW";
                str2 = "DRAW";
            }
            else
            {
                str2 = "WIN!!";
                str = "LOSE";
            }
            
            ResultPanel = Instantiate(ScoreText, _root);
            ResultPanel.transform.localPosition = new Vector2(200, -40);
            ResultPanel.GetComponent<Text>().text = str;
            ResultPanel.GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f); ;

            ResultPanel = Instantiate(ScoreText, _root);
            ResultPanel.transform.localPosition = new Vector2(-200, -40);
            ResultPanel.GetComponent<Text>().text = str2;
            ResultPanel.GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f); ;
        }

        //すべての文字と演出が終わったら遷移用ボタンの生成
        if (bSetText == true && bSetButton != true)
        {
            if(nCntTime < nMaginTime)
            {
                nCntTime++;
            }
            else
            {
                bSetButton = true;
                //Button button = TitleButtonObj.GetComponent<Button>();
                TitleButtonObj.SetActive(true);
                TitleButtonObj.transform.SetAsLastSibling();
                TitleButtonObj.GetComponent<Button>().Select();
                //button.onClick()
                ContinueButtonObj.SetActive(true);
                ContinueButtonObj.transform.SetAsLastSibling();
            }
            
        }

    }

    static void ClearConsole()
    {
        var logEntries = System.Type.GetType("UnityEditorInternal.LogEntries,UnityEditor.dll");
        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        clearMethod.Invoke(null, null);
    }
}
