using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TwitterApi.Model;

namespace TwitterApi.Data
{
    public interface ITweetRepository
    {
        Task AddAsync(Tweet tweet);

        Task<int> CountAsync();
    }

}
