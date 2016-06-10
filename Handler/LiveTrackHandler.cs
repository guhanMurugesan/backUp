using CleanIndia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleanIndia.Handler
{
    public class LiveTrackHandler
    {
        public List<RenderMapDetail> getVoteDetail()
        {
            IList<VoteDetail> voteDetail = new List<VoteDetail>();
            LocationDetail locationDetail = new LocationDetail() {
                Id = 1,
                LocLalitudeStart = 13.02804601720666,
                LocLalitudeEnd = 80.17689228057861,
                LocLongitudeStart = 13.029739344613546,
                LocLongitudeEnd = 80.17709612846375
            };
                voteDetail.Add(new VoteDetail()
                {
                    Id = 100,
                    GradeValue = 100,
                    LocationDetail = locationDetail
                });
                voteDetail.Add(new VoteDetail()
                {
                    Id = 100,
                    GradeValue = 75,
                    LocationDetail = locationDetail
                });
                voteDetail.Add(new VoteDetail()
                {
                    Id = 100,
                    GradeValue = 75,
                    LocationDetail = locationDetail
                });
                voteDetail.Add(new VoteDetail()
                {
                    Id = 100,
                    GradeValue = 100,
                    LocationDetail = locationDetail
                });

            return getModel(voteDetail);
        }

        private List<RenderMapDetail> getModel(IList<VoteDetail> voteDetail)
        {
            long totalGrade = 0;
            long totalVote = 0;
            List<RenderMapDetail> renderMapDetails = new List<RenderMapDetail>(); 
            var locationDetail = voteDetail[0].LocationDetail;
            foreach(var item in voteDetail){           
                var temp = Convert.ToInt64(item.GradeValue.ToString());
                totalGrade += temp; 
                totalVote++;
            }
            var average = totalGrade / totalVote;
            renderMapDetails.Add( new RenderMapDetail() { 
                ColorIndex = getColorIndex(average),
                LocLalitudeStart = locationDetail.LocLalitudeStart,
                LocLalitudeEnd = locationDetail.LocLalitudeEnd,
                LocLongitudeStart = locationDetail.LocLongitudeStart,
                LocLongitudeEnd = locationDetail.LocLongitudeEnd
            });
            return renderMapDetails;
        }

        private int getColorIndex(long average)
        {
            if (average > 75)
                return 1;
            else if (average > 50)
                return 2;
            else if (average > 25)
                return 3;
            else
                return 4;
        }
    }
}