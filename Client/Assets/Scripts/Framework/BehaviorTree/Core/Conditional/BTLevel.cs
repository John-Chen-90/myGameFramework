/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2018/06/18 18:02:43
** desc:  等级条件执行节点;
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class BTLevel : AbsDecorator
    {
        public BTLevel(Hashtable table) : base(table) { }

        protected override void AwakeEx()
        {
            throw new System.NotImplementedException();
        }

        protected override void Reset()
        {
            throw new System.NotImplementedException();
        }

        protected override void UpdateExx()
        {
            throw new System.NotImplementedException();
        }
    }
}