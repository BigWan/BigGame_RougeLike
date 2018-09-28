using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;
using BigRogue.Persistent;
using BigRogue.PathFinding;

namespace BigRogue.BattleSystem {


    /// <summary>
    /// 角色
    /// </summary>
    public class Actor : Entity {


        [Header("Actor Config")]
        
        public float moveSpeed = 3f;
        public float rotationSpeed = 180f;

        public Vector2Int orientation;


        /// <summary>
        /// 配置表记录ID
        /// </summary>
        public int charInfoID;

        [SerializeField]
        /// <summary>
        /// 角色基础信息
        /// </summary>
        private CharacterRecord charInfo;


        [Header("Energy")]
        public float energy;
        public float energyRegen {
            get {
                return charInfo.speed + 10;
            }
        }

        public int moveRange {
            get {
                return charInfo.moveRange;
            }
        }

        public int attackRange {
            get {
                return charInfo.attackRange;
            }
        }

        public BattleGround battleGround {
            get {
                return battleManager.battleGround;
            }
        }


        [Header("Refs")]
        public BattleManager battleManager;
        private CombatState combatState;
        private Animator m_animator {
            get {
                return GetComponentInChildren<Animator>();
            }
        }

        [Header("Event")]


        /// <summary>
        /// 角色进入回合
        /// </summary>
        public Action<Actor> EnterTurnHandler;
        /// <summary>
        /// 角色结束回合
        /// </summary>
        public Action<Actor> FinishTurnHandler;

        protected Action<Actor> ActStartEventHandler;
        protected Action<Actor> ActEndEventHandler;

        /// <summary>
        /// 角色开始移动
        /// </summary>
        public Action<Actor> MoveStartEventHandler;
        /// <summary>
        /// 角色移动完毕
        /// </summary>
        public Action<Actor> MoveEndEventHandler;

        // MonoBehaviour Message

        private void Awake() {
            battleManager = FindObjectOfType<BattleManager>();
            orientation = Vector2Int.up;
            GetCharInfo();
        }

        private void Start() {
            //m_animator = GetComponentInChildren<Animator>();
            //turnState = new IdleState(); 
        }


        /// <summary>
        /// 获取配置表数据
        /// </summary>
        void GetCharInfo() {
            charInfo = CharacterInfoHandler.GetRecord(charInfoID);
            if (charInfo.isEmpty()) {
                throw new UnityException($"配置信息错误{charInfoID}");
            }
        }


        #region "能量相关"

        public void RegenEnergy() {
            energy += energyRegen;
        }

        public void DeductEnergy() {
            energy -= 1000;
        }

        public bool IsEnergyEnough(float eng) {
            return energy >= eng;
        }

        #endregion


        #region "Check Flags"

        protected bool CanAct() {
            return true;
        }

        protected bool CanMoveTo(int x, int y) {
            return true;

        }
        protected bool CanMove() {
            return true;
        }

        protected bool CanAttack() {
            return true;
        }

        protected bool CanShoot() {
            return true;
        }

        protected bool CanCastSpell() {
            return true;
        }

        #endregion


        #region "Avatar相关"
        // some
        #endregion


        #region "状态机相关"


        int turn;
        public bool allowMove;
        public bool allowAct;
        private TurnStateBase turnState;        // 回合状态

        public Action MoveOverHandler;

        public void ChangeTurnState(TurnStateBase newState) {
            turnState.Exit();
            turnState = newState;
            turnState.Enter();
        }

        public bool turnFinished;

        /// <summary>
        /// 进入回合
        /// </summary>
        /// <returns></returns>
        public IEnumerator ActiveTurn() {

            Debug.Log($"{name}开始行动");

            turnFinished = false;
            allowMove = true;
            allowAct = true;

            EnterTurnHandler?.Invoke(this);
            turn++;

            turnState = new PrepareState(this);

            while (!turnFinished) {
                yield return null;
            }

            FinishedTurn();
        }


        void FinishedTurn() {
            Debug.Log("Im done");
            turnState = null;
            energy -= 1000f;
        }

        public void GetFinishTurnCommand() { }


        private void Select() {

        }

        private void Deselect() {

        }

        #endregion



        #region "移动相关"


        /// <summary>
        /// 朝目标移动
        /// </summary>
        /// <param name="target">行动范围内的一个地块</param>
        public void StartMove(Block target) {

            NodeMesh mesh = battleGround.PathNodeMesh();

            List<PathNode> path = AStar.FindPath(mesh,
                mesh.GetNode(coordinate2D),
                mesh.GetNode(target.coordinate2D),
                HeuristicsType.Manhattan, false, 10);

            StartCoroutine(MovingByPathCoroutine(path));
        }

        /// <summary>
        /// 按路径移动的移动
        /// </summary>
        /// <param name="path">寻路节点</param>
        /// <returns></returns>
        public IEnumerator MovingByPathCoroutine(List<PathNode> path) {
            if (path.Count <= 0) yield break;
            for (int i = path.Count - 1; i >= 0; i--) {
                yield return StartCoroutine(MoveToNode(path[i]));
            }
            transform.localPosition = path[0].localPosition;
            coordinate3D = path[0].coordinate3D;
            MoveOverHandler?.Invoke();
        }



        IEnumerator RotateCououtine(Vector3 euler) {
            float t = 0;
            while (t < 0.5f) {
                t += Time.deltaTime;
                transform.localEulerAngles += euler * 2 * Time.deltaTime;
                yield return null;
            }
            
        }

        IEnumerator MoveToNode(PathNode node) {
            //float moveSpeed = 3;
            m_animator.SetFloat("f_MoveSpeed", moveSpeed);
            Vector3 oldPosition = transform.localPosition;
            Vector2Int dir = node.coordinate2D - coordinate2D;

            Quaternion rotation = Quaternion.FromToRotation(
                new Vector3(orientation.x,0, orientation.y)
                , node.coordinate3D - coordinate3D);

            Vector3 euler = rotation.eulerAngles;

            yield return StartCoroutine(RotateCououtine(euler));

            float moveTime = 1f / moveSpeed;
            float t = 0;
            float deltaX;
            while (t < moveTime) {
                t += Time.deltaTime;
                deltaX = t / moveTime;
                transform.localPosition = oldPosition + new Vector3(dir.x, 0, dir.y) * deltaX;
                yield return null;
            }
            transform.localPosition = node.localPosition;
            coordinate3D = node.coordinate3D;
            m_animator.SetFloat("f_MoveSpeed", 0);
        }



        #endregion
    }
}