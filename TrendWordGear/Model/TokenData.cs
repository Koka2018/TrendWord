﻿namespace WordGear.Model
{
    public class TokenData
    {
        #region enum

        private enum EnumMeCabIdx
        {
            ///<summary> 品詞 </summary>
            Type = 0,
            ///<summary> 品詞細分類1 </summary>
            DetailType1,
            ///<summary> 品詞細分類2 </summary>
            DetailType2,
            ///<summary> 品詞細分類3 </summary>
            DetailType3,
            ///<summary> 活用形 </summary>
            AdaptMethod,
            ///<summary> 活用型 </summary>
            AdaptType,
            ///<summary> 原形 </summary>
            Basic,
            ///<summary> 読み </summary>
            WayOfRead,
            ///<summary> 発音 </summary>
            Pronunciation,
        }

        #endregion

        #region プロパティ

        ///<summary> Word </summary>
        public string Word { get; private set; }
        ///<summary> Feature </summary>
        public string Feature { get; private set; }

        ///<summary> 品詞 </summary>
        public string Type { get; private set; }
        ///<summary> 品詞細分類1 </summary>
        public string DetailType1 { get; private set; }
        ///<summary> 品詞細分類2 </summary>
        public string DetailType2 { get; private set; }
        ///<summary> 品詞細分類3 </summary>
        public string DetailType3 { get; private set; }
        ///<summary> 活用形 </summary>
        public string AdaptMethod { get; private set; }
        ///<summary> 活用型 </summary>
        public string AdaptType { get; private set; }
        ///<summary> 原形 </summary>
        public string BasicWord { get; private set; }
        ///<summary> 読み </summary>
        public string WayOfRead { get; private set; }
        ///<summary> 発音 </summary>
        public string Pronunciation { get; private set; }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="surface">Surface</param>
        /// <param name="feature">Feature</param>
        public TokenData(string surface, string feature)
        {
            Init();
            Word = surface.Replace("\0", "");
            Feature = feature.Replace("\0", "");

            ParseFeature(feature);
        }

        #region メソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Init()
        {
            Word = string.Empty;
            Feature = string.Empty;

            Type = string.Empty;
            DetailType1 = string.Empty;
            DetailType2 = string.Empty;
            DetailType3 = string.Empty;
            AdaptMethod = string.Empty;
            AdaptType = string.Empty;
            BasicWord = string.Empty;
            WayOfRead = string.Empty;
            Pronunciation = string.Empty;
        }

        /// <summary>
        /// Featureのパース
        /// </summary>
        /// <param name="feature">Feature</param>
        private void ParseFeature(string feature)
        {
            var sp_Feature = feature.Split(',');

            for (int col = 0; col < sp_Feature.Length; col++)
            {
                switch ((EnumMeCabIdx)col)
                {
                    case EnumMeCabIdx.Type:
                        Type = sp_Feature[col];
                        break;

                    case EnumMeCabIdx.DetailType1:
                        DetailType1 = sp_Feature[col];
                        break;

                    case EnumMeCabIdx.DetailType2:
                        DetailType2 = sp_Feature[col];
                        break;

                    case EnumMeCabIdx.DetailType3:
                        DetailType3 = sp_Feature[col];
                        break;

                    case EnumMeCabIdx.AdaptMethod:
                        AdaptMethod = sp_Feature[col];
                        break;

                    case EnumMeCabIdx.AdaptType:
                        AdaptType = sp_Feature[col];
                        break;

                    case EnumMeCabIdx.Basic:
                        BasicWord = sp_Feature[col];
                        break;

                    case EnumMeCabIdx.WayOfRead:
                        WayOfRead = sp_Feature[col];
                        break;

                    case EnumMeCabIdx.Pronunciation:
                        Pronunciation = sp_Feature[col];
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// トークンの結合
        /// </summary>
        /// <param name="left">トークン左</param>
        /// <param name="right">トークン右</param>
        /// <returns>結合トークン</returns>
        public static TokenData operator +(TokenData left, TokenData right)
        {
            var newToken = new TokenData(left.Word + right.Word, left.Feature);

            newToken.Type = MargeLabel(left.Type, right.Type);
            newToken.DetailType1 = MargeLabel(left.DetailType1, right.DetailType1);
            newToken.DetailType2 = MargeLabel(left.DetailType2, right.DetailType2);
            newToken.DetailType3 = MargeLabel(left.DetailType3, right.DetailType3);

            newToken.AdaptMethod = MargeLabel(left.AdaptMethod, right.AdaptMethod);
            newToken.AdaptType = MargeLabel(left.AdaptType, right.AdaptType);
            newToken.BasicWord = left.BasicWord + right.BasicWord;
            newToken.WayOfRead = left.WayOfRead + right.WayOfRead;
            newToken.Pronunciation = left.Pronunciation + right.Pronunciation;

            newToken.Feature = string.Join(",",
                                                newToken.Type,
                                                newToken.DetailType1,
                                                newToken.DetailType2,
                                                newToken.DetailType3,
                                                newToken.AdaptMethod,
                                                newToken.AdaptType,
                                                newToken.BasicWord,
                                                newToken.WayOfRead,
                                                newToken.Pronunciation);

            return newToken;
        }

        /// <summary>
        /// ラベルの結合処理
        /// </summary>
        /// <param name="left">ラベル左</param>
        /// <param name="right">ラベル右</param>
        /// <returns>結合ラベル</returns>
        public static string MargeLabel(string left, string right)
        {
            return (left == right) ? left : string.Format("{0}+{1}", left, right);
        }

        #endregion
    }
}
