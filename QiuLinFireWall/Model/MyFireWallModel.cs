using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiuLinFireWall.Model
{
  public   class MyFireWallModel
    {
        /// <summary>
        /// 规则名称
        /// </summary>
        public string RuleName { get; set; }


        /// <summary>
        /// 出入站规则类型
        /// </summary>
        public string RuleDirectionTpye { get; set; }
        /// <summary>
        /// 通讯协议规则类型 TCP or UDP or  ANY
        /// </summary>
        public string IpPriticolTpye { get; set; }
        /// <summary>
        /// 操作类型 ：允许连接（还是阻止连接
        /// </summary>
        public string ActionType { get; set; }
        /// <summary>
        /// 应用程序完整路径 （null 表示所有程序）
        /// </summary>
        public string AppPath { get; set; }

        /// <summary>
        /// 规则组名称
        /// </summary>
        public string Grouping { get; set; } 
    }
}
