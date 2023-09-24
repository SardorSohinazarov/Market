using Market.Domain.Entities.Common;
using System.Linq.Expressions;

namespace Market.Service.Interfaces
{
    public interface IAttachmentService
    {
        Task<Attachment> UploadAsync(Stream stream, string fileName);
        Task<Attachment> UpdateAsync(long id, Stream stream);
        Task<bool> DeleteAsync(Expression<Func<Attachment, bool>> expression);
    }
}
