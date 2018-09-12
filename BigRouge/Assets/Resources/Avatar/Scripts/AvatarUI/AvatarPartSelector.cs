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
        private Button catPre;
        private Button catNext;
        private Dropdown dropdown;
        private Button idPre;
        private Button idNext;
        private Text path;
        private Dictionary<int,AvatarRecord> avDict;

        private AvatarRecord avRecord;


        private void Awake() {

            avDict = new Dictionary<int, AvatarRecord>();
            avSetter = FindObjectOfType<AvatarSetter>();

            catDropDown = transform.GetChild(1).GetComponent<Dropdown>();
            catPre = transform.GetChild(2).GetComponent<Button>();
            catNext = transform.GetChild(3).GetComponent<Button>();
            dropdown =  transform.GetChild(4).GetComponent<Dropdown>();
            idPre = transform.GetChild(5).GetComponent<Button>();
            idNext = transform.GetChild(6).GetComponent<Button>();
            path = transform.GetChild(7).GetComponent<Text>();

            catDropDown.onValueChanged.AddListener(OnCatChange);
            dropdown.onValueChanged.AddListener(OnAvatarIDChange);
            sexDropDown.onValueChanged.AddListener(OnSexChange);

            idPre.onClick.AddListener(() => dropdown.value--);
            idNext.onClick.AddListener(() => dropdown.value++);

            catPre.onClick.AddListener(() => catDropDown.value--);
            catNext.onClick.AddListener(() => catDropDown.value++);


            catPre.GetComponentInChildren<Text>().text = "<";
            catNext.GetComponentInChildren<Text>().text = ">";
            idPre.GetComponentInChildren<Text>().text = "<";
            idNext.GetComponentInChildren<Text>().text = ">";
        }

        private void Start() {
            //avDict = AvatarDataHandler.SelectRecords(apt , sex, cat);


        }

        void OnSexChange(int id) {
            sex = (SexType)sexDropDown.value;

            catDropDown.ClearOptions();

            List<string> cats = AvatarDataHandler.SelectCats(apt, sex);

            catDropDown.AddOptions(cats);
            catDropDown.value = 0;
            OnCatChange(0);
            catDropDown.RefreshShownValue();
        }

        /// <summary>
        /// 变更关键字
        /// </summary>
        /// <param name="id"></param>
        void OnCatChange(int id) {
            cat = catDropDown.captionText.text;


            dropdown.ClearOptions();

            List<int> ids = AvatarDataHandler.SelectRecordIDs(apt, sex, cat);
            dropdown.options.Add(new Dropdown.OptionData("-1"));
            for (int i = 0; i < ids.Count; i++) {
                dropdown.options.Add(new Dropdown.OptionData(ids[i].ToString()));
            }

            dropdown.value = 0;

            dropdown.RefreshShownValue();

        }

 

        /// <summary>
        /// 选择AvID
        /// </summary>
        /// <param name="index"></param>
        void OnAvatarIDChange(int index) {

            int id = int.Parse(dropdown.captionText.text);
            avRecord = AvatarDataHandler.GetAvatarRecord(id);

            path.text = avRecord.path;

            avSetter.SetAndBuildAvatarPart(avSlot, id);
        }





  


    }

}