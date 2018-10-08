using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using BigRogue.Persistent;
using BigRogue.PathFinding;
using BigRogue.BattleSystem;
using BigRogue.ATB;

namespace BigRogue {

    /// <summary>
    /// 角色
    /// </summary>
    public class Actor : Entity {


        [Header("Actor Config")]

        public float moveSpeed = 3f;
        public float rotationSpeed = 180f;

        /// <summary>
        /// 配置表记录ID
        /// </summary>
        public int charInfoID;

        [SerializeField]
        /// <summary>
        /// 角色基础信息
        /// </summary>
        private CharacterRecord charRecord;


        [Header("Energy")]
        public float energy;
        public float energyRegen {
            get {
                return charRecord.speed * 0.01f + 10;
            }
        }

        public int moveRange {
            get {
                return charRecord.moveRange;
            }
        }

        public int attackRange {
            get {
                return charRecord.attackRange;
            }
        }

        public BattleGround battleGround {
            get {
                return battleManager.battleGround;
            }
        }


        [Header("Refs")]
        public BattleManager battleManager;
        private AttributeGroup attributeGroup;

        //private SelectAble selectAble;

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


            


            attributeGroup = new AttributeGroup();
            battleManager = FindObjectOfType<BattleManager>();
            //selectAble = GetComponent<SelectAble>();
            //selectAble.SelectEventHandler += OnSelect;
            GetCharInfo();
            
        }

        private void Start() {
            //m_animator = GetComponentInChildren<Animator>();
            //turnState = new IdleState(); 
            InitTurnState();
        }

        AttributeModifer baseAtk;
        AttributeModifer baseHp;
        AttributeModifer baseDef;
        AttributeModifer baseStr;
        AttributeModifer baseInt;
        AttributeModifer baseDex;


        AttributeModifer[] baseModifers;

        string[] baseModiferCode = new string[] { };




        void InitBaseAttribute() {
            baseAtk = new AttributeModifer("CHAR.BASE", "ATK", ModifierType.BaseValue, charRecord.atk);
            baseHp = new AttributeModifer("CHAR.BASE", "HP", ModifierType.BaseValue, charRecord.hp);
            baseDef = new AttributeModifer("CHAR.BASE", "DEF", ModifierType.BaseValue, charRecord.def);
            baseStr = new AttributeModifer("CHAR.BASE", "STR", ModifierType.BaseValue, charRecord.str);
            baseInt = new AttributeModifer("CHAR.BASE", "INT", ModifierType.BaseValue, charRecord.@int);
            baseDex = new AttributeModifer("CHAR.BASE", "DEX", ModifierType.BaseValue, charRecord.dex);
            attributeGroup.AddAttributeModifier(baseAtk);
            attributeGroup.AddAttributeModifier(baseHp);
            attributeGroup.AddAttributeModifier(baseDef);
            attributeGroup.AddAttributeModifier(baseStr);
            attributeGroup.AddAttributeModifier(baseInt);
            attributeGroup.AddAttributeModifier(baseDex);
            //TODO
        }

        private void OnDestroy() {
        }

