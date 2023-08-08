namespace AtencionMedica.WebApi.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public MetaData MetaData { get; set; }

        public ApiResponse(T data)
        {
            Data = data;
        }
    }
}
