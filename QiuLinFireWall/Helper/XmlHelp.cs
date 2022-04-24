using QiuLinFireWall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QiuLinFireWall.Helper
{
    public class XmlHelp
    {

        /// <summary>
        /// 读取XML 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<IpListModel> ReadXML(string path)
        {
            List<IpListModel> ipLists = new List<IpListModel>();
            XElement xe = XElement.Load(path);
            IEnumerable<XElement> elements = from ele in xe.Elements("IPData")
                                             select ele;

            foreach (var ele in elements)
            {
                IpListModel ipModel = new IpListModel();

                ipModel.Country = ele.Element("Country").Value.ToString().Trim();
                ipModel.IpSourceAddress = ele.Element("IpSourceAddress").Value.ToString().Trim();
                ipModel.IpList = ele.Element("IpList").Value.ToString().Trim();
                ipModel.IsChina = int.Parse(ele.Element("IsChina").Value.ToString().Trim());

                ipLists.Add(ipModel);
            }

            return ipLists;

        }



        /// <summary>
        /// 更新XML
        /// </summary>
        /// <param name="path">IpList.xml 文件地址</param>
        /// <param name="country">要更新的国家</param>
        /// <param name="ipList">新的IP集合</param>
        /// <returns>是否更新成功</returns>
        public static bool UpdateXML(string path, string country, string ipList)
        {
            try
            {

                XElement xe = XElement.Load(path);
                IEnumerable<XElement> element = from ele in xe.Elements("IPData")
                                                where ele.Element("Country").Value == country
                                                select ele;

                if (element.Count() > 0)
                {
                    XElement first = element.First();
                    first.ReplaceNodes(
                             new XElement("Country", first.Element("Country").Value.ToString()),
                             new XElement("IpSourceAddress", first.Element("IpSourceAddress").Value.ToString()),
                             new XElement("IpList", ipList),
                             new XElement("IsChina", first.Element("IsChina").Value.ToString())
                            );
                }
                xe.Save(path);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
