using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using BigRogue.Avatar;

namespace BigRogue.UI {

    /// <summary>
    /// 选择并设置某个部件的ID
    /// </summary>
    public class AvatarPartSelector : MonoBehaviour {

        public string avatarPartTypeName;


        private AvatarSetter avSetter;

        private Dropdown dropdown;

        private Button pre;

        private Button next;

        private Text path;

        private List<AvatarPartRecord> aprList;

        private AvatarPartRecord apr;


        private void Awake() {
            aprList = new List<AvatarPartRecord>();

            dropdown = GetComponentInChildren<Dropdown>();
            avSetter = FindObjectOfType<AvatarSetter>();
            avatarPartTypeName = transform.name;
            pre = transform.GetChild(2).GetComponent<Button>();
            next = transform.GetChild(3).GetComponent<Button>();
            path = transform.GetChild(4).GetComponent<Text>();

        }

        private void Start() {
            aprList = AvatarDataHandler.GetAvatarPartTypedList(avatarPartTypeName);

            FillOptions();


            dropdown.onValueChanged.AddListener(OnChangeAvatarID);

            pre.onClick.AddListener(() => dropdown.value--);
            next.onClick.AddListener(() => dropdown.value++);

        }


        void OnChangeAvatarID(int index) {
            int id = int.Parse(dropdown.options[dropdown.value].text);   
            apr = AvatarDataHandler.GetAvatarPartRecord(id);
            if (apr.id == -1) apr.avatarPartTypeName = avatarPartTypeName;
            avSetter.SetAndBuildAvatarPart(apr.avatarPartTypeName, apr.id);
        }



        void FillOptions() {
            if (aprList.Count <= 0) return;
            dropdown.options.Add(new Dropdown.OptionData("-1"));
            foreach (var item in aprList) {
                dropdown.options.Add(new Dropdown.OptionData(item.id.ToString()));
            }
        }


  


    }

}