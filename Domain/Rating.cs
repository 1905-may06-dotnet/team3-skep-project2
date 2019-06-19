using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Rating
    {
        public int RID { get; set; }
        public int RatingUid { get; set; }
        public int SurveyTakerUid { get; set; }
        public int Mid { get; set; }
        public int RatingScore { get; set; }
    }
}
