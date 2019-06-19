using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Rating
    {
        public int Rid { get; set; }
        public int RatingUid { get; set; }
        public int SurveyTakerUid { get; set; }
        public int Mid { get; set; }
        public int RatingScore { get; set; }

        public virtual Meeting M { get; set; }
        public virtual BGUser RatingU { get; set; }
        public virtual BGUser SurveyTakerU { get; set; }
    }
}
