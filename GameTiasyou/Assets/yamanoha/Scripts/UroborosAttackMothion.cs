using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UroborosAttackMothion : MonoBehaviour
{
    private GameObject attackCourtain;
    private bool attackFlg; // ウロボロスが攻撃中か判断する　true:攻撃中  false:否
    int coolTimeCount;  // ウロボロスが攻撃しない時間帯
    int timecount;

    // Start is called before the first frame update
    void Start()
    {
        attackCourtain = GameObject.Find("LaunchPort");
        attackFlg = false;
        timecount = 0;
        //attack.GetComponent<Bullet1>().AttackStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackFlg == false )
        {
            //attackCourtain.GetComponent<Bullet1>().AttackStart();
            attackCourtain.GetComponent<Bullet2>().AttackStart();

            attackFlg = true;
        }

        //if (timecount > 60) break;

        //timecount++;
    }

    /// <summary>
    /// 攻撃が終了する際に呼び出される関数
    /// </summary>
    public IEnumerator AttackFinishReceiver()
    {
        yield return new WaitForSeconds(Random.Range(3f, 10f));
        attackFlg = false;
    }
}
