using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFormation : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPlanePrefab;
        [SerializeField] private GameObject startPoint;
        [SerializeField] private GameObject spamPoint;

        private float formationSwitchInterval = 10f;
        private float timeSinceLastSwitch = 0.0f;
        private float timeSpam = 0.5f;

        private int indexFormation = 0;
        private int numEnemy = 16;
        private int currentFormationIndex = 0;

        

        private List<GameObject> enemyPlanes = new List<GameObject>();
        private List<Vector3> listTargetPos = new List<Vector3>();

        private List<FormationType> formations = new List<FormationType>()
            { FormationType.Normal, FormationType.Diamond, FormationType.Triagle, FormationType.Rectangle };

        private enum FormationType
        {
            Normal,
            Diamond,
            Triagle,
            Rectangle,

        }

        private void Start()
        {
            for (int i = 0; i < numEnemy; i++)
            {
                GameObject enemyPlane = Instantiate(enemyPlanePrefab, spamPoint.transform.position, Quaternion.identity);
                enemyPlanes.Add(enemyPlane);
            }
       
            CreateListTargetPos(formations[indexFormation]);
            StartCoroutine(MoveEnemy());
        }

        private void Update()
        {
            timeSinceLastSwitch += Time.deltaTime;

            if (timeSinceLastSwitch >= formationSwitchInterval && currentFormationIndex < formations.Count - 1)
            {
                SwitchFormation();
                timeSinceLastSwitch = 0.0f;
                currentFormationIndex++;
            }

        }

        private void SwitchFormation()
        {
            indexFormation++;
            if (indexFormation == formations.Count)
                indexFormation = 0;

            CreateListTargetPos(formations[indexFormation]);
            StartCoroutine(MoveEnemy());
        }

        IEnumerator MoveEnemy()
        {
            for (int i = 0; i < listTargetPos.Count; i++)
            {
                
                enemyPlanes[i].transform.DOMove(startPoint.transform.position + listTargetPos[i], timeSpam);
                yield return new WaitForSeconds(timeSpam);
            }
           
        }

        private void CreateListTargetPos(FormationType formation)
        {
            listTargetPos.Clear();
            float distance = 0.6f;
            
            switch (formation)
            {
                case FormationType.Normal:
                    {
  
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                listTargetPos.Add(new Vector3(j * distance, i * distance));
                            }
                        }
                        break;
                    }

                case FormationType.Diamond:
                    {

                        for (int i = 0; i < 5; i++)
                        {
                            if (i == 0 || i == 4)
                            {
                                listTargetPos.Add(new Vector3(2.5f * distance, i * distance));
                                continue;
                            }
                            if (i == 1 || i == 3)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    listTargetPos.Add(new Vector3(1 * distance + j * distance, i * distance));
                                }
                                continue;
                            }
                            if (i == 2)
                            {
                                for (int j = 0; j < 6; j++)
                                {
                                    listTargetPos.Add(new Vector3(j * distance, i * distance));
                                }
                                continue;
                            }

                        }
                        break;
                    }

                case FormationType.Triagle:
                    {

                        for (int i = 0; i < 5; i++)
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    listTargetPos.Add(new Vector3(j * distance, i * distance));
                                }
                                continue;
                            }
                            if (i == 1)
                            {
                                listTargetPos.Add(new Vector3(1 * distance, i * distance));
                                listTargetPos.Add(new Vector3(7 * distance, i * distance));
                                continue;
                            }
                            if (i == 2)
                            {
                                listTargetPos.Add(new Vector3(2 * distance, i * distance));
                                listTargetPos.Add(new Vector3(6 * distance, i * distance));
                                continue;
                            }
                            if (i == 3)
                            {
                                listTargetPos.Add(new Vector3(3 * distance, i * distance));
                                listTargetPos.Add(new Vector3(5 * distance, i * distance));
                                continue;
                            }
                            if (i == 4)
                            {
                                listTargetPos.Add(new Vector3(4 * distance, i * distance));
                                continue;
                            }
                        }
                        break;
                    }

                case FormationType.Rectangle:
                    {
         
                        for (int i = 0; i < 3; i++)
                        {
                            if (i == 1)
                            {
                                listTargetPos.Add(new Vector3(0, i * distance));
                                listTargetPos.Add(new Vector3(6 * distance, i * distance));
                            }
                            else
                            {
                                for (int j = 0; j < 7; j++)
                                {
                                    listTargetPos.Add(new Vector3(j * distance, i * distance));
                                }
                            }
                        }
                        break;
                    }

            }
        }

    }
