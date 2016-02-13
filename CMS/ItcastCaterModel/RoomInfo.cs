﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastCater.Model
{
    //RoomInfo table 

    //RoomId, RoomName, RoomType, RoomMinimumConsumer
    //RoomMaxConsumer, IsDefault, DelFlag, SubTime, SubBy
    public class RoomInfo
    {
        private int _roomId;

        public int RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }
        private string _roomName;

        public string RoomName
        {
            get { return _roomName; }
            set { _roomName = value; }
        }
        private int _roomType;

        public int RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }
        private decimal _roomMinimumConsumer;

        public decimal RoomMinimumConsumer
        {
            get { return _roomMinimumConsumer; }
            set { _roomMinimumConsumer = value; }
        }
        private int _roomMaxConsumer;

        public int RoomMaxConsumer
        {
            get { return _roomMaxConsumer; }
            set { _roomMaxConsumer = value; }
        }
        private int _isDefault;

        public int IsDefault
        {
            get { return _isDefault; }
            set { _isDefault = value; }
        }
        private int _delFlag;

        public int DelFlag
        {
            get { return _delFlag; }
            set { _delFlag = value; }
        }
        private DateTime _subTime;

        public DateTime SubTime
        {
            get { return _subTime; }
            set { _subTime = value; }
        }
        private int _subBy;

        public int SubBy
        {
            get { return _subBy; }
            set { _subBy = value; }
        }
    }
}
