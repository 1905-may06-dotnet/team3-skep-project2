using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
namespace Data
{
    public static class Mapper
    {
        public static Domain.BGLocation Map(Data.Models.BGLocation locations) => new Domain.BGLocation
        {
            LID = locations.LID,
            Address = locations.Address,
            City = locations.City,
            LocationName = locations.LocationName,
            State=locations.State,
            MeetingList= locations.MeetingList.ToList(),
            //MeetingRequestList=locations.MeetingRequestList.ToList(),
            //UserList=locations.UserList.ToList()
            
            //MeetingList=locations.MeetingList.Select(x=> new Data.Models.BGLocation(){
            //   Domain.Meeting=x;
            //})
            //list

        };
        public static Data.Models.BGLocation Map(Domain.BGLocation locations) => new Data.Models.BGLocation
        {
            LID = locations.LID,
            Address = locations.Address,
            City = locations.City,
            LocationName = locations.LocationName,
            State = locations.State
            //list

        };


    }
}
