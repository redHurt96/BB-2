using System.Collections.Generic;
using com.adjust.sdk;

namespace Mamboo.Analytics.Adjust.Internal
{
    internal static class AdjustConstants
    {
        internal const AdjustEnvironment Environment = AdjustEnvironment.Production;
        
        #if UNITY_ANDROID
        public const string AppToken = "4h0ciktebxmo";
        
        public const string Ad_impressions_1 = "knwrrc";
        public const string Ad_impressions_10 = "yeki4v";
        public const string Ad_impressions_100 = "ll37or";
        public const string Ad_impressions_20 = "s51nz7";
        public const string Ad_impressions_200 = "o7wrhl";
        public const string Ad_impressions_25 = "yns2gt";
        public const string Ad_impressions_45 = "ti4qcp";
        public const string Ad_impressions_5 = "tchxbc";
        public const string Ad_impressions_500 = "496bkw";
        public const string Ad_revenue_05_usd = "euwkjo";
        public const string Ad_revenue_10_usd = "81mxxo";
        public const string Ad_revenue_15_usd = "u5y6vc";
        public const string Ad_revenue_1_usd = "6fozf9";
        public const string Ad_revenue_2_usd = "4j6i5z";
        public const string Ad_revenue_4_usd = "uv9a1w";
        public const string Ad_revenue_6_usd = "8l647i";
        public const string Ad_revenue_7_usd = "vipdf4";
        public const string App_open = "z8c9y8";
        public const string Ecpm_100_usd = "y4z8o1";
        public const string Ecpm_15_usd = "44wblf";
        public const string Ecpm_25_usd = "x9z0mo";
        public const string Ecpm_35_usd = "go42sl";
        public const string Ecpm_45_usd = "cmhwx7";
        public const string Ecpm_5_usd = "ozrwfs";
        public const string Ecpm_65_usd = "1g4ead";
        public const string Ecpm_85_usd = "nv3uxg";
        public const string Playtime_10 = "mfb6vw";
        public const string Playtime_150 = "smeutb";
        public const string Playtime_20 = "t4okwt";
        public const string Playtime_250 = "rfgrh8";
        public const string Playtime_40 = "b5di8r";
        public const string Playtime_400 = "o0hliy";
        public const string Playtime_5 = "xc9ur7";
        public const string Playtime_80 = "kjxd01";
        public const string Purchase = "dbf485";
        public const string Purchase_failed = "3pg61v";
        public const string Purchase_not_verified = "1w9tf0";
        public const string Purchase_unknown = "k7hdvu";
        public const string CrossPromo_1 = "ret_D1";
        public const string StartAppEventId = "rkxzv7";
        public const string Retention = "";
        
        #endif
        #if UNITY_IOS
        public const string AppToken = "";
        
        public const string Ad_impressions_1 = "";
        public const string Ad_impressions_10 = "";
        public const string Ad_impressions_100 = "";
        public const string Ad_impressions_20 = "";
        public const string Ad_impressions_200 = "";
        public const string Ad_impressions_25 = "";
        public const string Ad_impressions_45 = "";
        public const string Ad_impressions_5 = "";
        public const string Ad_impressions_500 = "";
        public const string Ad_revenue_05_usd = "";
        public const string Ad_revenue_10_usd = "";
        public const string Ad_revenue_15_usd = "";
        public const string Ad_revenue_1_usd = "";
        public const string Ad_revenue_2_usd = "";
        public const string Ad_revenue_4_usd = "";
        public const string Ad_revenue_6_usd = "";
        public const string Ad_revenue_7_usd = "";
        public const string Ecpm_100_usd = "";
        public const string Ecpm_15_usd = "";
        public const string Ecpm_25_usd = "";
        public const string Ecpm_35_usd = "";
        public const string Ecpm_45_usd = "";
        public const string Ecpm_5_usd = "";
        public const string Ecpm_65_usd = "";
        public const string Ecpm_85_usd = "";
        public const string Playtime_10 = "";
        public const string Playtime_150 = "";
        public const string Playtime_20 = "";
        public const string Playtime_250 = "";
        public const string Playtime_40 = "";
        public const string Playtime_400 = "";
        public const string Playtime_5 = "";
        public const string Playtime_80 = "";
        public const string Purchase = "";
        public const string Purchase_failed = "";
        public const string Purchase_not_verified = "";
        public const string Purchase_unknown = "";
        public const string CrossPromo_1 = "";
        public const string StartAppEventId = "";
        public const string Retention = "";
        
        #endif

        public static Dictionary<string, string> TokensForPlaytime = new Dictionary<string, string>
        {
            {"playtime_10",  Playtime_10},
            {"playtime_150", Playtime_150},
            {"playtime_20",  Playtime_20},
            {"playtime_250", Playtime_250},
            {"playtime_40",  Playtime_40},
            {"playtime_400", Playtime_400},
            {"playtime_5",   Playtime_5},
            {"playtime_80",  Playtime_80}

        };
       
        public static Dictionary<string, string> TokensForOther = new Dictionary<string, string>
       {
           {"ad_revenue_05_usd", Ad_revenue_05_usd},
           {"ad_revenue_10_usd", Ad_revenue_10_usd},
           {"ad_revenue_15_usd", Ad_revenue_15_usd},
           {"ad_revenue_1_usd",  Ad_revenue_1_usd},
           {"ad_revenue_2_usd",  Ad_revenue_2_usd},
           {"ad_revenue_4_usd",  Ad_revenue_4_usd},
           {"ad_revenue_6_usd",  Ad_revenue_6_usd},
           {"ad_revenue_7_usd",  Ad_revenue_7_usd},
           {"ecpm_15_usd", Ecpm_15_usd},
           {"ecpm_25_usd", Ecpm_25_usd},
           {"ecpm_35_usd", Ecpm_35_usd},
           {"ecpm_45_usd", Ecpm_45_usd},
           {"ecpm_5_usd",  Ecpm_5_usd},
           {"ecpm_65_usd", Ecpm_65_usd},
           {"ecpm_85_usd", Ecpm_85_usd},
           {"ecpm_100_usd", Ecpm_100_usd},
           {"ad_impressions_1",    Ad_impressions_1},
           {"ad_impressions_10",   Ad_impressions_10},
           {"ad_impressions_100",  Ad_impressions_100},
           {"ad_impressions_20",   Ad_impressions_20},
           {"ad_impressions_200",  Ad_impressions_200},
           {"ad_impressions_25",   Ad_impressions_25},
           {"ad_impressions_45",   Ad_impressions_45},
           {"ad_impressions_5",  Ad_impressions_5},
           {"ad_impressions_500",  Ad_impressions_500 }
       };
       
        public  static Dictionary<string, string> TokensForCrossPromo = new Dictionary<string, string>
       {
           {"cross_1",  CrossPromo_1},
       };
    }
}