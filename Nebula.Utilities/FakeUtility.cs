﻿using System;
using System.Diagnostics;
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

        public static bool RandomBool()
        {
            return RandomUnitily.Random(0, 9) % 2  == 0;
        }

        public static int RandomInt(int min = 0,int max = 10000)
        {
            return RandomUnitily.Random(min,max);
        }

        public static double RandomDouble(int min = 0,int max = 10000)
        {
            return RandomUnitily.RandomDouble(min,max);
        }

        public static string CreateUsername(int minLength = 6,int maxLength = 12)
        {
            return RamdomLetters(minLength, maxLength);
        }

        public static string CreatePassword(int length = 6)
        {
            if (length < 4)
                length = 4;
            if (length > 8)
                length = 8;
            var numLength = RandomUnitily.Random(length - 2, length);
            var front = RandomUnitily.Random(100000, 999999).ToString().Substring(0, numLength);
            if(length > numLength)
                return front + RandomUnitily.RandomLetter(length - numLength);
            return front;
        }

        private static string RamdomLetters(int minLength, int maxLength)
        {
            return RandomUnitily.RandomLetter(minLength, maxLength);
        }

        public static string CreateEmail()
        {
            var dnsegs = new[]
            {
                "gmail.com","yahoo.com","msn.com","hotmail.com","aol.com","ask.com","live.com","qq.com","0355.net","163.com","163.net","263.net","3721.net","yeah.net","hotmail.com","msn.com","yahoo.com","gmail.com","aim.com","aol.com","mail.com","walla.com","inbox.com","126.com","163.com","sina.com","21cn.com","sohu.com","yahoo.com.cn","tom.com","qq.com","etang.com","eyou.com","56.com","x.cn","chinaren.com","sogou.com","citiz.com"

            };
            var back = dnsegs[RandomUnitily.Random(0,dnsegs.Length - 1)];
            var front = RamdomLetters(3,10);
            return front + "@" + back;
        }

        public static string CreateMobile()
        {
            var dnsegs = new []
            {
                "134","135","136","137","138","139","150","151","152","157","158","159","187","188","130","131","132","155","156","185","186","133","153","180","189"
            };

            var front = dnsegs[RandomUnitily.Random(0,dnsegs.Length - 1)];
            var back = RandomUnitily.Random(10000000,99999999);
            return front + back;
        }

        public static string CreatePersonName(GenderType gender)
        {
            var familyNames =
                "赵钱孙李周吴郑王冯陈褚卫蒋沈韩杨朱秦尤许何吕施张孔曹严华金魏陶姜戚谢邹喻柏水窦章云苏潘葛奚范彭郎鲁韦昌马苗凤花方俞任袁柳酆鲍史唐费廉岑薛雷贺倪汤滕殷罗毕郝邬安常乐于时傅皮卞齐康伍余元卜顾孟平黄和穆萧尹姚邵湛汪祁毛禹狄米贝明臧计伏成戴谈宋茅庞熊纪舒屈项祝董梁杜阮蓝闵席季麻贾路娄危江童颜郭梅盛林刁锺徐邱骆高夏蔡田樊胡凌霍虞万支柯昝管卢莫经房裘缪干解应宗丁宣贲邓郁单杭洪包诸左石崔吉";//钮龚程嵇邢滑裴陆荣翁荀羊於惠甄麴家封芮羿储靳汲邴糜松井段富巫乌焦巴弓牧隗山谷车侯宓蓬全郗班仰秋仲伊宫宁仇栾暴甘钭历戎祖武符刘景詹束龙叶幸司韶郜黎蓟溥印宿白怀蒲邰从鄂索咸籍赖卓蔺屠蒙池乔阳郁胥能苍双闻莘党翟谭贡劳逄姬申扶堵冉宰郦雍却璩桑桂濮牛寿通边扈燕冀僪浦尚农温别庄晏柴瞿阎充慕连茹习宦艾鱼容向古易慎戈廖庾终暨居衡步都耿满弘匡国文寇广禄阙东欧殳沃利蔚越夔隆师巩厍聂晁勾敖融冷訾辛阚那简饶空曾毋沙乜养鞠须丰巢关蒯相查后荆红游竺权逮盍益桓公";

            #region femaleNames and maleNames
            var femaleNames = new[] { "筠","柔","竹","霭","凝","晓","欢","霄","枫","芸","菲","寒","伊","亚","宜","可","姬","舒","影","荔","枝","思","丽","秀","娟","英","华","慧","巧","美","娜","静","淑","惠","珠","翠","雅","芝","玉","萍","红","娥","玲","芬","芳","燕","彩","春","菊","勤","珍","贞","莉","兰","凤","洁","梅","琳","素","云","莲","真","环","雪","荣","爱","妹","霞","香","月","莺","媛","艳","瑞","凡","佳","嘉","琼","桂","娣","叶","璧","璐","娅","琦","晶","妍","茜","秋","珊","莎","锦","黛","青","倩","婷","姣","婉","娴","瑾","颖","露","瑶","怡","婵","雁","蓓","纨","仪","荷","丹","蓉","眉","君","琴","蕊","薇","菁","梦","岚","苑","婕","馨","瑗","琰","韵","融","园","艺","咏","卿","聪","澜","纯","毓","悦","昭","冰","爽","琬","茗","羽","希","宁","欣","飘","育","滢","馥","莹","雪","琳","晗","涵","琴","晴","丽","美","瑶","梦","茜","倩","希","夕","梅","月","悦","乐","彤","珍","依","沫","玉","灵","彩","春","菊","兰","凤","洁","素","云","莲","婷","姣","婉","娴","瑾","颖","露","怡","婵","秀","娟","英","华","慧","巧","娜","静","淑","珠","翠","雅","芝","萍","红","枫","芸","菲","思","芬","芳","燕","莺","媛","艳","珊","莎","惠","毓","昭","冰","璐","娅","琦","晶","妍","柔","竹","霭","凝","晓","欢","霄","蕊","薇","菁","岚","苑","婕","馨","瑗","姬","舒","羽","希","宁","欣","琰","韵","融","园","艺","咏","卿","聪","澜","纯","爽","琬","茗","飘","育","滢","馥","筠","伊","亚","宜","可","影","枝","寒","锦","玲","秋","真","环","荣","爱","妹","霞","香","瑞","凡","佳","嘉","琼","勤","珍","贞","莉","桂","娣","叶","璧","黛","青","雁","蓓","纨","仪","荷","丹","寒","娥","玲","桂","娣","锦","蓉","眉","君","清","姿","娟","香","如","凤","环","嫣","烟","静","婷","曼","佳","洁","钗","雯","宝","雨","蕾","霜","语","紫","蝶","柳","碧","诗","芹","思","若","初","慧","妙","娇","花"};
            var maleNames = new [] {"绍","功","松","厚","庆","磊","民","友","裕","河","哲","之","轮","翰","朗","伯","宏","言","若","鸣","朋","斌","利","清","飞","彬","富","顺","信","子","杰","涛","昌","林","有","坚","和","彪","博","诚","先","敬","震","振","晨","辰","士","建","家","致","炎","德","行","时","泰","志","武","中","榕","奇","鹏","楠","泽","风","博","诚","伟","刚","勇","毅","俊","峰","强","军","平","东","文","兴","良","海","山","仁","波","宁","贵","福","生","龙","江","超","浩","亮","政","谦","亨","固","成","康","星","壮","会","思","豪","心","邦","承","乐","盛","雄","琛","先","敬","震","振","壮","茂","磊","航","辉","力","明","元","全","国","胜","学","祥","才","发","光","天","达","钧","冠","策","腾","弘","永","健","世","广","义","安","伟","刚","勇","毅","俊","峰","强","军","平","保","东","文","辉","力","明","永","健","世","广","志","义","兴","良","海","山","仁","波","宁","贵","福","生","龙","元","全","国","胜","学","祥","才","发","武","新","利","清","飞","彬","富","顺","信","子","杰","涛","昌","成","康","星","光","天","达","安","岩","中","茂","进","林","有","坚","和","彪","博","诚","先","敬","震","振","壮","会","思","群","豪","心","邦","承","乐","绍","功","松","善","厚","庆","磊","民","友","裕","河","哲","江","超","浩","亮","政","谦","亨","奇","固","之","轮","翰","朗","伯","宏","言","若","鸣","朋","斌","梁","栋","维","启","克","伦","翔","旭","鹏","泽","晨","辰","士","以","建","家","致","树","炎","德","行","时","泰","盛","世","韩","俯","颁","颇","频","颔","风","飒","飙","飚","马","亮","仑","仝","代","儋","利","力","劼","勒","卓","哲","喆","展","帝","弛","弢","弩","彰","征","律","德","志","忠","思","振","挺","掣","旲","旻","昊","昮","晋","晟","晸","朕","朗","段","殿","泰","滕","炅","炜","煜","煊","炎","选","玄","勇","君","稼","黎","利","贤","谊","金","鑫","辉","墨","欧","有","友","闻","问","舜","丞","主","产","仁","仇","仓","仕","仞","任","伋","众","伸","佐","佺","侃","侪","促","俟","信","俣","修","倝","倡","倧","偿","储","僖","僧","僳","儒","俊","伟","列","则","刚","创","前","剑","助","劭","势","勘","参","叔","吏","嗣","士","壮","孺","守","宽","宾","宋","宗","宙","宣","实","宰","尊","峙","峻","崇","崈","川","州","巡","帅","庚","战","才","承","拯","操","斋","昌","晁","暠","曾","珺","玮","珹","琒","琛","琩","琮","琸","瑎","玚","璟","璥","瑜","生","畴","矗","矢","石","磊","砂","碫","示","社","祖","祚","祥","禅","稹","穆","竣","竦","综","缜","绪","舱","舷","船","蚩","襦","轼","辑","轩","子","杰","榜","碧","葆","莱","蒲","天","乐","东","钢","铎","铖","铠","铸","铿","锋","镇","键","镰","馗","旭","骏","骢","骥","驹","驾","骄","诚","诤","赐","慕","端","征","坚","建","弓","强","彦","御","悍","擎","攀","旷","昂","晷","健","冀","凯","劻","啸","柴","木","林","森","朴","骞","寒","函","高","魁","魏","鲛","鲲","鹰","丕","乒","候","冕","勰","备","宪","宾","密","封","山","峰","弼","彪","彭","旁","日","明","昪","昴","胜","汉","涵","汗","浩","涛","淏","清","澜","浦","澉","澎","澔","濮","濯","瀚","瀛","灏","沧","虚","豪","豹","辅","辈","迈","邶","合","部","阔","雄","霆","震","飞","铭","镐"};
            #endregion

            var names = gender == GenderType.Female ? femaleNames : maleNames;
            var index = RandomUnitily.Random(0, familyNames.Length);
            var familyName = familyNames[index];
            var name = names[RandomUnitily.Random(0, names.Length)];
            if (index % 2 == 0)
                name += names[RandomUnitily.Random(0, names.Length)];
            return familyName + name;
        }

        public static GenderType CreateGender()
        {
            var index = RandomUnitily.Random(0,51);
            if(index >= 0 && index <= 24)
                return GenderType.Male;
            if (index >= 25 && index <= 49)
                return GenderType.Female;
            return GenderType.None;
        }

        public static float CreatePersonHeight()
        {
            return RandomUnitily.Random(160, 200) / 100.0f;
        }


        public static DateTime CreateBirthday(int startYear = 1950)
        {
            var year = RandomUnitily.Random(startYear, DateTime.Now.Year);
            var month = RandomUnitily.Random(1, 12);
            int maxDay;
            switch (month)
            {
                case 2:
                    maxDay = 28;
                    break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    maxDay = 31;
                    break;
                default:
                    maxDay = 30;
                    break;
            }

            var day = RandomUnitily.Random(1, maxDay);
            return new DateTime(year, month, day);
        }
    }
}
