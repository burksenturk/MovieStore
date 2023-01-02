using MovieStore.Core.Entity;
using MovieStore.Core.Model.Request.Order;
using MovieStore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Abstract
{
    public interface IOrderService
    {
        Task<BaseResponse<Order>> Create(OrderCreateRequest orderCreateRequest);
        Task<BaseResponse<Order>> Update(OrderUpdateRequest orderUpdateRequest);
        Task<BaseResponse<Order>> Delete(int Id);
        Task<BaseResponse<Order>> Get(Expression<Func<Order, bool>> filter);
        Task<BaseResponse<List<Order>>> GetAllByFilter(Expression<Func<Order, bool>> filter);
        Task<BaseResponse<List<Order>>> Getlist();

    }
}
