using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiuLinFireWall.Model
{
    public class IpListModel
    {
        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// IP 来源地址
        /// </summary>
        public string IpSourceAddress { get; set; }

        /// <summary>
        /// IP集合
        /// </summary>
        public string IpList { get; set; }

        /// <summary>
        /// 是否为中国
        /// </summary>
        public int IsChina { get; set; }
    }
}
