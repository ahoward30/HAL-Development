using ITMatching.Models;
using System.Collections.Generic;

namespace ITMatching.ViewModels
{
    public class ChatRoomViewModel
    {
        public Itmuser Client { get; set; }
        public Itmuser Expert { get; set; }
        public HelpRequest HelpRequest { get; set; }
        public Meeting Meeting { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public bool IsExpert { get; set; }
        public string DisplayName
        {
            get
            {
                Itmuser user = IsExpert ? Client : Expert;
                return (user.FirstName + " " + user.LastName).Trim(); ;
            }
        }
        public int CurrentUserId { get => IsExpert ? Expert.Id : Client.Id; }
        public string ErrorMessage { get; set; }
    }
}
