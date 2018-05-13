/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2018/05/13 20:57:14
** desc:  配置表管理类;
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Framework
{
    public class TableMgr<T> where T : TableData
    {
        protected List<T> _dataList = new List<T>();

        public T GetByIndex(int index)
        {
            return _dataList[index];
        }

        public int Size()
        {
            return _dataList.Count;
        }

        public void LoadData(byte[] bytes)
        {
            _dataList.Clear();
            int pos = 0;
            int dataCount = ConverterUtility.GetInt32(bytes, pos);
            pos += Marshal.SizeOf(pos);
            for (int i = 0; i < dataCount; i++)
            {
                T data = Activator.CreateInstance<T>();
                data.Decode(bytes, ref pos);
                _dataList.Add(data);
            }
        }
    }
}