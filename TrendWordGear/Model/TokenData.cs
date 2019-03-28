namespace TrendWordGear.Model
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
            Adapted,
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
        public string Word { get; private set; } = string.Empty;
        ///<summary> Feature </summary>
        public string Feature { get; private set; } = string.Empty;

        ///<summary> 品詞 </summary>
        public string Type { get; private set; } = string.Empty;
        ///<summary> 品詞細分類1 </summary>
        public string DetailType1 { get; private set; } = string.Empty;
        ///<summary> 品詞細分類2 </summary>
        public string DetailType2 { get; private set; } = string.Empty;
        ///<summary> 品詞細分類3 </summary>
        public string DetailType3 { get; private set; } = string.Empty;
        ///<summary> 活用形 </summary>
        public string AdaptMethod { get; private set; } = string.Empty;
        ///<summary> 活用型 </summary>
        public string AdaptType { get; private set; } = string.Empty;
        ///<summary> 原形 </summary>
        public string BasicWord { get; private set; } = string.Empty;
        ///<summary> 読み </summary>
        public string WayOfRead { get; private set; } = string.Empty;
        ///<summary> 発音 </summary>
        public string Pronunciation { get; private set; } = string.Empty;

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="surface">Surface</param>
        /// <param name="feature">Feature</param>
        public TokenData(string surface, string feature)
        {
            Word = surface;
            Feature = feature;

            ParseFeature(feature);
        }

        #region メソッド

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

                    case EnumMeCabIdx.Adapted:
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

        #endregion
    }
}
