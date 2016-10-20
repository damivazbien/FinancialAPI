using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace FinancialTimes.API.DAO
{
    public class BlobStorageInitializer : IStorageInitializer
    {
        
        private readonly CloudStorageAccount account;
		private readonly string documentsContainerName;

		public BlobStorageInitializer(CloudStorageAccount account, string documentsContainerName)
		{
			if (account == null)
			{
				throw new ArgumentNullException(nameof(account));
			}
			if (string.IsNullOrWhiteSpace(documentsContainerName))
			{
				throw new ArgumentNullException(nameof(documentsContainerName));
			}
			this.account = account;
			this.documentsContainerName = documentsContainerName.ToLowerInvariant();
		}

		public virtual string DocumentsContainerName => documentsContainerName;

		public void Initialize()
		{
			Initialize(BlobContainerPublicAccessType.Off);
		}

		public void Drop()
		{
			CloudBlobClient client = account.CreateCloudBlobClient();
			CloudBlobContainer container = client.GetContainerReference(documentsContainerName);
			container.DeleteIfExistsAsync();
		}

		public void Initialize(BlobContainerPublicAccessType accessType)
		{
			CloudBlobClient blobStorageType = account.CreateCloudBlobClient();
			CloudBlobContainer container = blobStorageType.GetContainerReference(documentsContainerName);
			container.CreateIfNotExistsAsync(accessType, null, null);
		}
	
        public class DocumentStorageInitializer<TDocument> : BlobStorageInitializer where TDocument : class
        {
            public DocumentStorageInitializer(CloudStorageAccount account)
                : base(account, typeof (TDocument).Name.ToLowerInvariant())
            {
            }
        }
    }    
}
