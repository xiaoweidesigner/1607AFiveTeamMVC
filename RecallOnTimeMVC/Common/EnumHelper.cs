using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecallOnTimeMVC.Common
{
    public class EnumHelper
    {
        public enum M_EditionEnum
        {//地区
            华语=1,
            美国=2,
            欧洲=3,
            韩国=4,
            日本=5,
            泰国=6,
            印度=7,
            其他=8
        }
        public enum M_MoldEnum
        {//所属类型
            喜剧 = 1,
            家庭 = 2,
            爱情 = 3,
            动作 = 4,
            战争 = 5,
            犯罪 = 6,
            惊悚 = 7,
            动画 = 8,
            伦理 = 8,
            其他 = 9
        }
    }
}