using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnController : MonoBehaviour {

    GameObject pg;
    GameObject pp;
    GameObject pm;
    GameObject pk;

    Penguingodstats pgs;
    PenguinKingStats pks;
    PenguinMasterStats pms;
    PenguinPriestStats pps;

    MechStats mstats;
    SwordsmanStats smstats;
    HealerStats hstats;
    CubeWarriorStats cwstats;
   
    GameObject swordsman;
    GameObject swordsmanbody;
    swordsmansummoning swordsmansummonscript;
    GameObject smsummon;
    NewGridTest gridscript;
    GameObject grid;
    Color swordsmanholdercolor;
    
  
    

    CubeWarriorSummon cws;
    GameObject cubewarriorsummoning;
    GameObject summoning;
    SummonCharacter sc;
    HealerSummon healersummonscript;
    GameObject healersummon;
    GameObject healer;
    GameObject healerbody;
    GameObject mech;
    GameObject cubewarrior;
    GameObject cubewarriorbody;
    float initialdistance = 10000;
    float ppregatktimer;
    float pgregatktimer;
    float pkregatktimer;
    float pmregatktimer;

    float hregatktimer;
    float smregatktimer;
    float cwregatktimer;
    float mregatktimer;
    // Use this for initialization
    public float basiccd = 5;
    public float cdadjust = .15f;
    void Awake()
    {
        
        mech = GameObject.Find("mech");
        mstats = mech.GetComponent<MechStats>();
        cubewarrior = GameObject.Find("CubeWarrior");
        cwstats = cubewarrior.GetComponent<CubeWarriorStats>();
        cubewarriorbody = GameObject.Find("CubeWarriorBody");

        swordsman = GameObject.Find("Swordsman");
        smstats = swordsman.GetComponent<SwordsmanStats>();
        swordsmanbody = GameObject.Find("SwordsmanBody");

        healer = GameObject.Find("Healer");
        hstats = healer.GetComponent<HealerStats>();
        healerbody = GameObject.Find("HealerBody");


        smsummon = GameObject.Find("SummonSwordsman");
        swordsmansummonscript = smsummon.GetComponent<swordsmansummoning>();

        grid = GameObject.Find("GridPlaceHolder");
        gridscript = grid.GetComponent<NewGridTest>();
        
        
        cubewarriorsummoning = GameObject.Find("CubeWarriorSummoning");
        cws = cubewarriorsummoning.GetComponent<CubeWarriorSummon>();

        summoning = GameObject.Find("Summoning");
        sc = summoning.GetComponent<SummonCharacter>();

        healersummon = GameObject.Find("SummonHealer");
        healersummonscript = healersummon.GetComponent<HealerSummon>();


        pg = GameObject.Find("PenguinGod");
        pm = GameObject.Find("PenguinMaster");
        pp = GameObject.Find("PenguinPriest");
        pk = GameObject.Find("PenguinKing");

        pgs = pg.GetComponent<Penguingodstats>();
        pms = pm.GetComponent<PenguinMasterStats>();
        pps = pp.GetComponent<PenguinPriestStats>();
        pks = pk.GetComponent<PenguinKingStats>();





    }
    void allsummoned()
    {
        if (swordsmansummonscript.battlestart == false)
        {
            
        }
        else
        {
            
            healerregularattack();
            cubewarriorregularattack();
            mechregularattack();
            swordsmanregularattack();
            ppregularattack();
            pkregularattack();
            pmregularattack();
            pgregularattack();
        }
    }
   

    void healerregularattack()
    {

        float pgd;//penguin god distance
        float ppd;// penguin priest distance
        float pkd;// penguin king distance
        float pmd;// penguin master distance
        List<float> distances = new List<float>();
        distances.Add(initialdistance);
        if ((smstats.isDead && hstats.isDead && mstats.isDead && cwstats.isDead) == true || (pgs.isDead && pms.isDead && pks.isDead && pps.isDead) == true)
        {
            
        }
            else if (hregatktimer >= (basiccd / (cdadjust * healersummonscript.speed)))
        {





            pgd = Vector3.Distance(pg.transform.position, healer.transform.position);
            if (pgs.isDead == false)
            {
              
                distances.RemoveAt(0);
                distances.Add(pgd);
            }
            pkd = Vector3.Distance(pk.transform.position, healer.transform.position);
            if ((pkd <= pgd && pks.isDead == false) || (pgs.isDead == true && pks.isDead == false))
            {
         
                distances.RemoveAt(0);
                distances.Add(pkd);
            }
            ppd = Vector3.Distance(pp.transform.position, healer.transform.position);
            if ((ppd <= pkd && ppd <= pgd && pgs.isDead == false) || (ppd <= pgd && pks.isDead == true && pps.isDead == false) || (ppd <= pkd && pgs.isDead == true && pps.isDead == false))
            {
        
                distances.RemoveAt(0);
                distances.Add(ppd);
            }
            pmd = Vector3.Distance(pm.transform.position, healer.transform.position);
            if ((pmd <= pkd & pmd <= pgd && pmd <= ppd && pms.isDead == false) || (pps.isDead == true && pks.isDead == true && pgs.isDead == true && pms.isDead == false) || (pmd <= ppd && pks.isDead == true && pgs.isDead == true && pms.isDead == false)
                        || (pmd <= ppd && pmd <= pkd && pgs.isDead == true && pms.isDead == false) || (pmd <= ppd && pks.isDead == true && pmd <= pgd && pms.isDead == false) || (pmd <= pkd && mstats.isDead == true && pms.isDead == false && pps.isDead == true)
                        || ( pmd <= pkd && pmd <= pgd && pms.isDead == false && pps.isDead == true) || (pps.isDead == true && pks.isDead == true && pgs.isDead == true && pms.isDead == false))

            {
                
             
                distances.RemoveAt(0);
                distances.Add(pmd);
            }




            if (distances[0] == pgd)
            {
                pgs.TakeDamage(hstats.attack);
            }
            else if (distances[0] == pmd)
            {
                pms.TakeDamage(hstats.attack);
            }
            else if (distances[0] == pkd)
            {
                pks.TakeDamage(hstats.attack);
            }
            else if (distances[0] == ppd)
            {
                pps.TakeDamage(hstats.attack);
            }
            

            hregatktimer = 0;
            distances.RemoveAt(0);
        }
    }

    void cubewarriorregularattack()
    {

        float pgd;//penguin god distance
        float ppd;// penguin priest distance
        float pkd;// penguin king distance
        float pmd;// penguin master distance
        List<float> distances = new List<float>();
        distances.Add(initialdistance);
        if ((smstats.isDead && hstats.isDead && mstats.isDead && cwstats.isDead) == true || (pgs.isDead && pms.isDead && pks.isDead && pps.isDead) == true)
        {
           
        }
            else if (cwregatktimer >= (basiccd / (cdadjust * cws.speed)))
        {


            pgd = Vector3.Distance(pg.transform.position, cubewarrior.transform.position);
            if (pgs.isDead == false)
            {
              
                distances.RemoveAt(0);
                distances.Add(pgd);
            }
            pkd = Vector3.Distance(pk.transform.position, cubewarrior.transform.position);
            if ((pkd <= pgd && pks.isDead == false) || (pgs.isDead == true && pks.isDead == false))
            {
               
                distances.RemoveAt(0);
                distances.Add(pkd);
            }
            ppd = Vector3.Distance(pp.transform.position, cubewarrior.transform.position);
            if ((ppd <= pkd && ppd <= pgd && pgs.isDead == false) || (ppd <= pgd && pks.isDead == true && pps.isDead == false) || (ppd <= pkd && pgs.isDead == true && pps.isDead == false))
            {
               
                distances.RemoveAt(0);
                distances.Add(ppd);
            }
            pmd = Vector3.Distance(pm.transform.position, cubewarrior.transform.position);
            if ((pmd <= pkd & pmd <= pgd && pmd <= ppd && pms.isDead == false) || (pps.isDead == true && pks.isDead == true && pgs.isDead == true && pms.isDead == false) || (pmd <= ppd && pks.isDead == true && pgs.isDead == true && pms.isDead == false)
                        || (pmd <= ppd && pmd <= pkd && pgs.isDead == true && pms.isDead == false) || (pmd <= ppd && pks.isDead == true && pmd <= pgd && pms.isDead == false) || (pmd <= pkd && mstats.isDead == true && pms.isDead == false && pps.isDead == true)
                        || (pmd <= pkd && pmd <= pgd && pms.isDead == false && pps.isDead == true) || (pps.isDead == true && pks.isDead == true && pgs.isDead == true && pms.isDead == false))

            {

                
                distances.RemoveAt(0);
                distances.Add(pmd);
            }

            if (distances[0] == pgd)
            {
                pgs.TakeDamage(cwstats.attack);
            }
            else if (distances[0] == pmd)
            {
                pms.TakeDamage(cwstats.attack);
            }
            else if (distances[0] == pkd)
            {
                pks.TakeDamage(cwstats.attack);
            }
            else if (distances[0] == ppd)
            {
                pps.TakeDamage(cwstats.attack);
            }

            cwregatktimer = 0;
            distances.RemoveAt(0);
        }
    }

    void mechregularattack()
    {

        float pgd;//penguin god distance
        float ppd;// penguin priest distance
        float pkd;// penguin king distance
        float pmd;// penguin master distance
        List<float> distances = new List<float>();
        distances.Add(initialdistance);
        if ((smstats.isDead && hstats.isDead && mstats.isDead && cwstats.isDead) == true || (pgs.isDead && pms.isDead && pks.isDead && pps.isDead) == true)
        {
        
        }
            else if (mregatktimer >= (basiccd / (cdadjust * sc.speed)))
        {


            pgd = Vector3.Distance(pg.transform.position, mech.transform.position);
            if (pgs.isDead == false)
            {
               
                distances.RemoveAt(0);
                distances.Add(pgd);
            }
            pkd = Vector3.Distance(pk.transform.position, mech.transform.position);
            if ((pkd <= pgd && pks.isDead == false) || (pgs.isDead == true && pks.isDead == false))
            {
                
                distances.RemoveAt(0);
                distances.Add(pkd);
            }
            ppd = Vector3.Distance(pp.transform.position, mech.transform.position);
            if ((ppd <= pkd && ppd <= pgd && pgs.isDead == false) || (ppd <= pgd && pks.isDead == true && pps.isDead == false) || (ppd <= pkd && pgs.isDead == true && pps.isDead == false))
            {
              
                distances.RemoveAt(0);
                distances.Add(ppd);
            }
            pmd = Vector3.Distance(pm.transform.position, mech.transform.position);
            if ((pmd <= pkd & pmd <= pgd && pmd <= ppd && pms.isDead == false) || (pps.isDead == true && pks.isDead == true && pgs.isDead == true && pms.isDead == false) || (pmd <= ppd && pks.isDead == true && pgs.isDead == true && pms.isDead == false)
                        || (pmd <= ppd && pmd <= pkd && pgs.isDead == true && pms.isDead == false) || (pmd <= ppd && pks.isDead == true && pmd <= pgd && pms.isDead == false) || (pmd <= pkd && mstats.isDead == true && pms.isDead == false && pps.isDead == true)
                        || (pmd <= pkd && pmd <= pgd && pms.isDead == false && pps.isDead == true) || (pps.isDead == true && pks.isDead == true && pgs.isDead == true && pms.isDead == false))

            {

               
                distances.RemoveAt(0);
                distances.Add(pmd);
            }

            if (distances[0] == pgd)
            {
                pgs.TakeDamage(mstats.attack);
            }
            else if (distances[0] == pmd)
            {
                pms.TakeDamage(mstats.attack);
            }
            else if (distances[0] == pkd)
            {
                pks.TakeDamage(mstats.attack);
            }
            else if (distances[0] == ppd)
            {
                pps.TakeDamage(mstats.attack);
            }

            mregatktimer = 0;
            distances.RemoveAt(0);
        }
    }

    void swordsmanregularattack()
    {

        float pgd;//penguin god distance
        float ppd;// penguin priest distance
        float pkd;// penguin king distance
        float pmd;// penguin master distance
        List<float> distances = new List<float>();
        distances.Add(initialdistance);
        if ((smstats.isDead && hstats.isDead && mstats.isDead && cwstats.isDead) == true || (pgs.isDead && pms.isDead && pks.isDead && pps.isDead) == true)
        {
            
        }
            else if (smregatktimer >= (basiccd / (cdadjust * swordsmansummonscript.speed)))
        {


            pgd = Vector3.Distance(pg.transform.position, swordsman.transform.position);
            if (pgs.isDead == false)
            {
                
                distances.RemoveAt(0);
                distances.Add(pgd);
            }
            pkd = Vector3.Distance(pk.transform.position, swordsman.transform.position);
            if ((pkd <= pgd && pks.isDead == false) || (pgs.isDead == true && pks.isDead == false))
            {
               
                distances.RemoveAt(0);
                distances.Add(pkd);
            }
            ppd = Vector3.Distance(pp.transform.position, swordsman.transform.position);
            if ((ppd <= pkd && ppd <= pgd && pgs.isDead == false) || (ppd <= pgd && pks.isDead == true && pps.isDead == false) || (ppd <= pkd && pgs.isDead == true && pps.isDead == false))
            {
               
                distances.RemoveAt(0);
                distances.Add(ppd);
            }
            pmd = Vector3.Distance(pm.transform.position, swordsman.transform.position);
            if ((pmd <= pkd & pmd <= pgd && pmd <= ppd && pms.isDead == false) || (pps.isDead == true && pks.isDead == true && pgs.isDead == true && pms.isDead == false) || (pmd <= ppd && pks.isDead == true && pgs.isDead == true && pms.isDead == false)
                        || (pmd <= ppd && pmd <= pkd && pgs.isDead == true && pms.isDead == false) || (pmd <= ppd && pks.isDead == true && pmd <= pgd && pms.isDead == false) || (pmd <= pkd && mstats.isDead == true && pms.isDead == false && pps.isDead == true)
                        || (pmd <= pkd && pmd <= pgd && pms.isDead == false && pps.isDead == true) || (pps.isDead == true && pks.isDead == true && pgs.isDead == true && pms.isDead == false))

            {

               
                distances.RemoveAt(0);
                distances.Add(pmd);
            }

            if (distances[0] == pgd)
            {
                pgs.TakeDamage(smstats.attack);
            }
            else if (distances[0] == pmd)
            {
                pms.TakeDamage(smstats.attack);
            }
            else if (distances[0] == pkd)
            {
                pks.TakeDamage(smstats.attack);
            }
            else if (distances[0] == ppd)
            {
                pps.TakeDamage(smstats.attack);
            }

            smregatktimer = 0;
            distances.RemoveAt(0);
        }
    }

    void ppregularattack()
    {

        float smd;// swordsman distance
        float hd;// healer distance
        float cwd;// cubewarrior distance
        float md;// mech distance
        List<float> distances = new List<float>();
        distances.Add(initialdistance);
        if ((smstats.isDead && hstats.isDead && mstats.isDead && cwstats.isDead) == true || (pgs.isDead && pms.isDead && pks.isDead && pps.isDead) == true)
        {
            
        }
            else if (ppregatktimer >= (basiccd / (cdadjust * pps.speed)))
        {




            smd = Vector3.Distance(swordsman.transform.position, pp.transform.position);
            if (smstats.isDead == false)
            {
               
                distances.RemoveAt(0);
                distances.Add(smd);
            }
            hd = Vector3.Distance(healer.transform.position, pp.transform.position);
            if ((hd <= smd && hstats.isDead == false) || (smstats.isDead == true && hstats.isDead == false))
            {
                
                distances.RemoveAt(0);
                distances.Add(hd);
            }
            md = Vector3.Distance(mech.transform.position, pp.transform.position);
            if ((md <= hd && md <= smd && mstats.isDead == false) || (md <= smd && hstats.isDead == true && mstats.isDead == false) || (md <= hd && smstats.isDead == true && mstats.isDead == false))
            {
               
                distances.RemoveAt(0);
                distances.Add(md);
            }
            cwd = Vector3.Distance(cubewarrior.transform.position, pp.transform.position);
            if ((cwd <= hd & cwd <= md && cwd <= smd && cwstats.isDead == false) || (smstats.isDead == true && hstats.isDead == true && mstats.isDead == true && cwstats.isDead == false) || (cwd <= smd && hstats.isDead == true && mstats.isDead == true && cwstats.isDead == false)
                        || (cwd <= smd && cwd <= hd && mstats.isDead == true && cwstats.isDead == false) || (cwd <= smd && hstats.isDead == true && cwd <= md && cwstats.isDead == false) || ( cwd <= hd && mstats.isDead == true && cwstats.isDead == false && smstats.isDead == true)
                        || ( cwd <= hd && cwd <= md && cwstats.isDead == false && smstats.isDead == true) || (smstats.isDead == true && hstats.isDead == true && mstats.isDead == true && cwstats.isDead == false))

            {
               
                distances.RemoveAt(0);
                distances.Add(cwd);
            }




            if (distances[0] == smd)
            {
               
                smstats.TakeDamage(pps.attack);
            }
            else if (distances[0] == hd)
            {
               
                hstats.TakeDamage(pps.attack);
            }
            else if (distances[0] == md)
            {
               
                mstats.TakeDamage(pps.attack);
            }
            else if (distances[0] == cwd)
            {
                
                cwstats.TakeDamage(pps.attack);
            }
            
            ppregatktimer = 0;
            distances.RemoveAt(0);

        }
    }

    void pgregularattack()
    {

        float smd;// swordsman distance
        float hd;// healer distance
        float cwd;// cubewarrior distance
        float md;// mech distance
        List<float> distances = new List<float>();
        distances.Add(initialdistance);
        if ((smstats.isDead && hstats.isDead && mstats.isDead && cwstats.isDead) == true || (pgs.isDead && pms.isDead && pks.isDead && pps.isDead) == true)
        {
           
        }
            else if (pgregatktimer >= (basiccd / (cdadjust * pgs.speed)))
        {




            smd = Vector3.Distance(swordsman.transform.position, pg.transform.position);
            if (smstats.isDead == false)
            {
               
                distances.RemoveAt(0);
                distances.Add(smd);
            }
            hd = Vector3.Distance(healer.transform.position, pg.transform.position);
            if ((hd <= smd && hstats.isDead == false) || (smstats.isDead == true && hstats.isDead == false))
            {
               
                distances.RemoveAt(0);
                distances.Add(hd);
            }
            md = Vector3.Distance(mech.transform.position, pg.transform.position);
            if ((md <= hd && md <= smd && mstats.isDead == false) || (md <= smd && hstats.isDead == true && mstats.isDead == false) || (md <= hd && smstats.isDead == true && mstats.isDead == false))
            {

                distances.RemoveAt(0);
                distances.Add(md);
            }
            cwd = Vector3.Distance(cubewarrior.transform.position, pg.transform.position);
            if ((cwd <= hd & cwd <= md && cwd <= smd && cwstats.isDead == false) || (smstats.isDead == true && hstats.isDead == true && mstats.isDead == true && cwstats.isDead == false) || (cwd <= smd && hstats.isDead == true && mstats.isDead == true && cwstats.isDead == false)
                        || (cwd <= smd && cwd <= hd && mstats.isDead == true && cwstats.isDead == false) || (cwd <= smd && hstats.isDead == true && cwd <= md && cwstats.isDead == false) || (cwd <= hd && mstats.isDead == true && cwstats.isDead == false && smstats.isDead == true)
                        || (cwd <= hd && cwd <= md && cwstats.isDead == false && smstats.isDead == true) || (smstats.isDead == true && hstats.isDead == true && mstats.isDead == true && cwstats.isDead == false))

            {
               
                distances.RemoveAt(0);
                distances.Add(cwd);
            }



            if (distances[0] == smd)
            {
                smstats.TakeDamage(pgs.attack);
            }
            else if (distances[0] == hd)
            {
                hstats.TakeDamage(pgs.attack);
            }
            else if (distances[0] == md)
            {
                mstats.TakeDamage(pgs.attack);
            }
            else if (distances[0] == cwd)
            {
                cwstats.TakeDamage(pgs.attack);
            }

            pgregatktimer = 0;
            distances.RemoveAt(0);
        }
    }

    void pmregularattack()
    {

        float smd;// swordsman distance
        float hd;// healer distance
        float cwd;// cubewarrior distance
        float md;// mech distance
        List<float> distances = new List<float>();
        distances.Add(initialdistance);
        if ((smstats.isDead && hstats.isDead && mstats.isDead && cwstats.isDead) == true || (pgs.isDead && pms.isDead && pks.isDead && pps.isDead) == true)
        {
           
        }
            else if (pmregatktimer >= (basiccd / (cdadjust * pms.speed)))
        {




            smd = Vector3.Distance(swordsman.transform.position, pm.transform.position);
            if (smstats.isDead == false)
            {
                
                distances.RemoveAt(0);
                distances.Add(smd);
            }
            hd = Vector3.Distance(healer.transform.position, pm.transform.position);
            if ((hd <= smd && hstats.isDead == false) || (smstats.isDead == true && hstats.isDead == false))
            {
                
                distances.RemoveAt(0);
                distances.Add(hd);
            }
            md = Vector3.Distance(mech.transform.position, pm.transform.position);
            if ((md <= hd && md <= smd && mstats.isDead == false) || (md <= smd && hstats.isDead == true && mstats.isDead == false) || (md <= hd && smstats.isDead == true && mstats.isDead == false))
            {
               
                distances.RemoveAt(0);
                distances.Add(md);
            }
            cwd = Vector3.Distance(cubewarrior.transform.position, pm.transform.position);
            if ((cwd <= hd & cwd <= md && cwd <= smd && cwstats.isDead == false) || (smstats.isDead == true && hstats.isDead == true && mstats.isDead == true && cwstats.isDead == false) || (cwd <= smd && hstats.isDead == true && mstats.isDead == true && cwstats.isDead == false)
                        || (cwd <= smd && cwd <= hd && mstats.isDead == true && cwstats.isDead == false) || (cwd <= smd && hstats.isDead == true && cwd <= md && cwstats.isDead == false) || (cwd <= hd && mstats.isDead == true && cwstats.isDead == false && smstats.isDead == true)
                        || (cwd <= hd && cwd <= md && cwstats.isDead == false && smstats.isDead == true) || (smstats.isDead == true && hstats.isDead == true && mstats.isDead == true && cwstats.isDead == false))

            {
               
                distances.RemoveAt(0);
                distances.Add(cwd);
            }


            if (distances[0] == smd)
            {
                smstats.TakeDamage(pms.attack);
            }
            else if (distances[0] == hd)
            {
                hstats.TakeDamage(pms.attack);
            }
            else if (distances[0] == md)
            {
                mstats.TakeDamage(pms.attack);
            }
            else if (distances[0] == cwd)
            {
                cwstats.TakeDamage(pms.attack);
            }

            pmregatktimer = 0;
            distances.RemoveAt(0);
        }
    }

    void pkregularattack()
{

    float smd;// swordsman distance
    float hd;// healer distance
    float cwd;// cubewarrior distance
    float md;// mech distance
    List<float> distances = new List<float>();
        distances.Add(initialdistance);
    if ((smstats.isDead && hstats.isDead && mstats.isDead && cwstats.isDead) == true || (pgs.isDead && pms.isDead && pks.isDead && pps.isDead) == true)
    {

    }
    else if (pkregatktimer >= (basiccd / (cdadjust * pks.speed)))
    {




        smd = Vector3.Distance(swordsman.transform.position, pk.transform.position);
        if (smstats.isDead == false)
            {
                
                distances.RemoveAt(0);
                distances.Add(smd);
            }
        hd = Vector3.Distance(healer.transform.position, pk.transform.position);
        if ((hd <= smd && hstats.isDead == false) || (smstats.isDead == true && hstats.isDead == false))
        {
               
            distances.RemoveAt(0);
                distances.Add(hd);
        }
        md = Vector3.Distance(mech.transform.position, pk.transform.position);
        if ((md <= hd && md <= smd && mstats.isDead == false) || (md <= smd && hstats.isDead == true && mstats.isDead == false) || (md <= hd && smstats.isDead == true && mstats.isDead == false ))
        {
                
            distances.RemoveAt(0);
            distances.Add(md);
        }
        cwd = Vector3.Distance(cubewarrior.transform.position, pk.transform.position);
            if ((cwd <= hd & cwd <= md && cwd <= smd && cwstats.isDead == false) || (smstats.isDead == true && hstats.isDead == true && mstats.isDead == true && cwstats.isDead == false) || (cwd <= smd && hstats.isDead == true && mstats.isDead == true && cwstats.isDead == false)
                            || (cwd <= smd && cwd <= hd && mstats.isDead == true && cwstats.isDead == false) || (cwd <= smd && hstats.isDead == true && cwd <= md && cwstats.isDead == false) || (cwd <= hd && mstats.isDead == true && cwstats.isDead == false && smstats.isDead == true)
                            || (cwd <= hd && cwd <= md && cwstats.isDead == false && smstats.isDead == true) || (smstats.isDead == true && hstats.isDead == true && mstats.isDead == true && cwstats.isDead == false))
            {
                
            distances.RemoveAt(0);
            distances.Add(cwd);
        }

        if (distances[0] == smd)
        {
            smstats.TakeDamage(pks.attack);
        }
        else if (distances[0] == hd)
        {
            hstats.TakeDamage(pks.attack);
        }
        else if (distances[0] == md)
        {
            mstats.TakeDamage(pks.attack);
        }
        else if (distances[0] == cwd)
        {
            cwstats.TakeDamage(pks.attack);
        }

        pkregatktimer = 0;
        distances.RemoveAt(0);

    } 
    }

    // Update is called once per frame
    void Update()
    {
        allsummoned();
        hregatktimer += Time.deltaTime;
        smregatktimer += Time.deltaTime;
        cwregatktimer += Time.deltaTime;
        mregatktimer += Time.deltaTime;
        ppregatktimer += Time.deltaTime;
        pgregatktimer += Time.deltaTime;
        pmregatktimer += Time.deltaTime;
        pkregatktimer += Time.deltaTime;
        
    }
}
