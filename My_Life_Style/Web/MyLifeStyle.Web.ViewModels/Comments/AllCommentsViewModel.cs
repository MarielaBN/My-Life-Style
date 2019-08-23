namespace MyLifeStyle.Web.ViewModels.Comments
{
    using System;

    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;

    public class AllCommentsViewModel : IMapFrom<Comment>
    {
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string UserUserName { get; set; }
    }
}
