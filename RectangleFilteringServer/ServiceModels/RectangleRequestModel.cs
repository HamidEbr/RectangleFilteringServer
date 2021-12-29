using System.Collections.Generic;

namespace RectangleFilteringServer.ServiceModels
{
    public class RectangleRequestModel
    {
        public RectangleDto Main { get; set; }
        public IEnumerable<RectangleDto> Input { get; set; }
    }
}