        /// <summary>
        /// 获取配置表数据
        /// </summary>
        void GetCharInfo() {
            charRecord = CharacterInfoHandler.GetRecord(charInfoID);
            if (charRecord.isEmpty()) {
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

        //protected bool CanAct() {
        //    return true;
        //}

        //protected bool CanMoveTo(int x, int y) {
        //    return true;

        //}
        //protected bool CanMove() {
        //    return true;
        //}

        //protected bool CanAttack() {
        //    return true;
        //}

        //protected bool CanShoot() {
        //    return true;
        //}

        //protected bool CanCastSpell() {
        //    return true;
        //}

        #endregion


        #region "Avatar相关"
        // some
        #endregion


        #region "状态机相关"


        int turn;
        public bool allowMove;
        public bool allowAct;
        private TurnStateBase turnState;        // 回合状态

        private PrepareState prepareState;
        private MoveState moveState;
        private ActState actState;

        void InitTurnState() {
            prepareState = new PrepareState(this);
            moveState = new MoveState(this, battleGround);
            actState = new ActState(this);
        }

        public void ChangeTurnState(TurnStateType stateName) {

            switch (stateName) {
                case TurnStateType.Preparing:
                    ChangeTurnState(prepareState);
                    break;
                case TurnStateType.Moving:
                    ChangeTurnState(moveState);
                    break;
                case TurnStateType.Acting:
                    ChangeTurnState(actState);
                    break;
                default:
                    break;
            }
            
        }

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

            //EnterTurnHandler?.Invoke(this);
            turn++;

            ChangeTurnState(prepareState);

            while (!turnFinished) {
                yield return null;
            }

            FinishedTurn();
        }


        void FinishedTurn() {
            Debug.Log("Im done");
            turnState = null;
            //Deselect();
            energy -= 1000f;
            battleManager.opMenu.FadeOut();
        }

        public void GetFinishTurnCommand() { }


        #endregion




        #region "移动相关"

        public Action MoveOverHandler;

        /// <summary>
        /// 朝目标移动
        /// </summary>
        /// <param name="targetBlock">行动范围内的一个地块</param>
        public void StartMove(Block targetBlock) {

            NodeMesh mesh = battleGround.PathNodeMesh();

            List<PathNode> path = AStar.FindPath(mesh,
                mesh.GetNode(coord),
                mesh.GetNode(targetBlock.coord),
                HeuristicsType.Manhattan, false, 10);
            if (path == null || path.Count <= 0) {
                Debug.Log("寻路结果为空");
                MoveOverHandler?.Invoke();
                return;
            }
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
            transform.localPosition = path[0].coord;
            coord = path[0].coord;
            MoveOverHandler?.Invoke();
        }


        IEnumerator MoveToNode(PathNode node) {
            //float moveSpeed = 3;
            m_animator.SetFloat("f_MoveSpeed", moveSpeed);

            Vector3 oldPosition = transform.localPosition;
            Vector3Int dir = node.coord - coord;

            //yield return StartCoroutine(RotateCououtine(dir));
            transform.rotation = Quaternion.LookRotation(dir);

            float moveTime = 1f / moveSpeed;
            float t = 0;
            float deltaX;
            while (t < moveTime) {
                t += Time.deltaTime;
                deltaX = t * moveSpeed;
                transform.localPosition = oldPosition + new Vector3(dir.x, 0, dir.z) * deltaX;
                yield return null;
            }

            transform.localPosition = node.coord;
            coord = node.coord;
            m_animator.SetFloat("f_MoveSpeed", 0);
        }

        #endregion

        
        public void MoveCommand() {
            
        }


        public void ShowOperateMenu() {
            GameUI.OperateMenu opMenu = battleManager.opMenu;
            opMenu.gameObject.SetActive(true);
            opMenu.Bind(this);

            if (allowMove) {
                opMenu.MoveButton.onClick.RemoveAllListeners();
                opMenu.MoveButton.onClick.AddListener(MoveCommand);
                opMenu.MoveButton.gameObject.SetActive(true);
            } else {
                opMenu.MoveButton.gameObject.SetActive(false);
            }
            if (allowAct) {
                opMenu.ActButton.onClick.RemoveAllListeners();
                opMenu.ActButton.onClick.AddListener(()=> ChangeTurnState(TurnStateType.Moving));
                opMenu.ActButton.gameObject.SetActive(true);
            } else {
                opMenu.ActButton.gameObject.SetActive(false);
            }
            opMenu.FinishButton.onClick.RemoveAllListeners();
            opMenu.FinishButton.onClick.AddListener(()=> turnFinished = true);

            opMenu.FadeIn();
        }


        public void HideOperateMenu() {
        }
    }
}