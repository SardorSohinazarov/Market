using Market.Domain.Commons;

namespace Market.Domain.Entities.Common
{
    public class Attachment : Auditable<long>
    {
        /// <summary>
        /// sardor.png
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// images/sardor.png
        /// </summary>
        public string Path { get; set; }
    }
}
