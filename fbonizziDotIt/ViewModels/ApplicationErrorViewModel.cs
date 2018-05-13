using System;

namespace fbonizziDotIt.ViewModels
{
    public class ApplicationErrorViewModel
    {
        public ApplicationErrorViewModel(
            Exception errorMessage)
        {
            ErrorMessage = errorMessage.ToString();
        }

        public string Title => "Ooops!";
        public string PublicMessage => "Sorry, something went wrong! Try again in a few minutes";
        public string ErrorMessage { get; }
    }
}
