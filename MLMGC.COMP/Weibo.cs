using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MLMGC.COMP
{
    /// <summary>
    /// 微博类
    /// </summary>
    public class Weibo
    {
        static Dictionary<string, string> _face;
        static readonly object _padlock = new object();
        public static Dictionary<string, string> Face
        {
            get
            {
                if (_face == null)
                {
                    lock (_padlock)
                    {
                        if (_face == null)
                        {
                            _face = new Dictionary<string, string>();
                            _face.Add("织", "/images/common/face/normal/zz2_thumb.gif");
                            _face.Add("神马", "/images/common/face/normal/horse2_thumb.gif");
                            _face.Add("浮云", "/images/common/face/normal/fuyun_thumb.gif");
                            _face.Add("给力", "/images/common/face/normal/geili_thumb.gif");
                            _face.Add("围观", "/images/common/face/normal/wg_thumb.gif");
                            _face.Add("威武", "/images/common/face/normal/vw_thumb.gif");
                            _face.Add("熊猫", "/images/common/face/normal/panda_thumb.gif");
                            _face.Add("兔子", "/images/common/face/normal/rabbit_thumb.gif");
                            _face.Add("奥特曼", "/images/common/face/normal/otm_thumb.gif");
                            _face.Add("囧", "/images/common/face/normal/j_thumb.gif");
                            _face.Add("互粉", "/images/common/face/normal/hufen_thumb.gif");
                            _face.Add("礼物", "/images/common/face/normal/liwu_thumb.gif");
                            _face.Add("呵呵", "/images/common/face/normal/smilea_thumb.gif");
                            _face.Add("嘻嘻", "/images/common/face/normal/tootha_thumb.gif");
                            _face.Add("哈哈", "/images/common/face/normal/laugh.gif");
                            _face.Add("可爱", "/images/common/face/normal/tza_thumb.gif");
                            _face.Add("可怜", "/images/common/face/normal/kl_thumb.gif");
                            _face.Add("挖鼻屎", "/images/common/face/normal/kbsa_thumb.gif");
                            _face.Add("吃惊", "/images/common/face/normal/cj_thumb.gif");
                            _face.Add("害羞", "/images/common/face/normal/shamea_thumb.gif");
                            _face.Add("挤眼", "/images/common/face/normal/zy_thumb.gif");
                            _face.Add("闭嘴", "/images/common/face/normal/bz_thumb.gif");
                            _face.Add("鄙视", "/images/common/face/normal/bs2_thumb.gif");
                            _face.Add("爱你", "/images/common/face/normal/lovea_thumb.gif");
                            _face.Add("泪", "/images/common/face/normal/sada_thumb.gif");
                            _face.Add("偷笑", "/images/common/face/normal/heia_thumb.gif");
                            _face.Add("亲亲", "/images/common/face/normal/qq_thumb.gif");
                            _face.Add("生病", "/images/common/face/normal/sb_thumb.gif");
                            _face.Add("太开心", "/images/common/face/normal/mb_thumb.gif");
                            _face.Add("懒得理你", "/images/common/face/normal/ldln_thumb.gif");
                            _face.Add("右哼哼", "/images/common/face/normal/yhh_thumb.gif");
                            _face.Add("左哼哼", "/images/common/face/normal/zhh_thumb.gif");
                            _face.Add("嘘", "/images/common/face/normal/x_thumb.gif");
                            _face.Add("衰", "/images/common/face/normal/cry.gif");
                            _face.Add("委屈", "/images/common/face/normal/wq_thumb.gif");
                            _face.Add("吐", "/images/common/face/normal/t_thumb.gif");
                            _face.Add("打哈气", "/images/common/face/normal/k_thumb.gif");
                            _face.Add("抱抱", "/images/common/face/normal/bba_thumb.gif");
                            _face.Add("怒", "/images/common/face/normal/angrya_thumb.gif");
                            _face.Add("疑问", "/images/common/face/normal/yw_thumb.gif");
                            _face.Add("馋嘴", "/images/common/face/normal/cza_thumb.gif");
                            _face.Add("拜拜", "/images/common/face/normal/88_thumb.gif");
                            _face.Add("思考", "/images/common/face/normal/sk_thumb.gif");
                            _face.Add("汗", "/images/common/face/normal/sweata_thumb.gif");
                            _face.Add("困", "/images/common/face/normal/sleepya_thumb.gif");
                            _face.Add("睡觉", "/images/common/face/normal/sleepa_thumb.gif");
                            _face.Add("钱", "/images/common/face/normal/money_thumb.gif");
                            _face.Add("失望", "/images/common/face/normal/sw_thumb.gif");
                            _face.Add("酷", "/images/common/face/normal/cool_thumb.gif");
                            _face.Add("花心", "/images/common/face/normal/hsa_thumb.gif");
                            _face.Add("哼", "/images/common/face/normal/hatea_thumb.gif");
                            _face.Add("鼓掌", "/images/common/face/normal/gza_thumb.gif");
                            _face.Add("晕", "/images/common/face/normal/dizzya_thumb.gif");
                            _face.Add("悲伤", "/images/common/face/normal/bs_thumb.gif");
                            _face.Add("抓狂", "/images/common/face/normal/crazya_thumb.gif");
                            _face.Add("黑线", "/images/common/face/normal/h_thumb.gif");
                            _face.Add("阴险", "/images/common/face/normal/yx_thumb.gif");
                            _face.Add("怒骂", "/images/common/face/normal/nm_thumb.gif");
                            _face.Add("心", "/images/common/face/normal/hearta_thumb.gif");
                            _face.Add("伤心", "/images/common/face/normal/unheart.gif");
                            _face.Add("猪头", "/images/common/face/normal/pig.gif");
                            _face.Add("ok", "/images/common/face/normal/ok_thumb.gif");
                            _face.Add("耶", "/images/common/face/normal/ye_thumb.gif");
                            _face.Add("good", "/images/common/face/normal/good_thumb.gif");
                            _face.Add("不要", "/images/common/face/normal/no_thumb.gif");
                            _face.Add("赞", "/images/common/face/normal/z2_thumb.gif");
                            _face.Add("来", "/images/common/face/normal/come_thumb.gif");
                            _face.Add("弱", "/images/common/face/normal/sad_thumb.gif");
                            _face.Add("蜡烛", "/images/common/face/normal/lazu_thumb.gif");
                            _face.Add("钟", "/images/common/face/normal/clock_thumb.gif");
                            _face.Add("蛋糕", "/images/common/face/normal/cake.gif");
                            _face.Add("话筒", "/images/common/face/normal/m_thumb.gif");
                        }
                    }
                }
                return _face;
            }
        }

        public static string WeiboContent(string str)
        {
            //今天周四[哈哈],明天周五[织].[adsfsdfsdfsdfsfd]
            if (string.IsNullOrWhiteSpace(str)) { return str; }
            //str = Regex.Replace(str, "\"", "&quot;");
            MatchCollection mc = Regex.Matches(str, @"\[\w*\]", RegexOptions.IgnoreCase);
            string[] array = Regex.Split(str, @"\[\w*\]", RegexOptions.IgnoreCase);
            string result = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                if (i != array.Length - 1)
                    result += array[i] + GetFace(mc[i].Groups[0].Value);
                else
                    result += array[i];
            }
            return result;
        }

        public static string GetFace(string str)
        {
            //去掉[]
            str = str.Trim('[',']');
            string result = string .Empty;
            if(Face.ContainsKey(str))
            {
                result = string.Format("<em><img type=\"face\" alt=\"[{0}]\" title=\"[{0}]\" src=\"{1}\"></em>", str, Face[str]);
            }
            else
            {
                result = string.Format("[{0}]", str);
            }            
            return result;
        }
    }
}
