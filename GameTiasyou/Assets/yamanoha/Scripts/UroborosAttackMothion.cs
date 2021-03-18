using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UroborosAttackMothion : MonoBehaviour
{
    private GameObject attackCourtain;
    private bool attackFlg; // ウロボロスが攻撃中か判断する　true:攻撃中  false:否

    // Start is called before the first frame update
    void Start()
    {
        attackCourtain = GameObject.Find("LaunchPort");
        attackFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackFlg == false )
        {
            var attackPaternChoice = Random.value;
            if(attackPaternChoice < 0.4)
                attackCourtain.GetComponent<Bullet1>().AttackStart();
            else 
                attackCourtain.GetComponent<Bullet2>().AttackStart();

            attackFlg = true;
        }
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
