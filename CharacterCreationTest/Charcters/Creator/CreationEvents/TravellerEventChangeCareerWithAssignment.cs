﻿namespace TravellerWiki.Data.CreationEvents
{
    public class TravellerEventChangeCareerWithAssignment : TravellerEventChangeCareers
    {
        public string Assignment { get; }

        public TravellerEventChangeCareerWithAssignment(string eventText, string newCareerName, string assignment) : base(eventText, newCareerName)
        {
            Assignment = assignment;
        }

        public override string ToString()
        {
            return $"{EventText}. Change Career to: {NewCareerName} - {Assignment}";
        }
    }
}