using System;

namespace Actio.Common.Event
{
    public class ActivityCreated : IAuthenticateEvent
    {
        public Guid UserId{ get;  }
        public Guid Id { get;  }    
        public string Category { get;  }    
        public string Name { get;  }
        public string Description { get;  } 
        public DateTime CreatedAt { get;  }

        protected ActivityCreated()
        {
            
        }
        public ActivityCreated(Guid id, Guid userid, string category, string name, string description)
        {
           this.Id = id;
           this.UserId = userid;
           this.Category = category;
           this.Description = description;
           this.Name = name; 
        }
    }
}