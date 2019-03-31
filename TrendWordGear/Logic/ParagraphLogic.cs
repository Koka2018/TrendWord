using System.Collections.Generic;

namespace WordGear.Logic
{
    public static class ParagraphLogic
    {
        /// <summary>
        /// 文の切り出し処理
        /// </summary>
        /// <param name="paragraph">文章</param>
        /// <returns>文リスト</returns>
        public static List<string> SplitParagraph(string paragraph)
        {
            var sentenceList = new List<string>(paragraph.Split('。'));

            return sentenceList;
        }
    }
}
