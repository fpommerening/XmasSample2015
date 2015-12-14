using System;
using Nancy;

namespace FP.XmasSample2015.XmasTimer
{
    public class XmasTimerModule : NancyModule
    {
        public XmasTimerModule()
        {
            Get["/"] = _ =>
            {
                var lastChance = new DateTime(2015, 12, 25, 18, 0, 0);

                var tsCountdown = lastChance - DateTime.Now;
                return string.Format("Restzeit zum Einkauf der Geschenke {0} Tage {1} Stunden {2} Minuten.", tsCountdown.Days,
                    tsCountdown.Hours, tsCountdown.Minutes);
            };
        }
    }
}
