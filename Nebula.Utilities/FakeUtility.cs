using System;
using Nebula.Common;
using Nebula.Utilities.Maths;

namespace Nebula.Utilities
{
    public class FakeUtility
    {
        public static Guid CreateGuid()
        {
            return Guid.NewGuid();
        }

        public static bool CreateBool()
        {
            throw new NotImplementedException();
        }

        public static int CreateIntNumber(int min = 0, int max = 10000)
        {
            return RandomUnitily.Random(min, max);
        }

        public static double CreateDouble(int min = 0, int max = 10000)
        {
            return RandomUnitily.RandomDouble(min, max);
        }



        public static string CreateUsername(int minLength = 6, int maxLength = 12)
        {
            return CreateLetters(minLength, minLength);
        }

        private static string CreateLetters(int minLength = 6, int maxLength = 12)
        {
            string str = String.Empty;
            for (int i = 0; i < 10; i++)
            {
                str = RandomUnitily.RandomLetter(8, 15);
            }
            return str;
        }

        public static string CreateEmail()
        {
            var dnsegs = new[]
            {
                "gmail.com", "yahoo.com", "msn.com", "hotmail.com", "aol.com", "ask.com", "live.com", "qq.com","0355.net", "163.com", "163.net", "263.net", "3721.net", "yeah.net", "hotmail.com", "msn.com","yahoo.com", "gmail.com", "aim.com", "aol.com", "mail.com", "walla.com", "inbox.com", "126.com","163.com", "sina.com", "21cn.com", "sohu.com", "yahoo.com.cn", "tom.com", "qq.com", "etang.com","eyou.com", "56.com", "x.cn", "chinaren.com", "sogou.com", "citiz.com"

            };
            var back = dnsegs[RandomUnitily.Random(0, dnsegs.Length - 1)];
            var front = CreateLetters(6, 15);
            return front + back;
        }

        public static string CreateMobile()
        {
            var dnsegs = new []
            {
                "134", "135", "136", "137", "138", "139", "150", "151", "152", "157", "158", "159", "187", "188", "130","131", "132", "155", "156", "185", "186", "133", "153", "180", "189"
            };

            var front = dnsegs[RandomUnitily.Random(0, dnsegs.Length - 1)];
            var back = RandomUnitily.Random(10000000, 99999999);
            return front + back;
        }

        public static Guid CreatePersonName()
        {
            var familyName = "赵钱孙李周吴郑王冯陈褚卫蒋沈韩杨朱秦尤许何吕施张孔曹严华金魏陶姜戚谢邹喻柏水窦章云苏潘葛奚范彭郎鲁韦昌马苗凤花方俞任袁柳酆鲍史唐费廉岑薛雷贺倪汤滕殷罗毕郝邬安常乐于时傅皮卞齐康伍余元卜顾孟平黄和穆萧尹姚邵湛汪祁毛禹狄米贝明臧计伏成戴谈宋茅庞熊纪舒屈项祝董梁杜阮蓝闵席季麻强贾路娄危江童颜郭梅盛林刁锺徐邱骆高夏蔡田樊胡凌霍虞万支柯昝管卢莫经房裘缪干解应宗丁宣贲邓郁单杭洪包诸左石崔吉钮龚程嵇邢滑裴陆荣翁荀羊於惠甄麴家封芮羿储靳汲邴糜松井段富巫乌焦巴弓牧隗山谷车侯宓蓬全郗班仰秋仲伊宫宁仇栾暴甘钭历戎祖武符刘景詹束龙叶幸司韶郜黎蓟溥印宿白怀蒲邰从鄂索咸籍赖卓蔺屠蒙池乔阳郁胥能苍双闻莘党翟谭贡劳逄姬申扶堵冉宰郦雍却璩桑桂濮牛寿通边扈燕冀僪浦尚农温别庄晏柴瞿阎充慕连茹习宦艾鱼容向古易慎戈廖庾终暨居衡步都耿满弘匡国文寇广禄阙东欧殳沃利蔚越夔隆师巩厍聂晁勾敖融冷訾辛阚那简饶空曾毋沙乜养鞠须丰巢关蒯相查后荆红游竺权逮盍益桓公";

            throw new NotImplementedException();
        }

        public static GenderType CreateGender()
        {
            var index = RandomUnitily.Random(0, 2);
            if(index == 2)
                return GenderType.Female;
            else if(index == 1)
                return GenderType.Male;
            else
                return GenderType.None;
        }

        public static GenderType CreatePersonHeight()
        {
            throw new NotImplementedException();
        }


        public static Guid CreateBirthday()
        {
            throw new NotImplementedException();
        }

        public static Guid CreateDateTime()
        {
            throw new NotImplementedException();
        }
    }
}
