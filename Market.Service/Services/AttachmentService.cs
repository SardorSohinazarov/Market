using Market.Data.IRepositories;
using Market.Domain.Entities.Common;
using Market.Service.Helpers;
using Market.Service.Interfaces;
using System.Linq.Expressions;

namespace Market.Service.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IUnitOfWork unitOfWork;

        public AttachmentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Attachment> UploadAsync(Stream stream, string fileName)
        {
            // store to wwwroot
            fileName = Guid.NewGuid().ToString("N") + "-" + fileName;
            string filePath = Path.Combine(EnvironmentHelper.AttachmentPath, fileName);

            FileStream fileStream = File.Create(filePath);
            await stream.CopyToAsync(fileStream);

            await fileStream.FlushAsync();
            fileStream.Close();

            //dbga saqlash
            var attachment = await unitOfWork.Attachments.AddAsync(new Attachment()
            {
                Name = Path.GetFileName(filePath),
                Path = Path.Combine(EnvironmentHelper.FilePath,Path.GetFileName(filePath)),
                CreatedAt = DateTime.Now,
            });

            await unitOfWork.SaveChangesAsync();

            return attachment;
        }

        public Task<bool> DeleteAsync(Expression<Func<Attachment, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Attachment> UpdateAsync(long id, Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
