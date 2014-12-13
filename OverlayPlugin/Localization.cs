using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    enum TextItem
    {
        ErrorTitle,
        RequiredAssemblyFileNotFound,
        RequiredAssemblyFileCannotRead,
        RequiredAssemblyFileBlocked,
        RequiredAssemblyFileException,
        DoNotSort,
        SortStringAscending,
        SortStringDescending,
        SortNumberAscending,
        SortNumberDescending
    }

    static class Localization
    {
        private static LocalizationDict dict;

        static Localization()
        {
            dict = new LocalizationDict();

            dict[TextItem.ErrorTitle, ""] = "Error";
            dict[TextItem.ErrorTitle, "ja"] = "エラー";
            dict[TextItem.RequiredAssemblyFileNotFound, ""] = "Required assembly file {0} was not found.";
            dict[TextItem.RequiredAssemblyFileNotFound, "ja"] = "アセンブリ {0} が存在しません。";
            dict[TextItem.RequiredAssemblyFileCannotRead, ""] = "Could not load required assembly file {0}.";
            dict[TextItem.RequiredAssemblyFileCannotRead, "ja"] = "アセンブリ {0} は存在しますが、読み込めません。";
            dict[TextItem.RequiredAssemblyFileBlocked, ""] = "Could not load required assembly file {0} due to security reasons. It seems the file has blocked or placed on the untrusted zone (such as network drive).";
            dict[TextItem.RequiredAssemblyFileBlocked, "ja"] = "セキュリティ上の問題からアセンブリ {0} を読み込めません。アセンブリがネットワーク上にあるか、またはブロックされている可能性があります。";
            dict[TextItem.RequiredAssemblyFileException, ""] = "Exception occured when loading required assembly file {0}:\n{1}";
            dict[TextItem.RequiredAssemblyFileException, "ja"] = "アセンブリ {0}の読み込み時に例外が発生しました:\n{1}";

            dict[TextItem.DoNotSort, ""] = "Do not sort";
            dict[TextItem.DoNotSort, "ja"] = "ソートしない";
            dict[TextItem.SortStringAscending, ""] = "String - Ascending";
            dict[TextItem.SortStringAscending, "ja"] = "文字列 - 昇順";
            dict[TextItem.SortStringDescending, ""] = "String - Descending";
            dict[TextItem.SortStringDescending, "ja"] = "文字列 - 降順";
            dict[TextItem.SortNumberAscending, ""] = "Number - Ascending";
            dict[TextItem.SortNumberAscending, "ja"] = "数値 - 昇順";
            dict[TextItem.SortNumberDescending, ""] = "Number - Descending";
            dict[TextItem.SortNumberDescending, "ja"] = "数値 - 降順";

        }

        public static string GetText(TextItem item)
        {
            return dict[item, GetCurrentLocale()];
        }

        private static string GetCurrentLocale()
        {
            var culture = System.Globalization.CultureInfo.CurrentUICulture;
            return culture.TwoLetterISOLanguageName.ToLower();
        }
    }

    class LocalizationDict
    {
        IDictionary<TextItem, IDictionary<string, string>> dict;

        public LocalizationDict()
        {
            this.dict = new Dictionary<TextItem, IDictionary<string, string>>();
        }

        public string this[TextItem item, string locale]
        {
            get
            {
                if (dict.ContainsKey(item))
                {
                    if (dict[item].ContainsKey(locale))
                    {
                        return dict[item][locale];
                    }
                    else if (dict[item].ContainsKey(""))
                    {
                        return dict[item][""];
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
                throw new KeyNotFoundException();
            }
            set
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, new Dictionary<string, string>());
                }
                if (!dict[item].ContainsKey(locale))
                {
                    dict[item].Add(locale, value);
                }
                else
                {
                    dict[item][locale] = value;
                }
            }
        }
    }
}