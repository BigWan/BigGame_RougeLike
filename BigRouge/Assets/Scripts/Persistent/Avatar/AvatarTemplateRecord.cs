using System;
using UnityEngine;
namespace BigRogue.Persistent {


    public struct AvatarTemplateRecord :IRecord {

        public int id { get; set; }
        public int bodyID;
        public int beardID;
        public int earsID;
        public int hairID;
        public int faceID;
        public int hornsID;
        public int wingID;
        public int bagID;
        public int mainHandID;
        public int offHandID;



        public void InitFromLine(string s) {
            try {
                string[] cells = s.Split(',');
                int i = 0;
                id = int.Parse(cells[i]);i++;
                bodyID = int.Parse(cells[i]);i++;
                beardID = int.Parse(cells[i]);i++;
                earsID = int.Parse(cells[i]);i++;
                hairID = int.Parse(cells[i]);i++;
                faceID = int.Parse(cells[i]);i++;
                hornsID = int.Parse(cells[i]);i++;
                wingID = int.Parse(cells[i]);i++;
                bagID = int.Parse(cells[i]);i++;
                mainHandID = int.Parse(cells[i]);i++;
                offHandID = int.Parse(cells[i]);i++;

            } catch (Exception) {

                throw new UnityException($"解析数据行错误:{s}");
            }
        }

        public bool isEmpty() {
            return id == -1;
        }
    }
}