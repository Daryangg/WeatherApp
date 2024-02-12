namespace Weather_app.Models
{

    public class ResponseModel
    {
        public bool IsSucces { get; set; }
        public String? Message { get; set; }
        public dynamic? JsonData { get; set; }

        public static ResponseModel Succes(dynamic jsonData)
        {
            return new ResponseModel
            {
                JsonData = jsonData,
                Message = null,
                IsSucces = true
            };
        }

        public static ResponseModel Error(String errorMessage)
        {
            return new ResponseModel
            {
                JsonData = null,
                Message = errorMessage,
                IsSucces = false
            };
        }


    }


}

