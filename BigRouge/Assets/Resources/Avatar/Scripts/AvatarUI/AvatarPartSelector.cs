using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using BigRogue.Avatar;

namespace BigRogue.UI {

    /// <summary>
    /// 选择并设置某个部件的ID
    /// </summary>
    public class AvatarPartSelector : MonoBehaviour {

        public AvatarSlot avSlot;

        public AvatarPartType apt;
        private SexType sex;
        private string cat;

        private AvatarSetter avSetter;
        public Dropdown sexDropDown;
        private Dropdown catDropDown;
        private Dropdown dropdown;
        private Button pre;
        private Button next;
        private Text path;
        private Dictionary<int,AvatarRecord> avDict;

        private AvatarRecord avRecord;


        private void Awake() {

            avDict = new Dictionary<int, AvatarRecord>();
            avSetter = FindObjectOfType<AvatarSetter>();

            catDropDown = transform.GetChild(1).GetComponent<Dropdown>();
            dropdown =  transform.GetChild(2).GetComponent<Dropdown>();
            pre = transform.GetChild(3).GetComponent<Button>();
            next = transform.GetChild(4).GetComponent<Button>();
            path = transform.GetChild(5).GetComponent<Text>();

        }

        private void Start() {
            //avDict = AvatarDataHandler.SelectRecords(apt , sex, cat);

            catDropDown.onValueChanged.AddListener(OnCatChange);
            dropdown.onValueChanged.AddListener(OnAvatarIDChange);
            sexDropDown.onValueChanged.AddListener(OnSexChange);

            pre.onClick.AddListener(() => dropdown.value--);
            next.onClick.AddListener(() => dropdown.value++);
        }

        void OnSexChange(int id) {
            sex = (SexType)sexDropDown.value;
            FillCatOptions();
        }

        /// <summary>
        /// 变更关键字
        /// </summary>
        /// <param name="id"></param>
        void OnCatChange(int id) {
            cat = catDropDown.captionText.text;
            FillAvatarIDOptions();

        }

        /// <summary>
        ///  填充关键字
        /// </summary>
        void FillCatOptions() {
            catDropDown.ClearOptions();

            List<string> cats = AvatarDataHandler.SelectCats(apt, sex);

            catDropDown.AddOptions(cats);

            catDropDown.RefreshShownValue();
        }

        /// <summary>
        /// 选择AvID
        /// </summary>
        /// <param name="index"></param>
        void OnAvatarIDChange(int index) {


        }



        void FillAvatarIDOptions() {
            dropdown.ClearOptions();

            List<int> ids = AvatarDataHandler.SelectRecordIDs(apt, sex, cat);
            Debug.Log(ids.Count);
            for (int i = 0; i < ids.Count; i++) {
                dropdown.options.Add(new Dropdown.OptionData(ids[i].ToString()));
            }

            dropdown.RefreshShownValue();
        }


  


    }

}