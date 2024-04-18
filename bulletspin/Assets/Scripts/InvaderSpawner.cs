using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EEL.RelativisticSpaceInvaders
{
    public class InvaderSpawner : MonoBehaviour
    {
        [System.Serializable]
        private struct InvaderType
        {
            public string name; 
            public Sprite[] sprites;
            public int points;
            public int rowCount;
        }

        internal static InvaderSpawner Instance;

        [Header("Spawn")]
        [SerializeField]
        private InvaderType[] invaderTypes; // array of invader types in use

        [SerializeField]
        private int columnCount; //total no. of columns for swarm

        // invader - density variables
        [SerializeField]
        private int ySpacing;
        [SerializeField]
        private int xSpacing;

        //defines spawn point
        [SerializeField]
        private Transform spawnStartPoint;

        //min. X pos for swarm (you can't go more to the left than that)
        private float minX;

        [Space]


        [Header("Movement")]
        [SerializeField]
        private float Speed = 10f;

        private Transform[,] invaders;
        private int rowCount;
        private bool isMovingRight = true;
        private float maxX;
        private float currentX;
        private float xIncrement;

        [SerializeField]
        private BulletSpawner bulletSpawnerPrefab;

        [SerializeField]
        private Transform cannonPosition;

        private int killCount;
        private System.Collections.Generic.Dictionary<string, int> ptsMap;

        // Methods:
        internal void IncDeathCount()
        {
            killCount++;
            if(killCount >= invaders.Length)
            {
                //GameCtrl.Instance.TriggerGameOvr(false); // to do
                return;
            }

        }

        internal Transform GetInvader(int row, int column)
        {
            if (row < 0 || column < 0
                    || row >= invaders.GetLength(0) || column >= invaders.GetLength(1))
            {
                return null;
            }

            return invaders[row, column];
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            if (columnCount == 0)
            {
                return;
            }
            else
            {

                minX = spawnStartPoint.position.x;
                GameObject swarm = new GameObject { name = "Swarm" };
                swarm.tag = "invader";
                Vector2 currentPos = spawnStartPoint.position;

                foreach (var Invader in invaderTypes)
                {
                    rowCount += Invader.rowCount;
                }

                maxX = -minX;
                currentX = minX;
                invaders = new Transform[rowCount, columnCount];
                ptsMap = new System.Collections.Generic.Dictionary<string, int>();

                int RowIndex = 0;

                foreach (var Invader in invaderTypes)
                {
                    var invaderName = Invader.name.Trim();
                    ptsMap[invaderName] = Invader.points;

                    for (int i = 0, len = Invader.rowCount; i < len; i++)
                    {
                        for (int k = 0; k < columnCount; k++)
                        {
                            var invader = new GameObject() { name = invaderName };
                            invader.AddComponent<SimpleAnimator>().sprites = Invader.sprites;
                            invader.AddComponent<BoxCollider2D>();
                            invader.GetComponent<BoxCollider2D>().size = new Vector2(36, 36);
                            //invader.AddComponent<Rigidbody2D>();
                            //defauld body type is dynamic.
                            //invader.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;// <-------- this line makes issues. So long the body type is dynamic collison between invader and player is visible due to the effects in the motion of the invader.
                            invader.tag = "invader";
                            invader.layer = 9;
                            invader.transform.position = currentPos;
                            invader.transform.SetParent(swarm.transform);
                            invaders[RowIndex, k] = invader.transform;
                            currentPos.x += xSpacing; //moving left to position next invader.
                        }
                        currentPos.x += minX;
                        currentPos.y -= ySpacing; //moving down for the new row of Invaders

                        RowIndex++;

                    }
                }

                for (int n = 0; n < columnCount; n++)
                {
                    var bulletSpawner = Instantiate(bulletSpawnerPrefab);
                    bulletSpawner.transform.SetParent(swarm.transform);
                    bulletSpawner.column = n;
                    bulletSpawner.currentRow = rowCount - 1;
                    bulletSpawner.Setup();
                    bulletSpawner.tag = "invader";

                }

            }
        }

        // Update is called once per frame: handles movement of swarm: left-right pingpong
        private void Update()
        {
            xIncrement = Speed * Time.deltaTime;
            if (isMovingRight)
            {
                currentX += xIncrement;
                if (currentX < maxX)
                {
                    MoveInvaders(xIncrement, 0);
                }
                else
                {
                    ChangeDirection();
                }
            }
            else
            {
                currentX -= xIncrement;
                if (currentX > minX)
                {
                    MoveInvaders(-xIncrement, 0);
                }
                else
                {
                    ChangeDirection();
                }
            }
        }

        private void MoveInvaders(float x, float y)
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    invaders[i, j].Translate(x, y, 0);
                }
            }
        }

        private void ChangeDirection()
        {
            isMovingRight = !isMovingRight;
            MoveInvaders(0, -ySpacing);
        }

        internal int GetPts(string name)
        {
            if (ptsMap.ContainsKey(name))
            {
                return ptsMap[name];
            }
            return 0;
        }



    }
    
}
