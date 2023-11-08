using System.IO;
using System.ServiceModel;
using UploadFile.DAL.UploadFileModel;

namespace UploadFile.WCF
{
    [ServiceContract]
    public interface IUploadFileService
    {

        [OperationContract]
        bool SaveFile(UploadFileModel model);

        [OperationContract]
        bool CollectStream(Stream model);

        [OperationContract]
        bool SumChunk();
    }
}
