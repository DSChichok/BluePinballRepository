using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionsAndBossesScript : MonoBehaviour
{
    //Music
    public GameObject Music;
    public GameObject BossDefeat;

    public GameObject Rocker;
    public GameObject Spear;
    public GameObject Heart;
    public GameObject Ones;
    public GameObject Zeros;

    public GameObject Parenting;
    public GameObject Minion01;
    public GameObject Minion02;
    public GameObject Minion03;
    public GameObject Minion04;
    public GameObject Minion05;
    public GameObject Minion06;
    public GameObject Minion2Special;
    public GameObject Boss01;
    public GameObject Boss02;
    public GameObject Boss03;
    public GameObject Boss04;
    public GameObject Boss05;
    public GameObject Boss06;
    public GameObject Boss07;
    public Text WaveAnnounce;
    public AudioSource Audio;
    public AudioClip AudioClip_RegenerateMinions;

    //Circle 1
    public GameObject Follow00;
    public GameObject Follow01;
    public GameObject Follow02;
    public GameObject Follow03;
    public GameObject Follow04;
    public GameObject Follow05;
    public GameObject Follow06;
    public GameObject Follow07;

    //Circle 1 X
    public GameObject X00;
    public GameObject X01;
    public GameObject X02;
    public GameObject X03;
    public GameObject X04;
    public GameObject X05;
    public GameObject X06;
    public GameObject X07;
    public GameObject X08;
    public GameObject X09;
    public GameObject X10;
    public GameObject X11;
    public GameObject X12;

    //Circle 2 X
    public GameObject Y00;
    public GameObject Y01;
    public GameObject Y02;
    public GameObject Y03;
    public GameObject Y04;
    public GameObject Y05;
    public GameObject Y06;
    public GameObject Y07;
    public GameObject Y08;
    public GameObject Y09;
    public GameObject Y10;
    public GameObject Y11;
    public GameObject Y12;
    public GameObject Y13;
    public GameObject Y14;
    public GameObject Y15;

    //Reverse Circle
    public GameObject Z00;
    public GameObject Z01;
    public GameObject Z02;
    public GameObject Z03;
    public GameObject Z04;
    public GameObject Z05;
    public GameObject Z06;
    public GameObject Z07;

    //Side to Side
    public GameObject SS0;
    public GameObject SS1;
    public GameObject SS2;
    public GameObject SS3;
    public GameObject SS4;
    public GameObject SS5;

    //Plus
    public GameObject P00;
    public GameObject P01;
    public GameObject P02;
    public GameObject P03;
    public GameObject P04;
    public GameObject P05;
    public GameObject P06;
    public GameObject P07;
    public GameObject P08;
    public GameObject Q00;
    public GameObject Q01;
    public GameObject Q02;
    public GameObject Q03;
    public GameObject Q04;
    public GameObject Q05;
    public GameObject Q06;
    public GameObject Q07;
    public GameObject Q08;

    //CircleLeftAndRight
    public GameObject V00;
    public GameObject V01;
    public GameObject V02;
    public GameObject V03;
    public GameObject V04;
    public GameObject V05;
    public GameObject V06;
    public GameObject V07;

    //RA
    public GameObject RA00;
    public GameObject RA01;
    public GameObject RA02;
    public GameObject RA03;
    public GameObject RA04;
    public GameObject RA05;
    public GameObject RA06;
    public GameObject RA07;
    public GameObject RA08;
    public GameObject RA09;
    public GameObject RA10;
    public GameObject RA11;
    public GameObject RA12;
    public GameObject RA13;

    //public CircleFollow
    public GameObject LS00;
    public GameObject LS01;
    public GameObject LS02;
    public GameObject LS03;
    public GameObject LS04;
    public GameObject LS05;
    public GameObject LS06;
    public GameObject LS07;
    public GameObject LT00;
    public GameObject LT01;
    public GameObject LT02;
    public GameObject LT03;
    public GameObject LT04;
    public GameObject LT05;
    public GameObject LT06;
    public GameObject LT07;

    bool BossMode = false;
    bool FinalBoss = false;
    bool DetectingMinions = false;
    bool LoadNextWave = false;
    int WaveCount = 1;
    int Stage = 0;
    int BossCount = 0;
    bool BossDefeated = false;
    bool BossLoaded = false;
    bool HeartLeft = true;

    // Use this for initialization
    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        BossLoaded = false;
        BossDefeated = false;
        BossCount = 0;
        FinalBoss = false;
        BossMode = false;
        Audio.loop = false;
        Level1Wave1();
        DetectingMinions = true;
        LoadNextWave = false;
        Stage = 0;
        WaveCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (BossMode)
        {
            BossTime();
        }
        else  //Minion Mode
        {
            if (GameObject.FindGameObjectsWithTag("Minion").Length == 0)
            {
                LoadNextWave = true;
            }
            MinionTime();
        }
    }

    public void StartNextStage()
    {
        Stage++;
        if (Stage > 5)
        {
            Stage = 0;
        }

        if (Stage == 0)
        {
            Level1Wave1();
        }
        else if (Stage == 1)
        {
            Level2Wave1();
        }
        else if (Stage == 2)
        {
            Level3Wave1();
        }
        else if (Stage == 3)
        {
            Level4Wave1();
        }
        else if (Stage == 4)
        {
            Level5Wave1();
        }
        else if (Stage == 5)
        {
            Level6Wave1();
        }

        BossMode = false;
        BossLoaded = false;
        LoadNextWave = false;
        WaveCount = 1;
        LoadNextWave = false;
    }

    void BossTime()
    {
        if (FinalBoss)
        {

        }
        else //Bosses 1-6
        {
            if (!BossLoaded)
            {
                if (BossCount == 0) //Boss 1
                {
                    Boss1Go();
                }
                else if (BossCount == 1) //Boss 2
                {
                    Boss2Go();
                }
                else if (BossCount == 2) //Boss 3
                {
                    Boss3Go();
                }
                else if (BossCount == 3) //Boss 4
                {
                    Boss4Go();
                }
                else if (BossCount == 4) //Boss 5
                {
                    Boss5Go();
                }
                else if (BossCount == 5) //Boss 6
                {
                    Boss6Go();
                }
                Music.GetComponent<MusicPlayerScript>().PlayBossTrack();
                BossDefeat.GetComponent<BossDefeaterScript>().PlayBossAnnounce();
                BossLoaded = true;
                BossCount++;
                if (BossCount > 5)
                {
                    BossCount = 0;
                }
            }
        }
    }

    void MinionTime()
    {
        if (Stage == 0)
        {
            Stage1Minions();
        }
        else if (Stage == 1)
        {
            Stage2Minions();
        }
        else if (Stage == 2)
        {
            Stage3Minions();
        }
        else if (Stage == 3)
        {
            Stage4Minions();
        }
        else if (Stage == 4)
        {
            Stage5Minions();
        }
        else if (Stage == 5)
        {
            Stage6Minions();
        }
    }

    //Remember, wave 1 already has their 1st wave out from the start
    void Stage1Minions()
    {
        if (LoadNextWave)
        {
            if (WaveCount == 0) //Therfore this particular one is only for the wrapping games
            {
                Level1Wave1();
            }
            else if (WaveCount == 1)
            {
                Level1Wave2();
            }
            else if (WaveCount == 2)
            {
                Level1Wave3();
            }
            else if (WaveCount == 3)
            {
                Level1Wave4();
            }
            else
            {
                BossMode = true;
            }
            WaveCount++;
            LoadNextWave = false;
        }
    }

    void Stage2Minions()
    {
        if (LoadNextWave)
        {
            if (WaveCount == 0) //Therfore this particular one is only for the wrapping games
            {
                Level2Wave1();

            }
            else if (WaveCount == 1)
            {
                Level2Wave2();
            }
            else if (WaveCount == 2)
            {
                Level2Wave3();
            }
            else if (WaveCount == 3)
            {
                Level2Wave4();
            }
            else
            {
                BossMode = true;
            }
            WaveCount++;
            LoadNextWave = false;
        }
    }

    void Stage3Minions()
    {
        if (LoadNextWave)
        {
            if (WaveCount == 0) //Therfore this particular one is only for the wrapping games
            {
                Level3Wave1();

            }
            else if (WaveCount == 1)
            {
                Level3Wave2();
            }
            else if (WaveCount == 2)
            {
                Level3Wave3();
            }
            else if (WaveCount == 3)
            {
                Level3Wave4();
            }
            else
            {
                BossMode = true;
            }
            WaveCount++;
            LoadNextWave = false;
        }
    }

    void Stage4Minions()
    {
        if (LoadNextWave)
        {
            if (WaveCount == 0) //Therfore this particular one is only for the wrapping games
            {
                Level4Wave1();

            }
            else if (WaveCount == 1)
            {
                Level4Wave2();
            }
            else if (WaveCount == 2)
            {
                Level4Wave3();
            }
            else if (WaveCount == 3)
            {
                Level4Wave4();
            }
            else
            {
                BossMode = true;
            }
            WaveCount++;
            LoadNextWave = false;
        }
    }

    void Stage5Minions()
    {
        if (LoadNextWave)
        {
            if (WaveCount == 0) //Therfore this particular one is only for the wrapping games
            {
                Level5Wave1();

            }
            else if (WaveCount == 1)
            {
                Level5Wave2();
            }
            else if (WaveCount == 2)
            {
                Level5Wave3();
            }
            else if (WaveCount == 3)
            {
                Level5Wave4();
            }
            else
            {
                BossMode = true;
            }
            WaveCount++;
            LoadNextWave = false;
        }
    }

    void Stage6Minions()
    {
        if (LoadNextWave)
        {
            if (WaveCount == 0) //Therfore this particular one is only for the wrapping games
            {
                Level6Wave1();

            }
            else if (WaveCount == 1)
            {
                Level6Wave2();
            }
            else if (WaveCount == 2)
            {
                Level6Wave3();
            }
            else if (WaveCount == 3)
            {
                Level6Wave4();
            }
            else
            {
                BossMode = true;
            }
            WaveCount++;
            LoadNextWave = false;
        }
    }

    void Level1Wave1()
    {
        SetStillMinion(Minion01, new Vector2(0f, 2f));
        SetStillMinion(Minion01, new Vector2(1f, 3f));
        SetStillMinion(Minion01, new Vector2(-1f, 3f));
        SetStillMinion(Minion01, new Vector2(2f, 2f));
        SetStillMinion(Minion01, new Vector2(-2f, 2f));
        SetStillMinion(Minion01, new Vector2(-3f, 3f));
        SetStillMinion(Minion01, new Vector2(3f, 3f));
        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level1Wave2()
    {
        //Mouth
        SetStillMinion(Minion01, new Vector2(-1.5f, 1f));
        SetStillMinion(Minion01, new Vector2(1.5f, 1f));
        SetStillMinion(Minion01, new Vector2(-1.5f, 1.5f));
        SetStillMinion(Minion01, new Vector2(1.5f, 1.5f));
        SetStillMinion(Minion01, new Vector2(-1f, 2f));
        SetStillMinion(Minion01, new Vector2(1f, 2f));
        SetStillMinion(Minion01, new Vector2(-.5f, 2f));
        SetStillMinion(Minion01, new Vector2(.5f, 2f));
        SetStillMinion(Minion01, new Vector2(0f, 2f));

        //Eyes
        SetStillMinion(Minion01, new Vector2(-.75f, 3.25f));
        SetStillMinion(Minion01, new Vector2(.75f, 3.25f));

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level1Wave3()
    {
        SetFollowingMinion(Minion01, Follow00);
        SetFollowingMinion(Minion01, Follow01);
        SetFollowingMinion(Minion01, Follow02);
        SetFollowingMinion(Minion01, Follow03);
        SetFollowingMinion(Minion01, Follow04);
        SetFollowingMinion(Minion01, Follow05);
        SetFollowingMinion(Minion01, Follow06);
        SetFollowingMinion(Minion01, Follow07);

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level1Wave4()
    {
        SetFollowingMinion(Minion01, X00);
        SetFollowingMinion(Minion01, X01);
        SetFollowingMinion(Minion01, X02);
        SetFollowingMinion(Minion01, X03);
        SetFollowingMinion(Minion01, X04);
        SetFollowingMinion(Minion01, X05);
        SetFollowingMinion(Minion01, X06);
        SetFollowingMinion(Minion01, X07);
        SetFollowingMinion(Minion01, X08);
        SetFollowingMinion(Minion01, X09);
        SetFollowingMinion(Minion01, X10);
        SetFollowingMinion(Minion01, X11);
        SetFollowingMinion(Minion01, X12);

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level2Wave1()
    {
        SetStillMinion(Minion02, new Vector2(0f, 2f));
        SetStillMinion(Minion02, new Vector2(1f, 3f));
        SetStillMinion(Minion02, new Vector2(-1f, 3f));
        SetStillMinion(Minion02, new Vector2(2f, 2f));
        SetStillMinion(Minion02, new Vector2(-2f, 2f));
        SetStillMinion(Minion02, new Vector2(-3f, 3f));
        SetStillMinion(Minion02, new Vector2(3f, 3f));
        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level2Wave2()
    {
        SetStillMinion(Minion02, new Vector2(0f, 1.5f));
        SetStillMinion(Minion02, new Vector2(0f, 3f));
        SetStillMinion(Minion02, new Vector2(0f, 4.5f));
        SetStillMinion(Minion02, new Vector2(1.5f, 1.5f));
        SetStillMinion(Minion02, new Vector2(1.5f, 3f));
        SetStillMinion(Minion02, new Vector2(1.5f, 4.5f));
        SetStillMinion(Minion02, new Vector2(-1.5f, 1.5f));
        SetStillMinion(Minion02, new Vector2(-1.5f, 3f));
        SetStillMinion(Minion02, new Vector2(-1.5f, 4.5f));
        SetStillMinion(Minion02, new Vector2(3f, 1.5f));
        SetStillMinion(Minion02, new Vector2(3f, 3f));
        SetStillMinion(Minion02, new Vector2(3f, 4.5f));
        SetStillMinion(Minion02, new Vector2(-3f, 1.5f));
        SetStillMinion(Minion02, new Vector2(-3f, 3f));
        SetStillMinion(Minion02, new Vector2(-3f, 4.5f));

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level2Wave3()
    {
        SetFollowingMinion(Minion02, Y00);
        SetFollowingMinion(Minion02, Y01);
        SetFollowingMinion(Minion02, Y02);
        SetFollowingMinion(Minion02, Y03);
        SetFollowingMinion(Minion02, Y04);
        SetFollowingMinion(Minion02, Y05);
        SetFollowingMinion(Minion02, Y06);
        SetFollowingMinion(Minion02, Y07);
        SetFollowingMinion(Minion02, Y08);
        SetFollowingMinion(Minion02, Y09);
        SetFollowingMinion(Minion02, Y10);
        SetFollowingMinion(Minion02, Y11);
        SetFollowingMinion(Minion02, Y12);
        SetFollowingMinion(Minion02, Y13);
        SetFollowingMinion(Minion02, Y14);
        SetFollowingMinion(Minion02, Y15);

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level2Wave4()
    {
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level3Wave1()
    {
        SetStillMinion(Minion03, new Vector2(0f, 2f));
        SetStillMinion(Minion03, new Vector2(1f, 3f));
        SetStillMinion(Minion03, new Vector2(-1f, 3f));
        SetStillMinion(Minion03, new Vector2(2f, 2f));
        SetStillMinion(Minion03, new Vector2(-2f, 2f));
        SetStillMinion(Minion03, new Vector2(-3f, 3f));
        SetStillMinion(Minion03, new Vector2(3f, 3f));
        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level3Wave2()
    {
        SetStillMinion(Minion03, new Vector2(-.5f, 1f));
        SetStillMinion(Minion03, new Vector2(.5f, 1f));
        SetStillMinion(Minion03, new Vector2(-.5f, 2f));
        SetStillMinion(Minion03, new Vector2(.5f, 2f));
        SetStillMinion(Minion03, new Vector2(-1.5f, 1f));
        SetStillMinion(Minion03, new Vector2(1.5f, 1f));
        SetStillMinion(Minion03, new Vector2(-1.5f, 2f));
        SetStillMinion(Minion03, new Vector2(1.5f, 2f));
        SetStillMinion(Minion03, new Vector2(-.5f, 3f));
        SetStillMinion(Minion03, new Vector2(.5f, 3f));
        SetStillMinion(Minion03, new Vector2(-1.5f, 3f));
        SetStillMinion(Minion03, new Vector2(1.5f, 3f));
        SetStillMinion(Minion03, new Vector2(-.5f, 4f));
        SetStillMinion(Minion03, new Vector2(.5f, 4f));
        SetStillMinion(Minion03, new Vector2(-1.5f, 4f));
        SetStillMinion(Minion03, new Vector2(1.5f, 4f));

        SetStillMinion(Minion03, new Vector2(0f, 5f));
        SetStillMinion(Minion03, new Vector2(1f, 5f));
        SetStillMinion(Minion03, new Vector2(-1f, 5f));

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level3Wave3()
    {
        SetFollowingMinion(Minion03, Follow00);
        SetFollowingMinion(Minion03, Follow01);
        SetFollowingMinion(Minion03, Follow02);
        SetFollowingMinion(Minion03, Follow03);
        SetFollowingMinion(Minion03, Follow04);
        SetFollowingMinion(Minion03, Follow05);
        SetFollowingMinion(Minion03, Follow06);
        SetFollowingMinion(Minion03, Follow07);
        SetFollowingMinion(Minion03, Z00);
        SetFollowingMinion(Minion03, Z01);
        SetFollowingMinion(Minion03, Z02);
        SetFollowingMinion(Minion03, Z03);
        SetFollowingMinion(Minion03, Z04);
        SetFollowingMinion(Minion03, Z05);
        SetFollowingMinion(Minion03, Z06);
        SetFollowingMinion(Minion03, Z07);

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level3Wave4()
    {
        SetStillMinion(Minion03, new Vector2(0f, 1f));
        SetStillMinion(Minion03, new Vector2(1f, 2f));
        SetStillMinion(Minion03, new Vector2(-1f, 2f));
        SetStillMinion(Minion03, new Vector2(1f, 0f));
        SetStillMinion(Minion03, new Vector2(-1f, 0f));
        SetStillMinion(Minion03, new Vector2(2f, 3f));
        SetStillMinion(Minion03, new Vector2(-2f, 3f));
        SetStillMinion(Minion03, new Vector2(2f, -1f));
        SetStillMinion(Minion03, new Vector2(-2f, -1f));
        SetStillMinion(Minion03, new Vector2(3f, 4f));
        SetStillMinion(Minion03, new Vector2(-3f, 4f));
        SetStillMinion(Minion03, new Vector2(3f, -2f));
        SetStillMinion(Minion03, new Vector2(-3f, -2f));

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level4Wave1()
    {
        SetStillMinion(Minion04, new Vector2(0f, 2f));
        SetStillMinion(Minion04, new Vector2(1f, 3f));
        SetStillMinion(Minion04, new Vector2(-1f, 3f));
        SetStillMinion(Minion04, new Vector2(2f, 2f));
        SetStillMinion(Minion04, new Vector2(-2f, 2f));
        SetStillMinion(Minion04, new Vector2(-3f, 3f));
        SetStillMinion(Minion04, new Vector2(3f, 3f));
        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level4Wave2()
    {
        SetStillMinion(Minion04, new Vector2(0f, 1f));
        SetStillMinion(Minion04, new Vector2(1f, 2f));
        SetStillMinion(Minion04, new Vector2(2f, 3f));
        SetStillMinion(Minion04, new Vector2(2.1f, 2.1f));
        SetStillMinion(Minion04, new Vector2(1.1f, 3.1f));
        SetStillMinion(Minion04, new Vector2(-1f, 0f));
        SetStillMinion(Minion04, new Vector2(-2f, -1f));
        SetStillMinion(Minion04, new Vector2(.2f, 3.2f));
        SetStillMinion(Minion04, new Vector2(2.2f, 1.2f));

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level4Wave3()
    {
        SetFollowingMinion(Minion04, SS0);
        SetFollowingMinion(Minion04, SS1);
        SetFollowingMinion(Minion04, SS2);
        SetFollowingMinion(Minion04, SS3);
        SetFollowingMinion(Minion04, SS4);
        SetFollowingMinion(Minion04, SS5);

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level4Wave4()
    {
        SetFollowingMinion(Minion04, P00);
        SetFollowingMinion(Minion04, P01);
        SetFollowingMinion(Minion04, P02);
        SetFollowingMinion(Minion04, P03);
        SetFollowingMinion(Minion04, P04);
        SetFollowingMinion(Minion04, P05);
        SetFollowingMinion(Minion04, P06);
        SetFollowingMinion(Minion04, P07);
        SetFollowingMinion(Minion04, P08);
        SetFollowingMinion(Minion04, Q00);
        SetFollowingMinion(Minion04, Q01);
        SetFollowingMinion(Minion04, Q02);
        SetFollowingMinion(Minion04, Q03);
        SetFollowingMinion(Minion04, Q04);
        SetFollowingMinion(Minion04, Q05);
        SetFollowingMinion(Minion04, Q06);
        SetFollowingMinion(Minion04, Q07);
        SetFollowingMinion(Minion04, Q08);

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level5Wave1()
    {
        SetStillMinion(Minion05, new Vector2(0f, 2f));
        SetStillMinion(Minion05, new Vector2(1f, 3f));
        SetStillMinion(Minion05, new Vector2(-1f, 3f));
        SetStillMinion(Minion05, new Vector2(2f, 2f));
        SetStillMinion(Minion05, new Vector2(-2f, 2f));
        SetStillMinion(Minion05, new Vector2(-3f, 3f));
        SetStillMinion(Minion05, new Vector2(3f, 3f));
        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level5Wave2()
    {
        SetStillMinion(Minion05, new Vector2(0f, 3f));
        SetStillMinion(Minion05, new Vector2(1f, 4f));
        SetStillMinion(Minion05, new Vector2(-1f, 4f));
        SetStillMinion(Minion05, new Vector2(2f, 4f));
        SetStillMinion(Minion05, new Vector2(-2f, 4f));
        SetStillMinion(Minion05, new Vector2(3f, 3f));
        SetStillMinion(Minion05, new Vector2(-3f, 3f));
        SetStillMinion(Minion05, new Vector2(3f, 2f));
        SetStillMinion(Minion05, new Vector2(-3f, 2f));
        SetStillMinion(Minion05, new Vector2(2f, 1f));
        SetStillMinion(Minion05, new Vector2(-2f, 1f));
        SetStillMinion(Minion05, new Vector2(1f, 0f));
        SetStillMinion(Minion05, new Vector2(-1f, 0f));
        SetStillMinion(Minion05, new Vector2(0f, -1f));
        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level5Wave3()
    {
        SetStillMinion(Minion05, new Vector2(0f, 4f));
        SetStillMinion(Minion05, new Vector2(-.5f, 3f));
        SetStillMinion(Minion05, new Vector2(.5f, 3f));
        SetStillMinion(Minion05, new Vector2(-1f, 2f));
        SetStillMinion(Minion05, new Vector2(1f, 2f));
        SetStillMinion(Minion05, new Vector2(-1.5f, 1f));
        SetStillMinion(Minion05, new Vector2(1.5f, 1f));
        SetStillMinion(Minion05, new Vector2(-2.2f, 2f));
        SetStillMinion(Minion05, new Vector2(2.2f, 2f));
        SetStillMinion(Minion05, new Vector2(-3.3f, 2f));
        SetStillMinion(Minion05, new Vector2(3.3f, 2f));
        SetStillMinion(Minion05, new Vector2(-2f, 0f));
        SetStillMinion(Minion05, new Vector2(2f, 0f));
        SetStillMinion(Minion05, new Vector2(-2.5f, -1f));
        SetStillMinion(Minion05, new Vector2(2.5f, -1f));
        SetStillMinion(Minion05, new Vector2(-1.2f, 0f));
        SetStillMinion(Minion05, new Vector2(1.2f, 0f));
        SetStillMinion(Minion05, new Vector2(-.6f, 1f));
        SetStillMinion(Minion05, new Vector2(.6f, 1f));
        SetStillMinion(Minion05, new Vector2(-2.7f, 1f));
        SetStillMinion(Minion05, new Vector2(2.7f, 1f));

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level5Wave4()
    {
        SetFollowingMinion(Minion05, V00);
        SetFollowingMinion(Minion05, V01);
        SetFollowingMinion(Minion05, V02);
        SetFollowingMinion(Minion05, V03);
        SetFollowingMinion(Minion05, V04);
        SetFollowingMinion(Minion05, V05);
        SetFollowingMinion(Minion05, V06);
        SetFollowingMinion(Minion05, V07);

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level6Wave1()
    {
        SetStillMinion(Minion06, new Vector2(0f, 2f));
        SetStillMinion(Minion06, new Vector2(1f, 3f));
        SetStillMinion(Minion06, new Vector2(-1f, 3f));
        SetStillMinion(Minion06, new Vector2(2f, 2f));
        SetStillMinion(Minion06, new Vector2(-2f, 2f));
        SetStillMinion(Minion06, new Vector2(-3f, 3f));
        SetStillMinion(Minion06, new Vector2(3f, 3f));
        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level6Wave2()
    {
        SetFollowingMinion(Minion06, RA00);
        SetFollowingMinion(Minion06, RA01);
        SetFollowingMinion(Minion06, RA02);
        SetFollowingMinion(Minion06, RA03);
        SetFollowingMinion(Minion06, RA04);
        SetFollowingMinion(Minion06, RA05);
        SetFollowingMinion(Minion06, RA06);
        SetFollowingMinion(Minion06, RA07);
        SetFollowingMinion(Minion06, RA08);
        SetFollowingMinion(Minion06, RA09);
        SetFollowingMinion(Minion06, RA10);
        SetFollowingMinion(Minion06, RA11);
        SetFollowingMinion(Minion06, RA12);
        SetFollowingMinion(Minion06, RA13);

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level6Wave3()
    {
        //0
        SetStillMinion(Minion06, new Vector2(-.5f, 4f));
        SetStillMinion(Minion06, new Vector2(.5f, 4f));
        SetStillMinion(Minion06, new Vector2(-1f, 3f));
        SetStillMinion(Minion06, new Vector2(1f, 3f));
        SetStillMinion(Minion06, new Vector2(-1.5f, 2f));
        SetStillMinion(Minion06, new Vector2(1.5f, 2f));
        SetStillMinion(Minion06, new Vector2(-1.5f, 1f));
        SetStillMinion(Minion06, new Vector2(1.5f, 1f));
        SetStillMinion(Minion06, new Vector2(-1f, 0f));
        SetStillMinion(Minion06, new Vector2(1f, 0f));
        SetStillMinion(Minion06, new Vector2(-.5f, -1f));
        SetStillMinion(Minion06, new Vector2(.5f, -1f));

        //1 left
        SetStillMinion(Minion06, new Vector2(-2.5f, 4f));
        SetStillMinion(Minion06, new Vector2(-2.5f, 3f));
        SetStillMinion(Minion06, new Vector2(-2.5f, 2f));
        SetStillMinion(Minion06, new Vector2(-2.5f, 1f));
        SetStillMinion(Minion06, new Vector2(-2.5f, 0f));
        SetStillMinion(Minion06, new Vector2(-2.5f, -1f));

        //1 right
        SetStillMinion(Minion06, new Vector2(2.5f, 4f));
        SetStillMinion(Minion06, new Vector2(2.5f, 3f));
        SetStillMinion(Minion06, new Vector2(2.5f, 2f));
        SetStillMinion(Minion06, new Vector2(2.5f, 1f));
        SetStillMinion(Minion06, new Vector2(2.5f, 0f));
        SetStillMinion(Minion06, new Vector2(2.5f, -1f));

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Level6Wave4()
    {
        SetFollowingMinion(Minion06, LS00);
        SetFollowingMinion(Minion06, LS01);
        SetFollowingMinion(Minion06, LS02);
        SetFollowingMinion(Minion06, LS03);
        SetFollowingMinion(Minion06, LS04);
        SetFollowingMinion(Minion06, LS05);
        SetFollowingMinion(Minion06, LS06);
        SetFollowingMinion(Minion06, LS07);
        SetFollowingMinion(Minion06, LT00);
        SetFollowingMinion(Minion06, LT01);
        SetFollowingMinion(Minion06, LT02);
        SetFollowingMinion(Minion06, LT03);
        SetFollowingMinion(Minion06, LT04);
        SetFollowingMinion(Minion06, LT05);
        SetFollowingMinion(Minion06, LT06);
        SetFollowingMinion(Minion06, LT07);

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }

    void Boss1Go()
    {
        GameObject m = Instantiate(Boss01, new Vector2(0f, 3f), Quaternion.identity);
        m.transform.localScale = new Vector3(1f, 1f, 0f);
        m.transform.SetParent(Parenting.transform, false);

        SetFollowingMinion(Minion01, Z00);
        SetFollowingMinion(Minion01, Z01);
        SetFollowingMinion(Minion01, Z02);
        SetFollowingMinion(Minion01, Z03);
        SetFollowingMinion(Minion01, Z04);
        SetFollowingMinion(Minion01, Z05);
        SetFollowingMinion(Minion01, Z06);
        SetFollowingMinion(Minion01, Z07);
    }

    void Boss2Go()
    {
        GameObject m = Instantiate(Boss02, new Vector2(0f, 3f), Quaternion.identity);
        m.transform.localScale = new Vector3(1f, 1f, 0f);
        m.transform.SetParent(Parenting.transform, false);

        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
        SetStillMinion2(Minion2Special, new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
    }

    void Boss3Go()
    {
        GameObject m = Instantiate(Boss03, new Vector2(0f, 1f), Quaternion.identity);
        m.transform.localScale = new Vector3(1f, 1f, 0f);
        m.transform.SetParent(Parenting.transform, false);
    }

    void Boss4Go()
    {
        GameObject m = Instantiate(Boss04, new Vector2(0f, 1f), Quaternion.identity);
        m.transform.localScale = new Vector3(1f, 1f, 0f);
        m.transform.SetParent(Parenting.transform, false);
    }

    void Boss5Go()
    {
        GameObject m = Instantiate(Boss05, new Vector2(0f, 1f), Quaternion.identity);
        m.transform.localScale = new Vector3(1f, 1f, 0f);
        m.transform.SetParent(Parenting.transform, false);
    }

    void Boss6Go()
    {
        GameObject m = Instantiate(Boss06, new Vector2(0f, 1f), Quaternion.identity);
        m.transform.localScale = new Vector3(1f, 1f, 0f);
        m.transform.SetParent(Parenting.transform, false);
    }

    public void FinalBossGo()
    {
        GameObject m = Instantiate(Boss07, new Vector2(0f, 1f), Quaternion.identity);
        m.transform.localScale = new Vector3(1f, 1f, 0f);
        m.transform.SetParent(Parenting.transform, false);
        BossDefeat.GetComponent<BossDefeaterScript>().PlayBossAnnounce();
    }

    void SetStillMinion( GameObject minion, Vector2 Position )
    {
        GameObject m = Instantiate( minion, Position, Quaternion.identity );
        m.transform.localScale = new Vector3(0.2f, 0.2f, 0f);
        m.transform.SetParent(Parenting.transform, false);
        m.GetComponent<MinionScript>().SetStillMinion();
    }

    void SetStillMinion2(GameObject minion, Vector2 Position)
    {
        GameObject m = Instantiate(minion, Position, Quaternion.identity);
        m.transform.localScale = new Vector3(0.2f, 0.2f, 0f);
        m.transform.SetParent(Parenting.transform, false);
        m.GetComponent<Minion2Script>().SetStillMinion2();
    }

    void SetFollowingMinion( GameObject minion, GameObject ObjectFollow )
    {
        GameObject m = Instantiate(minion, new Vector2(0, 0), Quaternion.identity);
        m.transform.localScale = new Vector3(0.2f, 0.2f, 0f);
        m.transform.SetParent(Parenting.transform, false);
        m.GetComponent<MinionScript>().FollowThisTarget(ObjectFollow);
    }

    public void SpawnRocks()
    {
        float Size = 0.5f;

        GameObject m = Instantiate(Rocker, new Vector2(0, 0), Quaternion.identity);
        m.GetComponent<RockHitScript>().StartFollowing(Z00);
        m.transform.localScale = new Vector3(Size, Size, 0f);

        GameObject m1 = Instantiate(Rocker, new Vector2(0, 0), Quaternion.identity);
        m1.GetComponent<RockHitScript>().StartFollowing(Z01);
        m1.transform.localScale = new Vector3(Size, Size, 0f);

        GameObject m2 = Instantiate(Rocker, new Vector2(0, 0), Quaternion.identity);
        m2.GetComponent<RockHitScript>().StartFollowing(Z02);
        m2.transform.localScale = new Vector3(Size, Size, 0f);

        GameObject m3 = Instantiate(Rocker, new Vector2(0, 0), Quaternion.identity);
        m3.GetComponent<RockHitScript>().StartFollowing(Z03);
        m3.transform.localScale = new Vector3(Size, Size, 0f);

        GameObject m4 = Instantiate(Rocker, new Vector2(0, 0), Quaternion.identity);
        m4.GetComponent<RockHitScript>().StartFollowing(Z04);
        m4.transform.localScale = new Vector3(Size, Size, 0f);

        GameObject m5 = Instantiate(Rocker, new Vector2(0, 0), Quaternion.identity);
        m5.GetComponent<RockHitScript>().StartFollowing(Z05);
        m5.transform.localScale = new Vector3(Size, Size, 0f);

        GameObject m6 = Instantiate(Rocker, new Vector2(0, 0), Quaternion.identity);
        m6.GetComponent<RockHitScript>().StartFollowing(Z06);
        m6.transform.localScale = new Vector3(Size, Size, 0f);

        GameObject m7 = Instantiate(Rocker, new Vector2(0, 0), Quaternion.identity);
        m7.GetComponent<RockHitScript>().StartFollowing(Z07);
        m7.transform.localScale = new Vector3(Size, Size, 0f);
    }

    public void SpawnSpear()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length != 0)
        {
            GameObject m = Instantiate(Spear, new Vector2(0, 0), Quaternion.identity);
            m.GetComponent<SpearScript>().StartFollowing(new Vector2(GameObject.FindGameObjectsWithTag("Ball")[0].transform.position.x, GameObject.FindGameObjectsWithTag("Ball")[0].transform.position.y));
        }
    }

    public void SpawnHeart()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length != 0)
        {
            foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
            {
                GameObject heart = Instantiate(Heart, new Vector2(ball.transform.position.x, 8f), Quaternion.identity);
                heart.transform.localScale = new Vector3(2f, 2f, 0f);
            }
        }
        else
        {
            if (HeartLeft)
            {
                Instantiate(Heart, new Vector2(-1f, 8f), Quaternion.identity);
            }
            else
            {
                Instantiate(Heart, new Vector2(1f, 8f), Quaternion.identity);
            }
            HeartLeft = !HeartLeft;
        } 
    }

    public void SpawnNumbers()
    {
        Instantiate(Ones, new Vector2(Random.Range(-2f, 2f), Random.Range(-3f, 3f)), Quaternion.identity);
        Instantiate(Ones, new Vector2(Random.Range(-2f, 2f), Random.Range(-3f, 3f)), Quaternion.identity);
        Instantiate(Zeros, new Vector2(Random.Range(-2f, 2f), Random.Range(-3f, 3f)), Quaternion.identity);
        Instantiate(Zeros, new Vector2(Random.Range(-2f, 2f), Random.Range(-3f, 3f)), Quaternion.identity);
    }

    public void LoadFinalBossMinions()
    {
        SetFollowingMinion(Minion01, Z00);
        SetFollowingMinion(Minion02, Z01);
        SetFollowingMinion(Minion03, Z02);
        SetFollowingMinion(Minion04, Z03);
        SetFollowingMinion(Minion05, Z04);
        SetFollowingMinion(Minion06, Z05);
        SetFollowingMinion(Minion01, Z06);
        SetFollowingMinion(Minion02, Z07);

        SetFollowingMinion(Minion03, LS00);
        SetFollowingMinion(Minion04, LS01);
        SetFollowingMinion(Minion05, LS02);
        SetFollowingMinion(Minion06, LS03);
        SetFollowingMinion(Minion01, LS04);
        SetFollowingMinion(Minion02, LS05);
        SetFollowingMinion(Minion03, LS06);
        SetFollowingMinion(Minion04, LS07);

        SetFollowingMinion(Minion05, LT00);
        SetFollowingMinion(Minion06, LT01);
        SetFollowingMinion(Minion01, LT02);
        SetFollowingMinion(Minion02, LT03);
        SetFollowingMinion(Minion03, LT04);
        SetFollowingMinion(Minion04, LT05);
        SetFollowingMinion(Minion05, LT06);
        SetFollowingMinion(Minion06, LT07);

        Audio.clip = AudioClip_RegenerateMinions;
        Audio.Play();
    }
}